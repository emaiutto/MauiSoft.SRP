using System.Diagnostics;
using MauiSoft.SRP.MyExtensions;
using TinyHIDLibrary;

namespace MauiSoft.SRP.LandingGearLibrary
{

    public delegate void Handler();

    public sealed class LandingGearDevice : IDisposable
    {

        int landingstate; // Iniciar el SIMU siempre con la palanca DOWN o leer el estado inicial.


        readonly HidDevice? Device; Task<ReadStatus>? Status;


        public event Handler? LandingGearUp;
        public event Handler? LandingGearDown;

        public event Handler? FlapsUp;
        public event Handler? FlapsDown;


        public LandingGearDevice()
        {

            Device = HidDevices.GetDevice(0x045e, 0x003c);

            if (Device == null) return;

            Device?.OpenDevice();

            Debug.WriteLineIf(condition: Device.IsOpen, $"LandingGearDevice: {Device}");

            landingstate = -1; // Estado inicial

            // Start reading...

            Status = Task.Run(async () => await Device.ReadAsync());

            Status.ContinueWith(t => OnReport());

        }

        private void OnReport()
        {

            // Check integrity to read the buffer safely
            if (Device == null || Status?.Result != ReadStatus.Success) return;

            if (Device.InputBuffer[4].IsBitSet(0)) FlapsUp?.Invoke();
            if (Device.InputBuffer[4].IsBitSet(1)) FlapsDown?.Invoke();


            if (IsValidState(-1) && Device.InputBuffer[4].IsBitSet(3))
            {
                LandingGearDown?.Invoke();
            }

            if (IsValidState(1) && Device.InputBuffer[4].IsBitSet(2))
            {
                LandingGearUp?.Invoke();
            }


            // continue reading...
            Status = Task.Run(async () => await Device.ReadAsync());

            Status.ContinueWith(t => OnReport());

        }

        private bool IsValidState(int transicion)
        {
            // CONCLUSION: Es válido cuando el estado actual es diferente al estado que quiere transicionar.

            //  0 -> +1  UP
            //  0 -> -1  DOWN

            // -1 -> +1  UP
            // +1 -> -1  DOWN


            bool valid = true;

            if (transicion == -1 && landingstate == -1) valid = false;

            if (transicion == 1 && landingstate == 1) valid = false;

            //bool valid = landingstate != transicion; // Equivale a SUMA == 0;

            if (valid) landingstate = transicion;

            return valid;
        }



        #region Liberar Recursos

        public void Dispose()
        {
            Device?.CloseDevice();

            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
