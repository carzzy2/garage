﻿using System;
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
    public partial class CusList : Form
    {
        public CusList()
        {
            InitializeComponent();
        }
        private MySqlConnection conn;
        private void CusList_Load(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string where = "WHERE 1";

            if (tb_search_cus_name.Text != "")
            {
                where += " AND fullname LIKE '%" + tb_search_cus_name.Text + "%'";
            }
            if (tb_search_cus_tel.Text != "")
            {
                where += " AND cus_tel LIKE '%" + tb_search_cus_tel.Text + "%'";
            }
            if (tb_search_cus_email.Text != "")
            {
                where += " AND cus_email LIKE '%" + tb_search_cus_email.Text + "%'";
            }
            if (tb_search_cus_address.Text != "")
            {
                where += " AND cus_address LIKE '%" + tb_search_cus_address.Text + "%'";
            }
            if (tb_search_cus_idcard.Text != "")
            {
                where += " AND cus_idcard LIKE '%" + tb_search_cus_idcard.Text + "%'";
            }
            if (tb_search_cus_veh_id.Text != "")
            {
                where += " AND veh_id LIKE '%" + tb_search_cus_veh_id.Text + "%'";
            }
            if (tb_search_cus_veh_type.Text != "")
            {
                where += " AND veh_type LIKE '%" + tb_search_cus_veh_type.Text + "%'";
            }

            string sqlSelectAll = "SELECT cus_id,fullname,cus_tel,cus_email,cus_idcard,cus_address,veh_id,veh_type,'แก้ไข' AS btn_edit,'ลบ' AS btn_del from customers " + where + " ORDER BY cus_id DESC";
            // Console.WriteLine(sqlSelectAll);
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;

            ///ปรับแต่งข้อความ header ของ gridview
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "ชื่อ";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "เบอร์โทรศัพท์";
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].HeaderText = "อีเมล์";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "เลขประจำตัวบัตรประชาชน";
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].HeaderText = "ที่อยู่";
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].HeaderText = "ทะเบียนรถ";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].HeaderText = "ยี่ห้อรถ";
            dataGridView1.Columns[7].Width = 100;

            dataGridView1.Columns[8].HeaderText = "";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[8].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[8].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            dataGridView1.Columns[9].HeaderText = "";
            dataGridView1.Columns[9].Width = 50;
            dataGridView1.Columns[9].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[9].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CusAdd acf = new CusAdd(this);
            acf.Show();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 9)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.deleteData(id);
                    }
                }
                if (e.ColumnIndex == 8)
                {
                    CusAdd da = new CusAdd(this);
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
                string query = "DELETE FROM customers WHERE cus_id = @id";
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
                if (e.ColumnIndex == 9)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมุล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.deleteData(id);
                    }
                }
                if (e.ColumnIndex == 8)
                {
                    CusAdd da = new CusAdd(this);
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
