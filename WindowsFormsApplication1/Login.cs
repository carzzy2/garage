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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private MySqlConnection conn;
        private void Login_Load(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            conn = connect.Connect();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string var_username = username.Text.ToString();
            string var_password = password.Text.ToString();

            string selectOne = "SELECT * FROM users where username = @username and password = @password LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(selectOne, conn);

            cmd.Parameters.AddWithValue("@username", var_username);
            cmd.Parameters.AddWithValue("@password", var_password);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int n = 0;
            while (reader.Read())
            {
                string name = reader.GetString("name");
                string surname = reader.GetString("surname");
                string[] user = new string[4];

                user[0] = reader.GetString("user_id");
                user[1] = reader.GetString("name");
                user[2] = reader.GetString("type");
                user[3] = reader.GetString("surname");
                MessageBox.Show("ยืนดีต้อนรับ คุณ" + name + " "+ surname + " เข้าสู่ระบบ");

                Main ds = new Main(user);
                ds.Show();
                this.Hide();
                n++;
            }
            if (n == 0)
            {
                MessageBox.Show("Username หรือ password ไม่ถูกต้อง");
            }
            conn.Close();

        }
    }
}
