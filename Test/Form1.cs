using System.Diagnostics;
using MauiSoft.SRP.LandingGearLibrary;
using MauiSoft.SRP.McpLibrary;
using MauiSoft.SRP.SaitekLibrary;

namespace Test
{
    public partial class Form1 : Form
    {

        static ROF? _MCP;

        static SaitekRadioPanel? _Saitek;

        static LandingGearDevice? _LandingGearDevice;


        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {

            _Saitek = new SaitekRadioPanel();

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



            _MCP = new ROF();

            _MCP.CRSL_INC += MCP_CRSL_INC;
            _MCP.CRSL_DEC += MCP_CRSL_DEC;

            _MCP.SPEED_INC += MCP_SPEED_INC;
            _MCP.SPEED_DEC += MCP_SPEED_DEC;

            _MCP.HEADING_INC += MCP_HEADING_INC;
            _MCP.HEADING_DEC += MCP_HEADING_DEC;

            _MCP.ALTITUDE_INC += MCP_ALTITUDE_INC;
            _MCP.ALTITUDE_DEC += MCP_ALTITUDE_DEC;

            _MCP.VERSPEED_INC += MCP_VERSPEED_INC;
            _MCP.VERSPEED_DEC += MCP_VERSPEED_DEC;

            _MCP.CRSR_INC += MCP_CRSR_INC;
            _MCP.CRSR_DEC += MCP_CRSR_DEC;



            _MCP.AT_BUTTON += MCP_AT_BUTTON;
            _MCP.FD_BUTTON += MCP_FD_BUTTON;

            _MCP.SPD_BUTTON += MCP_SPD_BUTTON;

            _MCP.VNAV_BUTTON += MCP_VNAV_BUTTON;
            _MCP.LVL_CHG_BUTTON += MCP_LVL_CHG_BUTTON;

            _MCP.HDGSEL_BUTTON += MCP_HDGSEL_BUTTON;

            _MCP.LNAV_BUTTON += MCP_LNAV_BUTTON;
            _MCP.APP_BUTTON += MCP_APP_BUTTON;

            _MCP.ALTHLD_BUTTON += MCP_ALTHLD_BUTTON;
            _MCP.VS_BUTTON += MCP_VS_BUTTON;

            _MCP.CMD_BUTTON += MCP_CMD_BUTTON;
            _MCP.CWS_BUTTON += MCP_CWS_BUTTON;



            _LandingGearDevice = new LandingGearDevice();

            _LandingGearDevice.FlapsUp += _LandingGearDevice_FlapsUp;
            _LandingGearDevice.FlapsDown += _LandingGearDevice_FlapsDown;

            _LandingGearDevice.LandingGearUp += _LandingGearDevice_LandingGearUp;
            _LandingGearDevice.LandingGearDown += _LandingGearDevice_LandingGearDown;

        }




        #region Events


        private void MCP_CWS_BUTTON()
        {
            //ThreadSafe(() => listBox1.Items.Add("MCP_CWS_BUTTON"));

            Debug.WriteLine("MCP_CWS_BUTTON");
        }

        private void MCP_CMD_BUTTON()
        {

            Debug.WriteLine("MCP_CMD_BUTTON");
        }

        private void MCP_VS_BUTTON()
        {

            Debug.WriteLine("MCP_VS_BUTTON");
        }

        private void MCP_ALTHLD_BUTTON()
        {
            Debug.WriteLine("MCP_ALTHLD_BUTTON");
        }

        private void MCP_APP_BUTTON()
        {
            Debug.WriteLine("MCP_APP_BUTTON");
        }

        private void MCP_LNAV_BUTTON()
        {
            Debug.WriteLine("MCP_LNAV_BUTTON");
        }

        private void MCP_HDGSEL_BUTTON()
        {
            Debug.WriteLine("MCP_HDGSEL_BUTTON");
        }

        private void MCP_LVL_CHG_BUTTON()
        {
            Debug.WriteLine("MCP_LVL_CHG_BUTTON");
        }

        private void MCP_VNAV_BUTTON()
        {
            Debug.WriteLine("MCP_VNAV_BUTTON");
        }

        private void MCP_SPD_BUTTON()
        {
            Debug.WriteLine("MCP_SPD_BUTTON");
        }

        private void MCP_FD_BUTTON()
        {
            Debug.WriteLine("MCP_FD_BUTTON");
        }

        private void MCP_AT_BUTTON()
        {
            Debug.WriteLine("MCP_AT_BUTTON");
        }

        private void MCP_CRSR_DEC()
        {
            Debug.WriteLine("MCP_CRSR_DEC");
        }

        private void MCP_CRSR_INC()
        {
            Debug.WriteLine("MCP_CRSR_INC");
        }

        private void MCP_VERSPEED_DEC()
        {
            Debug.WriteLine("MCP_VERSPEED_DEC"); // INC
        }

        private void MCP_VERSPEED_INC()
        {
            Debug.WriteLine("MCP_VERSPEED_INC"); // DEC
        }

        private void MCP_ALTITUDE_DEC()
        {
            Debug.WriteLine("MCP_ALTITUDE_DEC");
        }

        private void MCP_ALTITUDE_INC()
        {
            Debug.WriteLine("MCP_ALTITUDE_INC");
        }

        private void MCP_HEADING_DEC()
        {
            Debug.WriteLine("MCP_HEADING_DEC");
        }

        private void MCP_HEADING_INC()
        {
            Debug.WriteLine("MCP_HEADING_INC");
        }

        private void MCP_SPEED_DEC()
        {
            Debug.WriteLine("MCP_SPEED_DEC");
        }

        private void MCP_SPEED_INC()
        {
            Debug.WriteLine("MCP_SPEED_INC");
        }

        private void MCP_CRSL_DEC()
        {
            Debug.WriteLine("MCP_CRSL_DEC");
        }

        private void MCP_CRSL_INC()
        {
            Debug.WriteLine("MCP_CRSL_INC");
        }

        private void _Saitek_Buttons2()
        {
            Debug.WriteLine("_Saitek_Buttons2");
        }

        private void _Saitek_Buttons1()
        {
            Debug.WriteLine("_Saitek_Buttons1");
        }

        private void Saitek_EnconderS2L()
        {
            Debug.WriteLine("Saitek_EnconderS2L");
        }

        private void Saitek_EnconderS2R()
        {
            Debug.WriteLine("Saitek_EnconderS2R");
        }

        private void Saitek_EnconderB2L()
        {
            Debug.WriteLine("Saitek_EnconderB2L");
        }

        private void Saitek_EnconderB2R()
        {
            Debug.WriteLine("Saitek_EnconderB2R");
        }

        private void Saitek_EnconderS1L()
        {
            Debug.WriteLine("Saitek_EnconderS1L");
        }

        private void Saitek_EnconderS1R()
        {
            Debug.WriteLine("Saitek_EnconderS1R");
        }

        private void Saitek_EnconderB1L()
        {
            Debug.WriteLine("Saitek_EnconderB1L");
        }

        private void Saitek_EnconderB1R()
        {
            Debug.WriteLine("Saitek_EnconderB1R");
        }

        private void _LandingGearDevice_LandingGearDown()
        {
            Debug.WriteLine("LandingGearDown");
        }

        private void _LandingGearDevice_LandingGearUp()
        {
            Debug.WriteLine("LandingGearUp");
        }

        private void _LandingGearDevice_FlapsDown()
        {
            Debug.WriteLine("FlapsDown");
        }

        private void _LandingGearDevice_FlapsUp()
        {
            Debug.WriteLine("FlapsUp");
        }


        #endregion


        private void timerSaitek_Tick(object sender, EventArgs e)
        {

            try
            {
                _Saitek?.UpdateDebug();
            }
            catch (Exception ex)
            {
                timerSaitek.Stop();

                MessageBox.Show(ex.ToString());

                Debug.WriteLine(ex.ToString());
            }
        }



        private void ThreadSafe(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _MCP?.Dispose();
            
            _Saitek?.Dispose();

            _LandingGearDevice?.Dispose();

        }

    }
}
