namespace YAGE
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
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cboLeft = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.chkBorder = new System.Windows.Forms.CheckBox();
            this.cmdPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmdDisplayLayout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.cboRight = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdRandomize = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(53, 6);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Text = "36";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(202, 6);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 0;
            this.txtHeight.Text = "18";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(531, 6);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(75, 23);
            this.cmdGenerate.TabIndex = 3;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cboLeft
            // 
            this.cboLeft.FormattingEnabled = true;
            this.cboLeft.Location = new System.Drawing.Point(716, 8);
            this.cboLeft.Name = "cboLeft";
            this.cboLeft.Size = new System.Drawing.Size(121, 21);
            this.cboLeft.TabIndex = 6;
            this.cboLeft.SelectedIndexChanged += new System.EventHandler(this.cboLeft_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(425, 6);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 8;
            this.txtSize.Text = "64";
            // 
            // chkBorder
            // 
            this.chkBorder.AutoSize = true;
            this.chkBorder.Checked = true;
            this.chkBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBorder.Location = new System.Drawing.Point(322, 5);
            this.chkBorder.Name = "chkBorder";
            this.chkBorder.Size = new System.Drawing.Size(57, 17);
            this.chkBorder.TabIndex = 10;
            this.chkBorder.Text = "Border";
            this.chkBorder.UseVisualStyleBackColor = true;
            this.chkBorder.CheckedChanged += new System.EventHandler(this.chkBorder_CheckedChanged);
            // 
            // cmdPath
            // 
            this.cmdPath.Location = new System.Drawing.Point(1262, 11);
            this.cmdPath.Name = "cmdPath";
            this.cmdPath.Size = new System.Drawing.Size(28, 19);
            this.cmdPath.TabIndex = 13;
            this.cmdPath.Text = "...";
            this.cmdPath.UseVisualStyleBackColor = true;
            this.cmdPath.Click += new System.EventHandler(this.cmdPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(1116, 10);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(131, 20);
            this.txtPath.TabIndex = 12;
            // 
            // cmdDisplayLayout
            // 
            this.cmdDisplayLayout.Location = new System.Drawing.Point(1306, 9);
            this.cmdDisplayLayout.Name = "cmdDisplayLayout";
            this.cmdDisplayLayout.Size = new System.Drawing.Size(75, 23);
            this.cmdDisplayLayout.TabIndex = 14;
            this.cmdDisplayLayout.Text = "DisplayLayout";
            this.cmdDisplayLayout.UseVisualStyleBackColor = true;
            this.cmdDisplayLayout.Click += new System.EventHandler(this.cmdDisplayLayout_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1607, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pbLeft
            // 
            this.pbLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLeft.Location = new System.Drawing.Point(843, 6);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(64, 64);
            this.pbLeft.TabIndex = 16;
            this.pbLeft.TabStop = false;
            this.pbLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLeft_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(761, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Don\'t be stupid and putt letters were number go or something stupid like that and" +
    " this should all work perfectly , And for techincal Support please go fuck yours" +
    "elf";
            // 
            // pbRight
            // 
            this.pbRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRight.Location = new System.Drawing.Point(1040, 4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(64, 64);
            this.pbRight.TabIndex = 19;
            this.pbRight.TabStop = false;
            this.pbRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRight_MouseDown);
            // 
            // cboRight
            // 
            this.cboRight.FormattingEnabled = true;
            this.cboRight.Location = new System.Drawing.Point(913, 6);
            this.cboRight.Name = "cboRight";
            this.cboRight.Size = new System.Drawing.Size(121, 21);
            this.cboRight.TabIndex = 18;
            this.cboRight.SelectedIndexChanged += new System.EventHandler(this.cboRight_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(713, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Left Click";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(905, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Right Click";
            // 
            // cmdRandomize
            // 
            this.cmdRandomize.Location = new System.Drawing.Point(612, 5);
            this.cmdRandomize.Name = "cmdRandomize";
            this.cmdRandomize.Size = new System.Drawing.Size(75, 23);
            this.cmdRandomize.TabIndex = 23;
            this.cmdRandomize.Text = "Randomize";
            this.cmdRandomize.UseVisualStyleBackColor = true;
            this.cmdRandomize.Click += new System.EventHandler(this.cmdRandomize_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1424, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save Layout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1905, 907);
            this.Controls.Add(this.cmdRandomize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.cboRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdDisplayLayout);
            this.Controls.Add(this.cmdPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkBorder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.cboLeft);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "                       ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.ComboBox cboLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.CheckBox chkBorder;
        private System.Windows.Forms.Button cmdPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button cmdDisplayLayout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.ComboBox cboRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdRandomize;
        private System.Windows.Forms.Button button2;
    }
}

