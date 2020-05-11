using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        private string[] user = new string[3];
        public Main(string[] user)
        {
            this.user = user;
            InitializeComponent();
        }
        MySqlConnection conn;

        private void Main_Load(object sender, EventArgs e)
        {
            //string status = "";
            //if (this.user[2].ToString() == "admin")
            //{
            //    status = "เจ้าของกิจการ";
            //}
            // else
            //{
            //    status = "ผู้ใช้งาน";
            //}
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                //button4.Visible = false;
                //button7.Visible = false;
            }
            else if (this.user[2].ToString() == "ฝ่ายซ่อม")
            {
                button3.Visible = false;
                button2.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button7.Visible = false;
            }
            label1.Text = this.user[1].ToString() + " " + this.user[3].ToString() + " [" + this.user[2].ToString() + "]";
        }
        private void FormShown(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            conn = connection.Connect();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                UserList fm = new UserList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                CusList fm = new CusList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("คุณต้องการออกจากระบบหรือไม่ ?", "ออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Login fm = new Login();
                fm.Show();
                this.Hide();
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                SparesList fm = new SparesList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                VerifyList fm = new VerifyList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (this.user[2].ToString() == "ฝ่ายซ่อม")
            //{
                VerifyList fm = new VerifyList();
                fm.Show();
            //}
            //else
            //{
            //    MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
            //    return;
           // }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                GetSpareList fm = new GetSpareList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (this.user[2].ToString() == "ฝ่ายซ่อม")
           // {
                RepairList fm = new RepairList();
                fm.Show();
           // }
            //else
           // {
           //     MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
           //     return;
           // }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                ReportList fm = new ReportList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "เจ้าของกิจการ")
            {
                PayList fm = new PayList();
                fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }
    }
}
