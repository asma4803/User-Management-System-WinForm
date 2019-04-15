using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK) {
                var filePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<Gender> g = new List<Gender>();
            g.Add(new Gender() { id = 'm', name = "Male" });
            g.Add(new Gender() { id = 'f', name = "Female" });
            g.Add(new Gender() { id = 'o', name = "Other" });
            comboBox1.DataSource = g;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.name = textBox1.Text;
            user.login = textBox2.Text;
            user.password = textBox3.Text;
            user.email = textBox4.Text;
            Gender gender = (Gender)comboBox1.SelectedItem;
            user.gender = gender.id;
            user.address = richTextBox1.Text;
            user.age = (int)numericUpDown1.Value;
            user.NIC = textBox5.Text;
            string d = dateTimePicker1.Text;
            user.date = DateTime.Parse(d);
            if (checkBox1.CheckState == CheckState.Checked) {
                user.chess = true;
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                user.hockey = true;
            }
            if (checkBox3.CheckState == CheckState.Checked)
            {
                user.cricket = true;
            }
            string uniqueName = "";
            if (pictureBox1.Image != null) {
                string applicationPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string pathToSaveImage = applicationPath + @"\images\";

                uniqueName = Guid.NewGuid().ToString() + ".jpg";
                string imagePath = pathToSaveImage + uniqueName;
                pictureBox1.Image.Save(imagePath);
            }
            user.ImageName = uniqueName;

            if (user.name == "" || user.login == "" || user.NIC == "" || user.ImageName == "" || user.password == "" || user.address =="" || user.email==""|| user.age ==0) {
                MessageBox.Show("Some fields are empty");
                return;
            }

            Database db = new Database();
            if (db.saveNewUser(user) >-1)
            {
                int id = db.saveNewUser(user);
                MessageBox.Show("User saved");
                this.Hide();
                Form4 f = new Form4(user.name,id);
                f.Show();
            }
            else
            {
                MessageBox.Show("Some error occured");
            }
        }
    }
}
