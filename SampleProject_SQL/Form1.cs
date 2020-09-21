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
       public Button getBtn = new Button();
       public Button setBtn = new Button();
       public Button exitBtn = new Button();
        public Form1()
        {
            InitializeComponent();
            // add buttons top left and + 100 


            this.Controls.Add(getBtn);
            this.Controls.Add(setBtn);
            this.Controls.Add(exitBtn);

            getBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            getBtn.Text = "Get Data";
            getBtn.Location = new Point(10, 10);

            setBtn.Text = "Update Data";
            setBtn.AutoSize = true;
            setBtn.Location = new Point(getBtn.Location.X + getBtn.Width + 30, getBtn.Location.Y);

            exitBtn.Text = "Exit";
            exitBtn.Location = new Point(getBtn.Location.X + getBtn.Width + setBtn.Width + 30 + 30, getBtn.Location.Y);

            getBtn.Click += new EventHandler(this.GetDataEventHandler);
            setBtn.Click += new EventHandler(this.SetDataEventHandler);
            exitBtn.Click += new EventHandler(this.ExitEventHandler);

            //setBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //setBtn.Text = "Update Data";

            //while (sqlReader.Read())
            //{
            //    output = output + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1) + "\n";
            //}
            //txt.Text = output;
        }

        private void GetDataEventHandler(object sender, EventArgs e)
        {

            //datagridview
            DataGridView view = new DataGridView();
            this.Controls.Add(view);
            //view.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            view.AutoGenerateColumns = true;
            view.Size = new Size(this.Width - getBtn.Width, this.Height - getBtn.Height);
            //view.Dock = DockStyle.Fill;
            view.Margin = DefaultMargin;

            view.Location = new Point(getBtn.Location.X, getBtn.Location.Y + getBtn.Height + 10);

            this.Size = new Size(this.Width, this.Height + 100);
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
            view.AutoResizeColumns();
            view.AutoResizeRows();
        }
        private void SetDataEventHandler(object sender, EventArgs e)
        {
            string connectSQL;
            string comSQL;
            DataTable dt = new DataTable();
            SqlConnection con;
            SqlCommand com;
            SqlDataAdapter sqlReader;

            connectSQL = @"Server=LOSTPC\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
            //need to build string based on data entered or edited in grid view probably with separate event handler
            comSQL = "UPDATE Currency SET Name=";

            con = new SqlConnection(connectSQL);
            con.Open();
            com = new SqlCommand(comSQL, con);

            sqlReader = new SqlDataAdapter(comSQL, con);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlReader);
        }
        private void ExitEventHandler(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
