namespace CWLS
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
            this.components = new System.ComponentModel.Container();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHieght = new System.Windows.Forms.Label();
            this.txtHieght = new System.Windows.Forms.TextBox();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdStep = new System.Windows.Forms.Button();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRandom = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(12, 6);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(53, 3);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(41, 20);
            this.txtWidth.TabIndex = 6;
            this.txtWidth.Text = "127";
            // 
            // lblHieght
            // 
            this.lblHieght.AutoSize = true;
            this.lblHieght.Location = new System.Drawing.Point(100, 6);
            this.lblHieght.Name = "lblHieght";
            this.lblHieght.Size = new System.Drawing.Size(38, 13);
            this.lblHieght.TabIndex = 7;
            this.lblHieght.Text = "Hieght";
            // 
            // txtHieght
            // 
            this.txtHieght.Location = new System.Drawing.Point(141, 3);
            this.txtHieght.Name = "txtHieght";
            this.txtHieght.Size = new System.Drawing.Size(41, 20);
            this.txtHieght.TabIndex = 10;
            this.txtHieght.Text = "65";
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(276, 1);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(75, 23);
            this.cmdCreate.TabIndex = 15;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreateClick);
            // 
            // cmdStart
            // 
            this.cmdStart.Enabled = false;
            this.cmdStart.Location = new System.Drawing.Point(357, 1);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 16;
            this.cmdStart.Text = "start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.CmdStartClick);
            // 
            // cmdStop
            // 
            this.cmdStop.Enabled = false;
            this.cmdStop.Location = new System.Drawing.Point(438, 2);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 17;
            this.cmdStop.Text = "stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.CmdStopClick);
            // 
            // cmdStep
            // 
            this.cmdStep.Enabled = false;
            this.cmdStep.Location = new System.Drawing.Point(519, 3);
            this.cmdStep.Name = "cmdStep";
            this.cmdStep.Size = new System.Drawing.Size(75, 23);
            this.cmdStep.TabIndex = 19;
            this.cmdStep.Text = "Step";
            this.cmdStep.UseVisualStyleBackColor = true;
            this.cmdStep.Click += new System.EventHandler(this.CmdStepClick);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(229, 3);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(41, 20);
            this.txtSize.TabIndex = 21;
            this.txtSize.Text = "15";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Sqr size";
            // 
            // cmdRandom
            // 
            this.cmdRandom.Enabled = false;
            this.cmdRandom.Location = new System.Drawing.Point(600, 4);
            this.cmdRandom.Name = "cmdRandom";
            this.cmdRandom.Size = new System.Drawing.Size(75, 23);
            this.cmdRandom.TabIndex = 22;
            this.cmdRandom.Text = "randomize";
            this.cmdRandom.UseVisualStyleBackColor = true;
            this.cmdRandom.Click += new System.EventHandler(this.CmdRandomClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 478);
            this.Controls.Add(this.cmdRandom);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdStep);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.txtHieght);
            this.Controls.Add(this.lblHieght);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblWidth);
            this.Name = "Form1";
            this.Text = "BossMode Life SIm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblHieght;
        private System.Windows.Forms.TextBox txtHieght;
        private System.Windows.Forms.Button cmdCreate;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdStep;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRandom;
        private System.Windows.Forms.Timer timer1;

    }
}

