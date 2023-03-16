using MauiSoft.SRP.Gauges;

namespace MauiSoft.SRP
{
    public partial class FrmTemplate : Form
    {
        public FrmTemplate()
        {
            InitializeComponent();
        }

        protected void ThreadSafe(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }


        /// <summary>
        /// Find Control matching by TAG ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected ucVirtual FindControl(int id)
        {

            foreach (Control item in Controls)
            {
                if (item.Tag == null) continue;

                if (Convert.ToInt32(item.Tag) == id) return (ucVirtual)item;
            }

            return null;
        }


    }
}
