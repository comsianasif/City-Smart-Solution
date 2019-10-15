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
using City_Smart_Solution.Model__Clesses;



namespace City_Smart_Solution
{


  
    public partial class gerneratebarcode : Form
    {

        OracleDataAdapter dr;
        OracleCommandBuilder sd;
        DataTable table;
        
        private string text1;
        private string qunitity;
        private List <generatebarcodeclass> listadd= new List<generatebarcodeclass> ();
        // validdated check
        public void validcheck()
        {
            if (IsValidated())
            {
               

                generatebarcodeclass gentitem = new generatebarcodeclass()
                {
                    itemId=Convert.ToInt32 (barcodeid.Text.Trim()),
                    itemBarcode= textBox1.Text.Trim(),
                    itemName=item_name.Text.Trim(),
                  //  imagePicture=Convert.ToByte []()


                };

                listadd.Add(gentitem);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listadd;
            }
        }

        private bool IsValidated()
        {
           


            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("please Enter the barcode Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }
            if (item_name.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the item name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                item_name.Focus();
                return false;
            }
           



            return true;
        }
        // valid check finish 


        void loaddataBase ()
        {
            try
            {


                OracleConnection conn;

                string dd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(dd);
                conn.Open();



                string sq = "select * from CITYSMART.CREATEBARCODE ";






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


        // generate id 

        void autoidgenerate()
        {
            try
            {
                OracleConnection conn = null;


                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);

                 conn.Open();

                 String myquery = "select barcode_id from CITYSMART.CREATEBARCODE";
                 OracleCommand cmd = new OracleCommand(myquery,conn);

                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                 DataSet ds = new DataSet();
                 da.Fill(ds);
                 conn.Close();
                if (ds.Tables[0].Rows.Count < 1)
                 {

                 barcodeid.Text = "1";

                 }
                 else        
                {

                    OracleConnection conn1 = null;


                    string asdd = "Data Source=localhost;User ID=system;Password=oracle";

                    conn1 = new OracleConnection(asdd);

                    conn1.Open();

                    String myquery1 = "select max (barcode_id) from CITYSMART.CREATEBARCODE";
                    OracleCommand cmd1 = new OracleCommand(myquery1, conn1);

                    OracleDataAdapter da1 = new OracleDataAdapter();
                    da1.SelectCommand = cmd1;
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    barcodeid.Text = ds1.Tables[0].Rows[0][0].ToString();
                    int a;
                    a = Convert.ToInt32(barcodeid.Text);
                    a++;
                    barcodeid.Text = a.ToString();
                    conn1.Close();



                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }
       


        public gerneratebarcode()
        {
            InitializeComponent();
        }

        //save button

        private void button1_Click(object sender, EventArgs e)
        {
           // text1 = barcodeno.Text;
           // qunitity = item_name.Text;

            validcheck();


            OracleConnection conn = null;

            string sql = "insert into CITYSMART.CREATEBARCODE values(:barcode_id,:item_barcode,:item_name,:barcodeimage)";



           
            try
            {

                MemoryStream ms = new MemoryStream();
                this.pictureBox2.Image.Save(ms, ImageFormat.Bmp);



                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);


                conn.Open();

            //    string sql = "insert into CITYSMART.STOCK values(" + barcodeid.Text + ",'" + barcodeno.Text + "','" + item_name.Text + "',:barcode_image)";


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
               cmd.Parameters.Add("@barcode_id", barcodeid.Text);
               cmd.Parameters.Add("@item_barcode", textBox1.Text);
               cmd.Parameters.Add("@item_name", item_name.Text);

                OracleParameter param = new OracleParameter("@barcode_image", OracleDbType.Blob, ms.GetBuffer().Length);
                //    OracleParameter param = new OracleParameter("@BarcodeImage",Oracle.DataAccess.Client.OracleDbType.Blob,pictureBox1.Image);

                param.Value = ms.GetBuffer();
                cmd.Parameters.Add(param);
                // cmd.Parameters.Add("@barcodeimage",(Object)pictureBox1.Image);


               

                cmd.ExecuteNonQuery();



                MessageBox.Show("Save Successfully");


              


                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            button4.Enabled = true;
         

        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            //qunitity = Quantity.Text;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // stockentry f1 = new stockentry();
           
           // f1.Show();
            // this.Hide();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            autoidgenerate();
            textBox1.Text = "";
            
            item_name.Clear();
            textBox1.Focus();
        }

        private void gerneratebarcode_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
           button4.Enabled = false;
         //  button3.Enabled = false;
            loaddataBase();
            autoidgenerate();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection conn = null;

            
            try
            {

                MemoryStream ms = new MemoryStream();
                this.pictureBox2.Image.Save(ms, ImageFormat.Bmp);



                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);


                conn.Open();

                string sql = " update CITYSMART.CREATEBARCODE set item_barcode='" + textBox1.Text + "',item_name='"+item_name.Text+"' where barcode_id=" + barcodeid.Text + "";
                OracleCommand cmd = new OracleCommand();
              //  OracleParameter param = new OracleParameter("@barcode_image", OracleDbType.Blob, ms.GetBuffer().Length);
                 //  OracleParameter param = new OracleParameter("@BarcodeImage",Oracle.DataAccess.Client.OracleDbType.Blob,pictureBox1.Image);

               // param.Value = ms.GetBuffer();
                //cmd.Parameters.Add(param);
                

                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();


                generatebarcodeclass gentitem = new generatebarcodeclass()
                {
                    itemId = Convert.ToInt32(barcodeid.Text.Trim()),
                    itemBarcode = textBox1.Text.Trim(),
                    itemName = item_name.Text.Trim(),
                    //  imagePicture=Convert.ToByte []()


                };

                listadd.Add(gentitem);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listadd;


                MessageBox.Show("UpDate Successfully");





                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            button4.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OracleConnection conn = null;
            try
            {
                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);


                conn.Open();
                string sql = " delete from CITYSMART.CREATEBARCODE where barcode_id= " + barcodeid.Text + " ";
                OracleCommand cmd = new OracleCommand(sql,conn);
                cmd.ExecuteNonQuery();

                generatebarcodeclass gentitem = new generatebarcodeclass()
                {
                    itemId = Convert.ToInt32(barcodeid.Text.Trim()),
                    itemBarcode = textBox1.Text.Trim(),
                    itemName = item_name.Text.Trim(),
                    //  imagePicture=Convert.ToByte []()


                };

                listadd.Add(gentitem);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listadd;

                MessageBox.Show("Delete Data Successfully");





                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            button4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    text1 = textBox1.Text;
                    Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                    pictureBox2.Image = barcode.Draw(text1, 50);

                    label4.Text = text1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            barcodeid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            item_name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           // pictureBox1.Image = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            loaddataBase();
        }
    }
}
