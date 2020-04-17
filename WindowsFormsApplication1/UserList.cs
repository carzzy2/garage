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
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }
        private MySqlConnection conn;
        private void UserList_Load(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string where = "WHERE 1";
            if (tb_search_id.Text != "")
            {
                where += " AND user_id LIKE '%" + tb_search_id.Text + "%'";
            }
            if (tb_search_name.Text != "")
            {
                where += " AND fullname LIKE '%" + tb_search_name.Text + "%'";
            }
            string sqlSelectAll = "SELECT user_id,fullname,sex,tel,type,'แก้ไข' AS btn_edit,'ลบ' AS btn_del from users " + where + " ORDER BY user_id DESC";
            // Console.WriteLine(sqlSelectAll);
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;

            ///ปรับแต่งข้อความ header ของ gridview
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].HeaderText = "ชื่อ";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].HeaderText = "เพศ";
            dataGridView1.Columns[3].HeaderText = "โทรศัพท์";
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[4].HeaderText = "ประเภท";
            dataGridView1.Columns[5].HeaderText = "";
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[5].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            dataGridView1.Columns[6].HeaderText = "";
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[6].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UserAdd acf = new UserAdd(this);
            acf.Show();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 6)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.deleteData(id);
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    UserAdd da = new UserAdd(this);
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
                string query = "DELETE FROM users WHERE user_id = @id";
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            UserAdd acf = new UserAdd(this);
            acf.Show();
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
                if (e.ColumnIndex == 6)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.deleteData(id);
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    UserAdd da = new UserAdd(this);
                    da.ID = id;
                    da.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
