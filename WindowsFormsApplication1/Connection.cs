using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class Connection
    {
        public MySqlConnection Connect()
        {
            //String connetionString = @"Data Source=LAPTOP-CEGIU8P5\SQLEXPRESS;Initial Catalog=pos;Integrated Security=True";

            //String connetionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID=sa;Password=demol23";

            String connectionString = "server=localhost;port=3306;user=root; password=; database=garage1; SslMode=none;charset=utf8";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
    }
}
