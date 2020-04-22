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
    public partial class VerifyAdd : Form
    {
        private VerifyList Form;
        private MySqlConnection conn;
        private string id = "";
        public VerifyAdd(VerifyList FormAdd)
        {
            Connection connect = new Connection();
            conn = connect.Connect();

            this.Form = FormAdd;
            InitializeComponent();
        }
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
        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void VerifyAdd_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-01");
            long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            string sqlSelectAll = "select * from customers";
            MySqlCommand cmd1 = new MySqlCommand(sqlSelectAll, conn);
            conn.Open();
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                cus_id.Items.Add(reader1.GetString("fullname"));
            }

            conn.Close();
            if (this.id != "")
            {
                string cusid = "";
                string selectOne = "SELECT * from verify WHERE ver_id = @id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(selectOne, conn);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.CommandText = selectOne;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ver_id.Text = reader.GetString("ver_id");
                    dateTimePicker1.Text = reader.GetString("ver_date");
                    veh_id.Text = reader.GetString("veh_id");
                    veh_type.Text = reader.GetString("veh_type");
                    veh_type.Text = reader.GetString("veh_type");
                    veh_symtom.Text = reader.GetString("veh_symtom");
                    cusid = reader.GetString("cus_id");
                    button1.Text = "แก้ไข";
                }
                conn.Close();


                string selectOne2 = "SELECT * from customers WHERE cus_id = @id LIMIT 1";
                MySqlCommand cmd2 = new MySqlCommand(selectOne2, conn);
                cmd2.Parameters.AddWithValue("@id", cusid);
                cmd2.CommandText = selectOne2;
                conn.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    cus_id.SelectedItem = reader2.GetString("fullname");
                }
                conn.Close();
            }
            else
            {
                string id = this.id == "" ? ln.ToString() : this.id;
                this.id = id;
            }
            ver_id.Text = id;

            this.RenderGrid();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            VerifyAddSpares acf = new VerifyAddSpares(this,id);
            acf.Show();
        }
        public string SaveSpare(string spare_id, string m_num, string price)
        {
            if (spare_id != "")
            {
                try
                {
              
                    string query = "REPLACE INTO verify_item (ver_id,spares_id,price,num) VALUES (@ver_id,@spare_id,@price,@num)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ver_id", this.id);
                    cmd.Parameters.AddWithValue("@spare_id", spare_id);
                    cmd.Parameters.AddWithValue("@num", m_num);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conn.Close();
                    this.RenderGrid();
                    return "success";
                }
                catch (Exception ex)
                {
                    return "เกิดข้อผิดพลาดในการบันทึกข้อมูลเนื่องจาก : " + ex.Message;
                }
            }
            return "";
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT spares.spares_id,spares.spares_name,verify_item.num,format(verify_item.price,0),format((verify_item.num * verify_item.price),0) as all_price,'ลบ' AS btn_del " +
                "from verify_item " +
                "INNER JOIN spares on verify_item.spares_id = spares.spares_id " +
                "where ver_id=" +this.id + " ";
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
            dataGridView1.Columns[1].HeaderText = "ชื่ออะไหล่";
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].HeaderText = "จำนวน";
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].HeaderText = "ราคาขาย";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "รวม";
            dataGridView1.Columns[4].Width = 130;

            dataGridView1.Columns[5].HeaderText = "";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);

            string query = "SELECT SUM(vm.price*vm.num) AS price " +
                                "FROM spares AS sp " +
                                "INNER JOIN verify_item AS vm ON vm.spares_id = sp.spares_id " +
                                "WHERE vm.ver_id = @id GROUP BY vm.ver_id ";
            MySqlCommand cmdQuery = new MySqlCommand(query, conn);
            cmdQuery.Parameters.AddWithValue("@id", this.id);
            conn.Open();
            MySqlDataReader dr = cmdQuery.ExecuteReader();
            double c_cost = 0;
            while (dr.Read())
            {
                c_cost = dr.GetDouble("price");
            }
            //tb_change.Text = c_cost.ToString();
            tb_change.Text = String.Format("{0:#,##0}", c_cost);
            hiddenval.Text = c_cost.ToString();
            if (c_cost == 0)
            {
                button1.Enabled = false;
            }
            else {
                button1.Enabled = true;
            }
            conn.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 5)
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลนี้หรือไม่ ?", "ลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        string query = "DELETE FROM verify_item WHERE spares_id = @id and ver_id = @ver_id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@ver_id", this.id);
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
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cusid = "";
            if (cus_id.Text == "กรุณาเลือก")
            {
                MessageBox.Show("กรุณาเลือกลูกค้า");
            }
            else {
                string selectOne = "SELECT * from customers WHERE fullname = @name LIMIT 1";
                MySqlCommand cmd1 = new MySqlCommand(selectOne, conn);
                cmd1.Parameters.AddWithValue("@name", cus_id.Text);
                cmd1.CommandText = selectOne;
                conn.Open();
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    cusid = reader1.GetString("cus_id");
                }
                conn.Close();
                string query = "REPLACE INTO verify (ver_id,ver_date,status,all_price,veh_id,veh_type,veh_symtom,cus_id)" +
                                    "VALUES(@id,NOW(),'NEW',@sumtotal,@veh_id,@veh_type,@veh_symtom,@cus_id)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@sumtotal", this.hiddenval.Text);
                cmd.Parameters.AddWithValue("@veh_id", veh_id.Text);
                cmd.Parameters.AddWithValue("@veh_type", veh_type.Text);
                cmd.Parameters.AddWithValue("@veh_symtom", veh_symtom.Text);
                cmd.Parameters.AddWithValue("@cus_id", cusid);

                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
                this.Close();
                this.Form.RenderGrid();
            }
           
        }
    }
}
