using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using websitebackend.Properties;
using HelperLibrary;
using message;




namespace websitebackend
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;

        public static string GetConnectionString()
        {
            string connectionString = string.Empty;
            connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            return connectionString;
        }

        public void Connection()
        {
            string MY = websitebackend.login.GetConnectionString();
            con = new SqlConnection(MY);
        }

        private void login_Load(object sender, EventArgs e)
        {
            Connection();
        }
        private void likForPassword_MouseHover(object sender, EventArgs e)
        {
            likForPassword.ForeColor = Color.Red;
        }

        private void likForPassword_MouseLeave(object sender, EventArgs e)
        {
            likForPassword.ForeColor = Color.FromArgb(59, 89, 152);
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void likForPassword_MouseEnter(object sender, EventArgs e)
        {
            likForPassword.ForeColor = Color.Red;
        }

        private void likForPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginpanel.Visible = false;
            forgotpanel.Visible = true;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage massage = new MailMessage();
            massage.From = new MailAddress("satishsharma678@gmail.com");
            string use = txtforusername.Text;
            string password = "";
            string mailid = "";
            string html1 = "";
            cmd = new SqlCommand("SELECT EMAILID,PASSWORD FROM dbo.signup WHERE USERNAME ='" + use + "'", con);
            Connection();
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mailid = dr.GetString(0);
                password = dr.GetString(1);
                con.Close();
                if (mailid != null && password != null)
                {
                    html1 += "<!DOCTYPE html>                                       "
+ "<html>                                                "
+ "<head>                                                "
+ "<style>                                               "
+ "table {width:100%;}                                   "
+ "table  tr:nth-child(even) {background-color: #eee;}"
+ "table  tr:nth-child(odd) {background-color:#fff;}  "
+ "table  th	{background-color: #3B5998;color: #00FF00;}  "
+ "</style>                                              "
+ "</head>                                               "
+ "<body>                                                "
                        //+ "<table id="t01">                                      "
+ "  <tr>                                                "
+ "    <th>Your Usename</th>                             "
+ "    <th>Your mail id</th>                             "
+ "    <th>Password</th>		                         "
+ "  </tr>                                               "
+ "  <tr>		                                         "
+ "    <td  align=center>" + use + "</td>                              "
+ "    <td align=center>" + mailid + "</td>                           "
+ "    <td align=center >" + password + "</td>                         "
+ "  </tr>                                               "
+ "</table>                                              "
+ "</body>                                               "
+ "</html>												";

                    txtforusername.Clear();
                    massage.To.Add(mailid);
                    //massage.Body = "Your Usename is '" + use + "' '" + Environment.NewLine + "'Your mail Id Is '" + mailid + "' '" + Environment.NewLine + "' Password  Is '" + password + "'";
                    massage.Body = html1;
                    massage.IsBodyHtml = true;
                    massage.Subject = "Recall Password";
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential("satishsharma678@gmail.com", "satish14@");
                    client.Send(massage);
                    AutoClosingMessage.AutoClosingMessageBox.Show("Please Check Your Mail For Password", "Massage", 4000);
                    forgotpanel.Visible = false;
                    loginpanel.Visible = true;
                    Cursor.Current = Cursors.Arrow;
                }
            }
            else
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Usename Not Found OR Mail not Found In System. Plase Try Again", "Massage", 1500);
                con.Close();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Trim().Length != 0 && txtpassword.Text.Trim().Length != 0)
            {
                clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@username", txtusername.Text);
                dic.Add("@password", txtpassword.Text);
                string qu = "SELECT pkemployeeid,firstname+' '+lastname FROM dbo.signup WHERE username=@username AND password=@password";
                objDB.objExecuteQuery(qu, clsSqlHelper.QueryExcution.ExecuteReader, dic);
                if (objDB.dtrData.HasRows && objDB.dtrData.Read() && !objDB.dtrData.IsDBNull(0))
                {
                    int id = objDB.dtrData.GetInt32(0);
                    string name = objDB.dtrData.GetString(1);
                    this.Hide();
                    home home = new home();
                    home.namef = name;
                    home.idf = id;
                    home.Show();
                }
                else
                {
                    AutoClosingMessage.AutoClosingMessageBox.Show("Invalid Username or Password", "Error", 3000);
                    txtpassword.Clear();
                }
            }
            else
            {
                AutoClosingMessage.AutoClosingMessageBox.Show("Enter Username And Password", "Error", 3000);
                txtpassword.Clear();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtusername.Text.Trim().Length != 0 && txtpassword.Text.Trim().Length != 0 && e.KeyCode==Keys.Enter)
            {
                BtnLogin.Focus();
                BtnLogin.PerformClick();
            }
            
        }
    }
}
