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
            this.Form = FormAdd;
            InitializeComponent();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void VerifyAdd_Load(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            conn = connect.Connect();

            long ln = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            string id = this.id == "" ? ln.ToString() : this.id;
            vir_id.Text = id;

            string sqlSelectAll = "select * from customers";
            MySqlCommand cmd = new MySqlCommand(sqlSelectAll, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cus_id.Items.Add(reader.GetString("fullname"));

            }
            conn.Close();
            
        }
    }
}
