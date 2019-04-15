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

namespace Assignment4
{
    public partial class Form4 : Form
    {
        private string user_name;
        private int user_id;
        public Form4(string name,int id)
        {
            InitializeComponent();
            user_name = name;
            user_id = id;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = user_name;
            label1.Show();
            loadData();
        }
        public void loadData()
        {
            string connString = @"Data Source=.\SQLEXPRESS2012; initial Catalog=Assignment4; User Id=sa;Password=savechange; ";
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "Select ImageName from dbo.users where userid='"+user_id+"'";
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader rd = cmd.ExecuteReader();
                string imageName = "";
                if (rd.Read()) {
                   

                }
            }
        }
    }
}
