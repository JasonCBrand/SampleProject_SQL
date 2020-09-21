using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleProject_SQL
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
            Application.Run(new Form1());
        }
        
        static void GetList()
        {
            //return list of all records from SQL table
            string connectSQL;
            string comSQL;
            SqlConnection con;
            SqlCommand com;
            
            connectSQL = @"Server=localhost;Database=Test;Trusted_Connection=True;";
            comSQL = "SELECT * FROM CURRENCY";
            
            
            con = new SqlConnection(connectSQL);
            con.Open();
            com = new SqlCommand(comSQL, con);
           
        }

    }
}
