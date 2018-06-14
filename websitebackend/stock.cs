using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelperLibrary;
using message;
using System.Configuration;

namespace websitebackend
{
    public partial class stock : Form
    {
        int? fkemployeeid;
        int? pkidstock;
        int? qty;

        public stock(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);
        }

        private void stock_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            datagridload();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            firstpanel.Visible = false;
            secondpanel.Visible = false;
            thirdpanel.Visible = true;
            dataload.Visible = false;
            btnsave.Text = "Save";
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string StrQuery = "SELECT MAX(pkidstock) FROM dbo.stock ";
            objDB.objExecuteQuery(StrQuery, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                values.Text = (objDB.dtrData.GetInt32(0) + 1).ToString();
            }
            else
            {
                values.Text = "1";
            }
            txtcourse.DataSource = null;
            txtcourse.Text = "";
            txtcategory.DataSource = null;
            txtcategory.Text = "";
            txtsemester.DataSource = null;
            txtsemester.Text = "";
            courseidname();
            comboxenabledisable();
            btnsave.Text = "Save";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnadd.Visible = false;
            btnsearch.Visible = false;
            btnhidesearch.Visible = true;
            secondpanel.Visible = true;
            dataload.Visible = true;
            thirdpanel.Visible = false;
            searchcourseidname();
            txtsearchcourse.DroppedDown = true;
        }

        private void btnhidesearch_Click(object sender, EventArgs e)
        {
            btnadd.Visible = true;
            btnsearch.Visible = true;
            dataload.Visible = true;
            btnhidesearch.Visible = false;
            thirdpanel.Visible = false;
            savecancel();
        }

        public void datagridload()
        {
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            string type = "";
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (txtsearchcourse.SelectedIndex != 0 && txtsearchcourse.SelectedIndex != -1 && secondpanel.Visible == true)
            {
                type = "course";
            }
            else if (txtsearchcategory.SelectedIndex != 0 && txtsearchcategory.SelectedIndex != -1 && secondpanel.Visible == true)
            {
                type = "category";
            }
            else if (txtsearchsemester.SelectedIndex != 0 && txtsearchsemester.SelectedIndex != -1 && secondpanel.Visible == true)
            {
                type = "semester";
            }
            else if (txtsearchbook.SelectedIndex != 0 && txtsearchbook.SelectedIndex != -1 && secondpanel.Visible == true)
            {
                type = "books";
            }
            else if (txtsearchcourse.Text.Trim().Length == 0 && pkidstock == null)
            {
                type = "SELECTALL";
            }
            else if (txtsearchcourse.Text.Trim().Length == 0 && pkidstock != null)
            {
                type = "PkId";
            }
            else
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Select first", "Message", 3000);
                return;
            }
            dic.Add("@StatementType", type);
            dic.Add("@pkidcourse", txtsearchcourse.SelectedValue);
            dic.Add("@pkidcategory", txtsearchcategory.SelectedValue);
            dic.Add("@pkidsemester", txtsearchsemester.SelectedValue);
            dic.Add("@pkidbooks", txtsearchbook.SelectedValue);
            dic.Add("@pkidstock", pkidstock);

            if (objDB.objExecuteQuery("Sp_admin_stock_select", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }

            var col6 = new DataGridViewButtonColumn();
            col6.HeaderText = "Edit";
            col6.Name = "Edit";
            col6.Text = "Edit";
            col6.UseColumnTextForButtonValue = true;
            dataload.Columns.AddRange(new DataGridViewColumn[] { col6 });

            var col5 = new DataGridViewButtonColumn();
            col5.HeaderText = "Delete";
            col5.Name = "Delete";
            col5.Text = "Delete";
            col5.UseColumnTextForButtonValue = true;
            dataload.Columns.AddRange(new DataGridViewColumn[] { col5 });

            dataload.ReadOnly = true;
            dataload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataload.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataload.ClearSelection();
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

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        public void savecancel()
        {
            pkidstock = null;
            ClearTextBoxes(this);
            firstpanel.Visible = true;
            secondpanel.Visible = false;
            thirdpanel.Visible = false;
            datagridload();
            dataload.Visible = true;
            datadetail.DataSource = null;
            datadetail.Rows.Clear();
            datadetail.Columns.Clear();
            btnadd.Visible = true;
            btnsearch.Visible = true;
            btnhidesearch.Visible = false;
            comboxenabledisable();
            btnadd.Focus();
        }

        private void courseidname()
        {
            txtcourse.DataSource = null;
            txtcourse.Text = "";
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string qu = "SELECT pkcourseid  AS [ID],Course AS [Course]  FROM dbo.course";
            if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
            {
                txtcourse.DataSource = objDB.objDataset.Tables[0];
                txtcourse.ValueMember = "ID";
                txtcourse.DisplayMember = "Course";
            }
            DataRow dr = objDB.objDataset.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Course"] = "-Select Course-";
            objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
            txtcourse.SelectedIndex = 0;
            if (txtcourse.SelectedIndex == 0)
            {
                txtcategory.DataSource = null;
                txtcategory.Text = "";
                txtsemester.DataSource = null;
                txtsemester.Text = "";
                txtbook.DataSource = null;
                txtbook.Text = "";
            }
        }

        private void categoryidname()
        {
            if (txtcourse.SelectedIndex > 0)
            {
                txtcategory.DataSource = null;
                txtcategory.Text = "";
                txtsemester.DataSource = null;
                txtsemester.Text = "";
                txtbook.DataSource = null;
                txtbook.Text = "";
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidcategory as id,category FROM dbo.category WHERE fkcourseid='" + txtcourse.SelectedValue + "'";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtcategory.DataSource = objDB.objDataset.Tables[0];
                    txtcategory.ValueMember = "id";
                    txtcategory.DisplayMember = "category";
                }
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["category"] = "-Select Category-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtcategory.SelectedIndex = 0;
                txtcategory.Focus();
            }
            if (txtcourse.SelectedIndex == 0)
            {
                txtcategory.DataSource = null;
                txtcategory.Text = "";
                txtsemester.DataSource = null;
                txtsemester.Text = "";
                txtbook.DataSource = null;
                txtbook.Text = "";
            }
        }

        private void semesteridname()
        {
            if (txtcategory.SelectedIndex > 0)
            {
                txtsemester.DataSource = null;
                txtsemester.Text = "";
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidsemester as id,semester FROM dbo.semester WHERE fkcourse='" + txtcourse.SelectedValue + "' AND fkidcategory='" + txtcategory.SelectedValue + "'";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtsemester.DataSource = objDB.objDataset.Tables[0];
                    txtsemester.ValueMember = "id";
                    txtsemester.DisplayMember = "semester";
                }
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["id"] = 0;
                dr["semester"] = "-Select Semester-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtsemester.SelectedIndex = 0;
                txtsemester.Focus();
            }
            if (txtcategory.SelectedIndex == 0)
            {
                txtsemester.DataSource = null;
                txtsemester.Text = "";
                txtbook.DataSource = null;
                txtbook.Text = "";
            }

        }

        private void bookidname()
        {
            if (txtsemester.SelectedIndex > 0)
            {
                txtbook.DataSource = null;
                txtsemester.Text = "";
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidbooks as [id],bookname as [book] FROM dbo.books WHERE fkcourseid='" + txtcourse.SelectedValue + "' AND fkidcategory='" + txtcategory.SelectedValue + "' AND fkidsemester='" + txtsemester.SelectedValue + "'";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtbook.DataSource = objDB.objDataset.Tables[0];
                    txtbook.ValueMember = "id";
                    txtbook.DisplayMember = "book";
                }
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["id"] = 0;
                dr["book"] = "-Select Book-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtbook.SelectedIndex = 0;
                txtbook.Focus();
            }
            if (txtsemester.SelectedIndex == 0)
            {
                txtbook.DataSource = null;
                txtbook.Text = "";
                datadetail.DataSource = null;
                datadetail.Rows.Clear();
                datadetail.Columns.Clear();
            }

        }

        private void txtcourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            categoryidname();
        }

        private void txtcategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            semesteridname();
        }

        private void txtsemester_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bookidname();
        }

        private void txtbook_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtbook.Text.Trim().Length != 0)
            {
                txtstock.Focus();
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@fkcourseid", txtcourse.SelectedValue);
                dic.Add("@fkidcategory", txtcategory.SelectedValue);
                dic.Add("@fkidsemester", txtsemester.SelectedValue);
                dic.Add("@pkidbooks", txtbook.SelectedValue);
                if (objDB.objExecuteQuery("Sp_admin_bookdetail_select", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    DataTable dt = new DataTable();
                    dt = objDB.objDataset.Tables[0];
                    datadetail.DataSource = dt;
                }
                datadetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                datadetail.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                datadetail.ClearSelection();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            savecancel();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (txtcourse.Text.Trim().Length != 0 && txtcategory.Text.Trim().Length != 0 && btnsave.Text=="Save")
            {
                dic.Add("@fkcourseid", txtcourse.SelectedValue);
                dic.Add("@fkidcategory", txtcategory.SelectedValue);
                dic.Add("@fkidsemester", txtsemester.SelectedValue);
                dic.Add("@fkidbooks", txtbook.SelectedValue);
                dic.Add("@fkemployeeid", fkemployeeid);
                dic.Add("@qty", txtstock.Text);
                dic.Add("@barcode", datadetail.Rows[0].Cells["Barcode"].Value);
                if (objDB.objExecuteQuery("Sp_admin_stock_insert_update", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                    datagridload();
                    ClearTextBoxes(this);
                    savecancel();
                }
            }
            else if (pkidstock != null)
            {
                if (qty< int.Parse(txtstock.Text))
                {
                    dic.Add("@pkidstock", pkidstock);
                    dic.Add("@qty", txtstock.Text);
                    dic.Add("@oldqty", qty);
                    if (objDB.objExecuteQuery("Sp_admin_stock_update", clsSqlHelper.QueryExcution.storeProcedure, dic))
                    {
                        AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                        datagridload();
                        ClearTextBoxes(this);
                        savecancel();
                    }
                }

            }
            else
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Fill All Detail", "Message", 3000);
                return;
            }
        }

        private void dataload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@pkidstock", dataload.CurrentRow.Cells["Id"].Value);
            if (e.RowIndex >= 0 && e.ColumnIndex == dataload.Columns["Delete"].Index)
            {
                dataload.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                DialogResult a = MessageBox.Show("Are You Sure Delete" + Environment.NewLine + "Book Name:-     " + dataload.CurrentRow.Cells["Book Name"].Value + Environment.NewLine + "Qty:-     " + dataload.CurrentRow.Cells["Qty"].Value + "", "Question ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (a == DialogResult.Yes)
                {
                    if (objDB.objExecuteQuery("Sp_admin_stock_delete", clsSqlHelper.QueryExcution.storeProcedure, dic))
                    {
                        DataTable dt = new DataTable();
                        dt = objDB.objDataset.Tables[0];
                        if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                        {
                            AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                        }
                        else { AutoClosingMessage.AutoClosingMessageBox.Show("Can't Delete Sum Books Are Issue ", "Message", 5000); }
                        datagridload();
                        ClearTextBoxes(this);
                        savecancel();

                    }
                }
                else if (a == DialogResult.No)
                {
                    dataload.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Empty;
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataload.Columns["Edit"].Index)
            {
                pkidstock = int.Parse(dataload.CurrentRow.Cells["Id"].Value.ToString());
                secondpanel.Visible = false;
                btnhidesearch.Visible = false;
                firstpanel.Visible = false;
                ClearTextBoxes(this);
                datagridload();
                thirdpanel.Visible = true;
                values.Text = dataload.CurrentRow.Cells["Id"].Value.ToString();
                txtcourse.Text = dataload.CurrentRow.Cells["Course"].Value.ToString();
                txtcategory.Text = dataload.CurrentRow.Cells["Category"].Value.ToString();
                txtsemester.Text = dataload.CurrentRow.Cells["Semester"].Value.ToString();
                txtbook.Text = dataload.CurrentRow.Cells["Book Name"].Value.ToString();
                 qty = int.Parse(dataload.CurrentRow.Cells["Qty"].Value.ToString());
                txtstock.Text = qty.ToString();
                btnsave.Text = "Update";
                comboxenabledisable();
            }
        }

        public void comboxenabledisable()
        {
            if (txtcourse.Enabled == true && pkidstock != null)
            {
                txtcourse.Enabled = false;
                txtcategory.Enabled = false;
                txtsemester.Enabled = false;
                txtbook.Enabled = false;
            }
            else
            {
                txtcourse.Enabled = true;
                txtcategory.Enabled = true;
                txtsemester.Enabled = true;
                txtbook.Enabled = true;
            }
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            datagridload();
        }

        private void txtsearchcourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchcategoryidname();
        }

        private void txtsearchcategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchsemesteridname();
        }

        private void txtsearchsemester_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchbookidname();
        }

        private void searchcourseidname()
        {
            txtsearchcourse.DataSource = null;
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string qu = "SELECT pkcourseid  AS [ID],Course AS [Course]  FROM dbo.course";
            if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
            {
                txtsearchcourse.DataSource = objDB.objDataset.Tables[0];
                txtsearchcourse.ValueMember = "ID";
                txtsearchcourse.DisplayMember = "Course";
            }
            DataRow dr = objDB.objDataset.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Course"] = "-Select Course-";
            objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
            txtsearchcourse.SelectedIndex = 0;
            if (txtsearchcourse.SelectedIndex == 0)
            {
                txtsearchcategory.DataSource = null;
                txtsearchcategory.Text = "";
                txtsearchsemester.DataSource = null;
                txtsearchsemester.Text = "";
                txtsearchbook.DataSource = null;
                txtsearchbook.Text = "";
            }
        }

        private void searchcategoryidname()
        {
            if (txtsearchcourse.SelectedIndex > 0)
            {
                txtsearchcategory.DataSource = null;
                txtsearchcategory.Text = "";
                txtsearchsemester.DataSource = null;
                txtsearchsemester.Text = "";
                txtsearchbook.DataSource = null;
                txtsearchbook.Text = "";
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidcategory as id,category FROM dbo.category WHERE fkcourseid='" + txtsearchcourse.SelectedValue + "'";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtsearchcategory.DataSource = objDB.objDataset.Tables[0];
                    txtsearchcategory.ValueMember = "id";
                    txtsearchcategory.DisplayMember = "category";
                }
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["category"] = "-Select Category-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtsearchcategory.SelectedIndex = 0;
                txtsearchcategory.Focus();
            }
            if (txtsearchcourse.SelectedIndex == 0)
            {
                txtsearchcategory.DataSource = null;
                txtsearchcategory.Text = "";
                txtsearchsemester.DataSource = null;
                txtsearchsemester.Text = "";
                txtsearchbook.DataSource = null;
                txtsearchbook.Text = "";
            }
        }

        private void searchsemesteridname()
        {
            if (txtsearchcategory.SelectedIndex > 0)
            {
                txtsearchsemester.DataSource = null;
                txtsearchsemester.Text = "";
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidsemester as id,semester FROM dbo.semester WHERE fkcourse='" + txtsearchcourse.SelectedValue + "' AND fkidcategory='" + txtsearchcategory.SelectedValue + "'";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtsearchsemester.DataSource = objDB.objDataset.Tables[0];
                    txtsearchsemester.ValueMember = "id";
                    txtsearchsemester.DisplayMember = "semester";
                }
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["id"] = 0;
                dr["semester"] = "-Select Semester-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtsearchsemester.SelectedIndex = 0;
                txtsearchsemester.Focus();
            }
            if (txtsearchcategory.SelectedIndex == 0)
            {
                txtsearchsemester.DataSource = null;
                txtsearchsemester.Text = "";
                txtsearchbook.DataSource = null;
                txtsearchbook.Text = "";
            }
        }

        private void searchbookidname()
        {
            if (txtsearchsemester.SelectedIndex > 0)
            {
                txtbook.DataSource = null;
                txtsemester.Text = "";
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidbooks as [id],bookname as [book] FROM dbo.books WHERE fkcourseid='" + txtsearchcourse.SelectedValue + "' AND fkidcategory='" + txtsearchcategory.SelectedValue + "' AND fkidsemester='" + txtsearchsemester.SelectedValue + "'";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtsearchbook.DataSource = objDB.objDataset.Tables[0];
                    txtsearchbook.ValueMember = "id";
                    txtsearchbook.DisplayMember = "book";
                }
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["id"] = 0;
                dr["book"] = "-Select Book-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtsearchbook.SelectedIndex = 0;
                txtsearchbook.Focus();
            }
            if (txtsearchsemester.SelectedIndex == 0)
            {
                txtsearchbook.DataSource = null;
                txtsearchbook.Text = "";
            }
        }

    }
}
