namespace MauiSoft.SRP.MiniGauge
{
    public partial class Gauge : UserControl
    {

        public Gauge() : base() => InitializeComponent();

        protected void Virtual_Paint(object sender, PaintEventArgs e)
        {
            if (Tag == null) { return; }

            lbIdentificador.Text = $"{Tag:##}";

            lbIdentificador.Visible = DesignMode; // solo visible en modo diseño
        }


    }
}
