using MauiSoft.SRP.FsuipcWrapper;
using MauiSoft.SRP.MyExtensions;
using TinyHIDLibrary;

namespace MauiSoft.SRP.SaitekLibrary
{

    /// <summary>
    /// No need adicional parameters
    /// </summary>
    public delegate void Handler();

    public sealed class RadioPanel : IDisposable
    {


#if DEBUG // *************** FOR DEBUG ONLY (when fsuipc not running) ***********
        readonly Random rnd; // random value in display unit.
#endif

        readonly HidDevice? Device; Task<ReadStatus>? Status;


        #region Events

        public event Handler? EnconderB1R; // Enconder Big1 Right
        public event Handler? EnconderB1L; // Enconder Big1 Left

        public event Handler? EnconderS1R; // Enconder Small1 Right
        public event Handler? EnconderS1L; // Enconder Small1 Left

        public event Handler? EnconderB2R; // Enconder Big2 Right
        public event Handler? EnconderB2L; // Enconder Big2 Left

        public event Handler? EnconderS2R; // Enconder Small2 Right
        public event Handler? EnconderS2L; // Enconder Small2 Left

        public event Handler? Buttons1; // Botón de arriba
        public event Handler? Buttons2; // Botón de abajo

        #endregion


        public int[] Switches = new int[2];

        const int DIGITOS = 5;
        const int CLEAR = 255;
        const int NEGATIVE_SIGN = 230;
        const int DECIMAL_POINT = 220;


        public RadioPanel()
        {

            rnd = new Random(); // FOR TESTING ONLY

            Device = HidDevices.GetDevice(0x06a3, 0x0d05);

            Device?.OpenDevice();

            if (Device == null) return;

            Debug.WriteLine($"Saitek: {Device} FeaturesBuffer: {Device.FeaturesBuffer.Length}");

            Status = Task.Run(async () => await Device.ReadAsync());

            Status.ContinueWith(t => OnReport());


        }



        /// <summary>
        /// READ ENCONDERS/BUTTONS
        /// </summary>
        /// <param name = "report" ></ param >
        private void OnReport()
        {
            if (Device == null) return;

            byte encoders = Device.InputBuffer[3];

            if (encoders.IsBitSet(0)) EnconderS1R?.Invoke();
            if (encoders.IsBitSet(1)) EnconderS1L?.Invoke();

            if (encoders.IsBitSet(2)) EnconderB1R?.Invoke();
            if (encoders.IsBitSet(3)) EnconderB1L?.Invoke();

            if (encoders.IsBitSet(4)) EnconderS2R?.Invoke();
            if (encoders.IsBitSet(5)) EnconderS2L?.Invoke();

            if (encoders.IsBitSet(6)) EnconderB2R?.Invoke();
            if (encoders.IsBitSet(7)) EnconderB2L?.Invoke();


            // Buttons!
            byte buttons = Device.InputBuffer[2];
            if (buttons.IsBitSet(6)) Buttons1?.Invoke();
            if (buttons.IsBitSet(7)) Buttons2?.Invoke();


            byte switch1 = Device.InputBuffer[1];

            if (switch1 >= 128) switch1 -= 128;

            Switches[0] = (int)Math.Log(switch1, 2); // INT [0 - 6]


            byte switch2 = Device.InputBuffer[2];

            if (switch2 >= 128) switch2 -= 128;
            if (switch2 >= 64) switch2 -= 64;

            switch2 = (byte)(switch2 << 1);

            if (switch2 == 0) switch2 = 1;

            Switches[1] = (int)Math.Log(switch2, 2); // INT [0 - 6]


            Status = Task.Run(async () => await Device.ReadAsync());

            Status.ContinueWith(t => OnReport());

        }



        /// <summary>
        /// WRITE DISPLAY ANYCHAR
        /// </summary>
        /// <param name="value"></param>
        public void SetAll(byte value)
        {

            //Device.FeaturesBuffer[0] = 0x00;
            //Device.FeaturesBuffer[21] = 0x00;
            //Device.FeaturesBuffer[22] = 0x00;

            if (Device == null) return;

            for (int i = 1; i <= 20; i++) Device.FeaturesBuffer[i] = value;

            Device?.SetFeature();

        }


#if DEBUG

        /// <summary>
        /// ONLY FOR DEBUG
        /// </summary>
        public void UpdateDebug()
        {
            if (Device == null) return;

            for (int pos = 0; pos < 4; pos++)
            {

                int x = rnd.Next(0, 100000);

                string str = x.ToString("00000");

                for (int i = 0; i < DIGITOS; i++)
                    Device.FeaturesBuffer[pos * DIGITOS + i + 1] = (byte)str[i];

            }

            Device?.SetFeature();

        }
#endif


        public void Update()
        {

            for (int i = 0; i <= 3; i++)
                SetDisplay(i);

            Device?.SetFeature();
        }


        private void SetDisplay(int pos)
        {

            if (Device == null) return;

            // LIMPIAR DISPLAY (POS)
            for (int i = 1; i <= DIGITOS; i++)
                Device.FeaturesBuffer[pos * DIGITOS + i] = CLEAR;


            int sw = pos <= 1 ? 0 : 1; // SWITCH

            int index = Switches[sw]; // 0 - 6 (posicion del switch)


            string[]? data = null;

            ConfigItem? ConfigItem = Config.Instance.Get(index);

            if (pos == 0 || pos == 2) data = ConfigItem?.DSL; // DISPLAY LEFT

            if (pos == 1 || pos == 3) data = ConfigItem?.DSR; // DISPLAY RIGHT


            if (data == null) return; // RETORNA Y QUEDA LIMPIO!


            var item = OffsetList.Instance.Dictionary[data[0]];

            float? value = OffsetList.Instance.GetValue(data[0]);

            if (value == null) return; // RETORNA Y QUEDA LIMPIO!


            if (item.Frecuency != null && (bool)item.Frecuency)
            {
                value = TransformFrecuency(value);
            }
            else
            {
                value = (float)Math.Round((double)value, 2);
            }


            // FORMAT STRING

            string? str = data[1].IsNullEmptyOrSpace()
                ? (value?.ToString(CultureInfo.InvariantCulture))
                : (value?.ToString(data[1], CultureInfo.InvariantCulture));


            if (str == null) return; // RETORNA Y QUEDA LIMPIO!


            // Caso: Vertical Speed en GROUND
            // Negativo que no tienen que mostrarse (-16960)
            if (value == -16960) return;



            int ini = pos * DIGITOS + 1;

            int posdecimal = 0;

            int posicion = 4;

            for (int i = str.Length - 1; i >= 0; i--)
            {

                switch ((byte)str[i])
                {

                    case 45:
                        Device.FeaturesBuffer[ini + posicion] = NEGATIVE_SIGN;
                        break;

                    case 46:
                        posdecimal = posicion;
                        break;

                    default:
                        Device.FeaturesBuffer[ini + posicion] = (byte)str[i];
                        posicion--;
                        break;

                }

            }

            if (posdecimal > 0)
                Device.FeaturesBuffer[ini + posdecimal] += 160; // Agregar punto decimal


            byte? led = OffsetList.Instance.GetValue(data[2]);

            // Agrego un punto al final como indicador de "luz"
            if (led != null && led == 1)
            {
                if (Device.FeaturesBuffer[ini + 4] == CLEAR)
                {
                    Device.FeaturesBuffer[ini + 4] = DECIMAL_POINT;
                }
                else
                {
                    Device.FeaturesBuffer[ini + 4] += 160;
                }
            }

        }


        private static float? TransformFrecuency(float? value)
        {

            int entero = Convert.ToInt32(value);

            return Convert.ToSingle("1" + entero.ToString("X4")) / 100f;
        }


        #region Liberar Recursos

        public void Dispose()
        {
            Device?.CloseDevice();

            GC.SuppressFinalize(this);
        }

        //private void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            CloseDevice();
        //        }

        //        disposed = true;
        //    }
        //}


        #endregion


    }
}
