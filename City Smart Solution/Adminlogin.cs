using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace City_Smart_Solution
{
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loginnow cd = new Loginnow();
            cd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                OracleConnection con;

                string dd = "Data Source=localhost;User ID=system;Password=oracle";

                con = new OracleConnection(dd);
                con.Open();



                string sq = "select count(*) from CITYSMART. USERDETAIL where USERNAME='" + textBox1.Text + "'and PASSWORD=" + textBox2.Text + "" ;
                OracleDataAdapter dt = new OracleDataAdapter(sq, con);
                DataTable table = new DataTable();
                dt.Fill(table);
                dataGridView1.DataSource = table;
                con.Close();

                string t = dataGridView1.Rows[0].Cells[0].Value.ToString();


                int a = Int32.Parse(t);

                if (a == 1)
                {
                    MessageBox.Show("Welcome");
                    Main b = new Main();
                    b.Show();
                    this.Close();

                }
                else
                {

                    MessageBox.Show("sorry user name and password is incorrect ");

                    textBox1.Clear();
                    textBox2.Clear();
                }
                  




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        
        }
        
    

        private void Adminlogin_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Changepassword ab = new Changepassword();
            ab.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
