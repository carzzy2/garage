using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] user = new string[4];

            user[0] = "63722579876780";
            user[1] = "admin ";
            user[2] = "เจ้าของกิจการ";
            user[3] = "admin";

            Application.Run(new Login());
        }
    }
}
