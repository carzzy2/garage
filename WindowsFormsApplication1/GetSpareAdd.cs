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
    public partial class TakeSpareAdd : Form
    {
        private GetSpareList Form;
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
        public TakeSpareAdd(GetSpareList FormAdd)
        {
            Connection connect = new Connection();
            conn = connect.Connect();

            this.Form = FormAdd;

            InitializeComponent();
        }

        private void GetSpareAdd_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-01");
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
                string selectOne1 = "SELECT verify.*,get_id,get_date from verify " +
                    "INNER JOIN get_spares on get_spares.ver_id = verify.ver_id  WHERE get_spares.get_id = @id LIMIT 1";
                MySqlCommand cmd1 = new MySqlCommand(selectOne1, conn);
                cmd1.Parameters.AddWithValue("@id", this.id);
                cmd1.CommandText = selectOne1;
                conn.Open();
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    get_id.Text = reader1.GetString("get_id");
                    dateTimePicker1.Text = reader1.GetString("get_date");
                    veh_id.Text = reader1.GetString("veh_id");
                    veh_type.Text = reader1.GetString("veh_type");
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
            }
            else
            {
                string sqlSelectAll = "select * from verify where status ='QUOTATION'";
                MySqlCommand cmd = new MySqlCommand(sqlSelectAll, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ver_id.Items.Add(reader.GetString("ver_id"));
                }
                conn.Close();

                string id = this.id == "" ? ln.ToString() : this.id;
                this.id = id;
            }
            get_id.Text = id;
            this.RenderGrid();
        }
        private void ver_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlSelectAll = "select verify.*,customers.fullname from verify inner join customers on customers.cus_id = verify.cus_id where ver_id =" + ver_id.Text;
            MySqlCommand cmd = new MySqlCommand(sqlSelectAll, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                veh_id.Text = reader.GetString("veh_id");
                veh_type.Text = reader.GetString("veh_type");
                cusname.Text = reader.GetString("fullname");

            }
            conn.Close();
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


        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-01");
            long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            string id = ln.ToString();


            string query = "REPLACE INTO get_spares (get_id,get_date,ver_id)" +
                                "VALUES(@id,NOW(),@ver_id)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ver_id", ver_id.Text);
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();

            string query1 = "update verify set status ='GETSPARES' where ver_id=@id";
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@id", ver_id.Text);
            cmd1.CommandText = query1;
            conn.Open();
            cmd1.ExecuteNonQuery();
            cmd1.Parameters.Clear();
            conn.Close();
            this.Update_Spares();
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
            this.Close();
            this.Form.RenderGrid();
        }

        public void Update_Spares()
        {
            conn.Open();
            string query = "update spares a " +
                            "INNER JOIN verify_item b on a.spares_id = b.spares_id " +
                            "SET a.spares_qty = a.spares_qty - b.num where b.ver_id = @ver_id ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ver_id", ver_id.Text);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
