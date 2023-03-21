namespace MauiSoft.SRP
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timerSaitek = new System.Windows.Forms.Timer(components);
            DSP4 = new Label();
            DSP3 = new Label();
            DSP2 = new Label();
            DSP1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timerSaitek
            // 
            timerSaitek.Enabled = true;
            timerSaitek.Tick += timerSaitek_Tick;
            // 
            // DSP4
            // 
            DSP4.BackColor = Color.Black;
            DSP4.BorderStyle = BorderStyle.FixedSingle;
            DSP4.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP4.ForeColor = Color.Red;
            DSP4.Location = new Point(378, 228);
            DSP4.Name = "DSP4";
            DSP4.Size = new Size(240, 80);
            DSP4.TabIndex = 10;
            DSP4.Text = "110.10";
            DSP4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DSP3
            // 
            DSP3.BackColor = Color.Black;
            DSP3.BorderStyle = BorderStyle.FixedSingle;
            DSP3.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP3.ForeColor = Color.Red;
            DSP3.Location = new Point(111, 228);
            DSP3.Name = "DSP3";
            DSP3.Size = new Size(240, 80);
            DSP3.TabIndex = 9;
            DSP3.Text = "110.10";
            DSP3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DSP2
            // 
            DSP2.BackColor = Color.Black;
            DSP2.BorderStyle = BorderStyle.FixedSingle;
            DSP2.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP2.ForeColor = Color.Red;
            DSP2.Location = new Point(378, 130);
            DSP2.Name = "DSP2";
            DSP2.Size = new Size(240, 80);
            DSP2.TabIndex = 8;
            DSP2.Text = "110.10";
            DSP2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DSP1
            // 
            DSP1.BackColor = Color.Black;
            DSP1.BorderStyle = BorderStyle.FixedSingle;
            DSP1.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP1.ForeColor = Color.Red;
            DSP1.Location = new Point(111, 130);
            DSP1.Name = "DSP1";
            DSP1.Size = new Size(240, 80);
            DSP1.TabIndex = 6;
            DSP1.Text = "110.10";
            DSP1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(92, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(549, 221);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 448);
            Controls.Add(DSP4);
            Controls.Add(DSP3);
            Controls.Add(DSP2);
            Controls.Add(DSP1);
            Controls.Add(pictureBox1);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Test";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timerSaitek;
        private Label DSP4;
        private Label DSP3;
        private Label DSP2;
        private Label DSP1;
        private PictureBox pictureBox1;
    }
}

