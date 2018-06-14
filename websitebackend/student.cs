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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

namespace websitebackend
{
    public partial class student : Form
    {
        int? fkemployeeid;
        string updatepath;

        public student(string valueid)
        {
            InitializeComponent();
            fkemployeeid = Convert.ToInt32(valueid);
        }

        private void student_Load(object sender, EventArgs e)
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
            txtownrenthouse.SelectedIndex = 0;
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

        public void savecancel()
        {
            ClearTextBoxes(this);
            firstpanel.Visible = true;
            secondpanel.Visible = false;
            thirdpanel.Visible = false;
            datagridload();
            dataload.Visible = true;
            btnhidesearch.Visible = false;
            btnsearch.Visible = true;
            btnadd.Visible = true;

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

        public void datagridload()
        {
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            string type;
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (secondpanel.Visible == false)
            {
                txtfromdate.Value = DateTime.Now;
                txttodate.Value = DateTime.Now.AddDays(+1);
                type = "SELECTALL";
                dic.Add("@stardate", Convert.ToDateTime(txtfromdate.Value).ToString("yyyy-MM-dd"));
                dic.Add("@enddate", Convert.ToDateTime(txttodate.Value).ToString("yyyy-MM-dd"));
                dic.Add("@StatementType", type);
            }
            else
            {
                if (txtsearch.Text.Trim().Length == 0 && txtsearchlastname.Text.Trim().Length == 0)
                {
                    type = "SELECTALL";
                    dic.Add("@stardate", Convert.ToDateTime(txtfromdate.Value).ToString("yyyy-MM-dd"));
                    dic.Add("@enddate", Convert.ToDateTime(txttodate.Value).ToString("yyyy-MM-dd"));
                    dic.Add("@StatementType", type);
                }
                else if (txtsearch.Text.Trim().Length != 0 || txtsearchlastname.Text.Trim().Length != 0)
                {
                    type = "SELECTONE";
                    dic.Add("@firstname", txtsearch.Text);
                    dic.Add("@lastname", txtsearchlastname.Text);
                    dic.Add("@StatementType", type);
                }

            }
            if (objDB.objExecuteQuery("Sp_admin_client_view", clsSqlHelper.QueryExcution.storeProcedure, dic))
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

            //var col6 = new DataGridViewButtonColumn();
            //col6.HeaderText = "PDF";
            //col6.Name = "PDF";
            //col6.Text = "PDF";
            //col6.UseColumnTextForButtonValue = true;
            //dataload.Columns.AddRange(new DataGridViewColumn[] { col6 });
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = inputValidation();
            if (!string.IsNullOrEmpty(Convert.ToString(sb)))
            {
                //Response.Write("<script>alert(" + sb.ToString() + ");</script>");
                string test = sb.ToString();
                AutoClosingMessage.AutoClosingMessageBox.Show("" + test + "", "Error", 10000);
                return;
            }
            clsSqlHelper ObjBD = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> DicData = new Dictionary<string, object>();
            string extgardian = Path.GetExtension(filegardian.Text.ToString());
            string extstudent = Path.GetExtension(filestudent.Text.ToString());
            string extlight = Path.GetExtension(filelight.Text.ToString());
            string extmarksheet = Path.GetExtension(filemarksheet.Text.ToString());
            string extcollage = Path.GetExtension(filecollage.Text.ToString());
            string extaadhar = Path.GetExtension(fileaadhar.Text.ToString());
            string extsalary = Path.GetExtension(filesalaryslip.Text.ToString());
            string strGUID = "";
            var strFullServerPath = "";
            string strFilePath = "";
            var appPath = System.Configuration.ConfigurationManager.AppSettings["filepath"];

            #region Folder Creation
            if (btnsave.Text == "Save")
            {
                strGUID = Guid.NewGuid().ToString().Replace("-", "");

                strFullServerPath = appPath + (strGUID);
                if (!System.IO.Directory.Exists(strFullServerPath))
                {
                    System.IO.Directory.CreateDirectory(strFullServerPath);
                }
            }
            else if (btnsave.Text == "Update")
            {

                strGUID = updatepath.Remove(updatepath.LastIndexOf('\\')).Replace(@"\\clientImages\\", "");
                strFullServerPath = appPath + (strGUID);

            }


            #endregion Folder Creation
            //       /clientimages/588434b2c8b44e69a7c7843f4c24dd6d

            #region Uploading Document

            uploadDocument(filestudent.Text, "student", extstudent, strFullServerPath);
            uploadDocument(filelight.Text, "light", extlight, strFullServerPath);
            uploadDocument(filemarksheet.Text, "marksheet", extmarksheet, strFullServerPath);
            uploadDocument(filecollage.Text, "collage", extcollage, strFullServerPath);
            uploadDocument(fileaadhar.Text, "aadhar", extaadhar, strFullServerPath);
            uploadDocument(filegardian.Text, "Guardian", extgardian, strFullServerPath);
            uploadDocument(filesalaryslip.Text, "salaryslip", extsalary, strFullServerPath);

            DicData.Add("@selfphoto", "\\clientImages\\" + strGUID +  @"\student" + extstudent);
            DicData.Add("@lightbill", "\\clientImages\\" + strGUID +  @"\light" + extlight);
            DicData.Add("@marksheet", "\\clientImages\\" + strGUID +  @"\marksheet" + extmarksheet);
            DicData.Add("@collegeid", "\\clientImages\\" + strGUID +  @"\collage" + extcollage);
            DicData.Add("@aadharcard", "\\clientImages\\" + strGUID + @"\aadhar" + extaadhar);
            DicData.Add("@parentphoto", "\\clientImages\\" + strGUID +@"\Guardian" + extgardian);
            DicData.Add("@attachsalaryproof", "\\clientImages\\" + strGUID +@"\salaryslip" + extsalary);
            #endregion

            DicData.Add("@firstname", txtfirstname.Text.ToUpper().Trim());
            DicData.Add("@middlename", txtmiddlename.Text.ToUpper().Trim());
            DicData.Add("@lastname ", txtlastname.Text.ToUpper().Trim());
            DicData.Add("@address1 ", txtaddress1.Text.ToUpper().Trim());
            DicData.Add("@address2 ", txtaddress2.Text.ToUpper().Trim());
            DicData.Add("@moblie ", txtphone.Text.ToUpper().Trim());
            DicData.Add("@city ", txtcity.Text.ToUpper().Trim());
            DicData.Add("@state ", txtstatus.Text.ToUpper().Trim());
            DicData.Add("@country ", "INDIA");
            DicData.Add("@pincode ", txtpincode.Text.ToUpper().Trim());
            DicData.Add("@emailid ", txtemail.Text.Trim());
            DicData.Add("@username ", txtemail.Text.Trim());
            DicData.Add("@password ", txtpassword.Text);
            DicData.Add("@familymemberno", txtfamilyno.Text.Trim());
            if (!string.IsNullOrEmpty(txttotalearning.Text))
            {
                DicData.Add("@familyincome ", txttotalearning.Text.Trim());
            }
            else { DicData.Add("@familyincome ", '0'); }
            DicData.Add("@ownhouseorrent ", txtownrenthouse.SelectedItem);
            DicData.Add("@scholarship ", txtscholarship.Text.Trim());
            DicData.Add("@totalmark ", txttotalmark.Text.Trim());
            DicData.Add("@percentage ", txtpercentage.Text.Trim());
            DicData.Add("@caste ", txtcaste.Text.Trim());
            DicData.Add("@collagename ", txtcollagename.Text.ToUpper().Trim());
            DicData.Add("@std", txtstd.Text.Trim());
            DicData.Add("@promise", "YES");

            

            if (btnsave.Text == "Save")
                DicData.Add("@StatementType", "INSERT");
            else if (btnsave.Text == "Update")
            {
                DicData.Add("@pkclient", dataload.CurrentRow.Cells["Id"].Value);
                DicData.Add("@StatementType", "UPDATE");
            }


            if (ObjBD.objExecuteQuery("SpInsertUserinfrom", HelperLibrary.clsSqlHelper.QueryExcution.storeProcedure, DicData))
            {
                DataTable dt = new DataTable();
                dt = ObjBD.objDataset.Tables[0];

                if (Convert.ToInt32(dt.Rows[0][0]) == -99)
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Email ID is Already Exist", "Message", 3000);
                    txtemail.Focus();
                    return;
                }
                AutoClosingMessage.AutoClosingMessageBox.Show("Please Login With UserName :- " + txtemail.Text + " ;", "Message", 3000);

                ClearTextBoxes(this);
                savecancel();

            }
        }

        /// <summary>
        /// TO Upload the document on server
        /// </summary>
        /// <param name="strFileName"> file name</param>
        /// <param name="fileExtension">file extension</param>
        /// <param name="strFullPath"> complete path ('c:/document')</param>
        /// <param name="strFilePath"> file path ('/clientimages/guid/')</param>
        /// <returns>file path which need to be save in database</returns>
        private void uploadDocument(string strFileName, string file, string fileExtension, string strFullPath)
        {
            string strReturnFilePath = "";
            try
            {
                if (!string.IsNullOrEmpty(strFileName))
                {
                    string strFile = strFullPath + "/" + file + fileExtension;

                    // To save the file on server
                    // string filestudentpath = appPath +strFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                    File.Copy(strFileName, strFile);
                    strReturnFilePath = strFile;
                }
            }
            catch (Exception ex)
            {

            }
            //return strReturnFilePath;
        }

        private StringBuilder inputValidation()
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            if (string.IsNullOrEmpty(txtfirstname.Text))
            {
                sb.AppendLine(count + " Please Enter the first name. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtmiddlename.Text))
            {
                sb.AppendLine(count + " Please Enter the Middle name. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtlastname.Text))
            {
                sb.AppendLine(count + " Please Enter the Last name. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtaddress1.Text))
            {
                sb.AppendLine(count + " Please Enter the Address. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtphone.Text))
            {
                sb.AppendLine(count + " Please Enter the Phone Number. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtcity.Text))
            {
                sb.AppendLine(count + "Please Enter the City. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtstatus.Text))
            {
                sb.AppendLine(count + " Please Enter the State. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtpincode.Text))
            {
                sb.AppendLine(count + " Please Enter the Pincode. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                sb.AppendLine(count + " Please Enter the Email Id. ");
                count++;
            }
            if (string.IsNullOrEmpty(txttotalmark.Text))
            {
                sb.AppendLine(count + " Please Enter the Total Mark. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtpercentage.Text))
            {
                sb.AppendLine(count + " Please Enter the Percentage. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtcaste.Text))
            {
                sb.AppendLine(count + " Please Enter the Caste. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtcollagename.Text))
            {
                sb.AppendLine(count + " Please Enter the Collage Name. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtstd.Text))
            {
                sb.AppendLine(count + " Please Enter the Standard. ");
                count++;
            }
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                sb.AppendLine(count + " Please Enter the Password");
            }
            return sb;
        }

        private string pathopen()
        {
            string strFileName = null;
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|" +
                            "BMP Files: (*.BMP;*.DIB;*.RLE)|*.BMP;*.DIB;*.RLE|" +
                            "JPEG Files: (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|All Files|*.*";
                op.FilterIndex = 1;
                if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    strFileName = op.FileName;
                }
            }
            catch (Exception ex)
            {
                //logging
            }
            return strFileName;
        }

        private void btnfilegardian_Click(object sender, EventArgs e)
        {
            filegardian.Text = pathopen();
        }

        private void dataload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detail(int.Parse(dataload.CurrentRow.Cells["ID"].Value.ToString()));
            if (e.RowIndex >= 0 && e.ColumnIndex == dataload.Columns["Edit"].Index)
            {
                firstpanel.Visible = false;
                secondpanel.Visible = false;
                dataload.Visible = false;
                thirdpanel.Visible = true;
                btnsave.Text = "Update";
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataload.Columns["PDF"].Index)
            {
                sendMail();
            }
        }

        private void btnsearchclick_Click(object sender, EventArgs e)
        {
            datagridload();
        }

        public void detail( int id)
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
                updatepath = filegardian.Text;
            }
        }

        private void sendMail()
        {
            try
            {
                detail(int.Parse(dataload.CurrentRow.Cells["ID"].Value.ToString()));
                string mailer = "<html> <head> <title></title> </head> <body> <div style =\"line - height:0px; padding - top:10px\" align=\"center\" > <h1><b>SINDHU YOUTH CIRCLE</b></h1> <P>(REDG PUBLIC TRUST - EST-1962)</P> <h4>Behind Santu Bldg, Section- 22, Ulhasnagar - 421003 Phone- 2734916</h4> <br> <h2>SUMAN RAMESH TULSANI &amp;</h2> <h2>SUNDER SHEWAK SABHA BOOK BANK</h2> <br> <b> APPLICATION FORM FOR COLLAGE STUDENT</b> <p>(ONLY FOR NEEDY STUDENTS)</p> </div> <div class=\"notes\" style=\"padding - left: 10px\"> <p>Note: Follow the instruction before filling up the form:</p> <ol><li>Student has to reapply for the books if he/she fails</li> <li>Attach the zerox copy of marksheet of previous std passed</li> <li>Collage I-card</li> <li>Aadhaar card (Address proof)</li> </ol> </div> <br><br> <div class=\"data\"> <h3> Basic Details</h3> <table cellspacing=\"10px\" style=\"padding - left: 55px\"> <tbody> <tr> <td><b>Full Name</b></td> <td>{{fullname}}</td> </tr> <tr> <td><b>Residental Address</b></td> <td>{{address}}</td> </tr> <tr> <td><b>Email</b></td> <td>{{email}}</td> <td><b>mobile no</b></td> <td>{{mobile}}</td> </tr> <tr> <td><b>Name of collage</b></td> <td>{{collagename}}</td> </tr> <tr> <td><b>No. of family members and total earning per month</b></td> <td>{{noofmember}}</td> </tr> <tr> <td><b>Own house or rent</b></td> <td>{{houseorrent}}</td> </tr> <tr> <td><b>Have you won prize / award / scholarship</b></td> <td>{{scholarship}}</td> </tr> <tr> <td><b>Total marks</b></td> <td>{{marks}}</td> <td><b>Percentage</b></td> <td> {{percentage}} %</td> </tr> <tr> <td><b>Date of visit</b></td> <td>{{DOV}}</td> </tr> </tbody> </table> </div> <br><br> <div class=\"books\"> <h3>List of books applied</h3> <ol> {{books}} </ol> </div> <div class=\"footer\"> I promise to return the books as soon as my exams are over <b>WITHIN SEVEN DAYS.</b> I also promise to pay full price of books if they are lost or damaged. </div> </body> </html>";
                mailer = mailer.Replace("{{fullname}}", txtfirstname.Text + " " + txtmiddlename.Text + " " + txtlastname.Text);
                mailer = mailer.Replace("{{address}}", txtaddress1.Text + " " + txtaddress2.Text);
                mailer = mailer.Replace("{{email}}", txtemail.Text);
                mailer = mailer.Replace("{{mobile}}", txtphone.Text);
                mailer = mailer.Replace("{{collagename}}", txtcollagename.Text);
                mailer = mailer.Replace("{{noofmember}}", txtfamilyno.Text);
                mailer = mailer.Replace("{{houseorrent}}", txtownrenthouse.Text);
                mailer = mailer.Replace("{{scholarship}}", txtscholarship.Text);
                mailer = mailer.Replace("{{marks}}", txttotalmark.Text);
                mailer = mailer.Replace("{{percentage}}", txtpercentage.Text + " %");
                StringReader sr = new StringReader(mailer.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    byte[] bytes = memoryStream.ToArray();

                    //memoryStream.Position = 0;
                    System.IO.File.WriteAllBytes(@"e:\\filename.pdf", memoryStream.ToArray());
                    memoryStream.Close();
                    //MailMessage mm = new MailMessage("satishsharma678@gmail.com", UserDetails.emailid);
                    //mm.Subject = "Sindhu Circle";
                    //mm.Body = "Hey \n Your request for books are Approved. \n Please use " + newPassword + " to Login.";
                    //mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Approval.pdf"));
                    //mm.IsBodyHtml = true;
                    //SmtpClient smtp = new SmtpClient();
                    //smtp.Host = "smtp.gmail.com";
                    //smtp.EnableSsl = true;
                    //NetworkCredential NetworkCred = new NetworkCredential();
                    //NetworkCred.UserName = "loadtestbms@gmail.com";
                    //NetworkCred.Password = "Bigtree@1234";
                    //smtp.UseDefaultCredentials = true;
                    //smtp.Credentials = NetworkCred;
                    //smtp.Port = 587;
                    //smtp.Send(mm);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnfilestudent_Click(object sender, EventArgs e)
        {
            filestudent.Text = pathopen();
        }

        private void btnfileaadhar_Click(object sender, EventArgs e)
        {
            fileaadhar.Text = pathopen();
        }

        private void btnfilelight_Click(object sender, EventArgs e)
        {
            filelight.Text = pathopen();
        }

        private void btnfilemarksheet_Click(object sender, EventArgs e)
        {
            filemarksheet.Text = pathopen();
        }

        private void btnfilecollage_Click(object sender, EventArgs e)
        {
            filecollage.Text = pathopen();
        }

        private void btnfilesalaryslip_Click(object sender, EventArgs e)
        {
            filesalaryslip.Text = pathopen();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            savecancel();
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtfamilyno_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtstd_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txttotalmark_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtpercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            double value = 0;
            if (!double.TryParse(txtpercentage.Text + e.KeyChar.ToString(), out value) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttotalearning_KeyPress(object sender, KeyPressEventArgs e)
        {
            double value = 0;
            if (!double.TryParse(txttotalearning.Text + e.KeyChar.ToString(), out value) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtemail_Validating(object sender, CancelEventArgs e)
        {
            Regex mRegxExpression;
            if (txtemail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(txtemail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtemail.Focus();
                }
            }
        }

        private void txtpincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

    }
}
