namespace websitebackend
{
    partial class home
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
            this.menus = new System.Windows.Forms.MenuStrip();
            this.homes = new System.Windows.Forms.ToolStripMenuItem();
            this.User = new System.Windows.Forms.ToolStripMenuItem();
            this.emplayees = new System.Windows.Forms.ToolStripMenuItem();
            this.studentregistration = new System.Windows.Forms.ToolStripMenuItem();
            this.master = new System.Windows.Forms.ToolStripMenuItem();
            this.course = new System.Windows.Forms.ToolStripMenuItem();
            this.category = new System.Windows.Forms.ToolStripMenuItem();
            this.semester = new System.Windows.Forms.ToolStripMenuItem();
            this.books = new System.Windows.Forms.ToolStripMenuItem();
            this.stock = new System.Windows.Forms.ToolStripMenuItem();
            this.issue = new System.Windows.Forms.ToolStripMenuItem();
            this.returns = new System.Windows.Forms.ToolStripMenuItem();
            this.report = new System.Windows.Forms.ToolStripMenuItem();
            this.currentStock = new System.Windows.Forms.ToolStripMenuItem();
            this.viewattachment = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pkid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enddate = new System.Windows.Forms.Label();
            this.startdate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.value = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backup = new System.Windows.Forms.LinkLabel();
            this.formvalue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.LinkLabel();
            this.studentreport = new System.Windows.Forms.ToolStripMenuItem();
            this.menus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menus
            // 
            this.menus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.menus.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menus.GripMargin = new System.Windows.Forms.Padding(1);
            this.menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homes,
            this.User,
            this.master,
            this.stock,
            this.issue,
            this.returns,
            this.report,
            this.viewattachment,
            this.labelPrint});
            this.menus.Location = new System.Drawing.Point(0, 0);
            this.menus.Name = "menus";
            this.menus.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.menus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menus.ShowItemToolTips = true;
            this.menus.Size = new System.Drawing.Size(1370, 35);
            this.menus.TabIndex = 162;
            this.menus.Text = "menu";
            // 
            // homes
            // 
            this.homes.Font = new System.Drawing.Font("Arial", 15.75F);
            this.homes.ForeColor = System.Drawing.Color.Lime;
            this.homes.Name = "homes";
            this.homes.Size = new System.Drawing.Size(76, 29);
            this.homes.Text = "Home";
            this.homes.Click += new System.EventHandler(this.homes_Click);
            // 
            // User
            // 
            this.User.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emplayees,
            this.studentregistration});
            this.User.Font = new System.Drawing.Font("Arial", 15.75F);
            this.User.ForeColor = System.Drawing.Color.Lime;
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(91, 29);
            this.User.Text = "Sign up";
            // 
            // emplayees
            // 
            this.emplayees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.emplayees.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emplayees.ForeColor = System.Drawing.Color.MediumBlue;
            this.emplayees.Name = "emplayees";
            this.emplayees.Size = new System.Drawing.Size(327, 30);
            this.emplayees.Text = "Employee";
            this.emplayees.Click += new System.EventHandler(this.emplayees_Click);
            // 
            // studentregistration
            // 
            this.studentregistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.studentregistration.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentregistration.ForeColor = System.Drawing.Color.MediumBlue;
            this.studentregistration.Name = "studentregistration";
            this.studentregistration.Size = new System.Drawing.Size(327, 30);
            this.studentregistration.Text = "Student Registration";
            this.studentregistration.Click += new System.EventHandler(this.studentregistration_Click);
            // 
            // master
            // 
            this.master.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.course,
            this.category,
            this.semester,
            this.books});
            this.master.Font = new System.Drawing.Font("Arial", 15.75F);
            this.master.ForeColor = System.Drawing.Color.Lime;
            this.master.Name = "master";
            this.master.Size = new System.Drawing.Size(87, 29);
            this.master.Text = "Master";
            // 
            // course
            // 
            this.course.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.course.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course.ForeColor = System.Drawing.Color.MediumBlue;
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(193, 30);
            this.course.Text = "Course";
            this.course.Click += new System.EventHandler(this.course_Click);
            // 
            // category
            // 
            this.category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.category.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(193, 30);
            this.category.Text = "Category";
            this.category.Click += new System.EventHandler(this.category_Click);
            // 
            // semester
            // 
            this.semester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.semester.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semester.ForeColor = System.Drawing.Color.MediumBlue;
            this.semester.Name = "semester";
            this.semester.Size = new System.Drawing.Size(193, 30);
            this.semester.Text = "Semester";
            this.semester.Click += new System.EventHandler(this.semester_Click);
            // 
            // books
            // 
            this.books.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.books.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.books.ForeColor = System.Drawing.Color.MediumBlue;
            this.books.Name = "books";
            this.books.Size = new System.Drawing.Size(193, 30);
            this.books.Text = "Books";
            this.books.Click += new System.EventHandler(this.books_Click);
            // 
            // stock
            // 
            this.stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.stock.Font = new System.Drawing.Font("Arial", 15.75F);
            this.stock.ForeColor = System.Drawing.Color.Lime;
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(75, 29);
            this.stock.Text = "Stock";
            this.stock.Click += new System.EventHandler(this.stock_Click);
            // 
            // issue
            // 
            this.issue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.issue.Font = new System.Drawing.Font("Arial", 15.75F);
            this.issue.ForeColor = System.Drawing.Color.Lime;
            this.issue.Name = "issue";
            this.issue.Size = new System.Drawing.Size(138, 29);
            this.issue.Text = "Books Issue";
            this.issue.Click += new System.EventHandler(this.issue_Click);
            // 
            // returns
            // 
            this.returns.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.returns.ForeColor = System.Drawing.Color.Lime;
            this.returns.Name = "returns";
            this.returns.Size = new System.Drawing.Size(94, 29);
            this.returns.Text = "Return";
            this.returns.Click += new System.EventHandler(this.returns_Click);
            // 
            // report
            // 
            this.report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStock,
            this.studentreport});
            this.report.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.report.ForeColor = System.Drawing.Color.Lime;
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(106, 29);
            this.report.Text = "Reports";
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // currentStock
            // 
            this.currentStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.currentStock.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.currentStock.ForeColor = System.Drawing.Color.MediumBlue;
            this.currentStock.Name = "currentStock";
            this.currentStock.Size = new System.Drawing.Size(264, 30);
            this.currentStock.Text = "Current Stock";
            this.currentStock.Click += new System.EventHandler(this.currentStock_Click);
            // 
            // viewattachment
            // 
            this.viewattachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewattachment.ForeColor = System.Drawing.Color.Lime;
            this.viewattachment.Name = "viewattachment";
            this.viewattachment.Size = new System.Drawing.Size(199, 29);
            this.viewattachment.Text = "View Attachment";
            this.viewattachment.Click += new System.EventHandler(this.viewattachment_Click);
            // 
            // labelPrint
            // 
            this.labelPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelPrint.ForeColor = System.Drawing.Color.Lime;
            this.labelPrint.Name = "labelPrint";
            this.labelPrint.Size = new System.Drawing.Size(138, 29);
            this.labelPrint.Text = "Label Print";
            this.labelPrint.Click += new System.EventHandler(this.labelPrint_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pkid);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.enddate);
            this.panel1.Controls.Add(this.startdate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.value);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 37);
            this.panel1.TabIndex = 163;
            // 
            // pkid
            // 
            this.pkid.AutoSize = true;
            this.pkid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.pkid.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkid.ForeColor = System.Drawing.Color.White;
            this.pkid.Location = new System.Drawing.Point(1344, 8);
            this.pkid.Name = "pkid";
            this.pkid.Size = new System.Drawing.Size(19, 25);
            this.pkid.TabIndex = 167;
            this.pkid.Text = " ";
            this.pkid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(677, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 29);
            this.label2.TabIndex = 165;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enddate
            // 
            this.enddate.AutoSize = true;
            this.enddate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enddate.ForeColor = System.Drawing.Color.Transparent;
            this.enddate.Location = new System.Drawing.Point(703, 12);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(19, 18);
            this.enddate.TabIndex = 164;
            this.enddate.Text = "0";
            this.enddate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // startdate
            // 
            this.startdate.AutoSize = true;
            this.startdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startdate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startdate.ForeColor = System.Drawing.Color.Transparent;
            this.startdate.Location = new System.Drawing.Point(628, 12);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(19, 18);
            this.startdate.TabIndex = 163;
            this.startdate.Text = "0";
            this.startdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(906, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 155;
            this.label5.Text = "Welcome";
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.value.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value.ForeColor = System.Drawing.Color.White;
            this.value.Location = new System.Drawing.Point(1023, 9);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(76, 25);
            this.value.TabIndex = 156;
            this.value.Text = "value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(89, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 162;
            this.label1.Text = "Sindhi Youth Circle";
            // 
            // backup
            // 
            this.backup.AutoSize = true;
            this.backup.BackColor = System.Drawing.Color.White;
            this.backup.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backup.ForeColor = System.Drawing.Color.White;
            this.backup.LinkColor = System.Drawing.Color.Red;
            this.backup.Location = new System.Drawing.Point(1167, 85);
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(74, 18);
            this.backup.TabIndex = 164;
            this.backup.TabStop = true;
            this.backup.Text = "Back Up";
            this.backup.Click += new System.EventHandler(this.backup_Click);
            this.backup.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.backup.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // formvalue
            // 
            this.formvalue.AutoSize = true;
            this.formvalue.BackColor = System.Drawing.Color.White;
            this.formvalue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formvalue.ForeColor = System.Drawing.Color.BlueViolet;
            this.formvalue.Location = new System.Drawing.Point(36, 85);
            this.formvalue.Name = "formvalue";
            this.formvalue.Size = new System.Drawing.Size(57, 18);
            this.formvalue.TabIndex = 170;
            this.formvalue.Text = "Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 169;
            this.label8.Text = "label8";
            // 
            // logout
            // 
            this.logout.AutoSize = true;
            this.logout.BackColor = System.Drawing.Color.White;
            this.logout.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Image = global::websitebackend.Properties.Resources.Saki_NuoveXT_2_Apps_session_logout;
            this.logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.LinkColor = System.Drawing.Color.Red;
            this.logout.Location = new System.Drawing.Point(1250, 85);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(98, 18);
            this.logout.TabIndex = 166;
            this.logout.TabStop = true;
            this.logout.Text = "      LogOut";
            this.logout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            this.logout.MouseEnter += new System.EventHandler(this.logout_MouseEnter);
            this.logout.MouseLeave += new System.EventHandler(this.logout_MouseLeave);
            // 
            // studentreport
            // 
            this.studentreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.studentreport.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.studentreport.ForeColor = System.Drawing.Color.MediumBlue;
            this.studentreport.Name = "studentreport";
            this.studentreport.Size = new System.Drawing.Size(264, 30);
            this.studentreport.Text = "Student Report";
            this.studentreport.Click += new System.EventHandler(this.studentreport_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.formvalue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.backup);
            this.Controls.Add(this.menus);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "home";
            this.Text = "home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.home_Load);
            this.menus.ResumeLayout(false);
            this.menus.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menus;
        private System.Windows.Forms.ToolStripMenuItem homes;
        private System.Windows.Forms.ToolStripMenuItem User;
        private System.Windows.Forms.ToolStripMenuItem emplayees;
        private System.Windows.Forms.ToolStripMenuItem studentregistration;
        private System.Windows.Forms.ToolStripMenuItem master;
        private System.Windows.Forms.ToolStripMenuItem course;
        private System.Windows.Forms.ToolStripMenuItem category;
        private System.Windows.Forms.ToolStripMenuItem semester;
        private System.Windows.Forms.ToolStripMenuItem books;
        private System.Windows.Forms.ToolStripMenuItem stock;
        private System.Windows.Forms.ToolStripMenuItem issue;
        private System.Windows.Forms.ToolStripMenuItem report;
        private System.Windows.Forms.ToolStripMenuItem viewattachment;
        private System.Windows.Forms.ToolStripMenuItem returns;
        private System.Windows.Forms.ToolStripMenuItem labelPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label enddate;
        private System.Windows.Forms.Label startdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel logout;
        private System.Windows.Forms.LinkLabel backup;
        private System.Windows.Forms.Label formvalue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label pkid;
        private System.Windows.Forms.ToolStripMenuItem currentStock;
        private System.Windows.Forms.ToolStripMenuItem studentreport;

    }
}



