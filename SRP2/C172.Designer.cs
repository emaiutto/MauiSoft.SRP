using SRP.Gauges.Generics;

namespace MauiSoft.SRP
{
    partial class C172
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C172));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelOffsetsLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelCommands = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelFSUIPCRunning = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbAircraftProfile = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucHome1 = new SRP.Gauges.Generics.ucHome();
            this.ucGrados5 = new SRP.Gauges.Generics.ucGrados();
            this.ucGrados4 = new SRP.Gauges.Generics.ucGrados();
            this.ucMagneticHeading1 = new SRP.Gauges.Generics.ucMagneticHeading();
            this.ucGrados3 = new SRP.Gauges.Generics.ucGrados();
            this.ucOnGround1 = new SRP.Gauges.Generics.ucOnGround();
            this.ucGPS1 = new SRP.Gauges.Generics.ucGPS();
            this.ucLabelSimple1 = new SRP.Gauges.Generics.ucLabelSimple();
            this.ucTrim1 = new SRP.Gauges.C172.ucTrim();
            this.ucDeclination1 = new SRP.Gauges.Generics.ucDeclination();
            this.ucPressure1 = new SRP.Gauges.Generics.ucPressure();
            this.ucPressure2 = new SRP.Gauges.Generics.ucPressure();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelOffsetsLoad,
            this.toolStripStatusLabel2,
            this.LabelCommands,
            this.toolStripStatusLabel1,
            this.LabelFSUIPCRunning,
            this.toolStripStatusLabel3,
            this.lbAircraftProfile});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // LabelOffsetsLoad
            // 
            this.LabelOffsetsLoad.Name = "LabelOffsetsLoad";
            resources.ApplyResources(this.LabelOffsetsLoad, "LabelOffsetsLoad");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // LabelCommands
            // 
            this.LabelCommands.Name = "LabelCommands";
            resources.ApplyResources(this.LabelCommands, "LabelCommands");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // LabelFSUIPCRunning
            // 
            this.LabelFSUIPCRunning.Name = "LabelFSUIPCRunning";
            resources.ApplyResources(this.LabelFSUIPCRunning, "LabelFSUIPCRunning");
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            // 
            // lbAircraftProfile
            // 
            this.lbAircraftProfile.Name = "lbAircraftProfile";
            resources.ApplyResources(this.lbAircraftProfile, "lbAircraftProfile");
            // 
            // ucHome1
            // 
            this.ucHome1.BackColor = System.Drawing.Color.LightSeaGreen;
            resources.ApplyResources(this.ucHome1, "ucHome1");
            this.ucHome1.ForeColor = System.Drawing.Color.White;
            this.ucHome1.Name = "ucHome1";
            this.ucHome1.Tag = "10";
            // 
            // ucGrados5
            // 
            this.ucGrados5.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.ucGrados5, "ucGrados5");
            this.ucGrados5.ForeColor = System.Drawing.Color.White;
            this.ucGrados5.Name = "ucGrados5";
            this.ucGrados5.Tag = "2";
            // 
            // ucGrados4
            // 
            this.ucGrados4.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.ucGrados4, "ucGrados4");
            this.ucGrados4.ForeColor = System.Drawing.Color.White;
            this.ucGrados4.Name = "ucGrados4";
            this.ucGrados4.Tag = "9";
            // 
            // ucMagneticHeading1
            // 
            this.ucMagneticHeading1.BackColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.ucMagneticHeading1, "ucMagneticHeading1");
            this.ucMagneticHeading1.ForeColor = System.Drawing.Color.White;
            this.ucMagneticHeading1.Name = "ucMagneticHeading1";
            this.ucMagneticHeading1.Tag = "8";
            // 
            // ucGrados3
            // 
            this.ucGrados3.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.ucGrados3, "ucGrados3");
            this.ucGrados3.ForeColor = System.Drawing.Color.White;
            this.ucGrados3.Name = "ucGrados3";
            this.ucGrados3.Tag = "7";
            // 
            // ucOnGround1
            // 
            this.ucOnGround1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ucOnGround1, "ucOnGround1");
            this.ucOnGround1.ForeColor = System.Drawing.Color.White;
            this.ucOnGround1.Name = "ucOnGround1";
            this.ucOnGround1.Tag = "6";
            // 
            // ucGPS1
            // 
            this.ucGPS1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ucGPS1, "ucGPS1");
            this.ucGPS1.ForeColor = System.Drawing.Color.White;
            this.ucGPS1.Name = "ucGPS1";
            this.ucGPS1.Tag = "5";
            // 
            // ucLabelSimple1
            // 
            this.ucLabelSimple1.BackColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.ucLabelSimple1, "ucLabelSimple1");
            this.ucLabelSimple1.ForeColor = System.Drawing.Color.White;
            this.ucLabelSimple1.Name = "ucLabelSimple1";
            this.ucLabelSimple1.Tag = "1";
            // 
            // ucTrim1
            // 
            this.ucTrim1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ucTrim1, "ucTrim1");
            this.ucTrim1.ForeColor = System.Drawing.Color.White;
            this.ucTrim1.Name = "ucTrim1";
            this.ucTrim1.Tag = "13";
            // 
            // ucDeclination1
            // 
            this.ucDeclination1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ucDeclination1, "ucDeclination1");
            this.ucDeclination1.ForeColor = System.Drawing.Color.White;
            this.ucDeclination1.Name = "ucDeclination1";
            this.ucDeclination1.Tag = "3";
            // 
            // ucPressure1
            // 
            this.ucPressure1.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.ucPressure1, "ucPressure1");
            this.ucPressure1.ForeColor = System.Drawing.Color.White;
            this.ucPressure1.Name = "ucPressure1";
            this.ucPressure1.Tag = "11";
            // 
            // ucPressure2
            // 
            this.ucPressure2.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.ucPressure2, "ucPressure2");
            this.ucPressure2.ForeColor = System.Drawing.Color.White;
            this.ucPressure2.Name = "ucPressure2";
            this.ucPressure2.Tag = "12";
            // 
            // C172
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPressure2);
            this.Controls.Add(this.ucPressure1);
            this.Controls.Add(this.ucDeclination1);
            this.Controls.Add(this.ucTrim1);
            this.Controls.Add(this.ucHome1);
            this.Controls.Add(this.ucGrados5);
            this.Controls.Add(this.ucGrados4);
            this.Controls.Add(this.ucMagneticHeading1);
            this.Controls.Add(this.ucGrados3);
            this.Controls.Add(this.ucOnGround1);
            this.Controls.Add(this.ucGPS1);
            this.Controls.Add(this.ucLabelSimple1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "C172";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SRPMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SRPMain_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelOffsetsLoad;
        private System.Windows.Forms.ToolStripStatusLabel LabelFSUIPCRunning;
        private System.Windows.Forms.ToolStripStatusLabel LabelCommands;
        private ucLabelSimple ucLabelSimple1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ucGPS ucGPS1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lbAircraftProfile;
        private ucOnGround ucOnGround1;
        private ucGrados ucGrados3;
        private ucMagneticHeading ucMagneticHeading1;
        private ucGrados ucGrados4;
        private ucGrados ucGrados5;
        private ucHome ucHome1;
        private Gauges.C172.ucTrim ucTrim1;
        private ucDeclination ucDeclination1;
        private ucPressure ucPressure1;
        private ucPressure ucPressure2;
    }
}

