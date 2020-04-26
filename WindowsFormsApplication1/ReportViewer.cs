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

namespace WindowsFormsApplication1
{
    public partial class ReportViewer : Form
    {
        public ReportViewer(string report, string[] data)
        {
            InitializeComponent();
            ReportDocument rpt = new ReportDocument();
            //if (report =="print_quotation") {
                rpt.Load(System.IO.Directory.GetParent(@"../../").ToString() + "\\QuotationPrint.rpt");
                rpt.SetParameterValue("quo_id", data[0]);
            //}

            try
            {
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดเนื่องจาก : " + ex.Message);
            }
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
           
        }
    }
}
