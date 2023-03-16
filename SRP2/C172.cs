using System.IO.Ports;
using MauiSoft.SRP.Commands;
using MauiSoft.SRP.Offsets;
using MauiSoft.SRP.SaitekLibrary;

namespace MauiSoft.SRP
{
    public partial class C172 : FrmTemplate
    {

        static SaitekRadioPanel? _Saitek;

        static SerialPort _Arduino;

        public C172()
        {

            InitializeComponent();

            
            _Arduino = new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One);

            _Arduino.Open();

            _Arduino.DataReceived += Arduino_DataReceived;


            
            _Saitek = new SaitekRadioPanel(); 

            _Saitek.SetAll(220); // 230 -  220 .



            // Preguntando por COUNT para que el constructor (SINGLETON)
            // precargue el diccionario antes que comience el simulador

            ThreadSafe(() => { LabelOffsetsLoad.Text = $"Offsets: {OffsetList.Instance.Count}"; });

            ThreadSafe(() => { LabelCommands.Text = $"Commands: {FSUIPCHelper.Instance.Count}"; });

            ThreadSafe(() => { LabelFSUIPCRunning.Text = $"Trying connect FSUIPC..."; });

            FSUIPCHelper.Instance.Open();

            Thread.Sleep(500);

            if (!FSUIPCHelper.FSUIPC_Running)
            {
                
                ThreadSafe(() => { LabelFSUIPCRunning.Text = $"FSUIPC Not Running!"; });

                Console.WriteLine("FSUIPC not running!");

            }
            else
            {
                ThreadSafe(() => { LabelFSUIPCRunning.Text = $"FSUIPC Running."; });
            }


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

        }


        private void _Saitek_Buttons1() 
            => FSUIPCHelper.Instance.Execute("ALL_LIGHTS_TOGGLE");
        private void _Saitek_Buttons2()
            => FSUIPCHelper.Instance.Execute("TOGGLE_AVIONICS_MASTER");



        #region Eventos ENCODERS

        // 10000000L ticks -> 1 segundo

        //TimeSpan interval = new TimeSpan(10000000 / 10); // 1 decima de segundo (muy sensible)

        TimeSpan interval = new TimeSpan(10000000 / 20); // Menos sensible

        static DateTime LastTime = DateTime.Now;
        
        private void Saitek_EnconderB1R()
        {
            
            FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");
                FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");
            }
            
            FSUIPCHelper.Instance.Execute("MCP_HEADING_REL");

            LastTime = DateTime.Now;

        }

        private void Saitek_EnconderB1L()
        {

            FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");

            if (DateTime.Now - LastTime < interval)
            {
                // FAST MODE
                FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");
                FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");
            }

            FSUIPCHelper.Instance.Execute("MCP_HEADING_REL");

            LastTime = DateTime.Now;

        }

        private void Saitek_EnconderS1R()
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

        private void Saitek_EnconderS1L()
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



        private void Saitek_EnconderB2R()
        {
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_UP");
        }

        private void Saitek_EnconderB2L()
        {
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
            FSUIPCHelper.Instance.Execute("ELEV_TRIM_DW");
        }

        private void Saitek_EnconderS2R()
        {
            // DEBUG
            if (!FSUIPCHelper.FSUIPC_Running)
            {
                Console.WriteLine("Saitek_EnconderS2R");
                return;
            }

            FSUIPCHelper.Instance.Execute("MCP_HEADING_INC");
            FSUIPCHelper.Instance.Execute("MCP_HEADING_REL");
        }

        private void Saitek_EnconderS2L()
        {
            // DEBUG
            if (!FSUIPCHelper.FSUIPC_Running)
            {
                Console.WriteLine("Saitek_EnconderS2L");
                return;
            }

            FSUIPCHelper.Instance.Execute("MCP_HEADING_DEC");
            FSUIPCHelper.Instance.Execute("MCP_HEADING_REL");
        }

        #endregion




        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                FSUIPCHelper.Instance.Update(); // IMPORTANTE ACTUALIZAR

                foreach (var display in Display.Instance.Dictionary)
                {
                    ucVirtual panel = FindControl(display.Key);

                    panel?.Update(display.Value);
                }

                _Saitek.Update();

            }
            catch { }


        }

        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var spL = (SerialPort)sender;

                var ln = spL.ReadLine();

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



        #region CLOSE APP

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SRPMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _Saitek.SetAll(255);
            _Saitek.Dispose();
            


            timer1.Stop();
            timer1.Enabled = false;

            notifyIcon1.Icon = null;
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            
        }

        private void SRPMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            
        }

        #endregion



    }
}
