using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelperLibrary;
using message;
using websitebackend;
using Excel = Microsoft.Office.Interop.Excel;

namespace websitebackend
{
    public partial class studentReport : Form
    {
        public studentReport()
        {
            InitializeComponent();
        }

        string Client_ID = string.Empty;

        private void studentReport_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        public void getnameandlastname()
        {

            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            string StrQuery = "";
            if (txtfirstname.Text.Trim().Length != 0 && txtlastname.Text.Trim().Length == 0)
            {
                StrQuery = "SELECT pkclient,firstname,lastname FROM dbo.client where firstname LIKE '" + txtfirstname.Text + "%' ";
            }
            else if (txtfirstname.Text.Trim().Length == 0 && txtlastname.Text.Trim().Length != 0)
            {
                StrQuery = "SELECT pkclient,firstname,lastname FROM dbo.client where lastname LIKE '" + txtlastname.Text + "%' ";
            }
            if (objDB.objExecuteQuery(StrQuery, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
            {

                txtfirstname.DataSource = objDB.objDataset.Tables[0];
                txtfirstname.DisplayMember = "firstname";
                txtfirstname.ValueMember = "pkclient";

                txtlastname.DataSource = objDB.objDataset.Tables[0];
                txtlastname.DisplayMember = "lastname";
                txtlastname.ValueMember = "pkclient";


            }
        }

        private void txtfirstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && txtfirstname.Text.Trim().Length >= 0)
            {
                getnameandlastname();
            }
            else if (e.KeyCode == Keys.Enter && txtfirstname.Text.Trim().Length >= 0)
            {
                Client_ID = txtfirstname.SelectedValue.ToString();
                btnsearchclick.PerformClick();
            }
        }

        private void txtlastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && txtlastname.Text.Trim().Length >= 0)
            {
                getnameandlastname();
            }
            else if (e.KeyCode == Keys.Enter && txtlastname.Text.Trim().Length >= 0)
            {
                Client_ID = txtfirstname.SelectedValue.ToString();
                btnsearchclick.PerformClick();
            }
        }

        private void txtfirstname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Client_ID = txtfirstname.SelectedValue.ToString();
        }

        private void txtlastname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Client_ID = txtlastname.SelectedValue.ToString();
        }

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            string type = string.Empty;
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (Client_ID == string.Empty && txtfromdate.Text == txttodate.Text)
            {
                type = "All";
            }
            else if (Client_ID == string.Empty && txtfromdate.Text != txttodate.Text)
            {
                dic.Add("@startdate", Convert.ToDateTime(txtfromdate.Value).ToString("yyyy-MM-dd"));
                dic.Add("@enddate", Convert.ToDateTime(txttodate.Value).ToString("yyyy-MM-dd"));
                type = "Date";
            }
            else if (Client_ID != string.Empty && txtfromdate.Text == txttodate.Text)
            {
                dic.Add("@pkid", Client_ID);
                type = "pkid";
            }
            dic.Add("@type", type);

            if (objDB.objExecuteQuery("Sp_admin_studentreport", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }
            dataload.Visible = true;
            btnExport.Visible = true;
            btncancel.Visible = true;
            dataload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataload.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataload.ClearSelection();
            Client_ID = string.Empty;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);

        }

        public void ClearTextBoxes(Control control)
        {
            txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    if (!(c.Parent is NumericUpDown))
                    {
                        ((TextBox)c).Clear();
                    }
                }
                else if (c is NumericUpDown)
                {
                    ((NumericUpDown)c).Value = 0;
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                    ((ComboBox)c).Text = "";
                }

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            for (i = 1; i < dataload.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dataload.Columns[i - 1].HeaderText;
            }
            for (i = 0; i <= dataload.RowCount - 1; i++)
            {
                for (j = 0; j <= dataload.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataload[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }
            // var appPath = System.Configuration.ConfigurationManager.AppSettings["filepath"];
            string pathsave = @"E:\Report\";
            if (!System.IO.Directory.Exists(pathsave))
            {
                System.IO.Directory.CreateDirectory(pathsave);
            }
            string fullpath = pathsave + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".xls";
            xlWorkBook.SaveAs(fullpath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , " + fullpath + "");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
