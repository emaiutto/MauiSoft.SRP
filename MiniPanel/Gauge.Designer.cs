namespace MauiSoft.SRP.MiniGauge
{
    partial class Gauge
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbIdentificador = new Label();
            SuspendLayout();
            // 
            // lbIdentificador
            // 
            lbIdentificador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbIdentificador.AutoSize = true;
            lbIdentificador.Location = new Point(53, 0);
            lbIdentificador.Name = "lbIdentificador";
            lbIdentificador.Size = new Size(44, 23);
            lbIdentificador.TabIndex = 0;
            lbIdentificador.Text = "#00";
            // 
            // ucVirtual
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbIdentificador);
            Name = "ucVirtual";
            Size = new Size(100, 100);
            Paint += Virtual_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbIdentificador;
    }
}
