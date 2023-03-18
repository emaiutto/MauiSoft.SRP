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
            contextMenuStrip1.SuspendLayout();
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
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 450);
            Name = "FrmMain";
            Text = "Saitek Radio Panel";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItemCloseApp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerSaitek;
    }
}