using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.Drawing.Imaging;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace City_Smart_Solution
{
    public partial class stockview : Form
    {

        OracleDataAdapter dr;
        OracleCommandBuilder sd;
        DataTable table;
        public stockview()
        {
            InitializeComponent();
        }

        private void stockview_Load(object sender, EventArgs e)
        {
            try
            {

                OracleConnection conn;

                string dd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(dd);
                conn.Open();



                string sq = "select * from CITYSMART.STOCKENTRY ";






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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
