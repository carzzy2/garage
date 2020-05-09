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
    public partial class VerifyAddSpares : Form
    {
        private VerifyAdd Form;
        private string ver_id;
        private MySqlConnection conn;
        public VerifyAddSpares(VerifyAdd FormAdd,String ver_id)
        {
            this.Form = FormAdd;
            this.ver_id = ver_id.ToString();
            InitializeComponent();
        }

        private void VerifyAddSpares_Load(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string where = "WHERE 1";

            if (search_id.Text != "")
            {
                where += " AND spares_id LIKE '%" + search_id.Text + "%'";
            }
            if (search_name.Text != "")
            {
                where += " AND spares_name LIKE '%" + search_name.Text + "%'";
            }

            string sqlSelectAll = "SELECT spares_id,spares_name,spares_qty,spares_unit,spares_cost_price,spares_unit_price,spares_detail,'เลือก' AS btn_edit from spares " + where + " ORDER BY spares_id DESC";
            // Console.WriteLine(sqlSelectAll);
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;

            ///ปรับแต่งข้อความ header ของ gridview
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].HeaderText = "ชื่อ";
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].HeaderText = "จำนวนที่เหลือ";
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].HeaderText = "หน่วยนับ";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "ราคาต้นทุน";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].HeaderText = "ราคาขาย";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].HeaderText = "รายละเอียด";
            dataGridView1.Columns[6].Width = 130;

            dataGridView1.Columns[7].HeaderText = "";
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[7].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[7].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string spare_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string price = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string sp_num = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int num = Convert.ToInt32(sp_num);
            if (nb_m_num.Value > num)
            {
                MessageBox.Show("จำนวนที่เลือก มากกว่าจำนวนที่มีอยู่");
            }
            else {
                if (nb_m_num.Value < 1)
                {
                    MessageBox.Show("กรุณาระบุปริมาณที่ใช้");
                }
                else
                {
                    string msg = this.Form.SaveSpare(spare_id, nb_m_num.Value.ToString(), price);
                    if (msg != "success")
                    {
                        MessageBox.Show(msg);
                    }
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
    }
}
