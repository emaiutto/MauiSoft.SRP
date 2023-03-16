using MauiSoft.SRP.Commands;
using MauiSoft.SRP.MyExtensions;

namespace MauiSoft.SRP
{
    public partial class Main : Form
    {


        Form frm;

        string last;

        const string AIRCRAFT_NOT_LOADED = "Aircraft Not Loaded!";

        public Main()
        {
            InitializeComponent();
            
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
                      

            notifyIcon1.Text = AIRCRAFT_NOT_LOADED;

            //FSUIPCHelper.Instance.Open();
        }


        /// <summary>
        /// Search for a valid Aicraft Profile (metodo POOLING)
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                Profile.Profile.Instance.Update(); // solo actualiza el grupo PROFILE

                string aircraft = Profile.Profile.Instance.Aircraft;

                string name = Profile.Profile.Instance.Name;

                notifyIcon1.Text = $"{aircraft} - {name}"; // PROFILE / AIRCRAFT

                if (aircraft.IsNullEmptyOrSpace() || name.IsNullEmptyOrSpace())
                    return;


                FSUIPCHelper.Instance.Load(Profile.Profile.Instance.Aircraft);

                if (!name.Equals(last) || frm == null)
                {
                    last = name;

                    switch (aircraft)
                    {
                        case "PMDG":

                            frm = new PMDG();
                            frm.Show();

                            break;

                        case "C172":

                            frm = new C172();
                            frm.Show();

                            break;
                    }


                }
            }
            catch (Exception ex)
            {
                timer1.Stop();

                //Console.WriteLine(ex.ToString());

                //MessageBox.Show(ex.ToString());
            }

        }


        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            try
            {
                ClearNotifyIcon();

                if (frm != null) frm.Close();

                Close();
            }
            catch { }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearNotifyIcon();
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


    }
}
