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
            string status = "";
            if (this.user[2].ToString() == "admin")
            {
                status = "เจ้าของกิจการ";
            }
            else
            {
                status = "ผู้ใช้งาน";
            }
            label1.Text = this.user[1].ToString() + " ตำแหน่ง" + status;
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
            UserList fm = new UserList();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerList fm = new CustomerList();
            fm.Show();
            this.Hide();
        }
    }
}
