namespace TinyHIDLibrary
{


    public interface IHidDevice
    {

        IntPtr ReadHandle { get; }
        IntPtr WriteHandle { get; }
        bool IsOpen { get; }
        bool IsConnected { get; }
        string Description { get; }
        HidDeviceCapabilities Capabilities { get; }
        HidDeviceAttributes Attributes { get;  }
        string DevicePath { get; }


        void OpenDevice();

        void OpenDevice(DeviceMode readMode, DeviceMode writeMode, ShareMode shareMode);

        Task<ReadStatus> ReadAsync();

        void CloseDevice();
        
    }
}
