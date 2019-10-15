using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.Common;

namespace City_Smart_Solution
{
    public partial class sale_product_record : Form
    {

        //variables
        OracleDataAdapter dr;
        OracleCommandBuilder sd;
        DataTable table;
        OracleConnection conn;
        OracleCommand cmd;

        public sale_product_record()
        {
            InitializeComponent();
        }

        // load database
        void loaddataBase()
        {
            try
            {

                OracleConnection conn;

                string dd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(dd);
                conn.Open();



                string sq = "select * from CITYSMART.SALEPRODUCTSADD";






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

        private void sale_product_record_Load(object sender, EventArgs e)
        {
            loaddataBase();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
