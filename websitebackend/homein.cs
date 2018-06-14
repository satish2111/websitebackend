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
    public partial class homein : Form
    {
        public homein()
        {
            InitializeComponent();
        }

        private void homein_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.Employeeview.Rows.Add("1", "New Registration");//Sp_admin_client_view
            this.Employeeview.Rows.Add("2", "Books");//Sp_admin_book_select
            this.Employeeview.Rows.Add("3", "Stock");//Sp_admin_stock_select
            this.Employeeview.Rows.Add("4", "Books Issue");//Sp_admin_bookissue
            this.Employeeview.Rows.Add("5", "Books Payment Return");//
            this.Employeeview.Rows.Add("6", "Books Return");//
            this.Employeeview.Rows.Add("7", "Clear");//clear
            Employeeview.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
        }

        private void Employeeview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clsSqlHelper objDB = new clsSqlHelper(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            
            int caseProcedureName = Convert.ToInt32(Employeeview.CurrentRow.Cells[0].Value);
            string srtProcedureName = "";

            switch (caseProcedureName)
            {
                case 1:
                    srtProcedureName = "Sp_admin_client_view";
                    dic.Add("@StatementType", "SELECTALL");
                    dic.Add("@stardate", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));
                    dic.Add("@enddate", Convert.ToDateTime(DateTime.Now.AddDays(+1)).ToString("yyyy-MM-dd"));
                    break;

                case 2:
                    srtProcedureName = "Sp_admin_book_select";
                    dic.Add("@StatementType", "Home");
                    break;

                case 3:
                    srtProcedureName = "Sp_admin_stock_select";
                    dic.Add("@StatementType", "SELECTALL");
                    break;

                case 4:
                    srtProcedureName = "Sp_admin_bookissue";
                    dic.Add("@setdate", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));
                    dic.Add("@enddate", Convert.ToDateTime(DateTime.Now.AddDays(+1)).ToString("yyyy-MM-dd"));
                    break;

                case 5:
                    srtProcedureName = "Sp_admin_masterpayment_select";
                    dic.Add("@StatementType", "SELECTALL");
                    break;
                    
                case 6:
                    srtProcedureName = "Sp_admin_book_return_view";
                    break;

                case 7:
                    srtProcedureName = "Clear";
                    show.DataSource = null;
                    show.Rows.Clear();
                    show.Columns.Clear();
                    break;

                default:
                    break;
            }


            if (objDB.objExecuteQuery(srtProcedureName, clsSqlHelper.QueryExcution.storeProcedure, dic))
            {
                DataTable dt = new DataTable();
                dt = objDB.objDataset.Tables[0];
                show.DataSource = dt;
            }
            show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            show.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
            show.ClearSelection();
        }
    }
}
