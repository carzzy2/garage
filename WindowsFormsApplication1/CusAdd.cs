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
    public partial class CusAdd : Form
    {
        private CusList FormCus;
        private MySqlConnection conn;
        private string id = "";
        private int parsedValue;

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
        public CusAdd(CusList CusAdd)
        {
            this.FormCus = CusAdd;
            InitializeComponent();
        }

        private void CusAdd_Load(object sender, EventArgs e)
        {
            Connection connecttion = new Connection();
            conn = connecttion.Connect();
            if (this.id != "")
            {

                string selectOne = "SELECT * from customers WHERE cus_id = @cus_id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(selectOne, conn);
                cmd.Parameters.AddWithValue("@cus_id", this.id);
                cmd.CommandText = selectOne;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    fullname.Text = reader.GetString("fullname");
                    cus_tel.Text = reader.GetString("cus_tel");
                    cus_email.Text = reader.GetString("cus_email");
                    cus_address.Text = reader.GetString("cus_address");
                    cus_idcard.Text = reader.GetString("cus_idcard");
                    veh_id.Text = reader.GetString("veh_id");
                    veh_type.Text = reader.GetString("veh_type");

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
            if(fullname.Text == "" || cus_tel.Text == "" || cus_email.Text == "" || cus_address.Text == "" || cus_idcard.Text == "" || veh_id.Text == "" || veh_type.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง (*)");
                return;
            }
            ulong parsedValue;
            if (!ulong.TryParse(cus_tel.Text, out parsedValue))
            {
                MessageBox.Show("กรุณากรอกตัวเลขเท่านั้น");
                return;
            }
            if (!ulong.TryParse(cus_idcard.Text, out parsedValue))
            {
                MessageBox.Show("กรุณากรอกตัวเลขเท่านั้น");
                return;
            }
            if (cus_idcard.Text.Length < 13)
            {
                MessageBox.Show("กรุณากรอกเลขประจำตัวบัตรประชาชนให้ครบ 13 หลัก");
                return;
            }
            if (cus_tel.Text.Length < 9)
            {
                MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ให้ครบ 9 หรือ 10 หลัก");
                return;
            }

            else
            {
                string query = "REPLACE INTO customers (cus_id,fullname,cus_tel,cus_email,cus_address,cus_idcard,veh_id,veh_type)" +
                            " VALUES (@id,@fullname,@cus_tel,@cus_email,@cus_address,@cus_idcard,@veh_id,@veh_type)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                string id = this.id == "" ? null : this.id;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fullname", fullname.Text);
                cmd.Parameters.AddWithValue("@cus_tel", cus_tel.Text);
                cmd.Parameters.AddWithValue("@cus_email", cus_email.Text);
                cmd.Parameters.AddWithValue("@cus_address", cus_address.Text);
                cmd.Parameters.AddWithValue("@cus_idcard", cus_idcard.Text);
                cmd.Parameters.AddWithValue("@veh_id", veh_id.Text);
                cmd.Parameters.AddWithValue("@veh_type", veh_type.Text);
                cmd.CommandText = query;
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conn.Close();

                    string msg = this.id == "" ? "บันทีกข้อมูลเรียบร้อย" : "แก้ไขข้อมูลเรียบร้อย";
                    this.FormCus.RenderGrid();
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
                    MySqlCommand cmdDel = new MySqlCommand("DELETE FROM customers  WHERE  cus_id = @cus_id", conn);
                    cmdDel.Parameters.AddWithValue("@cus_id", this.id);
                    conn.Open();
                    cmdDel.ExecuteNonQuery();
                    cmdDel.Parameters.Clear();
                    conn.Close();

                    this.FormCus.RenderGrid();
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
