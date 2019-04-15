using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;

namespace Assignment4
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string password = textBox2.Text;
            Database db = new Database();
            if (db.validateAdmin(user_name, password))
            {
                this.Hide();
                Form9 f = new Form9();
                f.Show();
            }
            else {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
