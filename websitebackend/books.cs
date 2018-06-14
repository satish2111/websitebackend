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
    public partial class books : Form
    {
        int? fkemployeeid;
        string usernamefind;
        int? pkidbook;
        string barcode;
        int? number;
        public books(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);
        }

        private void books_Load(object sender, EventArgs e)
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
            string StrQuery = "SELECT MAX(pkidbooks) FROM dbo.books";
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
            txtcourse.Enabled = true;
            txtcategory.Enabled = true;
            txtsemester.Enabled = true;
            btnsave.Enabled = true;
            chkactive.Checked = true;
            number = 1;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnadd.Visible = false;
            btnsearch.Visible = false;
            btnhidesearch.Visible = true;
            secondpanel.Visible = true;
            dataload.Visible = true;
            thirdpanel.Visible = false;
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
            string type;
            if (txtsearch.Text.Trim().Length != 0)
            {
                type = "SELECTONE";
            }
            else
            {
                type = "SELECTALL";
            }
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@StatementType", type);
            dic.Add("@pkidbooks", txtsearch.Text);
            if (objDB.objExecuteQuery("Sp_admin_book_select", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }
            dataload.ReadOnly = true;
            dataload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataload.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataload.ClearSelection();
            var col5 = new DataGridViewButtonColumn();
            col5.HeaderText = "Edit";
            col5.Name = "Edit";
            col5.Text = "Edit";
            col5.UseColumnTextForButtonValue = true;
            dataload.Columns.AddRange(new DataGridViewColumn[] { col5 });
        }

        public void idsemester()
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@bookname", usernamefind);
            string qu = "SELECT pkidbooks FROM dbo.books WHERE bookname=@bookname";
            objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                pkidbook = objDB.dtrData.GetInt32(0);
            }
        }

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            usernamefind = txtsearch.Text;
            idsemester();
            datagridload();
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

        private void barcodemake()
        {
            Guid obj = Guid.NewGuid();
            string P = (obj).ToString();
            barcode = P.Substring(0, P.IndexOf('-')).ToUpper();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcourse.Text.Trim().Length != 0 && txtcategory.Text.Trim().Length != 0 && txtsemester.Text.Trim().Length != 0 && txtbooks.Text.Trim().Length != 0 && txtpublishyear.Text.Trim().Length != 0 && txtwritename.Text.Trim().Length != 0)
            {
                barcodemake();
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@fkcourseid", txtcourse.SelectedValue);
                dic.Add("@bookname", txtbooks.Text);
                dic.Add("@publishyear", txtpublishyear.Text);
                dic.Add("@writename", txtwritename.Text);
                dic.Add("@barcode", barcode);
                dic.Add("@fkemployeeid", fkemployeeid);
                dic.Add("@fkidcategory", txtcategory.SelectedValue);
                dic.Add("@fkidsemester", txtsemester.SelectedValue);
                bool active = chkactive.Checked;
                if (active == true)
                    dic.Add("@isactive", "True");
                else
                    dic.Add("@isactive", "False");
                if (btnsave.Text == "Save")
                {
                    dic.Add("@StatementType", "insert");
                }
                else if (btnsave.Text == "Update")
                {
                    dic.Add("@StatementType", "update");
                    dic.Add("@pkidbooks", pkidbook);
                }
                if (objDB.objExecuteQuery("Sp_admin_book_insert_update", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    DataTable dt = new DataTable();
                    dt = objDB.objDataset.Tables[0];
                    if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                    {
                        AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                    }
                    else { AutoClosingMessage.AutoClosingMessageBox.Show("Data Already Saved "+Environment.NewLine+" Book ID:-"+dt.Rows[0][0].ToString()+"", "Message", 5000); }
                    datagridload();
                    ClearTextBoxes(this);
                    savecancel();
                }
            }
            else
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Fill All Detail", "Message", 3000);
                return;
            }
        }

        public void savecancel()
        {
            number = 0;
            ClearTextBoxes(this);
            firstpanel.Visible = true;
            secondpanel.Visible = false;
            thirdpanel.Visible = false;
            datagridload();
            dataload.Visible = true;
        }

        private void dataload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataload.Columns["Edit"].Index)
            {
                btnsave.Text = "Update";
                btnsave.Enabled = true;
                txtcourse.DataSource = null;
                txtcategory.DataSource = null;
                txtsemester.DataSource = null;
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@pkidbooks", dataload.CurrentRow.Cells["Book ID"].Value.ToString());
                //                              0                1                2           3                         4                   5                    6                   7                            8                             9               10
                string qu = "SELECT a.pkidbooks AS [Id],b.course AS [Course],a.fkcourseid,c.category as [Category],a.fkidcategory,d.semester AS[Semester],a.fkidsemester,a.bookname AS [Book Name],a.publishyear AS [Publish Year],a.writename AS [Write Name],a.active  FROM  dbo.books a JOIN dbo.course b ON a.fkcourseid=b.pkcourseid JOIN dbo.category c ON a.fkidcategory=c.pkidcategory JOIN dbo.semester d ON a.fkidsemester=d.pkidsemester WHERE a.pkidbooks=@pkidbooks";
                objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
                if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
                {
                    data();
                    values.Text = objDB.dtrData.GetInt32(0).ToString();
                    txtbooks.Text = objDB.dtrData.GetString(7);
                    txtpublishyear.Text = objDB.dtrData.GetString(8);
                    txtwritename.Text = objDB.dtrData.GetString(9);
                    bool active = Convert.ToBoolean(objDB.dtrData.GetString(10));
                    if (active)
                    { chkactive.Checked = true; }
                    else { chkactive.Checked = false; }
                    pkidbook = int.Parse(values.Text);
                    txtcourse.Enabled = false;
                    txtcategory.Enabled = false;
                    txtsemester.Enabled = false;
                }
                firstpanel.Visible = false;
                dataload.Visible = false;
                thirdpanel.Visible = true;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex != dataload.Columns["Edit"].Index)
            {
                btnsave.Enabled = false;
            }
        }

        private void data()
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string idsem = "";
            string sub = "SELECT fkidsemester FROM dbo.books WHERE pkidbooks=@pkidbooks";
            dic.Add("@pkidbooks", dataload.CurrentRow.Cells["Book ID"].Value.ToString());
            objDB.objExecuteQuery(sub, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                idsem = objDB.dtrData.GetInt32(0).ToString();
            }
            string SubQuery = "SELECT a.pkidsemester AS [semester_Id],a.semester as [Semester],a.fkcourse AS [course_ID], b.course AS[Course],a.fkidcategory AS [Category_ID] ,c.category AS[Category] FROM dbo.semester a JOIN dbo.course b ON a.fkcourse=b.pkcourseid JOIN dbo.category c ON a.fkidcategory=c.pkidcategory WHERE a.pkidsemester='" + idsem + "'";
            if (objDB.objExecuteQuery(SubQuery, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
            {
                txtcourse.DataSource = objDB.objDataset.Tables[0];
                txtcourse.ValueMember = "course_ID";
                txtcourse.DisplayMember = "Course";
                txtcategory.DataSource = objDB.objDataset.Tables[0];
                txtcategory.ValueMember = "Category_ID";
                txtcategory.DisplayMember = "Category";
                txtsemester.DataSource = objDB.objDataset.Tables[0];
                txtsemester.DisplayMember = "Semester";
                txtsemester.ValueMember = "semester_Id";
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            savecancel();
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
        }

        private void categoryidname()
        {
            if (txtcourse.SelectedIndex > 0)
            {
                txtcategory.DataSource = null;
                txtcategory.Text = "";
                txtsemester.DataSource = null;
                txtsemester.Text = "";
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
            else if (txtcourse.SelectedIndex == 0)
            {
                txtcategory.DataSource = null;
                txtcategory.Text = "";
                txtsemester.DataSource = null;
                txtsemester.Text = "";
                txtbooks.Text = "";
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
            else if (txtcategory.SelectedIndex == 0)
            {

                txtsemester.DataSource = null;
                txtsemester.Text = "";
                txtbooks.Text = "";
            }
        }

        private void txtcourse_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtcourse.Text.Trim().Length != 0 && e.KeyCode == Keys.F1)
            {
                courseidname();
                txtcourse.DropDownStyle = ComboBoxStyle.DropDownList;
                txtcourse.DroppedDown = true;
                txtcategory.DataSource = null;
                txtcategory.Text = "";
                txtsemester.Text = "";
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
            if (btnsave.Text == "Update")
            {
                //semestername();
            }
            else if (btnsave.Text == "Save" && txtsemester.Text.Trim().Length != 0 && txtsemester.SelectedIndex != 0)
            {
                txtbooks.Focus();
            }
        }

        private void txtbooks_TextChanged(object sender, EventArgs e)
        {
            if (number == 1)
            {
                if (txtcourse.SelectedIndex == 0)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Plese Select Course ", "Error", 3000);
                    txtcourse.Focus();
                    return;
                }
                else if (txtcategory.SelectedIndex == 0)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Plese Select Category", "Error", 3000);
                    txtcategory.Focus();
                    return;
                }
                else if (txtsemester.SelectedIndex == 0)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Plese Select Semester", "Error", 3000);
                    txtsemester.Focus();
                    return;
                }
            }
        }
    }
}
