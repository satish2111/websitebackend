using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace websitebackend
{
    public partial class home : Form
    {
        private int childFormNumber = 0;
        private string name;
        private int id;

        public home()
        {
            InitializeComponent();
            pkid.Text = idf.ToString();
        }

        public string namef
        {
            get { return name; }
            set { name = value; }
        }

        public int idf
        {
            get { return id; }
            set { id = value; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;

        private void homes_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            homein o = new homein();
            o.MdiParent = this;
            o.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {
            label8.AutoSize = false;
            label8.Height = 3;
            label8.Width = 1300;
            label8.BackColor = Color.Red;
            label8.BorderStyle = BorderStyle.FixedSingle;
            backup.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            logout.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            formvalue.Text = "Home";
            startdate.Text = DateTime.Now.ToString("yyyy");
            enddate.Text = DateTime.Now.AddYears(1).ToString("yyyy");
            MaximizeBox = false;
            value.Text = name;
            pkid.Text = id.ToString();
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            homein o = new homein();
            o.MdiParent = this;
            o.Show();
        }

        private void emplayees_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Employee";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            employee o = new employee(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void studentregistration_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Student Registration";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            student o = new student(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void course_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Course";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            course o = new course(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void category_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Category";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            category o = new category(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void semester_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Semester";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            semester o = new semester(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void books_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Books";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            books o = new books(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Stock";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            stock o = new stock(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void issue_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Books Issue";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            booksissue o = new booksissue(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void Paymentpaid_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Payment Paid";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            currentstock o = new currentstock();
            o.MdiParent = this;
            o.Show();
        }

        private void labelPrint_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Label Print";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            labelPrint o = new labelPrint();
            o.MdiParent = this;
            o.Show();
        }

        private void backup_MouseEnter(object sender, EventArgs e)
        {
            backup.LinkColor = Color.Green;
        }

        private void logout_MouseEnter(object sender, EventArgs e)
        {
            logout.LinkColor = Color.Green;
        }

        private void backup_MouseLeave(object sender, EventArgs e)
        {
            backup.LinkColor = Color.Red;
        }

        private void logout_MouseLeave(object sender, EventArgs e)
        {
            logout.LinkColor = Color.Red;
        }

        public String ReadFilePath()
        {
            string path = Application.StartupPath + @"\filePath.txt";
            String readFilePath = "";
            if (!File.Exists(path))
            {
                using (StreamWriter tw = File.CreateText(path))
                {
                    tw.WriteLine(@"e:\backupdb");
                    tw.Close();
                    readFilePath = @"e:\backupdb";
                }
            }
            else
            {
                TextReader tr = new StreamReader(path);
                readFilePath = tr.ReadLine();
                tr.Close();
            }
            return readFilePath;
        }

        private void deleteFiles()
        {
            try
            {
                string srcDir = ReadFilePath();
                string[] files = Directory.GetFiles(srcDir, "*.bak");

                var items = System.IO.Directory.GetFiles(srcDir, "*.bak", System.IO.SearchOption.TopDirectoryOnly);
                foreach (String filePath in items)
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch
            { }


        }

        private void backup_Click(object sender, EventArgs e)
        {
            ReadFilePath();
            deleteFiles();
            backup o = new backup();
            o.conection_today();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            login n = new login();
            n.Show();
        }

        private void returns_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Books Return";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            booksreturn o = new booksreturn(pkid.Text);
            o.MdiParent = this;
            o.Show();
        }

        private void report_Click(object sender, EventArgs e)
        {

        }

        private void viewattachment_Click(object sender, EventArgs e)
        {
            formvalue.Text = "View Attachment";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            picture o = new picture(0);
            o.MdiParent = this;
            o.Show();
        }

        private void currentStock_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Current Stock";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            currentstock o = new currentstock();
            o.MdiParent = this;
            o.Show();
        }

        private void studentreport_Click(object sender, EventArgs e)
        {
            formvalue.Text = "Student Report";
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            studentReport o = new studentReport();
            o.MdiParent = this;
            o.Show();
        }
    }
}
