using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelperLibrary;
using System.Configuration;
using message;

namespace websitebackend
{
    public partial class booksreturn : Form
    {
        int? fkemployeeid;
        string Client_ID = "";
        string Book_ID = "";
        string pk_course_id = "";
        string pk_id_category = "";
        string pk_id_semester = "";
        string paymentreturn = "";

        public booksreturn(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);
        }

        private void booksreturn_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            datagridload();

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnsearch.Visible = false;
            btnhidesearch.Visible = true;
            secondpanel.Visible = true;
            btnpaymentreturn.Visible = false;
        }

        private void btnhidesearch_Click(object sender, EventArgs e)
        {
            btnsearch.Visible = true;
            btnhidesearch.Visible = false;
            savecancel();

        }

        public void savecancel()
        {
            ClearTextBoxes(this);
            firstpanel.Visible = true;
            secondpanel.Visible = false;
            btnpaymentreturn.Visible = true;
        }

        public void ClearTextBoxes(Control control)
        {
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
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            bookdetail.DataSource = null;
            bookdetail.Rows.Clear();
            bookdetail.Columns.Clear();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            dic.Add("@fkclient", Client_ID);
            string strProcedureName = "";
            if (paymentreturn == "Yes")
            {
                strProcedureName = "Sp_admin_bookview_return";
                btnsave.Text = "Payment Return";
            }
            else
            {

                strProcedureName = "Sp_admin_bookview_approved";
                btnsave.Text = "Book Return";
            }
            if (objDB.objExecuteQuery(strProcedureName, clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                bookdetail.DataSource = dt;
                if (bookdetail.Rows.Count == 0)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Data not found"+txtfirstname.Text+"", "Message", 3000);
                    txtfirstname.Text = "";
                    txtlastname.Text = "";
                    return;
                }
            }
            detailpanel.Visible = true;
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "retrun";
            dgvCmb.HeaderText = "Retrun";
            bookdetail.Columns.Add(dgvCmb);
            DataGridViewColumn column = bookdetail.Columns["retrun"];
            visiblecolumns();
            foreach (DataGridViewRow row in bookdetail.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["retrun"];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
            secondpanel.Visible = false;
            firstpanel.Visible = false;
            btnhidesearch.Visible = false;
            btnsearch.Visible = true;

        }

        public void visiblecolumns()
        {
            if (bookdetail.Rows.Count > 0)
            {
                bookdetail.Columns["pk_course_id"].Visible = false;
                bookdetail.Columns["pk_id_category"].Visible = false;
                bookdetail.Columns["pk_id_semester"].Visible = false;
                bookdetail.Columns["Name"].Visible = false;
                bookdetail.Columns["Course"].Visible = false;
                bookdetail.Columns["Category"].Visible = false;
                bookdetail.Columns["Semester"].Visible = false;
                // bookdetail.Columns["Comments"].Visible = false;
                bookdetail.Columns["ID_Transaction"].Visible = false;
                bookdetail.Columns["PK_Client"].Visible = false;
                bookdetail.Columns["Deposit"].Visible = false;
                valueId.Text = bookdetail.Rows[0].Cells["ID_Transaction"].Value.ToString();
                valueName.Text = bookdetail.Rows[0].Cells["Name"].Value.ToString();
                valueCourse.Text = bookdetail.Rows[0].Cells["Course"].Value.ToString();
                valueCategory.Text = bookdetail.Rows[0].Cells["Category"].Value.ToString();
                valueSemester.Text = bookdetail.Rows[0].Cells["Semester"].Value.ToString();
                // valueComments.Text = bookdetail.Rows[0].Cells["Comments"].Value.ToString();
                valueDeposit.Text = bookdetail.Rows[0].Cells["Deposit"].Value.ToString();
                pk_course_id = bookdetail.Rows[0].Cells["pk_course_id"].Value.ToString();
                pk_id_category = bookdetail.Rows[0].Cells["pk_id_category"].Value.ToString();
                pk_id_semester = bookdetail.Rows[0].Cells["pk_id_semester"].Value.ToString();
                Client_ID = bookdetail.Rows[0].Cells["PK_Client"].Value.ToString();
                Book_ID = bookdetail.Rows[0].Cells["ID_Transaction"].Value.ToString();
                bookdetail.Columns["Id"].Width = 30;
                bookdetail.Columns["retrun"].Width = 80;
                bookdetail.Columns["Barcode"].Width = 80;
                bookdetail.Columns["Book"].Width = 250;
                bookdetail.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            if (paymentreturn != "Yes")
            {
                string strBooksId = "";
                foreach (DataGridViewRow item in bookdetail.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["retrun"].Value))
                    {
                        if (strBooksId == "")
                        {
                            strBooksId = item.Cells["Id"].Value.ToString();
                        }
                        else if (strBooksId != "")
                        {
                            strBooksId = strBooksId + ',' + item.Cells["Id"].Value.ToString();
                        }
                    }
                }
                strBooksId = strBooksId.TrimEnd(',');
                DialogResult a = MessageBox.Show("Are You Sure For Procedure", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (a == DialogResult.No)
                { return; }
                dic.Add("@pk_Req_id", Book_ID);
                dic.Add("@fkclient", Client_ID);
                dic.Add("@fkemloyeeid", fkemployeeid);
                dic.Add("@bookIds", strBooksId);
                dic.Add("@fkcourseid", pk_course_id);
                dic.Add("@fkidcategory", pk_id_category);
                dic.Add("@fkidsemester", pk_id_semester);
                if (objDB.objExecuteQuery("Sp_admin_book_reture", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Book Return", "Message", 3000);
                }
            }
            DialogResult payment = MessageBox.Show("Payment Return", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (payment == DialogResult.No)
            {
                bookdetail.DataSource = null;
                bookdetail.Rows.Clear();
                bookdetail.Columns.Clear();
                savecancel();
                btnclick();
                return;
            }
            else if (payment == DialogResult.Yes)
            {
                Dictionary<string, object> dic1 = new Dictionary<string, object>();

                dic1.Add("@fkclient", Client_ID);

                try
                {
                    if (objDB.objExecuteQuery("Sp_admin_masterpayment_return", clsSqlHelper.QueryExcution.storeProcedure, dic1))
                    {
                        AutoClosingMessage.AutoClosingMessageBox.Show("Payment Return", "Message", 3000);
                        savecancel();
                        btnclick();
                    }
                }
                catch (Exception ex)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Book Not Return Still", "Message", 3000);
                }
                paymentreturn = "No";
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnclick();
        }

        public void btnclick()
        {
            ClearTextBoxes(this);
            detailpanel.Visible = false;
            secondpanel.Visible = false;
            firstpanel.Visible = true;
            btnpaymentreturn.Visible = true;
            cleartext();
        }

        private void cleartext()
        {
            txtfirstname.DataSource = null;
            txtlastname.DataSource = null;
            txtfirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
            Client_ID = string.Empty;
        }

        private void btnpaymentreturn_Click(object sender, EventArgs e)
        {
            paymentreturn = "Yes";
            btnsearch.PerformClick();
            btnpaymentreturn.Visible = false;
        }

        public void datagridload()
        {
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (objDB.objExecuteQuery("Sp_admin_book_return_view", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }
            dataload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataload.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataload.ClearSelection();
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
    }
}
