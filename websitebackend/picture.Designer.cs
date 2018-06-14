namespace websitebackend
{
    partial class picture
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
            this.picselfphoto = new System.Windows.Forms.PictureBox();
            this.compicture = new System.Windows.Forms.ComboBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picselfphoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picselfphoto
            // 
            this.picselfphoto.Location = new System.Drawing.Point(299, 134);
            this.picselfphoto.Name = "picselfphoto";
            this.picselfphoto.Size = new System.Drawing.Size(1059, 604);
            this.picselfphoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picselfphoto.TabIndex = 1;
            this.picselfphoto.TabStop = false;
            // 
            // compicture
            // 
            this.compicture.DropDownHeight = 75;
            this.compicture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compicture.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.compicture.FormattingEnabled = true;
            this.compicture.IntegralHeight = false;
            this.compicture.Items.AddRange(new object[] {
            "Salary Slip",
            "Student Photo",
            "Guardian Photo",
            "Light Bill",
            "Mark Sheet",
            "College Id",
            "Aadhar Card"});
            this.compicture.Location = new System.Drawing.Point(82, 199);
            this.compicture.Name = "compicture";
            this.compicture.Size = new System.Drawing.Size(211, 26);
            this.compicture.TabIndex = 198;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncancel.Location = new System.Drawing.Point(140, 231);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(91, 38);
            this.btncancel.TabIndex = 197;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnsave.Location = new System.Drawing.Point(34, 231);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(91, 38);
            this.btnsave.TabIndex = 196;
            this.btnsave.Text = "Show";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 195;
            this.label3.Text = "Images";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 200;
            this.label1.Text = "Name";
            // 
            // txtname
            // 
            this.txtname.DropDownHeight = 75;
            this.txtname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txtname.FormattingEnabled = true;
            this.txtname.IntegralHeight = false;
            this.txtname.Location = new System.Drawing.Point(82, 142);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(211, 26);
            this.txtname.TabIndex = 201;
            // 
            // picture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compicture);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picselfphoto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "picture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.picture_FormClosing);
            this.Load += new System.EventHandler(this.picture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picselfphoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picselfphoto;
        private System.Windows.Forms.ComboBox compicture;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtname;
    }
}