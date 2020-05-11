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
    public partial class UserAdd : Form
    {
        private UserList FormUser;
        private MySqlConnection conn;
        private string id = "";

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public UserAdd(UserList userAdd)
        {
            this.FormUser = userAdd;
            InitializeComponent();
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            Connection connecttion = new Connection();
            conn = connecttion.Connect();
            if (this.id != "")
            {

                string selectOne = "SELECT * from users WHERE user_id = @user_id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(selectOne, conn);
                cmd.Parameters.AddWithValue("@user_id", this.id);
                cmd.CommandText = selectOne;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name.Text = reader.GetString("name");
                    surname.Text = reader.GetString("surname");
                    sex.Text = reader.GetString("sex");
                    tel.Text = reader.GetString("tel");
                    username.Text = reader.GetString("username");
                    pass.Text = reader.GetString("password");
                    pass_again.Text = reader.GetString("password");

                    btn_save.Text = "แก้ไข";
                }
                conn.Close();

            }
            else
            {
                btn_delete.Hide();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if(name.Text == "" || surname.Text == "" || sex.Text == "" || tel.Text == "" || username.Text == "" || pass.Text == "" || pass_again.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง (*)");
                return;
            }
            if (pass.Text != pass_again.Text)
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                return;
            }
            ulong parsedValue;
            if (!ulong.TryParse(tel.Text, out parsedValue))
            {
                MessageBox.Show("กรุณากรอกตัวเลขเท่านั้น");
                return;
            }
            
            else
            {
                string query = "REPLACE INTO users (user_id,name,surname,fullname,type,tel,username,password,sex)" +
                            " VALUES (@id,@name,@surname,@fullname,@type,@tel,@username,@password,@sex)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                string id = this.id == "" ? ln.ToString() : this.id;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@surname", surname.Text);
                cmd.Parameters.AddWithValue("@fullname", name.Text + " " + surname.Text);
                cmd.Parameters.AddWithValue("@type", "เจ้าของกิจการ");
                cmd.Parameters.AddWithValue("@tel", tel.Text);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", pass.Text);
                cmd.Parameters.AddWithValue("@sex", sex.Text);
                cmd.CommandText = query;
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conn.Close();

                    string msg = this.id == "" ? "บันทีกข้อมูลเรียบร้อย" : "แก้ไขข้อมูลเรียบร้อย";
                    this.FormUser.RenderGrid();
                    MessageBox.Show(msg);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดเนื่องจาก : " + ex.Message);
                    conn.Close();
                }
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    MySqlCommand cmdDel = new MySqlCommand("DELETE FROM users  WHERE  user_id = @user_id", conn);
                    cmdDel.Parameters.AddWithValue("@user_id", this.id);
                    conn.Open();
                    cmdDel.ExecuteNonQuery();
                    cmdDel.Parameters.Clear();
                    conn.Close();
                    this.FormUser.RenderGrid();
                    MessageBox.Show("ลบข้อมูลเรียบร้อย");
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดเนื่องจาก : " + ex.Message);
                conn.Close();
            }
        }
    }
}
