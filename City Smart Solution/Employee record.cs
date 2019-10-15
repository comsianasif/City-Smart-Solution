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
    public partial class Employee_record : Form
    {
        string btn;

        string st="0000";
        OracleDataAdapter dr;
        OracleCommandBuilder sd;
        DataTable table;
        public Employee_record()
        {
            InitializeComponent();
        }

        private void Employee_record_Load(object sender, EventArgs e)
        {
            loadDatabase();

        }

        //load database
        void loadDatabase()
        {


            try
            {

                OracleConnection conn;

                string dd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(dd);
                conn.Open();



                string sq = "select * from CITYSMART.EMPLOYEE ";






                dr = new OracleDataAdapter(sq, conn);
                table = new DataTable();
                dr.Fill(table);
                dataGridView1.DataSource = table;
                conn.Close();










            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            


            if (rdname.Checked)
            {
                st = " select * from CITYSMART.EMPLOYEE where Name='" + textsearch.Text + "'";

               

                
            }
          

            if (rdid.Checked)
            {
                st = " select * from CITYSMART.EMPLOYEE where Id=" + int.Parse(textsearch.Text);
            }
          
            if (rdsalary.Checked)
            {
                st = " select * from CITYSMART.EMPLOYEE where Salary=" + int.Parse(textsearch.Text);
            }

          
          if (rdcnic.Checked)
            {
               st = " select * from CITYSMART.EMPLOYEE where Cnic=" + int.Parse(textsearch.Text);
            }
          
            try
            {

                OracleConnection conn;

                string dd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(dd);
                conn.Open();



                string sq = st;






                OracleDataAdapter dr = new OracleDataAdapter(sq, conn);
                DataTable table = new DataTable();

                
             
                dr.Fill(table);
                dataGridView1.DataSource = table;
                conn.Close();



                int aa = 0;

                aa = table.Rows.Count;
               
                if(aa==0){

                    MessageBox.Show("No record found");

                }



               







            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sd = new OracleCommandBuilder(dr);
                dr.Update(table);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
