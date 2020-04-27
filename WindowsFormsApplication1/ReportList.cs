using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class ReportList : Form
    {
        public ReportList()
        {
           

            InitializeComponent();
        }
         private void ReportList_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-01");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy-MM-01");
            dateTimePicker4.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker5.Text = DateTime.Now.ToString("yyyy-MM-01");
            dateTimePicker6.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void btn_repair_Click(object sender, EventArgs e)
        {
            string[] data = new string[4];
           
            data[0] = dateTimePicker3.Value.Date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            data[1] = dateTimePicker4.Value.Date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            ReportView rw = new ReportView("repair", data);
            rw.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] data = new string[4];
            ReportView rw = new ReportView("spare", data);
            rw.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] data = new string[4];
            data[0] = dateTimePicker5.Value.Date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            data[1] = dateTimePicker6.Value.Date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            ReportView rw = new ReportView("pay", data);
            rw.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] data = new string[4];
            data[0] = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            data[1] = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            ReportView rw = new ReportView("count", data);
            rw.Show();
        }
    }
}
