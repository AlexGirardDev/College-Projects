using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SC2Trainer
{
    partial class TrainerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainerForm));
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.lblMinerals = new System.Windows.Forms.Label();
            this.lblSupply = new System.Windows.Forms.Label();
            this.lblGas = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtStartMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartGas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGpm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMpm = new System.Windows.Forms.TextBox();
            this.lblRTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTestTime = new System.Windows.Forms.Label();
            this.btnCtrl1 = new System.Windows.Forms.Button();
            this.btnCtrl2 = new System.Windows.Forms.Button();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.lblTest1 = new System.Windows.Forms.Label();
            this.cmdSelectClear = new System.Windows.Forms.Button();
            this.lbltest4 = new System.Windows.Forms.Label();
            this.lblTest3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltest5 = new System.Windows.Forms.Label();
            this.cmdMarauder = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmdUploadHotkey = new System.Windows.Forms.Button();
            this.cmdDisplayHotkeys = new System.Windows.Forms.Button();
            this.btnCtrl4 = new System.Windows.Forms.Button();
            this.btnCtrl3 = new System.Windows.Forms.Button();
            this.btnCtrl6 = new System.Windows.Forms.Button();
            this.btnCtrl5 = new System.Windows.Forms.Button();
            this.btnCtrl8 = new System.Windows.Forms.Button();
            this.btnCtrl7 = new System.Windows.Forms.Button();
            this.btnCtrl0 = new System.Windows.Forms.Button();
            this.btnCtrl9 = new System.Windows.Forms.Button();
            this.cbRace = new System.Windows.Forms.ComboBox();
            this.btnSCV = new System.Windows.Forms.Button();
            this.cmdTab = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBase0M = new System.Windows.Forms.Label();
            this.lblBase0G1 = new System.Windows.Forms.Label();
            this.lblBase0G2 = new System.Windows.Forms.Label();
            this.lblBase1G2 = new System.Windows.Forms.Label();
            this.lblBase1G1 = new System.Windows.Forms.Label();
            this.lblBase1M = new System.Windows.Forms.Label();
            this.lblBase2G2 = new System.Windows.Forms.Label();
            this.lblBase2G1 = new System.Windows.Forms.Label();
            this.lblBase2M = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.lblBase0QueTime = new System.Windows.Forms.Label();
            this.lblBase0QueCount = new System.Windows.Forms.Label();
            this.lblBase1QueCount = new System.Windows.Forms.Label();
            this.lblBase1QueTime = new System.Windows.Forms.Label();
            this.lblBase2QueCount = new System.Windows.Forms.Label();
            this.lblBase2QueTime = new System.Windows.Forms.Label();
            this.pbPlaceBuilding = new System.Windows.Forms.PictureBox();
            this.pbAbil2 = new System.Windows.Forms.PictureBox();
            this.pbAbil3 = new System.Windows.Forms.PictureBox();
            this.pbAbil4 = new System.Windows.Forms.PictureBox();
            this.pbAbil5 = new System.Windows.Forms.PictureBox();
            this.pbAbil1 = new System.Windows.Forms.PictureBox();
            this.pbAbil6 = new System.Windows.Forms.PictureBox();
            this.pbAbil7 = new System.Windows.Forms.PictureBox();
            this.pbAbil8 = new System.Windows.Forms.PictureBox();
            this.pbAbil9 = new System.Windows.Forms.PictureBox();
            this.pbAbil10 = new System.Windows.Forms.PictureBox();
            this.pbAbil11 = new System.Windows.Forms.PictureBox();
            this.pbAbil12 = new System.Windows.Forms.PictureBox();
            this.pbAbil13 = new System.Windows.Forms.PictureBox();
            this.pbAbil14 = new System.Windows.Forms.PictureBox();
            this.pbAbil15 = new System.Windows.Forms.PictureBox();
            this.lblBase2G2Icon = new System.Windows.Forms.PictureBox();
            this.lblBase2G1Icon = new System.Windows.Forms.PictureBox();
            this.lblBase2MIcon = new System.Windows.Forms.PictureBox();
            this.pbBase2 = new System.Windows.Forms.PictureBox();
            this.lblBase1G2Icon = new System.Windows.Forms.PictureBox();
            this.lblBase1G1Icon = new System.Windows.Forms.PictureBox();
            this.lblBase1MIcon = new System.Windows.Forms.PictureBox();
            this.pbBase1 = new System.Windows.Forms.PictureBox();
            this.lblBase0G2Icon = new System.Windows.Forms.PictureBox();
            this.lblBase0G1Icon = new System.Windows.Forms.PictureBox();
            this.lblBase0MIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox34 = new System.Windows.Forms.PictureBox();
            this.pbGasIcon = new System.Windows.Forms.PictureBox();
            this.pbMineralIcon = new System.Windows.Forms.PictureBox();
            this.pbBase0 = new System.Windows.Forms.PictureBox();
            this.pbUnit3 = new System.Windows.Forms.PictureBox();
            this.pbUnit5 = new System.Windows.Forms.PictureBox();
            this.pbUnit6 = new System.Windows.Forms.PictureBox();
            this.pbUnit7 = new System.Windows.Forms.PictureBox();
            this.pbUnit8 = new System.Windows.Forms.PictureBox();
            this.pbUnit4 = new System.Windows.Forms.PictureBox();
            this.pbUnit2 = new System.Windows.Forms.PictureBox();
            this.pbUnit1 = new System.Windows.Forms.PictureBox();
            this.pbUnit11 = new System.Windows.Forms.PictureBox();
            this.pbUnit12 = new System.Windows.Forms.PictureBox();
            this.pbUnit13 = new System.Windows.Forms.PictureBox();
            this.pbUnit14 = new System.Windows.Forms.PictureBox();
            this.pbUnit15 = new System.Windows.Forms.PictureBox();
            this.pbUnit16 = new System.Windows.Forms.PictureBox();
            this.pbUnit10 = new System.Windows.Forms.PictureBox();
            this.pbUnit9 = new System.Windows.Forms.PictureBox();
            this.pbUnit19 = new System.Windows.Forms.PictureBox();
            this.pbUnit20 = new System.Windows.Forms.PictureBox();
            this.pbUnit21 = new System.Windows.Forms.PictureBox();
            this.pbUnit22 = new System.Windows.Forms.PictureBox();
            this.pbUnit23 = new System.Windows.Forms.PictureBox();
            this.pbUnit24 = new System.Windows.Forms.PictureBox();
            this.pbUnit18 = new System.Windows.Forms.PictureBox();
            this.pbUnit17 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstSupplyDepots = new System.Windows.Forms.ListBox();
            this.cmdLocation2 = new System.Windows.Forms.Button();
            this.cmdLocation0 = new System.Windows.Forms.Button();
            this.cmdLocation1 = new System.Windows.Forms.Button();
            this.cmdLocation7 = new System.Windows.Forms.Button();
            this.cmdLocation6 = new System.Windows.Forms.Button();
            this.cmdLocation5 = new System.Windows.Forms.Button();
            this.cmdLocation4 = new System.Windows.Forms.Button();
            this.cmdLocation3 = new System.Windows.Forms.Button();
            this.cmdLocation8 = new System.Windows.Forms.Button();
            this.lbllocationtest = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdBase0M = new System.Windows.Forms.Button();
            this.cmdBase0G1 = new System.Windows.Forms.Button();
            this.cmdBase0G2 = new System.Windows.Forms.Button();
            this.txtWorkerRally = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbScvState = new System.Windows.Forms.ComboBox();
            this.lblTestWatch = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.txtErrors = new System.Windows.Forms.Label();
            this.lstSpeedTest = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlaceBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase2G2Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase2G1Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase2MIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase1G2Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase1G1Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase1MIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase0G2Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase0G1Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase0MIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGasIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMineralIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit17)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.cmdStart, "cmdStart");
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.UseVisualStyleBackColor = false;
            this.cmdStart.Click += new System.EventHandler(this.CmdStartClick);
            // 
            // cmdStop
            // 
            this.cmdStop.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.cmdStop, "cmdStop");
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.UseVisualStyleBackColor = false;
            this.cmdStop.Click += new System.EventHandler(this.CmdStopClick);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.cmdReset, "cmdReset");
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.UseVisualStyleBackColor = false;
            // 
            // lblMinerals
            // 
            this.lblMinerals.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblMinerals, "lblMinerals");
            this.lblMinerals.ForeColor = System.Drawing.Color.White;
            this.lblMinerals.Name = "lblMinerals";
            this.lblMinerals.Click += new System.EventHandler(this.LblMineralsClick);
            // 
            // lblSupply
            // 
            this.lblSupply.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblSupply, "lblSupply");
            this.lblSupply.ForeColor = System.Drawing.Color.White;
            this.lblSupply.Name = "lblSupply";
            // 
            // lblGas
            // 
            this.lblGas.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblGas, "lblGas");
            this.lblGas.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblGas.Name = "lblGas";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Name = "label22";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.BackColor = System.Drawing.Color.Black;
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Name = "lblTime";
            // 
            // txtStartMin
            // 
            resources.ApplyResources(this.txtStartMin, "txtStartMin");
            this.txtStartMin.Name = "txtStartMin";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // txtStartGas
            // 
            resources.ApplyResources(this.txtStartGas, "txtStartGas");
            this.txtStartGas.Name = "txtStartGas";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // txtGpm
            // 
            resources.ApplyResources(this.txtGpm, "txtGpm");
            this.txtGpm.Name = "txtGpm";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // txtMpm
            // 
            resources.ApplyResources(this.txtMpm, "txtMpm");
            this.txtMpm.Name = "txtMpm";
            // 
            // lblRTime
            // 
            resources.ApplyResources(this.lblRTime, "lblRTime");
            this.lblRTime.BackColor = System.Drawing.Color.Black;
            this.lblRTime.ForeColor = System.Drawing.Color.White;
            this.lblRTime.Name = "lblRTime";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // lblTestTime
            // 
            resources.ApplyResources(this.lblTestTime, "lblTestTime");
            this.lblTestTime.Name = "lblTestTime";
            this.lblTestTime.Click += new System.EventHandler(this.LblTestTimeClick);
            // 
            // btnCtrl1
            // 
            this.btnCtrl1.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl1.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl1, "btnCtrl1");
            this.btnCtrl1.Name = "btnCtrl1";
            this.btnCtrl1.UseVisualStyleBackColor = false;
            this.btnCtrl1.Click += new System.EventHandler(this.BtnCtrl1Click);
            // 
            // btnCtrl2
            // 
            this.btnCtrl2.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl2.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl2, "btnCtrl2");
            this.btnCtrl2.Name = "btnCtrl2";
            this.btnCtrl2.UseVisualStyleBackColor = false;
            this.btnCtrl2.Click += new System.EventHandler(this.BtnCtrl2Click);
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdSelectAll.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdSelectAll, "cmdSelectAll");
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.UseVisualStyleBackColor = false;
            this.cmdSelectAll.Click += new System.EventHandler(this.CmdSelectAllClick);
            // 
            // lblTest2
            // 
            resources.ApplyResources(this.lblTest2, "lblTest2");
            this.lblTest2.BackColor = System.Drawing.Color.Black;
            this.lblTest2.ForeColor = System.Drawing.Color.White;
            this.lblTest2.Name = "lblTest2";
            // 
            // lblTest1
            // 
            resources.ApplyResources(this.lblTest1, "lblTest1");
            this.lblTest1.BackColor = System.Drawing.Color.Black;
            this.lblTest1.ForeColor = System.Drawing.Color.White;
            this.lblTest1.Name = "lblTest1";
            // 
            // cmdSelectClear
            // 
            this.cmdSelectClear.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdSelectClear.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdSelectClear.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdSelectClear, "cmdSelectClear");
            this.cmdSelectClear.Name = "cmdSelectClear";
            this.cmdSelectClear.UseVisualStyleBackColor = false;
            this.cmdSelectClear.Click += new System.EventHandler(this.CmdSelectClearClick);
            // 
            // lbltest4
            // 
            resources.ApplyResources(this.lbltest4, "lbltest4");
            this.lbltest4.BackColor = System.Drawing.Color.Black;
            this.lbltest4.ForeColor = System.Drawing.Color.White;
            this.lbltest4.Name = "lbltest4";
            // 
            // lblTest3
            // 
            resources.ApplyResources(this.lblTest3, "lblTest3");
            this.lblTest3.BackColor = System.Drawing.Color.Black;
            this.lblTest3.ForeColor = System.Drawing.Color.White;
            this.lblTest3.Name = "lblTest3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // lbltest5
            // 
            resources.ApplyResources(this.lbltest5, "lbltest5");
            this.lbltest5.BackColor = System.Drawing.Color.Black;
            this.lbltest5.ForeColor = System.Drawing.Color.White;
            this.lbltest5.Name = "lbltest5";
            // 
            // cmdMarauder
            // 
            this.cmdMarauder.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdMarauder.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdMarauder.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdMarauder, "cmdMarauder");
            this.cmdMarauder.Name = "cmdMarauder";
            this.cmdMarauder.UseVisualStyleBackColor = false;
            this.cmdMarauder.Click += new System.EventHandler(this.Button2Click1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "SC2Hotkeys";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.InitialDirectory = "@%UserProfile%/Starcraft II/";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
            // 
            // cmdUploadHotkey
            // 
            this.cmdUploadHotkey.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.cmdUploadHotkey, "cmdUploadHotkey");
            this.cmdUploadHotkey.Name = "cmdUploadHotkey";
            this.cmdUploadHotkey.UseVisualStyleBackColor = false;
            this.cmdUploadHotkey.Click += new System.EventHandler(this.CmdUploadHotkeyClick);
            // 
            // cmdDisplayHotkeys
            // 
            this.cmdDisplayHotkeys.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.cmdDisplayHotkeys, "cmdDisplayHotkeys");
            this.cmdDisplayHotkeys.Name = "cmdDisplayHotkeys";
            this.cmdDisplayHotkeys.UseVisualStyleBackColor = false;
            // 
            // btnCtrl4
            // 
            this.btnCtrl4.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl4.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl4.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl4, "btnCtrl4");
            this.btnCtrl4.Name = "btnCtrl4";
            this.btnCtrl4.UseVisualStyleBackColor = false;
            this.btnCtrl4.Click += new System.EventHandler(this.BtnCtrl4Click);
            // 
            // btnCtrl3
            // 
            this.btnCtrl3.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl3.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl3.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl3, "btnCtrl3");
            this.btnCtrl3.Name = "btnCtrl3";
            this.btnCtrl3.UseVisualStyleBackColor = false;
            this.btnCtrl3.Click += new System.EventHandler(this.BtnCtrl3Click);
            // 
            // btnCtrl6
            // 
            this.btnCtrl6.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl6.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl6.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl6, "btnCtrl6");
            this.btnCtrl6.Name = "btnCtrl6";
            this.btnCtrl6.UseVisualStyleBackColor = false;
            this.btnCtrl6.Click += new System.EventHandler(this.BtnCtrl6Click);
            // 
            // btnCtrl5
            // 
            this.btnCtrl5.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl5.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl5.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl5, "btnCtrl5");
            this.btnCtrl5.Name = "btnCtrl5";
            this.btnCtrl5.UseVisualStyleBackColor = false;
            this.btnCtrl5.Click += new System.EventHandler(this.BtnCtrl5Click);
            // 
            // btnCtrl8
            // 
            this.btnCtrl8.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl8.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl8.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl8, "btnCtrl8");
            this.btnCtrl8.Name = "btnCtrl8";
            this.btnCtrl8.UseVisualStyleBackColor = false;
            this.btnCtrl8.Click += new System.EventHandler(this.BtnCtrl8Click);
            // 
            // btnCtrl7
            // 
            this.btnCtrl7.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl7.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl7.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl7, "btnCtrl7");
            this.btnCtrl7.Name = "btnCtrl7";
            this.btnCtrl7.UseVisualStyleBackColor = false;
            this.btnCtrl7.Click += new System.EventHandler(this.BtnCtrl7Click);
            // 
            // btnCtrl0
            // 
            this.btnCtrl0.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl0.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl0.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl0, "btnCtrl0");
            this.btnCtrl0.Name = "btnCtrl0";
            this.btnCtrl0.UseVisualStyleBackColor = false;
            this.btnCtrl0.Click += new System.EventHandler(this.BtnCtrl0Click);
            // 
            // btnCtrl9
            // 
            this.btnCtrl9.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtrl9.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCtrl9.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnCtrl9, "btnCtrl9");
            this.btnCtrl9.Name = "btnCtrl9";
            this.btnCtrl9.UseVisualStyleBackColor = false;
            this.btnCtrl9.Click += new System.EventHandler(this.BtnCtrl9Click);
            // 
            // cbRace
            // 
            resources.ApplyResources(this.cbRace, "cbRace");
            this.cbRace.FormattingEnabled = true;
            this.cbRace.Items.AddRange(new object[] {
            resources.GetString("cbRace.Items")});
            this.cbRace.Name = "cbRace";
            // 
            // btnSCV
            // 
            this.btnSCV.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSCV.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnSCV.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btnSCV, "btnSCV");
            this.btnSCV.Name = "btnSCV";
            this.btnSCV.UseVisualStyleBackColor = false;
            this.btnSCV.Click += new System.EventHandler(this.BtnScvClick);
            // 
            // cmdTab
            // 
            this.cmdTab.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdTab.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdTab.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdTab, "cmdTab");
            this.cmdTab.Name = "cmdTab";
            this.cmdTab.UseVisualStyleBackColor = false;
            this.cmdTab.Click += new System.EventHandler(this.CmdTabClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // lblBase0M
            // 
            this.lblBase0M.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase0M, "lblBase0M");
            this.lblBase0M.ForeColor = System.Drawing.Color.White;
            this.lblBase0M.Name = "lblBase0M";
            // 
            // lblBase0G1
            // 
            this.lblBase0G1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase0G1, "lblBase0G1");
            this.lblBase0G1.ForeColor = System.Drawing.Color.White;
            this.lblBase0G1.Name = "lblBase0G1";
            // 
            // lblBase0G2
            // 
            this.lblBase0G2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase0G2, "lblBase0G2");
            this.lblBase0G2.ForeColor = System.Drawing.Color.White;
            this.lblBase0G2.Name = "lblBase0G2";
            // 
            // lblBase1G2
            // 
            this.lblBase1G2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase1G2, "lblBase1G2");
            this.lblBase1G2.ForeColor = System.Drawing.Color.White;
            this.lblBase1G2.Name = "lblBase1G2";
            // 
            // lblBase1G1
            // 
            this.lblBase1G1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase1G1, "lblBase1G1");
            this.lblBase1G1.ForeColor = System.Drawing.Color.White;
            this.lblBase1G1.Name = "lblBase1G1";
            // 
            // lblBase1M
            // 
            this.lblBase1M.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase1M, "lblBase1M");
            this.lblBase1M.ForeColor = System.Drawing.Color.White;
            this.lblBase1M.Name = "lblBase1M";
            // 
            // lblBase2G2
            // 
            this.lblBase2G2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase2G2, "lblBase2G2");
            this.lblBase2G2.ForeColor = System.Drawing.Color.White;
            this.lblBase2G2.Name = "lblBase2G2";
            // 
            // lblBase2G1
            // 
            this.lblBase2G1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase2G1, "lblBase2G1");
            this.lblBase2G1.ForeColor = System.Drawing.Color.White;
            this.lblBase2G1.Name = "lblBase2G1";
            // 
            // lblBase2M
            // 
            this.lblBase2M.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase2M, "lblBase2M");
            this.lblBase2M.ForeColor = System.Drawing.Color.White;
            this.lblBase2M.Name = "lblBase2M";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Maximum = 12358;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Step = 33;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.Maximum = 12358;
            this.progressBar2.Name = "progressBar2";
            // 
            // progressBar3
            // 
            this.progressBar3.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.progressBar3, "progressBar3");
            this.progressBar3.Maximum = 12358;
            this.progressBar3.Name = "progressBar3";
            // 
            // lblBase0QueTime
            // 
            resources.ApplyResources(this.lblBase0QueTime, "lblBase0QueTime");
            this.lblBase0QueTime.BackColor = System.Drawing.Color.Black;
            this.lblBase0QueTime.ForeColor = System.Drawing.Color.White;
            this.lblBase0QueTime.Name = "lblBase0QueTime";
            // 
            // lblBase0QueCount
            // 
            resources.ApplyResources(this.lblBase0QueCount, "lblBase0QueCount");
            this.lblBase0QueCount.BackColor = System.Drawing.Color.Black;
            this.lblBase0QueCount.ForeColor = System.Drawing.Color.White;
            this.lblBase0QueCount.Name = "lblBase0QueCount";
            // 
            // lblBase1QueCount
            // 
            resources.ApplyResources(this.lblBase1QueCount, "lblBase1QueCount");
            this.lblBase1QueCount.BackColor = System.Drawing.Color.Black;
            this.lblBase1QueCount.ForeColor = System.Drawing.Color.White;
            this.lblBase1QueCount.Name = "lblBase1QueCount";
            // 
            // lblBase1QueTime
            // 
            resources.ApplyResources(this.lblBase1QueTime, "lblBase1QueTime");
            this.lblBase1QueTime.BackColor = System.Drawing.Color.Black;
            this.lblBase1QueTime.ForeColor = System.Drawing.Color.White;
            this.lblBase1QueTime.Name = "lblBase1QueTime";
            // 
            // lblBase2QueCount
            // 
            resources.ApplyResources(this.lblBase2QueCount, "lblBase2QueCount");
            this.lblBase2QueCount.BackColor = System.Drawing.Color.Black;
            this.lblBase2QueCount.ForeColor = System.Drawing.Color.White;
            this.lblBase2QueCount.Name = "lblBase2QueCount";
            // 
            // lblBase2QueTime
            // 
            resources.ApplyResources(this.lblBase2QueTime, "lblBase2QueTime");
            this.lblBase2QueTime.BackColor = System.Drawing.Color.Black;
            this.lblBase2QueTime.ForeColor = System.Drawing.Color.White;
            this.lblBase2QueTime.Name = "lblBase2QueTime";
            // 
            // pbPlaceBuilding
            // 
            this.pbPlaceBuilding.BackgroundImage = global::SC2Trainer.Properties.Resources.buildUnitBackground;
            resources.ApplyResources(this.pbPlaceBuilding, "pbPlaceBuilding");
            this.pbPlaceBuilding.Name = "pbPlaceBuilding";
            this.pbPlaceBuilding.TabStop = false;
            this.pbPlaceBuilding.Click += new System.EventHandler(this.PbPlaceBuildingMouseClick);
            // 
            // pbAbil2
            // 
            this.pbAbil2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil2, "pbAbil2");
            this.pbAbil2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil2.Name = "pbAbil2";
            this.pbAbil2.TabStop = false;
            // 
            // pbAbil3
            // 
            this.pbAbil3.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil3, "pbAbil3");
            this.pbAbil3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil3.Name = "pbAbil3";
            this.pbAbil3.TabStop = false;
            this.pbAbil3.Click += new System.EventHandler(this.PbAbil3Click);
            this.pbAbil3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbAbil3MouseDown);
            this.pbAbil3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbAbil3MouseUp);
            // 
            // pbAbil4
            // 
            this.pbAbil4.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil4, "pbAbil4");
            this.pbAbil4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil4.Name = "pbAbil4";
            this.pbAbil4.TabStop = false;
            // 
            // pbAbil5
            // 
            this.pbAbil5.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil5, "pbAbil5");
            this.pbAbil5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil5.Name = "pbAbil5";
            this.pbAbil5.TabStop = false;
            // 
            // pbAbil1
            // 
            this.pbAbil1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil1, "pbAbil1");
            this.pbAbil1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil1.Name = "pbAbil1";
            this.pbAbil1.TabStop = false;
            this.pbAbil1.Click += new System.EventHandler(this.PbAbil1Click);
            this.pbAbil1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbAbil1MouseDown);
            this.pbAbil1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbAbil1MouseUp);
            // 
            // pbAbil6
            // 
            this.pbAbil6.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil6, "pbAbil6");
            this.pbAbil6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil6.Name = "pbAbil6";
            this.pbAbil6.TabStop = false;
            this.pbAbil6.Click += new System.EventHandler(this.PbAbil6Click);
            this.pbAbil6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbAbil6MouseDown);
            this.pbAbil6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbAbil6MouseUp);
            // 
            // pbAbil7
            // 
            this.pbAbil7.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil7, "pbAbil7");
            this.pbAbil7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil7.Name = "pbAbil7";
            this.pbAbil7.TabStop = false;
            // 
            // pbAbil8
            // 
            this.pbAbil8.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil8, "pbAbil8");
            this.pbAbil8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil8.Name = "pbAbil8";
            this.pbAbil8.TabStop = false;
            // 
            // pbAbil9
            // 
            this.pbAbil9.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil9, "pbAbil9");
            this.pbAbil9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil9.Name = "pbAbil9";
            this.pbAbil9.TabStop = false;
            // 
            // pbAbil10
            // 
            this.pbAbil10.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil10, "pbAbil10");
            this.pbAbil10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil10.Name = "pbAbil10";
            this.pbAbil10.TabStop = false;
            // 
            // pbAbil11
            // 
            this.pbAbil11.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil11, "pbAbil11");
            this.pbAbil11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil11.Name = "pbAbil11";
            this.pbAbil11.TabStop = false;
            this.pbAbil11.Click += new System.EventHandler(this.PbAbil11Click);
            this.pbAbil11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbAbil11MouseDown);
            this.pbAbil11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbAbil11MouseUp);
            // 
            // pbAbil12
            // 
            this.pbAbil12.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil12, "pbAbil12");
            this.pbAbil12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil12.Name = "pbAbil12";
            this.pbAbil12.TabStop = false;
            this.pbAbil12.Click += new System.EventHandler(this.PbAbil12Click);
            this.pbAbil12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbAbil12MouseDown);
            this.pbAbil12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbAbil12MouseUp);
            // 
            // pbAbil13
            // 
            this.pbAbil13.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil13, "pbAbil13");
            this.pbAbil13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil13.Name = "pbAbil13";
            this.pbAbil13.TabStop = false;
            // 
            // pbAbil14
            // 
            this.pbAbil14.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil14, "pbAbil14");
            this.pbAbil14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil14.Name = "pbAbil14";
            this.pbAbil14.TabStop = false;
            // 
            // pbAbil15
            // 
            this.pbAbil15.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbAbil15, "pbAbil15");
            this.pbAbil15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbil15.Name = "pbAbil15";
            this.pbAbil15.TabStop = false;
            // 
            // lblBase2G2Icon
            // 
            this.lblBase2G2Icon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.lblBase2G2Icon, "lblBase2G2Icon");
            this.lblBase2G2Icon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.lblBase2G2Icon.Name = "lblBase2G2Icon";
            this.lblBase2G2Icon.TabStop = false;
            // 
            // lblBase2G1Icon
            // 
            this.lblBase2G1Icon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.lblBase2G1Icon, "lblBase2G1Icon");
            this.lblBase2G1Icon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.lblBase2G1Icon.Name = "lblBase2G1Icon";
            this.lblBase2G1Icon.TabStop = false;
            // 
            // lblBase2MIcon
            // 
            this.lblBase2MIcon.BackColor = System.Drawing.Color.BlanchedAlmond;
            resources.ApplyResources(this.lblBase2MIcon, "lblBase2MIcon");
            this.lblBase2MIcon.Image = global::SC2Trainer.Properties.Resources.mineralIcon;
            this.lblBase2MIcon.Name = "lblBase2MIcon";
            this.lblBase2MIcon.TabStop = false;
            // 
            // pbBase2
            // 
            this.pbBase2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbBase2.BackgroundImage = global::SC2Trainer.Properties.Resources.T_cc_Picture;
            resources.ApplyResources(this.pbBase2, "pbBase2");
            this.pbBase2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBase2.Image = global::SC2Trainer.Properties.Resources.T_cc_Picture;
            this.pbBase2.Name = "pbBase2";
            this.pbBase2.TabStop = false;
            // 
            // lblBase1G2Icon
            // 
            this.lblBase1G2Icon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.lblBase1G2Icon, "lblBase1G2Icon");
            this.lblBase1G2Icon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.lblBase1G2Icon.Name = "lblBase1G2Icon";
            this.lblBase1G2Icon.TabStop = false;
            // 
            // lblBase1G1Icon
            // 
            this.lblBase1G1Icon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.lblBase1G1Icon, "lblBase1G1Icon");
            this.lblBase1G1Icon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.lblBase1G1Icon.Name = "lblBase1G1Icon";
            this.lblBase1G1Icon.TabStop = false;
            // 
            // lblBase1MIcon
            // 
            this.lblBase1MIcon.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblBase1MIcon, "lblBase1MIcon");
            this.lblBase1MIcon.Image = global::SC2Trainer.Properties.Resources.mineralIcon;
            this.lblBase1MIcon.Name = "lblBase1MIcon";
            this.lblBase1MIcon.TabStop = false;
            // 
            // pbBase1
            // 
            this.pbBase1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbBase1.BackgroundImage = global::SC2Trainer.Properties.Resources.T_cc_Picture;
            resources.ApplyResources(this.pbBase1, "pbBase1");
            this.pbBase1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBase1.Image = global::SC2Trainer.Properties.Resources.T_cc_Picture;
            this.pbBase1.Name = "pbBase1";
            this.pbBase1.TabStop = false;
            // 
            // lblBase0G2Icon
            // 
            this.lblBase0G2Icon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.lblBase0G2Icon, "lblBase0G2Icon");
            this.lblBase0G2Icon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.lblBase0G2Icon.Name = "lblBase0G2Icon";
            this.lblBase0G2Icon.TabStop = false;
            // 
            // lblBase0G1Icon
            // 
            this.lblBase0G1Icon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.lblBase0G1Icon, "lblBase0G1Icon");
            this.lblBase0G1Icon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.lblBase0G1Icon.Name = "lblBase0G1Icon";
            this.lblBase0G1Icon.TabStop = false;
            // 
            // lblBase0MIcon
            // 
            this.lblBase0MIcon.BackColor = System.Drawing.Color.Black;
            this.lblBase0MIcon.Image = global::SC2Trainer.Properties.Resources.mineralIcon;
            resources.ApplyResources(this.lblBase0MIcon, "lblBase0MIcon");
            this.lblBase0MIcon.Name = "lblBase0MIcon";
            this.lblBase0MIcon.TabStop = false;
            // 
            // pictureBox34
            // 
            this.pictureBox34.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox34.BackgroundImage = global::SC2Trainer.Properties.Resources.T_supplyIcon;
            resources.ApplyResources(this.pictureBox34, "pictureBox34");
            this.pictureBox34.Image = global::SC2Trainer.Properties.Resources.T_supplyIcon;
            this.pictureBox34.Name = "pictureBox34";
            this.pictureBox34.TabStop = false;
            // 
            // pbGasIcon
            // 
            this.pbGasIcon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.pbGasIcon, "pbGasIcon");
            this.pbGasIcon.Image = global::SC2Trainer.Properties.Resources.gasIcon;
            this.pbGasIcon.Name = "pbGasIcon";
            this.pbGasIcon.TabStop = false;
            this.pbGasIcon.Click += new System.EventHandler(this.PbGasIconClick);
            // 
            // pbMineralIcon
            // 
            this.pbMineralIcon.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.pbMineralIcon, "pbMineralIcon");
            this.pbMineralIcon.Image = global::SC2Trainer.Properties.Resources.mineralIcon;
            this.pbMineralIcon.Name = "pbMineralIcon";
            this.pbMineralIcon.TabStop = false;
            // 
            // pbBase0
            // 
            this.pbBase0.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbBase0.BackgroundImage = global::SC2Trainer.Properties.Resources.T_cc_Picture;
            resources.ApplyResources(this.pbBase0, "pbBase0");
            this.pbBase0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBase0.Image = global::SC2Trainer.Properties.Resources.T_cc_Picture;
            this.pbBase0.Name = "pbBase0";
            this.pbBase0.TabStop = false;
            this.pbBase0.Click += new System.EventHandler(this.PbBase1Click);
            // 
            // pbUnit3
            // 
            this.pbUnit3.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit3, "pbUnit3");
            this.pbUnit3.Name = "pbUnit3";
            this.pbUnit3.TabStop = false;
            this.pbUnit3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit5
            // 
            this.pbUnit5.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit5, "pbUnit5");
            this.pbUnit5.Name = "pbUnit5";
            this.pbUnit5.TabStop = false;
            this.pbUnit5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit6
            // 
            this.pbUnit6.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit6, "pbUnit6");
            this.pbUnit6.Name = "pbUnit6";
            this.pbUnit6.TabStop = false;
            this.pbUnit6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit7
            // 
            this.pbUnit7.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit7, "pbUnit7");
            this.pbUnit7.Name = "pbUnit7";
            this.pbUnit7.TabStop = false;
            this.pbUnit7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit8
            // 
            this.pbUnit8.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit8, "pbUnit8");
            this.pbUnit8.Name = "pbUnit8";
            this.pbUnit8.TabStop = false;
            this.pbUnit8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit4
            // 
            this.pbUnit4.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit4, "pbUnit4");
            this.pbUnit4.Name = "pbUnit4";
            this.pbUnit4.TabStop = false;
            this.pbUnit4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit2
            // 
            this.pbUnit2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit2, "pbUnit2");
            this.pbUnit2.Name = "pbUnit2";
            this.pbUnit2.TabStop = false;
            this.pbUnit2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit1
            // 
            this.pbUnit1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit1, "pbUnit1");
            this.pbUnit1.Name = "pbUnit1";
            this.pbUnit1.TabStop = false;
            this.pbUnit1.Click += new System.EventHandler(this.UnitSelectClicked);
            this.pbUnit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit11
            // 
            this.pbUnit11.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit11, "pbUnit11");
            this.pbUnit11.Name = "pbUnit11";
            this.pbUnit11.TabStop = false;
            this.pbUnit11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit12
            // 
            this.pbUnit12.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit12, "pbUnit12");
            this.pbUnit12.Name = "pbUnit12";
            this.pbUnit12.TabStop = false;
            this.pbUnit12.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit13
            // 
            this.pbUnit13.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit13, "pbUnit13");
            this.pbUnit13.Name = "pbUnit13";
            this.pbUnit13.TabStop = false;
            this.pbUnit13.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit14
            // 
            this.pbUnit14.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit14, "pbUnit14");
            this.pbUnit14.Name = "pbUnit14";
            this.pbUnit14.TabStop = false;
            this.pbUnit14.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit15
            // 
            this.pbUnit15.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit15, "pbUnit15");
            this.pbUnit15.Name = "pbUnit15";
            this.pbUnit15.TabStop = false;
            this.pbUnit15.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit16
            // 
            this.pbUnit16.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit16, "pbUnit16");
            this.pbUnit16.Name = "pbUnit16";
            this.pbUnit16.TabStop = false;
            this.pbUnit16.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit10
            // 
            this.pbUnit10.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit10, "pbUnit10");
            this.pbUnit10.Name = "pbUnit10";
            this.pbUnit10.TabStop = false;
            this.pbUnit10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit9
            // 
            this.pbUnit9.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit9, "pbUnit9");
            this.pbUnit9.Name = "pbUnit9";
            this.pbUnit9.TabStop = false;
            this.pbUnit9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit19
            // 
            this.pbUnit19.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit19, "pbUnit19");
            this.pbUnit19.Name = "pbUnit19";
            this.pbUnit19.TabStop = false;
            this.pbUnit19.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit20
            // 
            this.pbUnit20.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit20, "pbUnit20");
            this.pbUnit20.Name = "pbUnit20";
            this.pbUnit20.TabStop = false;
            this.pbUnit20.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit21
            // 
            this.pbUnit21.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit21, "pbUnit21");
            this.pbUnit21.Name = "pbUnit21";
            this.pbUnit21.TabStop = false;
            this.pbUnit21.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit22
            // 
            this.pbUnit22.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit22, "pbUnit22");
            this.pbUnit22.Name = "pbUnit22";
            this.pbUnit22.TabStop = false;
            this.pbUnit22.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit22.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit23
            // 
            this.pbUnit23.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit23, "pbUnit23");
            this.pbUnit23.Name = "pbUnit23";
            this.pbUnit23.TabStop = false;
            this.pbUnit23.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit23.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit24
            // 
            this.pbUnit24.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit24, "pbUnit24");
            this.pbUnit24.Name = "pbUnit24";
            this.pbUnit24.TabStop = false;
            this.pbUnit24.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit24.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit18
            // 
            this.pbUnit18.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit18, "pbUnit18");
            this.pbUnit18.Name = "pbUnit18";
            this.pbUnit18.TabStop = false;
            this.pbUnit18.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // pbUnit17
            // 
            this.pbUnit17.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pbUnit17, "pbUnit17");
            this.pbUnit17.Name = "pbUnit17";
            this.pbUnit17.TabStop = false;
            this.pbUnit17.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbUnit3MouseClick);
            this.pbUnit17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitSelectClicked);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1KeyDown);
            // 
            // lstSupplyDepots
            // 
            this.lstSupplyDepots.FormattingEnabled = true;
            resources.ApplyResources(this.lstSupplyDepots, "lstSupplyDepots");
            this.lstSupplyDepots.Name = "lstSupplyDepots";
            // 
            // cmdLocation2
            // 
            this.cmdLocation2.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation2.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation2, "cmdLocation2");
            this.cmdLocation2.Name = "cmdLocation2";
            this.cmdLocation2.UseVisualStyleBackColor = false;
            this.cmdLocation2.Click += new System.EventHandler(this.CmdLocation2Click);
            // 
            // cmdLocation0
            // 
            this.cmdLocation0.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation0.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation0.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation0, "cmdLocation0");
            this.cmdLocation0.Name = "cmdLocation0";
            this.cmdLocation0.UseVisualStyleBackColor = false;
            this.cmdLocation0.Click += new System.EventHandler(this.cmdLocation0_Click);
            // 
            // cmdLocation1
            // 
            this.cmdLocation1.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation1.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation1, "cmdLocation1");
            this.cmdLocation1.Name = "cmdLocation1";
            this.cmdLocation1.UseVisualStyleBackColor = false;
            this.cmdLocation1.Click += new System.EventHandler(this.cmdLocation1_Click);
            // 
            // cmdLocation7
            // 
            this.cmdLocation7.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation7.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation7.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation7, "cmdLocation7");
            this.cmdLocation7.Name = "cmdLocation7";
            this.cmdLocation7.UseVisualStyleBackColor = false;
            this.cmdLocation7.Click += new System.EventHandler(this.CmdLocation7Click);
            // 
            // cmdLocation6
            // 
            this.cmdLocation6.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation6.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation6.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation6, "cmdLocation6");
            this.cmdLocation6.Name = "cmdLocation6";
            this.cmdLocation6.UseVisualStyleBackColor = false;
            this.cmdLocation6.Click += new System.EventHandler(this.CmdLocation6Click);
            // 
            // cmdLocation5
            // 
            this.cmdLocation5.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation5.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation5.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation5, "cmdLocation5");
            this.cmdLocation5.Name = "cmdLocation5";
            this.cmdLocation5.UseVisualStyleBackColor = false;
            this.cmdLocation5.Click += new System.EventHandler(this.CmdLocation5Click);
            // 
            // cmdLocation4
            // 
            this.cmdLocation4.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation4.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation4.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation4, "cmdLocation4");
            this.cmdLocation4.Name = "cmdLocation4";
            this.cmdLocation4.UseVisualStyleBackColor = false;
            this.cmdLocation4.Click += new System.EventHandler(this.CmdLocation4Click);
            // 
            // cmdLocation3
            // 
            this.cmdLocation3.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation3.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation3.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation3, "cmdLocation3");
            this.cmdLocation3.Name = "cmdLocation3";
            this.cmdLocation3.UseVisualStyleBackColor = false;
            this.cmdLocation3.Click += new System.EventHandler(this.CmdLocation3Click);
            // 
            // cmdLocation8
            // 
            this.cmdLocation8.BackColor = System.Drawing.Color.Blue;
            this.cmdLocation8.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdLocation8.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdLocation8, "cmdLocation8");
            this.cmdLocation8.Name = "cmdLocation8";
            this.cmdLocation8.UseVisualStyleBackColor = false;
            this.cmdLocation8.Click += new System.EventHandler(this.CmdLocation8Click);
            // 
            // lbllocationtest
            // 
            resources.ApplyResources(this.lbllocationtest, "lbllocationtest");
            this.lbllocationtest.Name = "lbllocationtest";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmdBase0M
            // 
            this.cmdBase0M.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdBase0M.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdBase0M.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdBase0M, "cmdBase0M");
            this.cmdBase0M.Name = "cmdBase0M";
            this.cmdBase0M.UseVisualStyleBackColor = false;
            this.cmdBase0M.Click += new System.EventHandler(this.CmdBase0MClick);
            // 
            // cmdBase0G1
            // 
            this.cmdBase0G1.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdBase0G1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdBase0G1.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdBase0G1, "cmdBase0G1");
            this.cmdBase0G1.Name = "cmdBase0G1";
            this.cmdBase0G1.UseVisualStyleBackColor = false;
            // 
            // cmdBase0G2
            // 
            this.cmdBase0G2.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdBase0G2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.cmdBase0G2.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.cmdBase0G2, "cmdBase0G2");
            this.cmdBase0G2.Name = "cmdBase0G2";
            this.cmdBase0G2.UseVisualStyleBackColor = false;
            // 
            // txtWorkerRally
            // 
            resources.ApplyResources(this.txtWorkerRally, "txtWorkerRally");
            this.txtWorkerRally.Name = "txtWorkerRally";
            this.txtWorkerRally.TextChanged += new System.EventHandler(this.TxtWorkerRallyTextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cbScvState
            // 
            this.cbScvState.FormattingEnabled = true;
            this.cbScvState.Items.AddRange(new object[] {
            resources.GetString("cbScvState.Items"),
            resources.GetString("cbScvState.Items1"),
            resources.GetString("cbScvState.Items2")});
            resources.ApplyResources(this.cbScvState, "cbScvState");
            this.cbScvState.Name = "cbScvState";
            // 
            // lblTestWatch
            // 
            resources.ApplyResources(this.lblTestWatch, "lblTestWatch");
            this.lblTestWatch.BackColor = System.Drawing.Color.Black;
            this.lblTestWatch.ForeColor = System.Drawing.Color.White;
            this.lblTestWatch.Name = "lblTestWatch";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lstErrors
            // 
            this.lstErrors.FormattingEnabled = true;
            resources.ApplyResources(this.lstErrors, "lstErrors");
            this.lstErrors.Name = "lstErrors";
            // 
            // txtErrors
            // 
            resources.ApplyResources(this.txtErrors, "txtErrors");
            this.txtErrors.Name = "txtErrors";
            // 
            // lstSpeedTest
            // 
            this.lstSpeedTest.FormattingEnabled = true;
            resources.ApplyResources(this.lstSpeedTest, "lstSpeedTest");
            this.lstSpeedTest.Name = "lstSpeedTest";
            // 
            // TrainerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lstSpeedTest);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTestWatch);
            this.Controls.Add(this.cbScvState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWorkerRally);
            this.Controls.Add(this.cmdBase0G2);
            this.Controls.Add(this.cmdBase0G1);
            this.Controls.Add(this.cmdBase0M);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbllocationtest);
            this.Controls.Add(this.cmdLocation8);
            this.Controls.Add(this.cmdLocation3);
            this.Controls.Add(this.cmdLocation4);
            this.Controls.Add(this.cmdLocation5);
            this.Controls.Add(this.cmdLocation6);
            this.Controls.Add(this.cmdLocation7);
            this.Controls.Add(this.cmdLocation1);
            this.Controls.Add(this.cmdLocation0);
            this.Controls.Add(this.cmdLocation2);
            this.Controls.Add(this.lstSupplyDepots);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbPlaceBuilding);
            this.Controls.Add(this.lblBase2QueCount);
            this.Controls.Add(this.lblBase2QueTime);
            this.Controls.Add(this.lblBase1QueCount);
            this.Controls.Add(this.lblBase1QueTime);
            this.Controls.Add(this.lblBase0QueCount);
            this.Controls.Add(this.lblBase0QueTime);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pbAbil2);
            this.Controls.Add(this.pbAbil3);
            this.Controls.Add(this.pbAbil4);
            this.Controls.Add(this.pbAbil5);
            this.Controls.Add(this.pbAbil1);
            this.Controls.Add(this.pbAbil6);
            this.Controls.Add(this.pbAbil7);
            this.Controls.Add(this.pbAbil8);
            this.Controls.Add(this.pbAbil9);
            this.Controls.Add(this.pbAbil10);
            this.Controls.Add(this.pbAbil11);
            this.Controls.Add(this.pbAbil12);
            this.Controls.Add(this.pbAbil13);
            this.Controls.Add(this.pbAbil14);
            this.Controls.Add(this.pbAbil15);
            this.Controls.Add(this.lblBase2G2);
            this.Controls.Add(this.lblBase2G1);
            this.Controls.Add(this.lblBase2M);
            this.Controls.Add(this.lblBase2G2Icon);
            this.Controls.Add(this.lblBase2G1Icon);
            this.Controls.Add(this.lblBase2MIcon);
            this.Controls.Add(this.pbBase2);
            this.Controls.Add(this.lblBase1G2);
            this.Controls.Add(this.lblBase1G1);
            this.Controls.Add(this.lblBase1M);
            this.Controls.Add(this.lblBase1G2Icon);
            this.Controls.Add(this.lblBase1G1Icon);
            this.Controls.Add(this.lblBase1MIcon);
            this.Controls.Add(this.pbBase1);
            this.Controls.Add(this.lblBase0G2);
            this.Controls.Add(this.lblBase0G1);
            this.Controls.Add(this.lblBase0M);
            this.Controls.Add(this.lblBase0G2Icon);
            this.Controls.Add(this.lblBase0G1Icon);
            this.Controls.Add(this.lblBase0MIcon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox34);
            this.Controls.Add(this.cmdTab);
            this.Controls.Add(this.btnSCV);
            this.Controls.Add(this.pbGasIcon);
            this.Controls.Add(this.pbMineralIcon);
            this.Controls.Add(this.cbRace);
            this.Controls.Add(this.pbBase0);
            this.Controls.Add(this.btnCtrl0);
            this.Controls.Add(this.btnCtrl9);
            this.Controls.Add(this.btnCtrl8);
            this.Controls.Add(this.btnCtrl7);
            this.Controls.Add(this.btnCtrl6);
            this.Controls.Add(this.btnCtrl5);
            this.Controls.Add(this.btnCtrl4);
            this.Controls.Add(this.btnCtrl3);
            this.Controls.Add(this.cmdDisplayHotkeys);
            this.Controls.Add(this.cmdUploadHotkey);
            this.Controls.Add(this.cmdMarauder);
            this.Controls.Add(this.cmdSelectClear);
            this.Controls.Add(this.cmdSelectAll);
            this.Controls.Add(this.btnCtrl2);
            this.Controls.Add(this.btnCtrl1);
            this.Controls.Add(this.pbUnit3);
            this.Controls.Add(this.pbUnit5);
            this.Controls.Add(this.pbUnit6);
            this.Controls.Add(this.pbUnit7);
            this.Controls.Add(this.pbUnit8);
            this.Controls.Add(this.pbUnit4);
            this.Controls.Add(this.pbUnit2);
            this.Controls.Add(this.pbUnit1);
            this.Controls.Add(this.pbUnit11);
            this.Controls.Add(this.pbUnit12);
            this.Controls.Add(this.pbUnit13);
            this.Controls.Add(this.pbUnit14);
            this.Controls.Add(this.pbUnit15);
            this.Controls.Add(this.pbUnit16);
            this.Controls.Add(this.pbUnit10);
            this.Controls.Add(this.pbUnit9);
            this.Controls.Add(this.pbUnit19);
            this.Controls.Add(this.pbUnit20);
            this.Controls.Add(this.pbUnit21);
            this.Controls.Add(this.pbUnit22);
            this.Controls.Add(this.pbUnit23);
            this.Controls.Add(this.pbUnit24);
            this.Controls.Add(this.pbUnit18);
            this.Controls.Add(this.pbUnit17);
            this.Controls.Add(this.lbltest5);
            this.Controls.Add(this.lblTest3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTest1);
            this.Controls.Add(this.lbltest4);
            this.Controls.Add(this.lblTest2);
            this.Controls.Add(this.lblTestTime);
            this.Controls.Add(this.lblRTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMpm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGpm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStartGas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartMin);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblGas);
            this.Controls.Add(this.lblSupply);
            this.Controls.Add(this.lblMinerals);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdStart);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "TrainerForm";
            this.Load += new System.EventHandler(this.Form1Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrainerFormMouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlaceBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbil15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase2G2Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase2G1Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase2MIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase1G2Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase1G1Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase1MIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase0G2Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase0G1Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBase0MIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGasIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMineralIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnit17)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label lblMinerals;
        private System.Windows.Forms.Label lblSupply;
        private System.Windows.Forms.Label lblGas;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtStartMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartGas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGpm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMpm;
        private System.Windows.Forms.Label lblRTime;
        private System.Windows.Forms.Label label10;
      //  private System.Windows.Forms.Timer tmrUdate;
        private System.Windows.Forms.Label lblTestTime;
        private System.Windows.Forms.PictureBox pbUnit17;
        private System.Windows.Forms.PictureBox pbUnit18;
        private System.Windows.Forms.PictureBox pbUnit24;
        private System.Windows.Forms.PictureBox pbUnit23;
        private System.Windows.Forms.PictureBox pbUnit22;
        private System.Windows.Forms.PictureBox pbUnit21;
        private System.Windows.Forms.PictureBox pbUnit20;
        private System.Windows.Forms.PictureBox pbUnit19;
        private System.Windows.Forms.PictureBox pbUnit11;
        private System.Windows.Forms.PictureBox pbUnit12;
        private System.Windows.Forms.PictureBox pbUnit13;
        private System.Windows.Forms.PictureBox pbUnit14;
        private System.Windows.Forms.PictureBox pbUnit15;
        private System.Windows.Forms.PictureBox pbUnit16;
        private System.Windows.Forms.PictureBox pbUnit10;
        private System.Windows.Forms.PictureBox pbUnit9;
        private System.Windows.Forms.PictureBox pbUnit3;
        private System.Windows.Forms.PictureBox pbUnit5;
        private System.Windows.Forms.PictureBox pbUnit6;
        private System.Windows.Forms.PictureBox pbUnit7;
        private System.Windows.Forms.PictureBox pbUnit8;
        private System.Windows.Forms.PictureBox pbUnit4;
        private System.Windows.Forms.PictureBox pbUnit2;
        private System.Windows.Forms.PictureBox pbUnit1;
        private System.Windows.Forms.Button btnCtrl1;
        private System.Windows.Forms.Button btnCtrl2;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.Label lblTest2;
        private System.Windows.Forms.Label lblTest1;
        private System.Windows.Forms.Button cmdSelectClear;
        private System.Windows.Forms.Label lbltest4;
        private System.Windows.Forms.Label lblTest3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltest5;
        private System.Windows.Forms.Button cmdMarauder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cmdUploadHotkey;
        private System.Windows.Forms.Button cmdDisplayHotkeys;
        private System.Windows.Forms.Button btnCtrl4;
        private System.Windows.Forms.Button btnCtrl3;
        private System.Windows.Forms.Button btnCtrl6;
        private System.Windows.Forms.Button btnCtrl5;
        private System.Windows.Forms.Button btnCtrl8;
        private System.Windows.Forms.Button btnCtrl7;
        private System.Windows.Forms.Button btnCtrl0;
        private System.Windows.Forms.Button btnCtrl9;
        private System.Windows.Forms.PictureBox pbBase0;
        private System.Windows.Forms.ComboBox cbRace;
        private System.Windows.Forms.PictureBox pbMineralIcon;
        private System.Windows.Forms.PictureBox pbGasIcon;
        private System.Windows.Forms.Button btnSCV;
        private System.Windows.Forms.Button cmdTab;
        private System.Windows.Forms.PictureBox pictureBox34;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox lblBase0MIcon;
        private System.Windows.Forms.PictureBox lblBase0G1Icon;
        private System.Windows.Forms.PictureBox lblBase0G2Icon;
        private System.Windows.Forms.Label lblBase0M;
        private System.Windows.Forms.Label lblBase0G1;
        private System.Windows.Forms.Label lblBase0G2;
        private System.Windows.Forms.Label lblBase1G2;
        private System.Windows.Forms.Label lblBase1G1;
        private System.Windows.Forms.Label lblBase1M;
        private System.Windows.Forms.PictureBox lblBase1G2Icon;
        private System.Windows.Forms.PictureBox lblBase1G1Icon;
        private System.Windows.Forms.PictureBox lblBase1MIcon;
        private System.Windows.Forms.PictureBox pbBase1;
        private System.Windows.Forms.Label lblBase2G2;
        private System.Windows.Forms.Label lblBase2G1;
        private System.Windows.Forms.Label lblBase2M;
        private System.Windows.Forms.PictureBox lblBase2G2Icon;
        private System.Windows.Forms.PictureBox lblBase2G1Icon;
        private System.Windows.Forms.PictureBox lblBase2MIcon;
        private System.Windows.Forms.PictureBox pbBase2;
        private System.Windows.Forms.PictureBox pbAbil2;
        private System.Windows.Forms.PictureBox pbAbil3;
        private System.Windows.Forms.PictureBox pbAbil4;
        private System.Windows.Forms.PictureBox pbAbil5;
        private System.Windows.Forms.PictureBox pbAbil1;
        private System.Windows.Forms.PictureBox pbAbil6;
        private System.Windows.Forms.PictureBox pbAbil7;
        private System.Windows.Forms.PictureBox pbAbil8;
        private System.Windows.Forms.PictureBox pbAbil9;
        private System.Windows.Forms.PictureBox pbAbil10;
        private System.Windows.Forms.PictureBox pbAbil11;
        private System.Windows.Forms.PictureBox pbAbil12;
        private System.Windows.Forms.PictureBox pbAbil13;
        private System.Windows.Forms.PictureBox pbAbil14;
        private System.Windows.Forms.PictureBox pbAbil15;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label lblBase0QueTime;
        private System.Windows.Forms.Label lblBase0QueCount;
        private System.Windows.Forms.Label lblBase1QueCount;
        private System.Windows.Forms.Label lblBase1QueTime;
        private System.Windows.Forms.Label lblBase2QueCount;
        private System.Windows.Forms.Label lblBase2QueTime;
        private System.Windows.Forms.PictureBox pbPlaceBuilding;
        private TextBox textBox1;
        private ListBox lstSupplyDepots;
        private Button cmdLocation2;
        private Button cmdLocation0;
        private Button cmdLocation1;
        private Button cmdLocation7;
        private Button cmdLocation6;
        private Button cmdLocation5;
        private Button cmdLocation4;
        private Button cmdLocation3;
        private Button cmdLocation8;
        private Label lbllocationtest;
        private Button button2;
        private Button cmdBase0M;
        private Button cmdBase0G1;
        private Button cmdBase0G2;
        private TextBox txtWorkerRally;
        private Label label1;
        private Label label5;
        private ComboBox cbScvState;
        private Label lblTestWatch;
        private Label label6;
        private ListBox lstErrors;
        private Label txtErrors;
        private ListBox lstSpeedTest;
  
 



    }
}

