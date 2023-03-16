using System.IO.Ports;
using MauiSoft.SRP.Commands;
using MauiSoft.SRP.LandingGearLibrary;
using MauiSoft.SRP.Offsets;
using MauiSoft.SRP.SaitekLibrary;
using MauiSoft.SRP.McpLibrary;

namespace MauiSoft.SRP
{
    public partial class PMDG : FrmTemplate
    {

        static SaitekRadioPanel _Saitek;

        static LandingGearDevice landingGear;

        static ROF MCP;

        static SerialPort _Arduino;


        // 10000000L ticks -> 1 segundo

        //TimeSpan interval2 = new TimeSpan(10000000 / 10); // 1 decima de segundo (muy sensible)

        TimeSpan interval = new TimeSpan(10000000 / 20); // Menos sensible

        static DateTime LastTime = DateTime.Now;



        public PMDG()
        {

            InitializeComponent();


            _Arduino = new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One);
            _Arduino.Open();
            _Arduino.DataReceived += Arduino_DataReceived;



            _Saitek = new SaitekRadioPanel();

            _Saitek.SetAll(220); // 230 -  220 .

            _Saitek.EnconderB1R += Saitek_EnconderB1R;
            _Saitek.EnconderB1L += Saitek_EnconderB1L;

            _Saitek.EnconderS1R += Saitek_EnconderS1R;
            _Saitek.EnconderS1L += Saitek_EnconderS1L;

            _Saitek.EnconderB2R += Saitek_EnconderB2R;
            _Saitek.EnconderB2L += Saitek_EnconderB2L;

            _Saitek.EnconderS2R += Saitek_EnconderS2R;
            _Saitek.EnconderS2L += Saitek_EnconderS2L;

            _Saitek.Buttons1 += _Saitek_Buttons1;
            _Saitek.Buttons2 += _Saitek_Buttons2;



            MCP = new ROF();

            MCP.CRSL_INC += MCP_CRSL_INC;
            MCP.CRSL_DEC += MCP_CRSL_DEC;

            MCP.SPEED_INC += MCP_SPEED_INC;
            MCP.SPEED_DEC += MCP_SPEED_DEC;

            MCP.HEADING_INC += MCP_HEADING_INC;
            MCP.HEADING_DEC += MCP_HEADING_DEC;

            MCP.ALTITUDE_INC += MCP_ALTITUDE_INC;
            MCP.ALTITUDE_DEC += MCP_ALTITUDE_DEC;

            MCP.VERSPEED_INC += MCP_VERSPEED_INC;
            MCP.VERSPEED_DEC += MCP_VERSPEED_DEC;

            MCP.CRSR_INC += MCP_CRSR_INC;
            MCP.CRSR_DEC += MCP_CRSR_DEC;



            MCP.AT_BUTTON += MCP_AT_BUTTON;
            MCP.FD_BUTTON += MCP_FD_BUTTON;

            MCP.SPD_BUTTON += MCP_SPD_BUTTON;

            MCP.VNAV_BUTTON += MCP_VNAV_BUTTON;
            MCP.LVL_CHG_BUTTON += MCP_LVL_CHG_BUTTON;

            MCP.HDGSEL_BUTTON += MCP_HDGSEL_BUTTON;

            MCP.LNAV_BUTTON += MCP_LNAV_BUTTON;
            MCP.APP_BUTTON += MCP_APP_BUTTON;

            MCP.ALTHLD_BUTTON += MCP_ALTHLD_BUTTON;
            MCP.VS_BUTTON += MCP_VS_BUTTON;

            MCP.CMD_BUTTON += MCP_CMD_BUTTON;
            MCP.CWS_BUTTON += MCP_CWS_BUTTON;




            landingGear = new LandingGearDevice();
           
            landingGear.LandingGearDown += LandingGear_LandingGearDown;
            landingGear.LandingGearUp += LandingGear_LandingGearUp;
            
            landingGear.FlapsUp += LandingGear_FlapsUp;
            landingGear.FlapsDown += LandingGear_FlapsDown;



            // Preguntando por COUNT para que el constructor (SINGLETON)
            // precargue el diccionario antes que comience el simulador

            ThreadSafe(() => { LabelOffsetsLoad.Text = $"Offsets: {OffsetList.Instance.Count}"; });

            ThreadSafe(() => { LabelCommands.Text = $"Commands: {FSUIPCHelper.Instance.Count}"; });


            //FSUIPCHelper.Instance.Open();

            Thread.Sleep(1000);

            if (FSUIPCHelper.FSUIPC_Running)
            {
                ThreadSafe(() => { LabelFSUIPCRunning.Text = $"FSUIPC Running..."; });

                timer1.Enabled = true;
                timer1.Start();

                TimerSaitekUpdate.Enabled = true;
                TimerSaitekUpdate.Start();
            }
            else
            {

                ThreadSafe(() => { LabelFSUIPCRunning.Text = $"FSUIPC Not Running!"; });

                timer1.Enabled = false;
                timer1.Stop();

                TimerSaitekUpdate.Enabled = false;
                TimerSaitekUpdate.Stop();

            }

        }


        #region LandingGear Events
        

        private void LandingGear_LandingGearUp()
        {
            FSUIPCHelper.Instance.Execute("LandingGearUp");
        }

        private void LandingGear_LandingGearDown()
        {
            FSUIPCHelper.Instance.Execute("LandingGearDown");
        }


        private void LandingGear_FlapsUp()
        {
            FSUIPCHelper.Instance.Execute("FlapsUp");
        }

        private void LandingGear_FlapsDown()
        {
            FSUIPCHelper.Instance.Execute("FlapsDown");
        }

        #endregion


        #region MCP EVENTS

        #region ROTARYS ENCODERS


        private void MCP_CRSL_INC()
        {
            FSUIPCHelper.Instance.Execute("MCP_CRSL_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_CRSL_INC");
                FSUIPCHelper.Instance.Execute("MCP_CRSL_INC");
            }

            FSUIPCHelper.Instance.Execute("MCP_CRSL_REL");

            LastTime = DateTime.Now;
        }
        private void MCP_CRSL_DEC()
        {
            FSUIPCHelper.Instance.Execute("MCP_CRSL_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_CRSL_DEC");
                FSUIPCHelper.Instance.Execute("MCP_CRSL_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_CRSL_REL");

            LastTime = DateTime.Now;
        }

        private void MCP_SPEED_INC()
        {
            FSUIPCHelper.Instance.Execute("MCP_SPEED_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_SPEED_INC");
                FSUIPCHelper.Instance.Execute("MCP_SPEED_INC");
            }

            FSUIPCHelper.Instance.Execute("MCP_SPEED_REL");

            LastTime = DateTime.Now;

        }
        private void MCP_SPEED_DEC()
        {
            FSUIPCHelper.Instance.Execute("MCP_SPEED_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_SPEED_DEC");
                FSUIPCHelper.Instance.Execute("MCP_SPEED_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_SPEED_REL");

            LastTime = DateTime.Now;

        }

        private void MCP_HEADING_INC()
        {
            FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");
                FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");
                //FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");
            }

            FSUIPCHelper.Instance.Execute("MCP_HEADING_REL");

            LastTime = DateTime.Now;
        }
        private void MCP_HEADING_DEC()
        {
            FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");
                FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");
                //FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_HEADING_REL");

            LastTime = DateTime.Now;
        }

        private void MCP_ALTITUDE_INC()
        {
            FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_INC");
                FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_INC");
            }

            FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_REL");

            LastTime = DateTime.Now;
        }
        private void MCP_ALTITUDE_DEC()
        {
            FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_DEC");
                FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_ALTITUDE_REL");

            LastTime = DateTime.Now;
        }

        private void MCP_VERSPEED_INC()
        {
            FSUIPCHelper.Instance.Execute("MCP_VERSPEED_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_VERSPEED_INC");
                FSUIPCHelper.Instance.Execute("MCP_VERSPEED_INC");
            }

            FSUIPCHelper.Instance.Execute("MCP_VERSPEED_REL");

            LastTime = DateTime.Now;
        }
        private void MCP_VERSPEED_DEC()
        {
            FSUIPCHelper.Instance.Execute("MCP_VERSPEED_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_VERSPEED_DEC");
                FSUIPCHelper.Instance.Execute("MCP_VERSPEED_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_VERSPEED_REL");

            LastTime = DateTime.Now;
        }

        private void MCP_CRSR_INC()
        {
            FSUIPCHelper.Instance.Execute("MCP_CRSR_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_CRSR_INC");
                FSUIPCHelper.Instance.Execute("MCP_CRSR_INC");
            }

            FSUIPCHelper.Instance.Execute("MCP_CRSR_REL");

            LastTime = DateTime.Now;
        }
        private void MCP_CRSR_DEC()
        {
            FSUIPCHelper.Instance.Execute("MCP_CRSR_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_CRSR_DEC");
                FSUIPCHelper.Instance.Execute("MCP_CRSR_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_CRSR_REL");

            LastTime = DateTime.Now;
        }

        #endregion


        #region BUTTONS

        private void MCP_AT_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_AT_BUTTON");
        }
        private void MCP_FD_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_FD_BUTTON");
        }

        private void MCP_SPD_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_SPD_BUTTON");
        }

        private void MCP_VNAV_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_VNAV_BUTTON");
        }
        private void MCP_LVL_CHG_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_LVL_CHG_BUTTON");
        }

        private void MCP_HDGSEL_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_HDGSEL_BUTTON");

        }


        private void MCP_LNAV_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_LNAV_BUTTON");
        }
        private void MCP_APP_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_APP_BUTTON");
        }


        private void MCP_ALTHLD_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_ALTHLD_BUTTON");
        }
        private void MCP_VS_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_VS_BUTTON");
        }


        private void MCP_CMD_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_CMD_BUTTON");
        }
        private void MCP_CWS_BUTTON()
        {
            FSUIPCHelper.Instance.Execute("MCP_CWS_BUTTON");
        }


        #endregion

        #endregion


        #region SAITEK EVENTS

        private void Saitek_EnconderB1R()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[0]).BRR;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Saitek_EnconderB1L()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[0]).BRL;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Saitek_EnconderS1R()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[0]).SRR;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Saitek_EnconderS1L()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[0]).SRL;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Saitek_EnconderB2R()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[1]).BRR;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Saitek_EnconderB2L()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[1]).BRL;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Saitek_EnconderS2R()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[1]).SRR;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Saitek_EnconderS2L()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[1]).SRL;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _Saitek_Buttons1()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[0]).BTN;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _Saitek_Buttons2()
        {
            try
            {
                var cmds = SaitekConfig.Instance.Get(_Saitek.Switches[1]).BTN;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        #endregion



        /// <summary>
        /// TRIM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var spL = (SerialPort)sender;

                var ln = spL.ReadLine();

                //Console.WriteLine(ln);

                switch (ln)
                {

                    case "1R\r":

                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
                        break;

                    case "1L\r":

                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
                        FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
                        break;
                }
            }
            catch
            {
                // Console.WriteLine(ln);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            // Separar en grupo de diferente frecuencia de actualizacion

            //FSUIPCHelper.Instance.Update(); // IMPORTANTE ACTUALIZAR

            foreach (var display in Display.Instance.Dictionary)
            {
                ucVirtual panel = FindControl(display.Key);

                panel?.Update(display.Value);
            }

        }


        #region CLOSE APP

        private void SRPMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            // DETENER TIMERS
            timer1.Stop();
            timer1.Enabled = false;

            TimerSaitekUpdate.Stop();
            TimerSaitekUpdate.Enabled = false;

            
            // CLEAR SAITEK DISPLAY
            _Saitek.SetAll(255);


            // LIBERAR DEVICES
            _Saitek.Dispose();
            MCP.Dispose();
            landingGear.Dispose();



            
        }

        private void SRPMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }



        #endregion

        private void TimerSaitekUpdate_Tick(object sender, EventArgs e)
        {

            try
            {
                _Saitek.Update();
            }
            catch (Exception ex)
            {
                TimerSaitekUpdate.Stop();

                MessageBox.Show(ex.ToString());

                Console.WriteLine (ex.ToString());
            }
            
        }
    }
}
