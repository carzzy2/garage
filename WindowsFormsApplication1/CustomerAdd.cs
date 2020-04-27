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
    public partial class CustomerAdd : Form
    {
        private CustomerList Form;
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
        public CustomerAdd(CustomerList form)
        {
            this.Form = form;
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void CustomerAdd_Load(object sender, EventArgs e)
        {
            Connection connecttion = new Connection();
            conn = connecttion.Connect();
            if (this.id != "")
            {

                string selectOne = "SELECT * from customers WHERE cus_id = @id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(selectOne, conn);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.CommandText = selectOne;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name.Text = reader.GetString("name");
                    surname.Text = reader.GetString("surname");
                    tel.Text = reader.GetString("tel");
                    address.Text = reader.GetString("address");

                    btn_save.Text = "แก้ไข";
                }
                conn.Close();

            }
            else
            {
                btn_delete.Hide();
            }
        }
        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    MySqlCommand cmdDel = new MySqlCommand("DELETE FROM customers  WHERE  cus_id = @id", conn);
                    cmdDel.Parameters.AddWithValue("@id", this.id);
                    conn.Open();
                    cmdDel.ExecuteNonQuery();
                    cmdDel.Parameters.Clear();
                    conn.Close();
                    this.Form.RenderGrid();
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            string query = "REPLACE INTO customers (cus_id,name,surname,fullname,tel,address)" +
                        " VALUES (@id,@name,@surname,@fullname,@tel,@address)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            string id = this.id == "" ? ln.ToString() : this.id;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@surname", surname.Text);
            cmd.Parameters.AddWithValue("@fullname", name.Text + " " + surname.Text);
            cmd.Parameters.AddWithValue("@tel", tel.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);

            cmd.CommandText = query;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();

                string msg = this.id == "" ? "บันทีกข้อมูลเรียบร้อย" : "แก้ไขข้อมูลเรียบร้อย";
                this.Form.RenderGrid();
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
}
