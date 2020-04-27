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
    public partial class ReportView : Form
    {
        public ReportView(string report, string[] data)
        {
            InitializeComponent();
            ReportDocument rpt = new ReportDocument();
            if (report == "repair")
            {// ซ่อม
                rpt.Load(System.IO.Directory.GetParent(@"../../").ToString() + "\\ReportRepair.rpt");
                rpt.SetParameterValue("fromdate", data[0]);
                rpt.SetParameterValue("todate", data[1]);
            }
            else if (report == "spare")
            {//อะไหล่
                rpt.Load(System.IO.Directory.GetParent(@"../../").ToString() + "\\ReportSpare.rpt");
            }
            else if (report == "pay") 
            {//รายได้
                rpt.Load(System.IO.Directory.GetParent(@"../../").ToString() + "\\ReportPay.rpt");
                rpt.SetParameterValue("fromdate", data[0]);
                rpt.SetParameterValue("todate", data[1]);
            } 
            else if (report == "count") 
            { //สรุปยอด
                rpt.Load(System.IO.Directory.GetParent(@"../../").ToString() + "\\ReportCount.rpt");
                rpt.SetParameterValue("fromdate", data[0]);
                rpt.SetParameterValue("todate", data[1]);
            }

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

        private void ReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
