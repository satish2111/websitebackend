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
    public partial class course : Form
    {
        int? fkemployeeid;
        string usernamefind;
        int? pkidcourse;

        public course(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);

        }

        private void course_Load(object sender, EventArgs e)
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
            string StrQuery = "SELECT MAX(pkcourseid) FROM dbo.course";
            objDB.objExecuteQuery(StrQuery, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                values.Text = (objDB.dtrData.GetInt32(0) + 1).ToString();
            }
            else
            {
                values.Text = "1";
            }
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
            dic.Add("@pkcourseid", pkidcourse);
            if (objDB.objExecuteQuery("Sp_admin_course_select", clsSqlHelper.QueryExcution.storeProcedure, dic))
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
            dic.Add("@course", usernamefind);
            string qu = "SELECT pkcourseid FROM dbo.course WHERE course=@course";
            objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
            if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
            {
                pkidcourse = objDB.dtrData.GetInt32(0);
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
            if (txtcourse.Text.Trim().Length != 0)
            {
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@course", txtcourse.Text);
                dic.Add("@depositamount", txtdepositamt.Text);
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
                    dic.Add("@pkcourseid", pkidcourse);

                }
                if (objDB.objExecuteQuery("Sp_admin_course_insert_update", clsSqlHelper.QueryExcution.storeProcedure, dic))
                {
                    DataTable dt = new DataTable();
                    dt = objDB.objDataset.Tables[0];
                    if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                    {
                        AutoClosingMessage.AutoClosingMessageBox.Show("Data Saved", "Message", 3000);
                    }
                    else { AutoClosingMessage.AutoClosingMessageBox.Show("Data Already Saved " + Environment.NewLine + " Course ID:-" + dt.Rows[0][0].ToString() + "", "Message", 5000); }
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
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@pkcourseid", dataload.CurrentRow.Cells["ID"].Value.ToString());
                string qu = "SELECT pkcourseid  AS [ID],Course AS [Course],depositamount,active  FROM dbo.course WHERE pkcourseid=@pkcourseid";
                objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
                if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
                {
                    values.Text = objDB.dtrData.GetInt32(0).ToString();
                    txtcourse.Text = objDB.dtrData.GetString(1);
                    pkidcourse = int.Parse(values.Text);
                    txtdepositamt.Text = objDB.dtrData.GetDecimal(2).ToString();
                    bool active = Convert.ToBoolean(objDB.dtrData.GetString(3));
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

        private void txtdepositamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

    }
}
