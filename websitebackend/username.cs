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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using message;

namespace websitebackend
{
    class backup
    {

        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        SqlCommandBuilder sqlCommandB;
        DataSet ds;
        public static SqlConnection con = null;

        public void conection_today()
        {
            Cursor.Current = Cursors.WaitCursor;
            con = new SqlConnection("Data Source=localhost; Initial Catalog= website; User Id= sa;Password=sql#2008");
            string dbname = "website";
            string destdir = "e:\\backupdb";

            if (!Directory.Exists(destdir))
                Directory.CreateDirectory(destdir);
            
            try
            {
                string a = dbname+"_"+DateTime.Now.ToString("dd-MM-yyyy_hhmmss");
                con.Open();
                cmd = new SqlCommand("backup database  " + dbname + " to disk='" + destdir + "\\"+a + ".Bak'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                AutoClosingMessage.AutoClosingMessageBox.Show("Backup database successfully " + Environment.NewLine + " " + Environment.NewLine + " Back Name " + a + "", "Massage", 3000);
                Cursor.Current = Cursors.Hand;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error During backup database!");
            }

        }

        internal void username(string un)
        {
            throw new NotImplementedException();
        }
    }
}
