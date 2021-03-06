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
    public partial class PayAdd : Form
    {
        private PayList Form;
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
        public PayAdd(PayList FormAdd)
        {
            Connection connect = new Connection();
            conn = connect.Connect();

            this.Form = FormAdd;

            InitializeComponent();
        }

        private void PayAdd_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (this.id != "")
            {
                string sqlSelectAll = "select * from verify ";
                MySqlCommand cmd = new MySqlCommand(sqlSelectAll, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ver_id.Items.Add(reader.GetString("ver_id"));
                }
                conn.Close();


                string cusid = "";
                string verid = "";
                string selectOne1 = "SELECT verify.*,pay.pay_id,pay.pay_date,detail,customers.veh_id,customers.veh_type,customers.cus_tel,customers.cus_address " +
                    "from verify " +
                    "left join customers on customers.cus_id = verify.cus_id  INNER JOIN pay on pay.ver_id = verify.ver_id  " +
                    "INNER JOIN repairs on repairs.ver_id = verify.ver_id " +
                    "WHERE pay.pay_id = @id LIMIT 1";
                MySqlCommand cmd1 = new MySqlCommand(selectOne1, conn);
                cmd1.Parameters.AddWithValue("@id", this.id);
                cmd1.CommandText = selectOne1;
                conn.Open();
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    pay_id.Text = reader1.GetString("pay_id");
                    dateTimePicker1.Text = reader1.GetString("pay_date");
                    veh_id.Text = reader1.GetString("veh_id");
                    veh_type.Text = reader1.GetString("veh_type");
                    veh_symtom.Text = reader1.GetString("veh_symtom");
                    repair_box.Text = reader1.GetString("detail");
                    txttel.Text = reader1.GetString("cus_tel");
                    txtaddress.Text = reader1.GetString("cus_address");
                    cusid = reader1.GetString("cus_id");
                    verid = reader1.GetString("ver_id");
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
                    cusname.Text = reader2.GetString("fullname");
                }
                conn.Close();
                ver_id.SelectedItem = verid;
                ver_id.Enabled = false;
                button1.Visible = false;
                repair_box.Enabled = false;
            }
            else
            {
                string id2 = "";
                string query2 = "Select case when Max(substr(pay_id, -6)) + 1 is null then 'PAY-000001' else case when (Max(substr(pay_id, -6)) + 1) < 10 then CONCAT('PAY-00000',(Max(substr(pay_id, -6)) + 1)) else CONCAT('PAY-0000',(Max(substr(pay_id, -6)) + 1)) end end as MaxID from pay";
                MySqlCommand cmdQuery = new MySqlCommand(query2, conn);
                cmdQuery.CommandText = query2;
                conn.Open();
                MySqlDataReader dr = cmdQuery.ExecuteReader();
                while (dr.Read())
                {
                    id2 = dr.GetString("MaxID");
                }
                conn.Close();

                string sqlSelectAll = "select * from verify where status ='REPAIR'";
                MySqlCommand cmd = new MySqlCommand(sqlSelectAll, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ver_id.Items.Add(reader.GetString("ver_id"));
                }
                conn.Close();

                string id = this.id == "" ? id2 : this.id;
                this.id = id;
            }
            pay_id.Text = id;
            this.RenderGrid();
        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT spares.spares_id,spares.spares_name,verify_item.num,format(verify_item.price,0),format((verify_item.num * verify_item.price),0) as all_price " +
                "from verify_item " +
                "INNER JOIN spares on verify_item.spares_id = spares.spares_id " +
                "where ver_id='" + ver_id.Text + "' ";
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
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "ราคาขาย";
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].HeaderText = "รวม";
            dataGridView1.Columns[4].Width = 150;
            string query = "SELECT SUM(vm.price*vm.num) AS price " +
                                "FROM spares AS sp " +
                                "INNER JOIN verify_item AS vm ON vm.spares_id = sp.spares_id " +
                                "WHERE vm.ver_id = @id GROUP BY vm.ver_id ";
            MySqlCommand cmdQuery = new MySqlCommand(query, conn);
            cmdQuery.Parameters.AddWithValue("@id", ver_id.Text);
            conn.Open();
            MySqlDataReader dr = cmdQuery.ExecuteReader();
            double c_cost = 0;
            while (dr.Read())
            {
                c_cost = dr.GetDouble("price");
            }
            tb_change.Text = String.Format("{0:#,##0}", c_cost);
            hiddenval.Text = c_cost.ToString();

            if (c_cost == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ver_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlSelectAll = "select verify.*,customers.fullname,repairs.detail,customers.veh_id,customers.veh_type,customers.cus_tel,customers.cus_address " +
                "from verify " +
                "inner join customers on customers.cus_id = verify.cus_id " +
                "inner join repairs on repairs.ver_id = verify.ver_id " +
                "where verify.ver_id = '" + ver_id.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sqlSelectAll, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                veh_id.Text = reader.GetString("veh_id");
                veh_type.Text = reader.GetString("veh_type");
                veh_symtom.Text = reader.GetString("veh_symtom");
                cusname.Text = reader.GetString("fullname");
                repair_box.Text = reader.GetString("detail");
                txttel.Text = reader.GetString("cus_tel");
                txtaddress.Text = reader.GetString("cus_address");

            }
            conn.Close();
            this.RenderGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            string id = this.id;


            string query = "REPLACE INTO pay (pay_id,pay_date,ver_id,price)" +
                                "VALUES(@id,NOW(),@ver_id,@price)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ver_id", ver_id.Text);
            cmd.Parameters.AddWithValue("@price", hiddenval.Text);

            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();

            string query1 = "update verify set status ='PAY' where ver_id=@id";
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@id", ver_id.Text);
            cmd1.CommandText = query1;
            conn.Open();
            cmd1.ExecuteNonQuery();
            cmd1.Parameters.Clear();
            conn.Close();

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย");

            string[] data = new string[4];
            data[0] = id;
            PrintView rw = new PrintView("print_pay", data);
            rw.Show();

            this.Close();
            this.Form.RenderGrid();
        }
    }
}
