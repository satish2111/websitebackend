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

namespace websitebackend
{
    public partial class currentstock : Form
    {
        public currentstock()
        {
            InitializeComponent();
        }

        private void paymentpaid_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            datagridload();
        }


        public void datagridload()
        {
            dataload.DataSource = null;
            dataload.Rows.Clear();
            dataload.Columns.Clear();
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            if (objDB.objExecuteQuery("Sp_admin_currentstock", clsSqlHelper.QueryExcution.storeProcedure))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                dataload.DataSource = dt;
            }
            dataload.ReadOnly = true;
            dataload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataload.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataload.ClearSelection();
            //						

            dataload.Columns["Srno"].DisplayIndex = 0;
            dataload.Columns["Course"].DisplayIndex = 1;
            dataload.Columns["Category"].DisplayIndex = 2;
            dataload.Columns["Semester"].DisplayIndex = 3;
            dataload.Columns["Books"].DisplayIndex = 4;
            dataload.Columns["Qty"].DisplayIndex = 5;
            dataload.Columns["status"].DisplayIndex = 6;
        }
    }
}
