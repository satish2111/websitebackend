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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using message;
using iTextSharp.text.html.simpleparser;
using System.Drawing.Imaging;
using websitebackend;

namespace websitebackend
{
    public partial class booksissue : Form
    {
        int? fkemployeeid;
        string Book_ID = "";
        string Client_ID = "";
        // string Totaldeposit = "";
        string pk_course_id = "";
        string pk_id_category = "";
        string pk_id_semester = "";
        string Comments = "";
        public booksissue(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);
        }

        private void booksissue_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            datagridload();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (btnsearch.Text != "Back")
            {
                btnsearch.Visible = false;
                btnhidesearch.Visible = true;
                secondpanel.Visible = true;
                dataload.Visible = true;
            }
            else if (btnsearch.Text == "Back")
            {
                btnsearch.Text = "Search";
                detailpanel.Visible = false;
                savecancel();
            }
        }

        private void btnhidesearch_Click(object sender, EventArgs e)
        {
            btnsearch.Visible = true;
            dataload.Visible = true;
            btnhidesearch.Visible = false;
            savecancel();
        }

        public void savecancel()
        {
            detailpanel.Visible = false;
            secondpanel.Visible = false;
            datagridload();
            firstpanel.Visible = true;
            dataload.Visible = true;
            thirdpanel.Visible = false;
            btnsearch.Visible = true;
            Book_ID = "";
            Client_ID = "";
            pk_course_id = "";
            pk_id_category = "";
            pk_id_semester = "";
            Comments = "";
        }

        public void datagridload()
        {
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            if (secondpanel.Visible == false)
            {
                txtfromdate.Value = DateTime.Now;
                txttodate.Value = DateTime.Now.AddDays(+1);
            }
            dic.Add("@setdate", Convert.ToDateTime(txtfromdate.Value).ToString("yyyy-MM-dd"));
            dic.Add("@enddate", Convert.ToDateTime(txttodate.Value).ToString("yyyy-MM-dd"));
            if (objDB.objExecuteQuery("Sp_admin_bookissue", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }
            if (dataload.Rows.Count > 0)
            {
                dataload.Columns["Totaldeposit"].DefaultCellStyle.Format = "0.00##";
                dataload.Columns["pk_course_id"].Visible = false;
                dataload.Columns["pk_id_category"].Visible = false;
                dataload.Columns["pk_id_semester"].Visible = false;
                var col5 = new DataGridViewButtonColumn();
                col5.HeaderText = "Details";
                col5.Name = "Details";
                col5.Text = "Details";
                col5.UseColumnTextForButtonValue = true;
                dataload.Columns.AddRange(new DataGridViewColumn[] { col5 });

                var View = new DataGridViewButtonColumn();
                View.HeaderText = "BooksView";
                View.Name = "Booksview";
                View.Text = "Booksview";
                View.UseColumnTextForButtonValue = true;
                dataload.Columns.AddRange(new DataGridViewColumn[] { View });

                var picture = new DataGridViewButtonColumn();
                picture.HeaderText = "Picture";
                picture.Name = "Picture";
                picture.Text = "Picture";
                picture.UseColumnTextForButtonValue = true;
                dataload.Columns.AddRange(new DataGridViewColumn[] { picture });

                dataload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataload.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                dataload.ClearSelection();
            }
        }

        private void mainseacrch_Click(object sender, EventArgs e)
        {
            datagridload();
        }

        public void visiblecolumns()
        {
            valueId.Text = dataload.Rows[0].Cells["Tran_ID"].Value.ToString();
            valueName.Text = dataload.Rows[0].Cells["Name"].Value.ToString();
            valueCourse.Text = dataload.Rows[0].Cells["Course"].Value.ToString();
            valueCategory.Text = dataload.Rows[0].Cells["Category"].Value.ToString();
            valueSemester.Text = dataload.Rows[0].Cells["Semester"].Value.ToString();
            valueComments.Text = Comments;
            bookdetail.Columns["Id"].Width = 30;
            bookdetail.Columns["Chk"].Width = 80;
            bookdetail.Columns["Barcode"].Width = 80;
            bookdetail.Columns["Book"].Width = 250;
            bookdetail.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

        }

        private void dataload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            if (e.RowIndex >= 0 && dataload.Columns.Contains("Booksview") && e.ColumnIndex == dataload.Columns["Booksview"].Index)
            {
                Book_ID = dataload.CurrentRow.Cells["Tran_ID"].Value.ToString();
                dic.Add("@fk_Req_Id", Book_ID);
                Bookapply(dic, objDB);
            }

            else if (e.RowIndex >= 0 && dataload.Columns.Contains("Details") && e.ColumnIndex == dataload.Columns["Details"].Index)
            {
                btnhidesearch.Visible = false;
                detail(int.Parse(dataload.CurrentRow.Cells["Client_ID"].Value.ToString()));
                firstpanel.Visible = false;
                dataload.Visible = false;
                secondpanel.Visible = false;
                thirdpanel.Visible = true;
            }
            else if (e.RowIndex >= 0 && dataload.Columns.Contains("picture") && e.ColumnIndex == dataload.Columns["picture"].Index)
            {
                bookdetail.Enabled = false;
                int values = int.Parse(dataload.CurrentRow.Cells["Client_ID"].Value.ToString());
                picture o = new picture(values);
                o.Show();
            }
        }

        private void Bookapply(Dictionary<string, object> dic, clsSqlHelper objDB)
        {

            Client_ID = dataload.CurrentRow.Cells["Client_ID"].Value.ToString();
            Comments = dataload.CurrentRow.Cells["Comments"].Value.ToString();
            pk_course_id = dataload.CurrentRow.Cells["pk_course_id"].Value.ToString();
            pk_id_category = dataload.CurrentRow.Cells["pk_id_category"].Value.ToString();
            pk_id_semester = dataload.CurrentRow.Cells["pk_id_semester"].Value.ToString();
            txtdeposit.Text = (Math.Round(Convert.ToDecimal(dataload.CurrentRow.Cells["Totaldeposit"].Value.ToString()), 2)).ToString();
            bookdetail.DataSource = null;
            bookdetail.Rows.Clear();
            bookdetail.Columns.Clear();
            if (objDB.objExecuteQuery("Sp_admin_bookview", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                bookdetail.DataSource = dt;
                if (bookdetail.Rows.Count > 0)
                {
                    DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                    dgvCmb.ValueType = typeof(bool);
                    dgvCmb.Name = "Chk";
                    dgvCmb.HeaderText = "Approved";
                    bookdetail.Columns.Add(dgvCmb);
                    DataGridViewColumn column364 = dataload.Columns["Chk"];
                    visiblecolumns();
                    detailpanel.Visible = true;
                    txtbarcode.Focus(); 
                    firstpanel.Visible = false;
                    secondpanel.Visible = false;
                    dataload.Visible = false;
                    btnhidesearch.Visible = false;
                }
                else if (bookdetail.Rows.Count == 0)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("No Record Found", "Message", 3000);
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string strBooksId = "";

            foreach (DataGridViewRow item in bookdetail.Rows)
            {
                if (Convert.ToBoolean(item.Cells["chk"].Value))
                {
                    if (strBooksId == "")
                    {
                        strBooksId = item.Cells["id"].Value.ToString();
                    }
                    else if (strBooksId != "")
                    {
                        strBooksId = strBooksId + ',' + item.Cells["id"].Value.ToString();
                    }
                }
            }
            if (strBooksId.Trim().Length == 0)
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Select Book", "Error", 3000);
                return;
            }
            strBooksId = strBooksId.TrimEnd(',');
            Dictionary<string, object> dic = new Dictionary<string, object>();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            DialogResult a = MessageBox.Show("Are You Sure For Procedure", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (a == DialogResult.No)
            { return; }

            dic.Add("@pk_Req_id", Book_ID);
            dic.Add("@fkclient", Client_ID);
            dic.Add("@fkemloyeeid", fkemployeeid);
            dic.Add("@totaldeposit", txtdeposit.Text);
            dic.Add("@bookIds", strBooksId);
            dic.Add("@fkcourseid", pk_course_id);
            dic.Add("@fkidcategory", pk_id_category);
            dic.Add("@fkidsemester", pk_id_semester);
            Dictionary<string, SqlDbType> dicOut = new Dictionary<string, SqlDbType>();
            dicOut.Add("@response", SqlDbType.NVarChar);
            bookdetail.DataSource = null;
            bookdetail.Rows.Clear();
            bookdetail.Columns.Clear();
            if (objDB.objExecuteQuery("Sp_admin_finaldone", clsSqlHelper.QueryExcution.storeProcedure, dic, dicOut))
            {
                Dictionary<string, object> dicObject = objDB.objGetOutputParams;
                string strMessage = "";
                if (dicObject.Count > 0)
                {
                    strMessage = "Books " + Convert.ToString(dicObject["@response"]).TrimEnd(',') + " are not approved." + Environment.NewLine + " Please check stock for same";
                }
                else
                {
                    strMessage = "All books are approved.";
                }
                AutoClosingMessage.AutoClosingMessageBox.Show(strMessage, "Message", 5000);
                savecancel();
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            savecancel();
        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtbarcode.Text.Trim().Length != 0)
            {
                foreach (DataGridViewRow item in bookdetail.Rows)
                {
                    if (item.Cells["Barcode"].Value != null)
                    {
                        if (item.Cells["Barcode"].Value.ToString().Equals(txtbarcode.Text.ToString()))
                        {
                            bookdetail.Rows[item.Index].Cells["Chk"].Value = true;
                            txtbarcode.Clear();
                            break;
                        }
                    }
                }
            }
        }

        private void bookdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bookdetail.Columns.Contains("Chk") && e.ColumnIndex == bookdetail.Columns["Chk"].Index)
            {
                if (bookdetail.CurrentRow.Cells["Chk"].Value == null)
                {
                    bookdetail.CurrentRow.Cells["Chk"].Value = true;
                }
                else if (Convert.ToBoolean(bookdetail.CurrentRow.Cells["Chk"].Value) == true)
                {
                    bookdetail.CurrentRow.Cells["Chk"].Value = false;
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            savecancel();
        }

        public void detail(int id)
        {
            clsSqlHelper ObjBD = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> DicData = new Dictionary<string, object>();
            DicData.Add("@pkclient", id);
            //                          0           1         2     3         4     5       6       7         8      9    10    11      12                  13          14          15         16    17         18          19          20      21          22      23          24          25              26
            string SubQuery = "SELECT firstname,middlename,lastname,emailid,moblie,caste,password,address1,address2,city,state,pincode,familymemberno,ownhouseorrent,familyincome,collagename,std,totalmark,percentage,parentphoto,selfphoto,aadharcard,lightbill,marksheet,collegeid,attachsalaryproof,scholarship FROM dbo.client WHERE pkclient=@pkclient";
            ObjBD.objExecuteQuery(SubQuery, clsSqlHelper.QueryExcution.ExecuteReader, DicData);
            if (ObjBD.dtrData.HasRows && ObjBD.dtrData.Read() && !ObjBD.dtrData.IsDBNull(0))
            {
                txtfirstname.Text = ObjBD.dtrData.GetString(0);
                txtmiddlename.Text = ObjBD.dtrData.GetString(1);
                txtlastname.Text = ObjBD.dtrData.GetString(2);
                txtemail.Text = ObjBD.dtrData.GetString(3);
                txtphone.Text = ObjBD.dtrData.GetString(4);
                txtcaste.Text = ObjBD.dtrData.GetString(5);
                txtpassword.Text = ObjBD.dtrData.GetString(6);
                txtaddress1.Text = ObjBD.dtrData.GetString(7);
                txtaddress2.Text = ObjBD.dtrData.GetString(8);
                txtcity.Text = ObjBD.dtrData.GetString(9);
                txtstatus.Text = ObjBD.dtrData.GetString(10);
                txtpincode.Text = ObjBD.dtrData.GetString(11);
                txtfamilyno.Text = ObjBD.dtrData.GetInt32(12).ToString();
                txtownrenthouse.Text = ObjBD.dtrData.GetString(13);
                txttotalearning.Text = ObjBD.dtrData.GetDecimal(14).ToString();
                txtcollagename.Text = ObjBD.dtrData.GetString(15);
                txtstd.Text = ObjBD.dtrData.GetString(16);
                txttotalmark.Text = ObjBD.dtrData.GetInt32(17).ToString();
                txtpercentage.Text = ObjBD.dtrData.GetDecimal(18).ToString();
                filegardian.Text = ObjBD.dtrData.GetString(19);
                filestudent.Text = ObjBD.dtrData.GetString(20);
                fileaadhar.Text = ObjBD.dtrData.GetString(21);
                filelight.Text = ObjBD.dtrData.GetString(22);
                filemarksheet.Text = ObjBD.dtrData.GetString(23);
                filecollage.Text = ObjBD.dtrData.GetString(24);
                filesalaryslip.Text = ObjBD.dtrData.GetString(25);
                txtscholarship.Text = ObjBD.dtrData.GetString(26);
            }
        }

        private void btnapplybooks_Click(object sender, EventArgs e)
        {
            applybookspanel.Visible = true;
            detailpanel.Enabled = false;
            applybookspanel.Enabled = true;
            //DataRow dr = objDB.objDataset.Tables[0].NewRow();
            //dr["id"] = 0;
            //dr["book"] = "-Select Book-";
            //objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
            //txtbook.SelectedIndex = 0;
            txtbook.Focus();
        }

        private void Dvgbooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && Dvgbooks.Columns.Contains("Chk") && e.ColumnIndex == Dvgbooks.Columns["Chk"].Index)
            {
                if (Dvgbooks.CurrentRow.Cells["Chk"].Value == null)
                {
                    Dvgbooks.CurrentRow.Cells["Chk"].Value = true;
                }
                else if (Convert.ToBoolean(Dvgbooks.CurrentRow.Cells["Chk"].Value) == true)
                {
                    Dvgbooks.CurrentRow.Cells["Chk"].Value = false;
                }
            }
        }

        private void btnapplycancel_Click(object sender, EventArgs e)
        {
            txtbook.Text = "";
            txtbook.DataSource = null;
            Dvgbooks.DataSource = null;
            applybookspanel.Visible = false;
            detailpanel.Enabled = true;
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            string strBooksId = "";

            foreach (DataGridViewRow item in Dvgbooks.Rows)
            {
                if (Convert.ToBoolean(item.Cells["chk"].Value))
                {
                    if (strBooksId == "")
                    {
                        strBooksId = item.Cells["Book Id"].Value.ToString();
                    }
                    else if (strBooksId != "")
                    {
                        strBooksId = strBooksId + ',' + item.Cells["id"].Value.ToString();
                    }
                }
            }
            if (strBooksId.Trim().Length == 0)
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Select Book", "Error", 3000);
                return;
            }
            else
            {
                Dictionary<string, object> dicsub = new Dictionary<string, object>();
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                dicsub.Add("@fk_Req_Id", valueId.Text);
                dicsub.Add("@fk_Client_id", Client_ID);
                dicsub.Add("@fk_Book_id", strBooksId);
                dicsub.Add("@fk_admin_id", fkemployeeid);
                if (objDB.objExecuteQuery("Sp_admin_tblTransaction_Details_inster", clsSqlHelper.QueryExcution.storeProcedure, dicsub))
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Book Apply", "Message", 5000);
                    Bookapply(dicsub, objDB);
                    btnapplycancel.PerformClick();
                }
            }

        }

        private void txtbook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtbook.Text.Trim().Length != 0)
            {
                dataloadforapply();
            }
            else if (e.KeyCode == Keys.F1 && txtbook.Text.Trim().Length != 0)
            {
                txtbook.DataSource = null;
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string qu = "SELECT pkidbooks as [id],bookname as [book] FROM dbo.books where bookname LIKE '" + txtbook.Text + "%' ";
                if (objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteDataAdapter, dic))
                {
                    txtbook.DataSource = objDB.objDataset.Tables[0];
                    txtbook.ValueMember = "id";
                    txtbook.DisplayMember = "book";
                    txtbook.DroppedDown = true;
                }
            }
        }

        private void dataloadforapply()
        {
            Dvgbooks.DataSource = null;
            Dvgbooks.Columns.Clear();
            Dvgbooks.Rows.Clear();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            dic.Add("@bookname", txtbook.Text);
            if (objDB.objExecuteQuery("Sp_admin_book_apply", clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                Dvgbooks.DataSource = dt;
            }
            Dvgbooks.Columns["Book Id"].Visible = false;
            Dvgbooks.Columns["Barcode"].Visible = false;
            Dvgbooks.Columns["Qty"].Width = 40;
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Approved";
            Dvgbooks.Columns.Add(dgvCmb);
            DataGridViewColumn column364 = dataload.Columns["Chk"];
            Dvgbooks.Columns["Semester"].Width = 80;
            Dvgbooks.Columns["Chk"].Width = 60;
            Dvgbooks.Columns["Write Name"].Visible = false;
            Dvgbooks.Columns["Publish Year"].Visible = false;
        }

        private void menusfalse()
        {
            ((Form)this.MdiParent).Controls["menus"].Enabled = false;
            ((Form)this.MdiParent).Controls["Logout"].Enabled = false;
            ((Form)this.MdiParent).Controls["backup"].Enabled = false;
        }

        private void menustrue()
        {
            ((Form)this.MdiParent).Controls["menus"].Enabled = true;
            ((Form)this.MdiParent).Controls["Logout"].Enabled = true;
            ((Form)this.MdiParent).Controls["backup"].Enabled = true;
        }

    }
}
