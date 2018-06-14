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
    public partial class category : Form
    {
        int? fkemployeeid;
        string usernamefind;
        int? pkidcategory;

        public category(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);

        }

        private void category_Load(object sender, EventArgs e)
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
            string StrQuery = "SELECT MAX(pkidcategory) FROM dbo.category";
            objDB.objExecuteQuery(StrQuery, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
               
                values.Text = (objDB.dtrData.GetInt32(0) + 1).ToString();
            }
            else
            {
                values.Text = "1";
            }
            courseidname();
            chkactive.Checked = true;

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
            dic.Add("@pkidcategory", pkidcategory);
            if (objDB.objExecuteQuery("Sp_admin_category_select", clsSqlHelper.QueryExcution.storeProcedure, dic))
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

        public void idcourse()
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@category", usernamefind);
            string qu = "SELECT pkidcategory FROM dbo.category WHERE category=@category";
            objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                pkidcategory = objDB.dtrData.GetInt32(0);
            }
        }

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            usernamefind = txtsearch.Text;
            idcourse();
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcourse.Text.Trim().Length != 0 && txtcategory.Text.Trim().Length != 0)
            {
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@fkcourseid", txtcourse.SelectedValue);
                dic.Add("@category", txtcategory.Text);
                bool active = chkactive.Checked;
                if (active == true)
                    dic.Add("@isactive", "True");
                else
                    dic.Add("@isactive", "False");
                dic.Add("@fkemployeeid", fkemployeeid);
                if (btnsave.Text == "Save")
                {
                    dic.Add("@StatementType", "insert");
                }
                else if (btnsave.Text == "Update")
                {
                    dic.Add("@StatementType", "update");
                    dic.Add("@pkidcategory", pkidcategory);

                }
                if (objDB.objExecuteQuery("Sp_admin_category_insert_update", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    DataTable dt = new DataTable();
                    dt = objDB.objDataset.Tables[0];
                    if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                    {
                        AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                    }
                    else { AutoClosingMessage.AutoClosingMessageBox.Show("Data Already Saved " + Environment.NewLine + " Category ID:-" + dt.Rows[0][0].ToString() + "", "Message", 5000); }
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
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                values.Text = dataload.CurrentRow.Cells["ID"].Value.ToString();
                txtcategory.Text = dataload.CurrentRow.Cells["Category"].Value.ToString();
                pkidcategory = int.Parse(values.Text);
                string qu = "SELECT b.course AS [Coures],b.pkcourseid,a.active  FROM dbo.category a JOIN dbo.course b ON a.fkcourseid=b.pkcourseid WHERE a.pkidcategory=" + pkidcategory + "";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
                {
                    txtcourse.DataSource = objDB.objDataset.Tables[0];
                    txtcourse.DisplayMember = "Coures";
                    txtcourse.ValueMember = "pkcourseid";
                    bool active = Convert.ToBoolean(objDB.objDataset.Tables[0].Rows[0][2]);
                    if (active)
                    { chkactive.Checked = true; }
                    else { chkactive.Checked = false; }
                }
                firstpanel.Visible = false;
                dataload.Visible = false;
                thirdpanel.Visible = true;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            savecancel();
        }

        private void courseidname()
        {
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

        private void txtcourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtcourse.SelectedIndex > 0)
            {
                txtcategory.Focus();
            }
        }

        private void txtcourse_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnsave.Text == "Update" && e.KeyCode==Keys.F1)
            {
                courseidname();
            }
        }
    }
}
