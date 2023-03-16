using System.Diagnostics;
using MauiSoft.SRP.MyExtensions;
using TinyHIDLibrary;

namespace MauiSoft.SRP.McpLibrary
{

    public delegate void Handler();

    public sealed class ROF : IDisposable
    {

        readonly HidDevice? Player00; Task<ReadStatus>? Status00;
        readonly HidDevice? Player01; Task<ReadStatus>? Status01;
        readonly HidDevice? Player02; Task<ReadStatus>? Status02;
        readonly HidDevice? Player03; Task<ReadStatus>? Status03;


        #region Events

        // ENCODERS

        public event Handler? CRSL_INC;
        public event Handler? CRSL_DEC;

        public event Handler? SPEED_INC;
        public event Handler? SPEED_DEC;

        public event Handler? HEADING_INC;
        public event Handler? HEADING_DEC;

        public event Handler? ALTITUDE_INC;
        public event Handler? ALTITUDE_DEC;

        public event Handler? VERSPEED_INC;
        public event Handler? VERSPEED_DEC;

        public event Handler? CRSR_INC;
        public event Handler? CRSR_DEC;


        // BUTTONS

        public event Handler? AT_BUTTON;
        public event Handler? FD_BUTTON;

        public event Handler? SPD_BUTTON;

        public event Handler? VNAV_BUTTON;
        public event Handler? LVL_CHG_BUTTON;

        public event Handler? HDGSEL_BUTTON;

        public event Handler? LNAV_BUTTON;
        public event Handler? APP_BUTTON;

        public event Handler? ALTHLD_BUTTON;
        public event Handler? VS_BUTTON;

        public event Handler? CMD_BUTTON;
        public event Handler? CWS_BUTTON;


        #endregion


        public ROF()
        {

            const int VendorId = 0xffff; // ROF
            const int ProductId = 0xb004;


            // Se puede agregar esta sobrecarga a HidDevices
            Player00 = HidDevices.Enumerate(VendorId, ProductId).Where(dev => dev.DevicePath.Contains("mi_00")).First();
            Player00?.OpenDevice();

            Player01 = HidDevices.Enumerate(VendorId, ProductId).Where(dev => dev.DevicePath.Contains("mi_01")).First();
            Player01?.OpenDevice();

            Player02 = HidDevices.Enumerate(VendorId, ProductId).Where(dev => dev.DevicePath.Contains("mi_02")).First();
            Player02?.OpenDevice();

            Player03 = HidDevices.Enumerate(VendorId, ProductId).Where(dev => dev.DevicePath.Contains("mi_03")).First();
            Player03?.OpenDevice();

            if (Player00 == null | Player01 == null | Player02 == null | Player03 == null) return;

            Debug.WriteLine($"ROF 1: {Player00}");
            Debug.WriteLine($"ROF 2: {Player01}");
            Debug.WriteLine($"ROF 3: {Player02}");
            Debug.WriteLine($"ROF 4: {Player03}");


            Status00 = Task.Run(async () => await Player00.ReadAsync());
            Status00.ContinueWith(t => OnReportPlayer00());

            Status01 = Task.Run(async () => await Player01.ReadAsync());
            Status01.ContinueWith(t => OnReportPlayer01());

            Status02 = Task.Run(async () => await Player02.ReadAsync());
            Status02.ContinueWith(t => OnReportPlayer02());

            Status03 = Task.Run(async () => await Player03.ReadAsync());
            Status03.ContinueWith(t => OnReportPlayer03());

        }



        /// <summary>
        /// READ ENCONDERS/BUTTONS
        /// </summary>
        /// <param name="report"></param>
        private void OnReportPlayer00()
        {

            // Check integrity to read the buffer safely
            if (Player00 == null || Status00?.Result != ReadStatus.Success) return;


            if (Player00.InputBuffer[7].IsBitSet(2)) CRSL_INC?.Invoke();
            if (Player00.InputBuffer[7].IsBitSet(3)) CRSL_DEC?.Invoke();

            if (Player00.InputBuffer[7].IsBitSet(0)) SPEED_INC?.Invoke();
            if (Player00.InputBuffer[7].IsBitSet(1)) SPEED_DEC?.Invoke();

            if (Player00.InputBuffer[6].IsBitSet(6)) HEADING_INC?.Invoke();
            if (Player00.InputBuffer[6].IsBitSet(7)) HEADING_DEC?.Invoke();

            if (Player00.InputBuffer[6].IsBitSet(4)) ALTITUDE_INC?.Invoke();
            if (Player00.InputBuffer[6].IsBitSet(5)) ALTITUDE_DEC?.Invoke();

            if (Player00.InputBuffer[6].IsBitSet(3)) VERSPEED_INC?.Invoke(); // DERECHA   --> UP
            if (Player00.InputBuffer[6].IsBitSet(2)) VERSPEED_DEC?.Invoke(); // IZQUIERDA --> DOWN

            if (Player00.InputBuffer[6].IsBitSet(0)) CRSR_INC?.Invoke();
            if (Player00.InputBuffer[6].IsBitSet(1)) CRSR_DEC?.Invoke();

            if (Player00.InputBuffer[9].IsBitSet(4)) CWS_BUTTON?.Invoke();

            if (Player00.InputBuffer[9].IsBitSet(5)) APP_BUTTON?.Invoke();


            Status00 = Task.Run(async () => await Player00.ReadAsync());

            Status00.ContinueWith(t => OnReportPlayer00());

        }

        private void OnReportPlayer01()
        {

            // Check integrity to read the buffer safely
            if (Player01 == null || Status01?.Result != ReadStatus.Success) return;


            if (Player01.InputBuffer[6].IsBitSet(0)) CMD_BUTTON?.Invoke();

            if (Player01.InputBuffer[9].IsBitSet(7)) LNAV_BUTTON?.Invoke();

            if (Player01.InputBuffer[9].IsBitSet(6)) ALTHLD_BUTTON?.Invoke();

            if (Player01.InputBuffer[9].IsBitSet(5)) VS_BUTTON?.Invoke();


            //// CRS2  9  -- 4   


            Status01 = Task.Run(async () => await Player01.ReadAsync());

            Status01.ContinueWith(t => OnReportPlayer01());

        }

        private void OnReportPlayer02()
        {

            // Check integrity to read the buffer safely
            if (Player02 == null || Status02?.Result != ReadStatus.Success) return;


            if (Player02.InputBuffer[7].IsBitSet(3)) FD_BUTTON?.Invoke();

            if (Player02.InputBuffer[7].IsBitSet(2)) LVL_CHG_BUTTON?.Invoke();


            Status02 = Task.Run(async () => await Player02.ReadAsync());
            Status02.ContinueWith(t => OnReportPlayer02());

        }

        private void OnReportPlayer03()
        {

            // Check integrity to read the buffer safely
            if (Player03 == null || Status03?.Result != ReadStatus.Success) return;


            if (Player03.InputBuffer[7].IsBitSet(2)) AT_BUTTON?.Invoke();

            if (Player03.InputBuffer[7].IsBitSet(1)) SPD_BUTTON?.Invoke();

            if (Player03.InputBuffer[7].IsBitSet(0)) VNAV_BUTTON?.Invoke();

            if (Player03.InputBuffer[6].IsBitSet(7)) HDGSEL_BUTTON?.Invoke();


            Status03 = Task.Run(async () => await Player03.ReadAsync());

            Status03.ContinueWith(t => OnReportPlayer03());

        }



        #region Liberar Recursos

        public void Dispose()
        {

            Player00?.CloseDevice();
            Player01?.CloseDevice();
            Player02?.CloseDevice();
            Player03?.CloseDevice();

            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
