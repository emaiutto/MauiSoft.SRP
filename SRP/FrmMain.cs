using MauiSoft.SRP.FsuipcWrapper;
using MauiSoft.SRP.SaitekLibrary;
using MauiSoft.SRP.MyExtensions;

namespace MauiSoft.SRP
{
    public partial class FrmMain : Form
    {

        RadioPanel? RadioPanel;


        string? last;

        // 10000000L ticks -> 1 segundo

        //TimeSpan interval2 = new TimeSpan(10000000 / 10); // 1 decima de segundo (muy sensible)

        //TimeSpan interval = new TimeSpan(10000000 / 30); // Menos sensible

        //static DateTime LastTime = DateTime.Now;



        public FrmMain() => InitializeComponent();


        #region GUI Events

        private void FrmMain_Load(object sender, EventArgs e)
        {

            FSUIPCHelper.Open();


            RadioPanel = new RadioPanel();

            RadioPanel.EnconderB1R += SaitekRadioPanel_EnconderB1R;
            RadioPanel.EnconderB1L += SaitekRadioPanel_EnconderB1L;

            RadioPanel.EnconderS1R += SaitekRadioPanel_EnconderS1R;
            RadioPanel.EnconderS1L += SaitekRadioPanel_EnconderS1L;

            RadioPanel.EnconderB2R += SaitekRadioPanel_EnconderB2R;
            RadioPanel.EnconderB2L += SaitekRadioPanel_EnconderB2L;

            RadioPanel.EnconderS2R += SaitekRadioPanel_EnconderS2R;
            RadioPanel.EnconderS2L += SaitekRadioPanel_EnconderS2L;

            RadioPanel.Buttons1 += SaitekRadioPanel_Buttons1;
            RadioPanel.Buttons2 += SaitekRadioPanel_Buttons2;

            RadioPanel.SetAll(220);  // 230 -  220 .



            // Preguntando por COUNT para que el constructor (SINGLETON)
            // precargue el diccionario antes que comience el simulador

            //ThreadSafe(() => { LabelOffsetsLoad.Text = $"Offsets: {OffsetList.Instance.Count}"; });

            //ThreadSafe(() => { LabelCommands.Text = $"Commands: {FSUIPCHelper.Instance.Count}"; });


            //Thread.Sleep(1000);

            //if (FSUIPCHelper.FSUIPC_Running)
            //{
            //    ThreadSafe(() => { LabelFSUIPCRunning.Text = $"FSUIPC Running..."; });

            //    timer1.Enabled = true;
            //    timer1.Start();

            //    TimerSaitekUpdate.Enabled = true;
            //    TimerSaitekUpdate.Start();
            //}
            //else
            //{

            //    ThreadSafe(() => { LabelFSUIPCRunning.Text = $"FSUIPC Not Running!"; });

            //    timer1.Enabled = false;
            //    timer1.Stop();

            //    TimerSaitekUpdate.Enabled = false;
            //    TimerSaitekUpdate.Stop();

            //}

        }


        #region SAITEK EVENTS


        private void SaitekRadioPanel_EnconderB1R()
        {

            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(index: RadioPanel.Switches[0])?.BRR;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SaitekRadioPanel_EnconderB1L()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[0])?.BRL;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void SaitekRadioPanel_EnconderS1R()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[0])?.SRR;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void SaitekRadioPanel_EnconderS1L()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[0])?.SRL;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void SaitekRadioPanel_EnconderB2R()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[1])?.BRR;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void SaitekRadioPanel_EnconderB2L()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[1])?.BRL;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SaitekRadioPanel_EnconderS2R()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[1])?.SRR;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SaitekRadioPanel_EnconderS2L()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[1])?.SRL;
                
                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void SaitekRadioPanel_Buttons1()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[0])?.BTN;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void SaitekRadioPanel_Buttons2()
        {
            if (RadioPanel == null) return;

            try
            {
                var cmds = Config.Instance.Get(RadioPanel.Switches[1])?.BTN;

                if (cmds == null) return;

                foreach (var cmd in cmds) FSUIPCHelper.Instance.Execute(cmd);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        #endregion


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            // DETENER TIMERS
            timer1.Stop();
            timer1.Enabled = false;
            //TimerSaitekUpdate.Stop();
            //TimerSaitekUpdate.Enabled = false;


            // CLEAR & DISPOSE
            RadioPanel?.SetAll(255);
            RadioPanel?.Dispose();

            ClearNotifyIcon();
        }

        private void toolStripMenuItemCloseApp_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch { }
        }


        private void ClearNotifyIcon()
        {

            if (notifyIcon1 == null) return;

            try
            {
                notifyIcon1.Visible = false;
                notifyIcon1.Icon = null;
                notifyIcon1.Dispose();
            }
            catch { }
        }

        #endregion



        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                // solo actualiza el grupo PROFILE
                Profile.Profile.Instance.Update();



                string aircraft = Profile.Profile.Instance.Aircraft;

                string name = Profile.Profile.Instance.Name;


                notifyIcon1.Text = $"{aircraft} - {name}"; // PROFILE / AIRCRAFT

                if (aircraft.IsNullEmptyOrSpace() || name.IsNullEmptyOrSpace())
                    return;


                FSUIPCHelper.Instance.Load(Profile.Profile.Instance.Aircraft);

                OffsetList.Instance.Load(Profile.Profile.Instance.Aircraft);

                Config.Instance.Load(Profile.Profile.Instance.Aircraft);


                timerSaitek.Enabled = true;


                //if (!name.Equals(last))
                //{
                //    last = name;

                //    switch (aircraft)
                //    {
                //        case "PMDG":


                //            timerSaitek.Enabled = true;

                //            //frm = new PMDG();
                //            //frm.Show();

                //            break;

                //        case "C172":

                //            //frm = new C172();
                //            //frm.Show();

                //            break;
                //    }
                //}


            }
            catch
            {
                Close();

                //Console.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
        }

        private void TimerSaitek_Tick(object sender, EventArgs e)
        {
            try
            {

                FSUIPCHelper.Update();

                RadioPanel?.Update();
            }
            catch (Exception ex)
            {
                timerSaitek.Stop();

                MessageBox.Show(ex.ToString());

                Console.WriteLine(ex.ToString());
            }
        }

    }
}