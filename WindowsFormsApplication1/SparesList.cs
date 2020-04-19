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
    public partial class SparesList : Form
    {
        public SparesList()
        {
            InitializeComponent();
        }
        private MySqlConnection conn;
        private void SparesList_Load(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string where = "WHERE 1";

            if (tb_search_spares_name.Text != "")
            {
                where += " AND spares_name LIKE '%" + tb_search_spares_name.Text + "%'";
            }
            if (tb_search_spares_unit.Text != "")
            {
                where += " AND spares_unit LIKE '%" + tb_search_spares_unit.Text + "%'";
            }

            string sqlSelectAll = "SELECT spares_id,spares_name,spares_qty,spares_unit,spares_cost_price,spares_unit_price,spares_detail,'แก้ไข' AS btn_edit,'ลบ' AS btn_del from tb_spares " + where + " ORDER BY spares_id DESC";
            // Console.WriteLine(sqlSelectAll);
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;

            ///ปรับแต่งข้อความ header ของ gridview
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].HeaderText = "ชื่อ";
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].HeaderText = "จำนวน";
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].HeaderText = "หน่วยนับ";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "ราคาต้นทุน";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "ราคาขาย";
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].HeaderText = "รายละเอียด";
            dataGridView1.Columns[6].Width = 130;

            dataGridView1.Columns[7].HeaderText = "";
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[7].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[7].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            dataGridView1.Columns[8].HeaderText = "";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[8].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[8].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SparesAdd acf = new SparesAdd(this);
            acf.Show();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 8)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.deleteData(id);
                    }
                }
                if (e.ColumnIndex == 7)
                {
                    SparesAdd da = new SparesAdd(this);
                    da.ID = id;
                    da.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void deleteData(string id)
        {
            if (id != "")
            {
                string query = "DELETE FROM tb_spares WHERE spares_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                try
                {

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conn.Close();
                    this.RenderGrid();
                    MessageBox.Show("ลบข้อมูลเรียบร้อย");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูลเนื่องจาก : " + ex.Message);
                    conn.Close();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RenderGrid();
        }

        private void dataGridView1_CelltClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 8)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.deleteData(id);
                    }
                }
                if (e.ColumnIndex == 7)
                {
                    SparesAdd da = new SparesAdd(this);
                    da.ID = id;
                    da.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
