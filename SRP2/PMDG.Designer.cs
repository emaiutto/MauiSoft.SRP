namespace MauiSoft.SRP
{
    partial class PMDG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMDG));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelOffsetsLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelCommands = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelFSUIPCRunning = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucTrim1 = new SRP.Gauges.B738.ucTrim();
            this.ucGrados7 = new SRP.Gauges.Generics.ucGrados();
            this.ucGrados6 = new SRP.Gauges.Generics.ucGrados();
            this.ucHome1 = new SRP.Gauges.Generics.ucHome();
            this.ucGrados5 = new SRP.Gauges.Generics.ucGrados();
            this.ucGrados4 = new SRP.Gauges.Generics.ucGrados();
            this.ucMagneticHeading1 = new SRP.Gauges.Generics.ucMagneticHeading();
            this.ucGrados3 = new SRP.Gauges.Generics.ucGrados();
            this.ucOnGround1 = new SRP.Gauges.Generics.ucOnGround();
            this.ucGPS1 = new SRP.Gauges.Generics.ucGPS();
            this.ucLabelSimple1 = new SRP.Gauges.Generics.ucLabelSimple();
            this.ucDeclination1 = new SRP.Gauges.Generics.ucDeclination();
            this.TimerSaitekUpdate = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelOffsetsLoad,
            this.toolStripStatusLabel2,
            this.LabelCommands,
            this.toolStripStatusLabel1,
            this.LabelFSUIPCRunning});
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1336, 28);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelOffsetsLoad
            // 
            this.LabelOffsetsLoad.Name = "LabelOffsetsLoad";
            this.LabelOffsetsLoad.Size = new System.Drawing.Size(87, 23);
            this.LabelOffsetsLoad.Text = "offsets: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 23);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // LabelCommands
            // 
            this.LabelCommands.Name = "LabelCommands";
            this.LabelCommands.Size = new System.Drawing.Size(124, 23);
            this.LabelCommands.Text = "commands: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 23);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // LabelFSUIPCRunning
            // 
            this.LabelFSUIPCRunning.Name = "LabelFSUIPCRunning";
            this.LabelFSUIPCRunning.Size = new System.Drawing.Size(148, 23);
            this.LabelFSUIPCRunning.Text = "FSUIPC Running";
            // 
            // ucTrim1
            // 
            this.ucTrim1.BackColor = System.Drawing.Color.Black;
            this.ucTrim1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTrim1.ForeColor = System.Drawing.Color.White;
            this.ucTrim1.Location = new System.Drawing.Point(1186, 4);
            this.ucTrim1.Margin = new System.Windows.Forms.Padding(2);
            this.ucTrim1.Name = "ucTrim1";
            this.ucTrim1.Padding = new System.Windows.Forms.Padding(2);
            this.ucTrim1.Size = new System.Drawing.Size(150, 313);
            this.ucTrim1.TabIndex = 16;
            this.ucTrim1.Tag = "13";
            // 
            // ucGrados7
            // 
            this.ucGrados7.BackColor = System.Drawing.Color.ForestGreen;
            this.ucGrados7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrados7.ForeColor = System.Drawing.Color.White;
            this.ucGrados7.Location = new System.Drawing.Point(168, 167);
            this.ucGrados7.Name = "ucGrados7";
            this.ucGrados7.Padding = new System.Windows.Forms.Padding(3);
            this.ucGrados7.Size = new System.Drawing.Size(150, 150);
            this.ucGrados7.TabIndex = 15;
            this.ucGrados7.Tag = "12";
            // 
            // ucGrados6
            // 
            this.ucGrados6.BackColor = System.Drawing.Color.ForestGreen;
            this.ucGrados6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrados6.ForeColor = System.Drawing.Color.White;
            this.ucGrados6.Location = new System.Drawing.Point(324, 167);
            this.ucGrados6.Name = "ucGrados6";
            this.ucGrados6.Padding = new System.Windows.Forms.Padding(3);
            this.ucGrados6.Size = new System.Drawing.Size(150, 150);
            this.ucGrados6.TabIndex = 14;
            this.ucGrados6.Tag = "11";
            // 
            // ucHome1
            // 
            this.ucHome1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ucHome1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucHome1.ForeColor = System.Drawing.Color.White;
            this.ucHome1.Location = new System.Drawing.Point(479, 167);
            this.ucHome1.Margin = new System.Windows.Forms.Padding(2);
            this.ucHome1.Name = "ucHome1";
            this.ucHome1.Padding = new System.Windows.Forms.Padding(2);
            this.ucHome1.Size = new System.Drawing.Size(150, 150);
            this.ucHome1.TabIndex = 13;
            this.ucHome1.Tag = "10";
            // 
            // ucGrados5
            // 
            this.ucGrados5.BackColor = System.Drawing.Color.ForestGreen;
            this.ucGrados5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrados5.ForeColor = System.Drawing.Color.White;
            this.ucGrados5.Location = new System.Drawing.Point(12, 168);
            this.ucGrados5.Name = "ucGrados5";
            this.ucGrados5.Padding = new System.Windows.Forms.Padding(3);
            this.ucGrados5.Size = new System.Drawing.Size(150, 150);
            this.ucGrados5.TabIndex = 11;
            this.ucGrados5.Tag = "2";
            // 
            // ucGrados4
            // 
            this.ucGrados4.BackColor = System.Drawing.Color.ForestGreen;
            this.ucGrados4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrados4.ForeColor = System.Drawing.Color.White;
            this.ucGrados4.Location = new System.Drawing.Point(323, 12);
            this.ucGrados4.Name = "ucGrados4";
            this.ucGrados4.Padding = new System.Windows.Forms.Padding(3);
            this.ucGrados4.Size = new System.Drawing.Size(150, 150);
            this.ucGrados4.TabIndex = 10;
            this.ucGrados4.Tag = "9";
            // 
            // ucMagneticHeading1
            // 
            this.ucMagneticHeading1.BackColor = System.Drawing.Color.Brown;
            this.ucMagneticHeading1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucMagneticHeading1.ForeColor = System.Drawing.Color.White;
            this.ucMagneticHeading1.Location = new System.Drawing.Point(789, 12);
            this.ucMagneticHeading1.Name = "ucMagneticHeading1";
            this.ucMagneticHeading1.Padding = new System.Windows.Forms.Padding(3);
            this.ucMagneticHeading1.Size = new System.Drawing.Size(150, 150);
            this.ucMagneticHeading1.TabIndex = 9;
            this.ucMagneticHeading1.Tag = "8";
            // 
            // ucGrados3
            // 
            this.ucGrados3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ucGrados3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrados3.ForeColor = System.Drawing.Color.White;
            this.ucGrados3.Location = new System.Drawing.Point(479, 12);
            this.ucGrados3.Name = "ucGrados3";
            this.ucGrados3.Padding = new System.Windows.Forms.Padding(3);
            this.ucGrados3.Size = new System.Drawing.Size(150, 150);
            this.ucGrados3.TabIndex = 8;
            this.ucGrados3.Tag = "7";
            // 
            // ucOnGround1
            // 
            this.ucOnGround1.BackColor = System.Drawing.Color.Black;
            this.ucOnGround1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucOnGround1.ForeColor = System.Drawing.Color.White;
            this.ucOnGround1.Location = new System.Drawing.Point(634, 167);
            this.ucOnGround1.Name = "ucOnGround1";
            this.ucOnGround1.Padding = new System.Windows.Forms.Padding(3);
            this.ucOnGround1.Size = new System.Drawing.Size(150, 150);
            this.ucOnGround1.TabIndex = 7;
            this.ucOnGround1.Tag = "6";
            // 
            // ucGPS1
            // 
            this.ucGPS1.BackColor = System.Drawing.Color.Black;
            this.ucGPS1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGPS1.ForeColor = System.Drawing.Color.White;
            this.ucGPS1.Location = new System.Drawing.Point(168, 12);
            this.ucGPS1.Margin = new System.Windows.Forms.Padding(2);
            this.ucGPS1.Name = "ucGPS1";
            this.ucGPS1.Padding = new System.Windows.Forms.Padding(2);
            this.ucGPS1.Size = new System.Drawing.Size(150, 150);
            this.ucGPS1.TabIndex = 6;
            this.ucGPS1.Tag = "5";
            // 
            // ucLabelSimple1
            // 
            this.ucLabelSimple1.BackColor = System.Drawing.Color.Maroon;
            this.ucLabelSimple1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabelSimple1.ForeColor = System.Drawing.Color.White;
            this.ucLabelSimple1.Location = new System.Drawing.Point(12, 12);
            this.ucLabelSimple1.Name = "ucLabelSimple1";
            this.ucLabelSimple1.Padding = new System.Windows.Forms.Padding(3);
            this.ucLabelSimple1.Size = new System.Drawing.Size(150, 150);
            this.ucLabelSimple1.TabIndex = 2;
            this.ucLabelSimple1.Tag = "1";
            // 
            // ucDeclination1
            // 
            this.ucDeclination1.BackColor = System.Drawing.Color.Black;
            this.ucDeclination1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDeclination1.ForeColor = System.Drawing.Color.White;
            this.ucDeclination1.Location = new System.Drawing.Point(634, 11);
            this.ucDeclination1.Margin = new System.Windows.Forms.Padding(2);
            this.ucDeclination1.Name = "ucDeclination1";
            this.ucDeclination1.Padding = new System.Windows.Forms.Padding(2);
            this.ucDeclination1.Size = new System.Drawing.Size(150, 150);
            this.ucDeclination1.TabIndex = 17;
            this.ucDeclination1.Tag = "3";
            // 
            // TimerSaitekUpdate
            // 
            this.TimerSaitekUpdate.Tick += new System.EventHandler(this.TimerSaitekUpdate_Tick);
            // 
            // PMDG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 386);
            this.Controls.Add(this.ucDeclination1);
            this.Controls.Add(this.ucTrim1);
            this.Controls.Add(this.ucGrados7);
            this.Controls.Add(this.ucGrados6);
            this.Controls.Add(this.ucHome1);
            this.Controls.Add(this.ucGrados5);
            this.Controls.Add(this.ucGrados4);
            this.Controls.Add(this.ucMagneticHeading1);
            this.Controls.Add(this.ucGrados3);
            this.Controls.Add(this.ucOnGround1);
            this.Controls.Add(this.ucGPS1);
            this.Controls.Add(this.ucLabelSimple1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PMDG";
            this.Opacity = 0.75D;
            this.Text = "";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SRPMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SRPMain_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelOffsetsLoad;
        private System.Windows.Forms.ToolStripStatusLabel LabelFSUIPCRunning;
        private System.Windows.Forms.ToolStripStatusLabel LabelCommands;
        private ucLabelSimple ucLabelSimple1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ucGPS ucGPS1;
        private ucOnGround ucOnGround1;
        private ucGrados ucGrados3;
        private ucMagneticHeading ucMagneticHeading1;
        private ucGrados ucGrados4;
        private ucGrados ucGrados5;
        private ucHome ucHome1;
        private ucGrados ucGrados6;
        private ucGrados ucGrados7;
        private ucTrim ucTrim1;
        private ucDeclination ucDeclination1;
        private System.Windows.Forms.Timer TimerSaitekUpdate;
    }
}

