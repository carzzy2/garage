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
    public partial class RepairList : Form
    {
        private MySqlConnection conn;

        public RepairList()
        {
            InitializeComponent();
        }

        private void RepairList_Load(object sender, EventArgs e)
        {
            this.RenderGrid();

        }
        public void RenderGrid()
        {
            Connection connect = new Connection();
            conn = connect.Connect();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string where = "WHERE 1 ";

            if (search.Text != "")
            {
                where += " AND ver_id LIKE '%" + search.Text + "%'";
            }

            string sqlSelectAll = "SELECT rep_id,rep_date,veh_id,veh_type,veh_symtom,format(verify.all_price,0),'ดู' as btn_view " +
                "from repairs " +
                "INNER JOIN verify on verify.ver_id = repairs.ver_id " + where + " ORDER BY rep_id DESC";
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
            dataGridView1.Columns[6].DefaultCellStyle.ForeColor = Color.Green;
            dataGridView1.Columns[6].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);

        }
        private void dataGridView1_CelltClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (e.ColumnIndex == 6)
            {
                RepairAdd da = new RepairAdd(this);
                da.ID = id;
                da.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepairAdd da = new RepairAdd(this);
            da.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RenderGrid();
        }
    }
}
