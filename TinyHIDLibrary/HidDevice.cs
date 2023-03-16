namespace TinyHIDLibrary
{

    public enum DeviceMode
    {
        NonOverlapped = 0,
        Overlapped = 1
    }

    [Flags]
    public enum ShareMode
    {
        Exclusive = 0,
        ShareRead = NativeMethods.FILE_SHARE_READ,
        ShareWrite = NativeMethods.FILE_SHARE_WRITE
    }


    public enum ReadStatus
    {
        Success = 0,
        WaitTimedOut = 1,
        WaitFail = 2,
        NoDataRead = 3,
        ReadError = 4,
        NotConnected = 5
    }

    public class HidDevice : IHidDevice
    {

        public byte[] InputBuffer { get; private set; }

        public byte[] FeaturesBuffer { get; set; }

        public int ReadTimeOut { get; set; } = 0;
        public int WriteTimeOut { get; set; } = 0;
        

        public string DevicePath { get; }
        public string Description { get; }
        
        public HidDeviceCapabilities Capabilities { get; }
        public HidDeviceAttributes Attributes { get; }



        private DeviceMode _deviceReadMode = DeviceMode.NonOverlapped;

        //private DeviceMode _deviceWriteMode = DeviceMode.NonOverlapped;
        //private ShareMode _deviceShareMode = ShareMode.ShareRead | ShareMode.ShareWrite;


        public IntPtr ReadHandle { get; private set; }
        public IntPtr WriteHandle { get; private set; }


        public bool IsOpen { get; private set; }
        public bool IsConnected => HidDevices.IsConnected(DevicePath);


        internal HidDevice(string devicePath, string description)
        {
            
            DevicePath = devicePath;

            Description = description;

            try
            {

                var hidHandle = OpenDeviceIO(DevicePath, NativeMethods.ACCESS_NONE);

                Attributes = GetDeviceAttributes(hidHandle);

                Capabilities = GetDeviceCapabilities(hidHandle);

                InputBuffer = new byte[Capabilities.InputReportByteLength];

                FeaturesBuffer = new byte[Capabilities.FeatureReportByteLength];

                CloseDeviceIO(hidHandle);

            }
            catch (Exception exception)
            {
                throw new Exception($"Error querying HID device '{devicePath}'.", exception);
            }
        }






        public async Task<ReadStatus> ReadAsync()
        {
            return await Task.Run(() => { return Read(); });
        }


        private ReadStatus Read()
        {

            IntPtr nonManagedBuffer = Marshal.AllocHGlobal(InputBuffer.Length);

            var status = ReadStatus.NoDataRead;
            
            uint bytesRead;
                        

            if (_deviceReadMode == DeviceMode.Overlapped)
            {
                var security = new NativeMethods.SECURITY_ATTRIBUTES();
                var overlapped = new NativeOverlapped();

                // El timeout lo lee de una propiedad. No tiene sentido pasarlo en toda la cadena de llamados
                var overlapTimeout = ReadTimeOut <= 0 ? NativeMethods.WAIT_INFINITE : ReadTimeOut;

                security.lpSecurityDescriptor = IntPtr.Zero;
                security.bInheritHandle = true;
                security.nLength = Marshal.SizeOf(security);

                overlapped.OffsetLow = 0;
                overlapped.OffsetHigh = 0;
                overlapped.EventHandle = NativeMethods.CreateEvent(ref security, Convert.ToInt32(false), Convert.ToInt32(true), string.Empty);

                try
                {
                    var success = NativeMethods.ReadFile(ReadHandle, nonManagedBuffer, (uint)InputBuffer.Length, out bytesRead, ref overlapped);

                    if (success)
                    {
                        status = ReadStatus.Success;
                    }
                    else
                    {
                        var result = NativeMethods.WaitForSingleObject(overlapped.EventHandle, overlapTimeout);

                        switch (result)
                        {
                            case NativeMethods.WAIT_OBJECT_0:
                                status = ReadStatus.Success;
                                NativeMethods.GetOverlappedResult(ReadHandle, ref overlapped, out bytesRead, false);

                                break;
                            
                            case NativeMethods.WAIT_TIMEOUT:
                                status = ReadStatus.WaitTimedOut;
                                break;

                            case NativeMethods.WAIT_FAILED:
                                status = ReadStatus.WaitFail;
                                break;

                            default:
                                status = ReadStatus.NoDataRead;
                                break;
                        }
                    }

                    Marshal.Copy(nonManagedBuffer, InputBuffer, 0, (int)bytesRead);

                }
                catch { status = ReadStatus.ReadError; }
                finally
                {
                    CloseDeviceIO(overlapped.EventHandle);
                    Marshal.FreeHGlobal(nonManagedBuffer);
                }
            }
            else
            {
                try
                {
                    var overlapped = new NativeOverlapped();

                    NativeMethods.ReadFile(ReadHandle, nonManagedBuffer, (uint)InputBuffer.Length, out bytesRead, ref overlapped);
                    
                    status = ReadStatus.Success;
                    
                    Marshal.Copy(nonManagedBuffer, InputBuffer, 0, (int)bytesRead);

                }
                catch { status = ReadStatus.ReadError; }
                finally { Marshal.FreeHGlobal(nonManagedBuffer); }
            }

            return status;
            
        }




        public bool SetFeature()
        {
            
            try
            {
                return NativeMethods.HidD_SetFeature(WriteHandle, FeaturesBuffer, FeaturesBuffer.Length);
            }
            catch (Exception exception)
            {
                throw new Exception($"Error accessing HID device HidD_SetFeature '{DevicePath}'.", exception);
            }

        }


        private static HidDeviceAttributes GetDeviceAttributes(IntPtr hidHandle)
        {
            var deviceAttributes = default(NativeMethods.HIDD_ATTRIBUTES);
            
            deviceAttributes.Size = Marshal.SizeOf(deviceAttributes);
           
            bool success = NativeMethods.HidD_GetAttributes(hidHandle, ref deviceAttributes);

            if (!success) throw new Exception("GetDeviceAttributes failed");

            return new HidDeviceAttributes(deviceAttributes);
        }


        private static HidDeviceCapabilities GetDeviceCapabilities(IntPtr hidHandle)
        {
            var capabilities = default(NativeMethods.HIDP_CAPS);

            var preparsedDataPointer = default(IntPtr);

            if (NativeMethods.HidD_GetPreparsedData(hidHandle, ref preparsedDataPointer))
            {
                int c = NativeMethods.HidP_GetCaps(preparsedDataPointer, ref capabilities);

                // check c.. ? >0 

                NativeMethods.HidD_FreePreparsedData(preparsedDataPointer);
            }

            return new HidDeviceCapabilities(capabilities);
        }
        






        //public void Dispose()
        //{
        //    if (MonitorDeviceEvents) MonitorDeviceEvents = false;
        //    if (IsOpen) CloseDevice();
        //}


        /// <summary>
        /// For debug only
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"VendorId = {Attributes.VendorHexId}, ProductId = {Attributes.ProductHexId}, DevicePath = {DevicePath}";
        }


        #region OPEN / CLOSE


        public void OpenDevice()
        {
            OpenDevice(DeviceMode.NonOverlapped, DeviceMode.NonOverlapped, ShareMode.ShareRead | ShareMode.ShareWrite);
        }

        public void OpenDevice(DeviceMode readMode, DeviceMode writeMode, ShareMode shareMode)
        {

            if (IsOpen) return;

            _deviceReadMode = readMode;
            //_deviceWriteMode = writeMode;
            //_deviceShareMode = shareMode;

            try
            {
                ReadHandle = OpenDeviceIO(DevicePath, readMode, NativeMethods.GENERIC_READ, shareMode);

                WriteHandle = OpenDeviceIO(DevicePath, writeMode, NativeMethods.GENERIC_WRITE, shareMode);



            }
            catch (Exception exception)
            {
                IsOpen = false;

                throw new Exception("Error opening HID device.", exception);
            }

            IsOpen = ReadHandle != IntPtr.Zero && WriteHandle != IntPtr.Zero;

            //IsOpen = ReadHandle.ToInt32() != NativeMethods.INVALID_HANDLE_VALUE &&
            //         WriteHandle.ToInt32() != NativeMethods.INVALID_HANDLE_VALUE;
        }


        private static IntPtr OpenDeviceIO(string devicePath, uint deviceAccess)
        {
            return OpenDeviceIO(devicePath, DeviceMode.NonOverlapped, deviceAccess, ShareMode.ShareRead | ShareMode.ShareWrite);
        }

        private static IntPtr OpenDeviceIO(string devicePath, DeviceMode deviceMode, uint deviceAccess, ShareMode shareMode)
        {
            var security = new NativeMethods.SECURITY_ATTRIBUTES();
            var flags = 0;

            if (deviceMode == DeviceMode.Overlapped) flags = NativeMethods.FILE_FLAG_OVERLAPPED;

            security.lpSecurityDescriptor = IntPtr.Zero;
            security.bInheritHandle = true;
            security.nLength = Marshal.SizeOf(security);

            return NativeMethods.CreateFile(devicePath, deviceAccess, (int)shareMode, ref security, NativeMethods.OPEN_EXISTING, flags, hTemplateFile: IntPtr.Zero);
        }


        public void CloseDevice()
        {
            if (!IsOpen) return;
            CloseDeviceIO(ReadHandle);
            CloseDeviceIO(WriteHandle);
            IsOpen = false;
        }


        private static void CloseDeviceIO(IntPtr handle)
        {

            //if (Environment.OSVersion.Version.Major > 5)
            //{
            //    NativeMethods.CancelIoEx(handle, IntPtr.Zero);
            //}

            NativeMethods.CancelIoEx(handle, IntPtr.Zero);
            NativeMethods.CloseHandle(handle);
        }


        #endregion

    }
}
