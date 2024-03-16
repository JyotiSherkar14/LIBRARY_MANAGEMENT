using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryM
{
    public partial class Form1 : Form
    {
        string cs, q;
        MySqlConnection c1;
        MySqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cs = "server = localhost; database = library; uid=root; pwd=root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("Welcome To Library");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.iss.Visible = true;
            f2.ret.Visible = true;
            f2.search.Visible = true;
            f2.label1.Text = "Issue/Return Books";
            f2.sid.ReadOnly = false;
            f2.sname.ReadOnly = true;
            f2.rn.ReadOnly = true;
            f2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.sub.Visible = true;
            f2.label1.Text = "Add Student";

            c1.Open();
            try
            {
                q = "select count(sid) from students";
                cmd = new MySqlCommand(q, c1);
                int ids = Convert.ToInt32(cmd.ExecuteScalar());
                ids++;
                f2.sid.Text = ids.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter valid text...");
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }

            f2.Show();
        }

        private void updateStudentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.upd.Visible = true;
            f2.search.Visible = true;
            f2.label1.Text = "Update Student Profile";
            f2.sid.ReadOnly = false;
            f2.sname.ReadOnly = true;
            f2.rn.ReadOnly = true;
            f2.Show();
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.search.Visible = true;
            f2.rem.Visible = true;
            f2.label1.Text = "Remove Student Profile";
            f2.sid.ReadOnly = false;
            f2.sname.ReadOnly = true;
            f2.rn.ReadOnly = true;
            f2.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.sub.Visible = true;
            f3.label1.Text = "Add Books";

            c1.Open();
            try
            {
                q = "select count(bid) from books";
                cmd = new MySqlCommand(q, c1);
                int idb = Convert.ToInt32(cmd.ExecuteScalar());
                idb++;
                f3.bid.Text = idb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }

            f3.Show();
        }

        private void modifyBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.upd.Visible = true;
            f3.search.Visible = true;
            f3.label1.Text = "Update Books";
            f3.bid.ReadOnly = false;
            f3.bname.ReadOnly = true;
            f3.aut.ReadOnly = true;
            f3.qua.ReadOnly = true;
            f3.Show();
        }

        private void removeBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.search.Visible = true;
            f3.rem.Visible = true;
            f3.label1.Text = "Remove Books";
            f3.bid.ReadOnly = false;
            f3.bname.ReadOnly = true;
            f3.aut.ReadOnly = true;
            f3.qua.ReadOnly = true;
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5= new Form5();
            f5.label5.Visible = false;
            f5.sid.Visible = false;

            c1.Open();
            try
            {
                q = "select * from books";
                MySqlDataAdapter da = new MySqlDataAdapter(q, c1);
                DataTable t = new DataTable();
                da.Fill(t);

                f5.dataGridView1.DataSource = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong...");
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
            f5.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Library Management System...\n\nthis project is created by our team under the guidance of,\nMr. V. M. Chandode Sir\n\n Our Team:\n1. Dhananjay D. Gitte\n2. Shashikant D. Karad\n3. Dhanashree G. Bhatane\n4. Mastan N. Shaikh\n\nThank you for visiting our management system, for more information contact us at\nM.B.E. Society's Collage of Engineering Ambajogai.");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
