using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleProject_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //textbox
            //TextBox txt = new TextBox();
            //txt.Multiline = true;
            //txt.Size = new Size(300, 400);
            //this.Controls.Add(txt);
            //datagridview
            DataGridView view = new DataGridView();
            this.Controls.Add(view);
            view.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            view.AutoGenerateColumns = true;
            view.Dock = DockStyle.Fill;

            
            string connectSQL;
            string comSQL;
            DataTable dt = new DataTable();
            SqlConnection con;
            SqlCommand com;
            SqlDataAdapter sqlReader;

            connectSQL = @"Server=LOSTPC\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
            comSQL = "SELECT * FROM CURRENCY";


            con = new SqlConnection(connectSQL);
            con.Open();
            com = new SqlCommand(comSQL, con);

            sqlReader = new SqlDataAdapter(comSQL, con);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlReader);

            sqlReader.Fill(dt);
            view.DataSource = dt;

            //while (sqlReader.Read())
            //{
            //    output = output + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1) + "\n";
            //}
            //txt.Text = output;
        }
    }
}
