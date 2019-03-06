namespace SKPHotel_2._0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgReservations = new System.Windows.Forms.DataGridView();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblIDlabel = new System.Windows.Forms.Label();
            this.cmdBook = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequests = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBeds = new System.Windows.Forms.ComboBox();
            this.Confirmation = new System.Windows.Forms.Label();
            this.cmbBalcony = new System.Windows.Forms.ComboBox();
            this.DTPCheckIn = new System.Windows.Forms.DateTimePicker();
            this.cmbSmoke = new System.Windows.Forms.ComboBox();
            this.DTPCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgReservations)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgReservations
            // 
            this.dgReservations.AllowUserToAddRows = false;
            this.dgReservations.AllowUserToDeleteRows = false;
            this.dgReservations.AllowUserToResizeColumns = false;
            this.dgReservations.AllowUserToResizeRows = false;
            this.dgReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReservations.Location = new System.Drawing.Point(351, 12);
            this.dgReservations.MaximumSize = new System.Drawing.Size(843, 546);
            this.dgReservations.MinimumSize = new System.Drawing.Size(843, 546);
            this.dgReservations.MultiSelect = false;
            this.dgReservations.Name = "dgReservations";
            this.dgReservations.ReadOnly = true;
            this.dgReservations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReservations.Size = new System.Drawing.Size(843, 546);
            this.dgReservations.StandardTab = true;
            this.dgReservations.TabIndex = 69;
            this.dgReservations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReservations_CellClick);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(179, 316);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 9;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.cmdUpdate);
            this.pnlControls.Controls.Add(this.cmdRemove);
            this.pnlControls.Controls.Add(this.lblId);
            this.pnlControls.Controls.Add(this.lblIDlabel);
            this.pnlControls.Controls.Add(this.cmdBook);
            this.pnlControls.Controls.Add(this.txtName);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.txtRequests);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.label8);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.cmbBeds);
            this.pnlControls.Controls.Add(this.Confirmation);
            this.pnlControls.Controls.Add(this.cmbBalcony);
            this.pnlControls.Controls.Add(this.DTPCheckIn);
            this.pnlControls.Controls.Add(this.cmbSmoke);
            this.pnlControls.Controls.Add(this.DTPCheckOut);
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.label6);
            this.pnlControls.Controls.Add(this.label7);
            this.pnlControls.Location = new System.Drawing.Point(-3, 220);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(348, 364);
            this.pnlControls.TabIndex = 71;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(260, 316);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 10;
            this.cmdRemove.Text = "Delete";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(106, 5);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 57;
            this.lblId.Text = "id ";
            // 
            // lblIDlabel
            // 
            this.lblIDlabel.AutoSize = true;
            this.lblIDlabel.Location = new System.Drawing.Point(14, 5);
            this.lblIDlabel.Name = "lblIDlabel";
            this.lblIDlabel.Size = new System.Drawing.Size(21, 13);
            this.lblIDlabel.TabIndex = 56;
            this.lblIDlabel.Text = "ID:";
            // 
            // cmdBook
            // 
            this.cmdBook.Location = new System.Drawing.Point(13, 316);
            this.cmdBook.Name = "cmdBook";
            this.cmdBook.Size = new System.Drawing.Size(121, 23);
            this.cmdBook.TabIndex = 8;
            this.cmdBook.Text = "Book";
            this.cmdBook.UseVisualStyleBackColor = true;
            this.cmdBook.Click += new System.EventHandler(this.cmdBook_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Requests  *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(14, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Check Out";
            // 
            // txtRequests
            // 
            this.txtRequests.Location = new System.Drawing.Point(106, 226);
            this.txtRequests.Name = "txtRequests";
            this.txtRequests.Size = new System.Drawing.Size(180, 20);
            this.txtRequests.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Check In";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "*50 characters or less";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Name *";
            // 
            // cmbBeds
            // 
            this.cmbBeds.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3(2 beds 1 cot)"});
            this.cmbBeds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBeds.FormattingEnabled = true;
            this.cmbBeds.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbBeds.Items.AddRange(new object[] {
            "1",
            "2",
            "3( 2 bed 1 cot)"});
            this.cmbBeds.Location = new System.Drawing.Point(106, 130);
            this.cmbBeds.Name = "cmbBeds";
            this.cmbBeds.Size = new System.Drawing.Size(176, 21);
            this.cmbBeds.TabIndex = 4;
            // 
            // Confirmation
            // 
            this.Confirmation.AutoSize = true;
            this.Confirmation.ForeColor = System.Drawing.Color.Black;
            this.Confirmation.Location = new System.Drawing.Point(93, 121);
            this.Confirmation.Name = "Confirmation";
            this.Confirmation.Size = new System.Drawing.Size(0, 13);
            this.Confirmation.TabIndex = 42;
            // 
            // cmbBalcony
            // 
            this.cmbBalcony.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalcony.FormattingEnabled = true;
            this.cmbBalcony.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbBalcony.Location = new System.Drawing.Point(106, 98);
            this.cmbBalcony.Name = "cmbBalcony";
            this.cmbBalcony.Size = new System.Drawing.Size(176, 21);
            this.cmbBalcony.TabIndex = 3;
            // 
            // DTPCheckIn
            // 
            this.DTPCheckIn.Location = new System.Drawing.Point(106, 159);
            this.DTPCheckIn.Name = "DTPCheckIn";
            this.DTPCheckIn.Size = new System.Drawing.Size(180, 20);
            this.DTPCheckIn.TabIndex = 5;
            // 
            // cmbSmoke
            // 
            this.cmbSmoke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmoke.FormattingEnabled = true;
            this.cmbSmoke.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbSmoke.Location = new System.Drawing.Point(106, 66);
            this.cmbSmoke.Name = "cmbSmoke";
            this.cmbSmoke.Size = new System.Drawing.Size(176, 21);
            this.cmbSmoke.TabIndex = 2;
            // 
            // DTPCheckOut
            // 
            this.DTPCheckOut.Location = new System.Drawing.Point(106, 191);
            this.DTPCheckOut.Name = "DTPCheckOut";
            this.DTPCheckOut.Size = new System.Drawing.Size(180, 20);
            this.DTPCheckOut.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Balcony";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "# of Beds";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Smoking";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SKPHotel_2._0.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 201);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 571);
            this.Controls.Add(this.dgReservations);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SKP Hotel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgReservations)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgReservations;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblIDlabel;
        private System.Windows.Forms.Button cmdBook;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBeds;
        private System.Windows.Forms.Label Confirmation;
        private System.Windows.Forms.ComboBox cmbBalcony;
        private System.Windows.Forms.DateTimePicker DTPCheckIn;
        private System.Windows.Forms.ComboBox cmbSmoke;
        private System.Windows.Forms.DateTimePicker DTPCheckOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

