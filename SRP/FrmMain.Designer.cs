namespace MauiSoft.SRP
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItemCloseApp = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            timerSaitek = new System.Windows.Forms.Timer(components);
            DSP1 = new Label();
            pictureBox1 = new PictureBox();
            DSP2 = new Label();
            DSP4 = new Label();
            DSP3 = new Label();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Aircraft Not Loaded!";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCloseApp });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(111, 32);
            // 
            // toolStripMenuItemCloseApp
            // 
            toolStripMenuItemCloseApp.Name = "toolStripMenuItemCloseApp";
            toolStripMenuItemCloseApp.Size = new Size(110, 28);
            toolStripMenuItemCloseApp.Text = "&Exit";
            toolStripMenuItemCloseApp.Click += ToolStripMenuItemCloseApp_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2000;
            timer1.Tick += Timer1_Tick;
            // 
            // timerSaitek
            // 
            timerSaitek.Tick += TimerSaitek_Tick;
            // 
            // DSP1
            // 
            DSP1.BackColor = Color.Black;
            DSP1.BorderStyle = BorderStyle.FixedSingle;
            DSP1.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP1.ForeColor = Color.FromArgb(255, 128, 0);
            DSP1.Location = new Point(31, 28);
            DSP1.Name = "DSP1";
            DSP1.Size = new Size(240, 80);
            DSP1.TabIndex = 1;
            DSP1.Text = "110.10";
            DSP1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(549, 221);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // DSP2
            // 
            DSP2.BackColor = Color.Black;
            DSP2.BorderStyle = BorderStyle.FixedSingle;
            DSP2.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP2.ForeColor = Color.FromArgb(255, 128, 0);
            DSP2.Location = new Point(298, 28);
            DSP2.Name = "DSP2";
            DSP2.Size = new Size(240, 80);
            DSP2.TabIndex = 3;
            DSP2.Text = "110.10";
            DSP2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DSP4
            // 
            DSP4.BackColor = Color.Black;
            DSP4.BorderStyle = BorderStyle.FixedSingle;
            DSP4.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP4.ForeColor = Color.FromArgb(255, 128, 0);
            DSP4.Location = new Point(298, 126);
            DSP4.Name = "DSP4";
            DSP4.Size = new Size(240, 80);
            DSP4.TabIndex = 5;
            DSP4.Text = "110.10";
            DSP4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DSP3
            // 
            DSP3.BackColor = Color.Black;
            DSP3.BorderStyle = BorderStyle.FixedSingle;
            DSP3.Font = new Font("P51LCD", 48F, FontStyle.Bold, GraphicsUnit.Point);
            DSP3.ForeColor = Color.FromArgb(255, 128, 0);
            DSP3.Location = new Point(31, 126);
            DSP3.Name = "DSP3";
            DSP3.Size = new Size(240, 80);
            DSP3.TabIndex = 4;
            DSP3.Text = "110.10";
            DSP3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 248);
            Controls.Add(DSP4);
            Controls.Add(DSP3);
            Controls.Add(DSP2);
            Controls.Add(DSP1);
            Controls.Add(pictureBox1);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmMain";
            Text = "Saitek Radio Panel";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItemCloseApp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerSaitek;
        private Label DSP1;
        private PictureBox pictureBox1;
        private Label DSP2;
        private Label DSP4;
        private Label DSP3;
    }
}