using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;

namespace ProjectHotel
{
    public partial class ReportCustomer : Form
    {
        public ReportCustomer()
        {
            InitializeComponent();
        }

        private void ReportCustomer_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();

            rd.Load("C:\\Users\\Abdullah Fawwaz Q\\Documents\\Visual Studio 2015\\Projects\\ProjectHotel\\ProjectHotel\\CrystalReport1.rpt");

            crystalReportViewer1.ReportSource = rd;
        }
    }
}
