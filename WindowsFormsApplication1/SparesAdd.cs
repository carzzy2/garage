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
    public partial class SparesAdd : Form
    {
        private SparesList FormSpares;
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
        public SparesAdd(SparesList SparesAdd)
        {
            this.FormSpares = SparesAdd;
            InitializeComponent();
        }

        private void SparesAdd_Load(object sender, EventArgs e)
        {
            Connection connecttion = new Connection();
            conn = connecttion.Connect();
            if (this.id != "")
            {

                string selectOne = "SELECT * from spares WHERE spares_id = @spares_id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(selectOne, conn);
                cmd.Parameters.AddWithValue("@spares_id", this.id);
                cmd.CommandText = selectOne;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    spares_name.Text = reader.GetString("spares_name");
                    spares_qty.Text = reader.GetString("spares_qty");
                    spares_unit_price.Text = reader.GetString("spares_unit_price");
                    spares_unit.Text = reader.GetString("spares_unit");
                    spares_cost_price.Text = reader.GetString("spares_cost_price");
                    spares_detail.Text = reader.GetString("spares_detail");

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
            if(spares_name.Text == "" || spares_qty.Text == "" || spares_unit_price.Text == "" || spares_unit.Text == "" || spares_cost_price.Text == "" || spares_detail.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง (*)");
                return;
            }
            ulong parsedValue;
            if (!ulong.TryParse(spares_qty.Text, out parsedValue))
            {
                MessageBox.Show("กรุณากรอกตัวเลขเท่านั้น");
                return;
            }
            if (!ulong.TryParse(spares_unit_price.Text, out parsedValue))
            {
                MessageBox.Show("กรุณากรอกตัวเลขเท่านั้น");
                return;
            }
            if (!ulong.TryParse(spares_cost_price.Text, out parsedValue))
            {
                MessageBox.Show("กรุณากรอกตัวเลขเท่านั้น");
                return;
            }
            else
            {
                string query = "REPLACE INTO spares (spares_id,spares_name,spares_qty,spares_unit_price,spares_unit,spares_cost_price,spares_detail)" +
                            " VALUES (@id,@spares_name,@spares_qty,@spares_unit_price,@spares_unit,@spares_cost_price,@spares_detail)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                string id = this.id == "" ? null : this.id;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@spares_name", spares_name.Text);
                cmd.Parameters.AddWithValue("@spares_qty", spares_qty.Text);
                cmd.Parameters.AddWithValue("@spares_unit_price", spares_unit_price.Text);
                cmd.Parameters.AddWithValue("@spares_unit", spares_unit.Text);
                cmd.Parameters.AddWithValue("@spares_cost_price", spares_cost_price.Text);
                cmd.Parameters.AddWithValue("@spares_detail", spares_detail.Text);
                cmd.CommandText = query;
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conn.Close();

                    string msg = this.id == "" ? "บันทีกข้อมูลเรียบร้อย" : "แก้ไขข้อมูลเรียบร้อย";
                    this.FormSpares.RenderGrid();
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
                    MySqlCommand cmdDel = new MySqlCommand("DELETE FROM spares  WHERE  spares_id = @spares_id", conn);
                    cmdDel.Parameters.AddWithValue("@spares_id", this.id);
                    conn.Open();
                    cmdDel.ExecuteNonQuery();
                    cmdDel.Parameters.Clear();
                    conn.Close();
                    this.FormSpares.RenderGrid();
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
