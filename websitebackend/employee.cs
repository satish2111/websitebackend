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
    public partial class employee : Form
    {
        int? fkemployeeid;
        string usernamefind;
        public employee(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);
        }

        private void employee_Load(object sender, EventArgs e)
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
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string StrQuery = "SELECT MAX(pkemployeeid) FROM dbo.signup";
            objDB.objExecuteQuery(StrQuery, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                values.Text = (objDB.dtrData.GetInt32(0) + 1).ToString();
            }
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
            usernamefind = txtsearch.Text;
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
            dic.Add("@username", usernamefind);
            if (objDB.objExecuteQuery("Sp_admin_signup_select", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }
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

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim().Length != 0)
            {
                datagridload();
            }
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text != txtconfirmpassword.Text)
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Password And confirm Password Same", "Error", 3000);
                txtpassword.Clear();
                txtconfirmpassword.Clear();
                txtpassword.Focus();
                return;
            }
            else if (txtfirstname.Text.Trim().Length != 0 && txtmiddlename.Text.Trim().Length != 0 && txtlastname.Text.Trim().Length != 0 && txtusername.Text.Trim().Length != 0 && txtpassword.Text.Trim().Length != 0)
            {
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@firstname", txtfirstname.Text);
                dic.Add("@middlename", txtmiddlename.Text);
                dic.Add("@lastname", txtlastname.Text);
                dic.Add("@emailid", txtusername.Text);
                dic.Add("@username", txtusername.Text);
                dic.Add("@password", txtpassword.Text);
                dic.Add("@fkemployeeid", fkemployeeid);
                if (btnsave.Text == "Save")
                {
                    dic.Add("@StatementType", "insert");
                }
                else if (btnsave.Text == "Update")
                {
                    dic.Add("@StatementType", "update");
                }
                if (objDB.objExecuteQuery("Sp_admin_signup_insert_update", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                    savecancel();
                }
            }
            else 
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Fill All Detail","Message",3000);
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
            }
            //else if (e.RowIndex >= 0 && e.ColumnIndex == dataload.Columns["Delete"].Index)
            //{
            //    btnsave.Text = "Delete";
            //}

            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@username", dataload.CurrentRow.Cells["USERNAME"].Value.ToString());
            string qu = "SELECT  pkemployeeid,firstname ,middlename ,lastname ,username ,password FROM dbo.signup WHERE username=@username";
            objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                values.Text = objDB.dtrData.GetInt32(0).ToString();
                txtfirstname.Text = objDB.dtrData.GetString(1);
                txtmiddlename.Text = objDB.dtrData.GetString(2);
                txtlastname.Text = objDB.dtrData.GetString(3);
                txtusername.Text = objDB.dtrData.GetString(4);
                txtpassword.Text = objDB.dtrData.GetString(5);
            }
            firstpanel.Visible = false;
            dataload.Visible = false;
            thirdpanel.Visible = true;

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            savecancel();
        }

     
    }
}
