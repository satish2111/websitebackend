namespace websitebackend
{
    partial class homein
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.show = new System.Windows.Forms.DataGridView();
            this.Employeeview = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Employeeview)).BeginInit();
            this.SuspendLayout();
            // 
            // show
            // 
            this.show.AllowUserToAddRows = false;
            this.show.AllowUserToDeleteRows = false;
            this.show.AllowUserToResizeColumns = false;
            this.show.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.show.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.show.BackgroundColor = System.Drawing.Color.White;
            this.show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.show.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.show.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.show.DefaultCellStyle = dataGridViewCellStyle2;
            this.show.EnableHeadersVisualStyles = false;
            this.show.GridColor = System.Drawing.Color.DarkOrange;
            this.show.Location = new System.Drawing.Point(452, 110);
            this.show.MultiSelect = false;
            this.show.Name = "show";
            this.show.RowHeadersVisible = false;
            this.show.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.show.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.show.ShowCellErrors = false;
            this.show.ShowEditingIcon = false;
            this.show.ShowRowErrors = false;
            this.show.Size = new System.Drawing.Size(872, 427);
            this.show.StandardTab = true;
            this.show.TabIndex = 206;
            // 
            // Employeeview
            // 
            this.Employeeview.AllowUserToAddRows = false;
            this.Employeeview.AllowUserToDeleteRows = false;
            this.Employeeview.AllowUserToResizeColumns = false;
            this.Employeeview.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Employeeview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Employeeview.BackgroundColor = System.Drawing.Color.White;
            this.Employeeview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Employeeview.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Employeeview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Employeeview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.Description});
            this.Employeeview.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Employeeview.DefaultCellStyle = dataGridViewCellStyle4;
            this.Employeeview.EnableHeadersVisualStyles = false;
            this.Employeeview.GridColor = System.Drawing.Color.DarkOrange;
            this.Employeeview.Location = new System.Drawing.Point(46, 109);
            this.Employeeview.MultiSelect = false;
            this.Employeeview.Name = "Employeeview";
            this.Employeeview.RowHeadersVisible = false;
            this.Employeeview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Employeeview.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employeeview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Employeeview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Employeeview.ShowCellErrors = false;
            this.Employeeview.ShowEditingIcon = false;
            this.Employeeview.ShowRowErrors = false;
            this.Employeeview.Size = new System.Drawing.Size(407, 427);
            this.Employeeview.StandardTab = true;
            this.Employeeview.TabIndex = 205;
            this.Employeeview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Employeeview_CellClick);
            // 
            // srno
            // 
            this.srno.HeaderText = "Sr No";
            this.srno.Name = "srno";
            this.srno.Width = 110;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Description.Name = "Description";
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Description.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Description.Width = 290;
            // 
            // homein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.show);
            this.Controls.Add(this.Employeeview);
            this.Name = "homein";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.homein_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Employeeview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView show;
        private System.Windows.Forms.DataGridView Employeeview;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewLinkColumn Description;


    }
}