using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace websitebackend
{
    public partial class labelPrint : Form
    {
        public labelPrint()
        {
            InitializeComponent();
        }

        private void labelPrint_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnsearch.Visible = false;
            btnhidesearch.Visible = true;
        }
    }
}
