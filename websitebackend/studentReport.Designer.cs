namespace websitebackend
{
    partial class studentReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.secondpanel = new System.Windows.Forms.Panel();
            this.txtlastname = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtfirstname = new System.Windows.Forms.ComboBox();
            this.txttodate = new System.Windows.Forms.DateTimePicker();
            this.txtfromdate = new System.Windows.Forms.DateTimePicker();
            this.btnsearchclick = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dataload = new System.Windows.Forms.DataGridView();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.secondpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataload)).BeginInit();
            this.SuspendLayout();
            // 
            // secondpanel
            // 
            this.secondpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondpanel.Controls.Add(this.txtlastname);
            this.secondpanel.Controls.Add(this.label47);
            this.secondpanel.Controls.Add(this.txtfirstname);
            this.secondpanel.Controls.Add(this.txttodate);
            this.secondpanel.Controls.Add(this.txtfromdate);
            this.secondpanel.Controls.Add(this.btnsearchclick);
            this.secondpanel.Controls.Add(this.label2);
            this.secondpanel.Controls.Add(this.label1);
            this.secondpanel.Controls.Add(this.label19);
            this.secondpanel.Location = new System.Drawing.Point(82, 111);
            this.secondpanel.Name = "secondpanel";
            this.secondpanel.Size = new System.Drawing.Size(1012, 47);
            this.secondpanel.TabIndex = 176;
            // 
            // txtlastname
            // 
            this.txtlastname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txtlastname.FormattingEnabled = true;
            this.txtlastname.Location = new System.Drawing.Point(344, 6);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(180, 26);
            this.txtlastname.TabIndex = 221;
            this.txtlastname.SelectionChangeCommitted += new System.EventHandler(this.txtlastname_SelectionChangeCommitted);
            this.txtlastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlastname_KeyDown);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(257, 12);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(85, 16);
            this.label47.TabIndex = 185;
            this.label47.Text = "Last Name";
            // 
            // txtfirstname
            // 
            this.txtfirstname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txtfirstname.FormattingEnabled = true;
            this.txtfirstname.Location = new System.Drawing.Point(59, 6);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(192, 26);
            this.txtfirstname.TabIndex = 220;
            this.txtfirstname.SelectionChangeCommitted += new System.EventHandler(this.txtfirstname_SelectionChangeCommitted);
            this.txtfirstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfirstname_KeyDown);
            // 
            // txttodate
            // 
            this.txttodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txttodate.Location = new System.Drawing.Point(806, 12);
            this.txttodate.Name = "txttodate";
            this.txttodate.Size = new System.Drawing.Size(98, 20);
            this.txttodate.TabIndex = 182;
            // 
            // txtfromdate
            // 
            this.txtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfromdate.Location = new System.Drawing.Point(628, 12);
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.Size = new System.Drawing.Size(98, 20);
            this.txtfromdate.TabIndex = 183;
            // 
            // btnsearchclick
            // 
            this.btnsearchclick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnsearchclick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearchclick.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearchclick.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnsearchclick.Location = new System.Drawing.Point(910, 4);
            this.btnsearchclick.Name = "btnsearchclick";
            this.btnsearchclick.Size = new System.Drawing.Size(91, 38);
            this.btnsearchclick.TabIndex = 182;
            this.btnsearchclick.Text = "Search";
            this.btnsearchclick.UseVisualStyleBackColor = false;
            this.btnsearchclick.Click += new System.EventHandler(this.btnsearchclick_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(725, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 180;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 180;
            this.label1.Text = "Name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(526, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 18);
            this.label19.TabIndex = 181;
            this.label19.Text = "From Date";
            // 
            // dataload
            // 
            this.dataload.AllowUserToAddRows = false;
            this.dataload.AllowUserToDeleteRows = false;
            this.dataload.AllowUserToResizeColumns = false;
            this.dataload.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataload.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataload.BackgroundColor = System.Drawing.Color.White;
            this.dataload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataload.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataload.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataload.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataload.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataload.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataload.EnableHeadersVisualStyles = false;
            this.dataload.GridColor = System.Drawing.Color.DarkOrange;
            this.dataload.Location = new System.Drawing.Point(82, 164);
            this.dataload.MultiSelect = false;
            this.dataload.Name = "dataload";
            this.dataload.RowHeadersVisible = false;
            this.dataload.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataload.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataload.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataload.ShowCellErrors = false;
            this.dataload.ShowEditingIcon = false;
            this.dataload.ShowRowErrors = false;
            this.dataload.Size = new System.Drawing.Size(1207, 453);
            this.dataload.StandardTab = true;
            this.dataload.TabIndex = 226;
            this.dataload.Visible = false;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncancel.Location = new System.Drawing.Point(1198, 115);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(91, 38);
            this.btncancel.TabIndex = 228;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExport.Location = new System.Drawing.Point(1095, 115);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 38);
            this.btnExport.TabIndex = 227;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // studentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataload);
            this.Controls.Add(this.secondpanel);
            this.Name = "studentReport";
            this.Text = "Student Report";
            this.Load += new System.EventHandler(this.studentReport_Load);
            this.secondpanel.ResumeLayout(false);
            this.secondpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel secondpanel;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.DateTimePicker txttodate;
        private System.Windows.Forms.DateTimePicker txtfromdate;
        private System.Windows.Forms.Button btnsearchclick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox txtlastname;
        private System.Windows.Forms.ComboBox txtfirstname;
        private System.Windows.Forms.DataGridView dataload;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnExport;
    }
}