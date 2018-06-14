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
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace websitebackend
{
    public partial class picture : Form
    {
        int? clientid;
        public picture(int valueid)
        {
            InitializeComponent();
            clientid = valueid;
        }

        private void picture_Load(object sender, EventArgs e)
        {
            if (clientid == 0)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            if (clientid != 0)
            {
                this.Size = new Size(1340, 630);
                this.Location = new Point(20, 60);
                
            }
            name();
            ComboBox item = new ComboBox();
            item.Text = "Salary Slip";
            item.ValueMember = "attachsalaryproof";
            item.Text = "Student Photo";
            item.ValueMember = "selfphoto";
            item.Text = "Guardian Photo";
            item.ValueMember = "parentphoto";
            item.Text = "Light Bill";
            item.ValueMember = "lightbill";
            item.Text = "Mark Sheet";
            item.ValueMember = "marksheet";
            item.Text = "College Id";
            item.ValueMember = "collegeid";
            item.Text = "Aadhar Card";
            item.ValueMember = "aadharcard";
            compicture.Items.Add(item);

        }

        public void name()
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string strQuery = "";
            if (clientid != 0)
            {
                strQuery = "SELECT pkclient AS [Id],(firstname+' '+middlename+' '+lastname)AS NAME FROM dbo.client WHERE pkclient='" + clientid + "'";
            }
            else
            {
                strQuery = "SELECT pkclient AS [Id],(firstname+' '+middlename+' '+lastname)AS NAME FROM dbo.client";
            }
            if (objDB.objExecuteQuery(strQuery, clsSqlHelper.QueryExcution.ExecuteDataAdapter))
            {
                txtname.DataSource = objDB.objDataset.Tables[0];
                txtname.ValueMember = "ID";
                txtname.DisplayMember = "NAME";
            }
            if (clientid == 0)
            {
                DataRow dr = objDB.objDataset.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["NAME"] = "-Select Course-";
                objDB.objDataset.Tables[0].Rows.InsertAt(dr, 0);
                txtname.SelectedIndex = 0;
            }
            else
            {
                txtname.SelectedIndex = 0;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string fullpath = "";
            string attachsalaryproof = "";
            string selfphoto = "";
            string parentphoto = "";
            string lightbill = "";
            string marksheet = "";
            string collegeid = "";
            string aadharcard = "";
            if (string.IsNullOrEmpty(fullpath))
            {
                clientid = Int32.Parse(txtname.SelectedValue.ToString());
                var path = System.Configuration.ConfigurationManager.AppSettings["filepath"];
                clsSqlHelper ObjBD = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> DicData = new Dictionary<string, object>();
                DicData.Add("@pkclient", clientid);
                //0         1         2         3         4           5           6
                string SubQuery = "SELECT parentphoto,selfphoto,aadharcard,lightbill,marksheet,collegeid,attachsalaryproof FROM dbo.client WHERE pkclient=@pkclient";
                ObjBD.objExecuteQuery(SubQuery, clsSqlHelper.QueryExcution.ExecuteReader, DicData);
                if (ObjBD.dtrData.HasRows && ObjBD.dtrData.Read() && !ObjBD.dtrData.IsDBNull(0))
                {
                    parentphoto = ObjBD.dtrData.GetString(0).Remove(0, 15);
                    selfphoto = ObjBD.dtrData.GetString(1).Remove(0, 15);
                    aadharcard = ObjBD.dtrData.GetString(2).Remove(0, 15);
                    lightbill = ObjBD.dtrData.GetString(3).Remove(0, 15);
                    marksheet = ObjBD.dtrData.GetString(4).Remove(0, 15);
                    collegeid = ObjBD.dtrData.GetString(5).Remove(0, 15);
                    attachsalaryproof = ObjBD.dtrData.GetString(6).Remove(0, 15);
                }
                switch (compicture.SelectedIndex)
                {

                    case 0:
                        fullpath = path + attachsalaryproof;
                        break;
                    case 1:
                        fullpath = path + selfphoto;
                        break;
                    case 2:
                        fullpath = path + parentphoto;
                        break;
                    case 3:
                        fullpath = path + lightbill;
                        break;
                    case 4:
                        fullpath = path + marksheet;
                        break;
                    case 5:
                        fullpath = path + collegeid;
                        break;
                    case 6:
                        fullpath = path + aadharcard;
                        break;
                    default:
                        break;
                }
            }
            try
            {
                picselfphoto.SizeMode = PictureBoxSizeMode.AutoSize;
                picselfphoto.Image = Image.FromFile(fullpath);
            }
            catch (Exception ex)
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Image Not Found " + Environment.NewLine + ex + "", "Message", 3000);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtname.DataSource = null;
            compicture.Text = "";

        }

        private void picture_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

    }
}
