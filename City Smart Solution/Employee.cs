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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                OracleConnection conn;

                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);
                conn.Open();

                string sql = "insert into CITYSMART.EMPLOYEE values(" + empid.Text + ",'" + name.Text + "','" + fname.Text + "','" + address.Text + "'," + phone.Text + "," + cnic.Text + ",'" + workertype.Text + "'," + salary.Text + ",'" + dateTimePicker1.Text + "')";



                OracleCommand cmd = new OracleCommand(sql, conn);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

              //  if(empid.TextLength<=7){ }

               // else  { MessageBox.Show("Your Id length is largervalue of 7 digits"); }


               // if (name.TextLength <= 15) { }
               // else { MessageBox.Show("Your Name length is larger value of 15 digits"); }


                MessageBox.Show("Save Successfully");

                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main cd = new Main();
            cd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            empid.Clear();
            name.Clear();
            fname.Clear();
            address.Clear();
            phone.Clear();
            cnic.Clear();
            workertype.Clear();
            salary.Clear();

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
           

            }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

       
  

        private void phoneNOmber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only inter the number && only 11 digit enter");
            }
        }

        private void onlynumberempid(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only inter the number");
            }

        }

        private void phoneNumberonlydigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only inter the number");
            }
        }

        private void cniconlynumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only inter the number");
            }
        }

        private void salaryonlynumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only inter the number");
            }
        }

        private void cnic_TextChanged(object sender, EventArgs e)
        {

        }
        }
    
}
