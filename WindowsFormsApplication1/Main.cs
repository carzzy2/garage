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
                //SparesList fm = new SparesList();
                //fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.user[2].ToString() == "ฝ่ายซ่อม")
            {
                //SparesList fm = new SparesList();
                //fm.Show();
            }
            else
            {
                MessageBox.Show("ขออภัย ท่านไม่ได้รับสิทธิ์สำหรับเมนูนี้");
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
