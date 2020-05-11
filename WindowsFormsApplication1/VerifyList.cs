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
    public partial class VerifyList : Form
    {
        private MySqlConnection conn;
        public VerifyList()
        {
            Connection connect = new Connection();
            conn = connect.Connect();

            InitializeComponent();
        }

        private void VerifyList_Load(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string where = "WHERE status!='DELETE'";

            if (search.Text != "")
            {
                where += " AND ver_id LIKE '%" + search.Text + "%'";
            }

            string sqlSelectAll = "SELECT v.ver_id,v.ver_date,c.veh_id,c.veh_type,v.veh_symtom,format(v.all_price,0),'แก้ไข' AS btn_edit,'ลบ' AS btn_del,'พิมพ์' AS btn_print from verify v join customers c on c.cus_id = v.cus_id " + where + " ORDER BY v.ver_id DESC";
            // Console.WriteLine(sqlSelectAll);
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;

            ///ปรับแต่งข้อความ header ของ gridview
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].HeaderText = "วันที่";
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].HeaderText = "ทะเบียนรถ";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].HeaderText = "ยี่ห้อรถ";
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].HeaderText = "อาการ";
            dataGridView1.Columns[4].Width = 250;
            dataGridView1.Columns[5].HeaderText = "ราคา";
            dataGridView1.Columns[5].Width = 150;

            dataGridView1.Columns[6].HeaderText = "";
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[6].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[6].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);

            dataGridView1.Columns[7].HeaderText = "";
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[7].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);

            dataGridView1.Columns[8].HeaderText = "";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[8].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[8].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            VerifyAdd acf = new VerifyAdd(this);
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
                if (e.ColumnIndex == 7)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        string query = "update verify set status ='DELETE' WHERE ver_id = @id";
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
                if (e.ColumnIndex == 6)
                {
                    VerifyAdd da = new VerifyAdd(this);
                    da.ID = id;
                    da.Show();
                }
                if (e.ColumnIndex == 8)
                {
                    string[] data = new string[4];
                    data[0] = id;
                    PrintView rw = new PrintView("print_quotation", data);
                    rw.Show();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
