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
using System.Data.Common;


namespace City_Smart_Solution
{
    public partial class customer : Form
    {
        //oracle variable 

        OracleDataAdapter dr;
        OracleCommandBuilder sd;
        DataTable table;
        OracleConnection conn;
        OracleCommand cmd;

        //variable decleration
        string code, name, size, color, model; int id, price, quanty; int unitcost, lastamount, totalamount;
 

        public customer()
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



                string sq = "select * from CITYSMART.CUSTOMERADD1";






                dr = new OracleDataAdapter(sq, conn);
                table = new DataTable();
                dr.Fill(table);
                dataGridView2.DataSource = table;
                conn.Close();










            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        // auto id generate
        void autoidgenerate()
        {
            try
           {
            //    OracleConnection conn = null;


               //  string asd = "Data Source=localhost;User ID=system;Password=oracle";

                // conn = new OracleConnection(asd);

               //  conn.Open();

               //   String myquery = "select cus_id from CITYSMART.STOCKENTRY";
              //   OracleCommand cmd = new OracleCommand(myquery,conn);

            //    OracleDataAdapter da = new OracleDataAdapter();
             //   da.SelectCommand = cmd;
              ///   DataSet ds = new DataSet();
               //  da.Fill(ds);
               //  conn.Close();
             //   if (ds.Tables[0].Rows.Count < 1)
              //  {
              //  cus_id.Text = "1";

              //   }
                // else        
                {

                    OracleConnection conn1 = null;


                    string asdd = "Data Source=localhost;User ID=system;Password=oracle";

                    conn1 = new OracleConnection(asdd);

                    conn1.Open();

                    String myquery1 = "select max (cus_id) from CITYSMART.CUSTOMERADD1";
                    OracleCommand cmd1 = new OracleCommand(myquery1, conn1);

                    OracleDataAdapter da1 = new OracleDataAdapter();
                    da1.SelectCommand = cmd1;
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    cus_id.Text = ds1.Tables[0].Rows[0][0].ToString();
                    int a;
                    a = Convert.ToInt32(cus_id.Text);
                    a++;
                    cus_id.Text = a.ToString();
                    conn1.Close();



                }

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }
       


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main cd = new Main();
            cd.Show();
            this.Hide();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            loaddataBase();
            autoidgenerate();
            purchace_price.Hide();

        }

        private void cusbarcode_TextChanged(object sender, EventArgs e)
        {

            try
            {

                 conn = null;


                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);

                conn.Open();
                string sql = "select * from CITYSMART.STOCKENTRY where item_barcode= '" + cusbarcode.Text + "'  ";

                 cmd = new OracleCommand(sql, conn);
                OracleDataReader myreader;
                // DataColumn reade;
                //  DbDataReader reader;
                myreader = cmd.ExecuteReader();

                if(myreader.Read ())

                {
                    itemid.Text = (myreader["item_id"].ToString());
                  
                   itemname.Text = (myreader["item_name"].ToString());
                   itemprice.Text= (myreader["sale_price"].ToString());
                   itemsize.Text = (myreader["item_size"].ToString());
                   itemmodel.Text = (myreader["item_model"].ToString());
                   itemcolor.Text = (myreader["item_color"].ToString());
                   quantity.Text = (myreader["quantity"].ToString());
                   purchace_price.Text = (myreader["purchace_price"].ToString());

                   try
                   {
                       string text1 = cusbarcode.Text;
                       Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                       pictureBox1.Image = barcode.Draw(text1, 50);

                   }
                   catch (Exception ex)
                   {

                       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
                }


                cus_quantity.Text = "1";

                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                 quanty = Int32.Parse(quantity.Text);

            if (quanty == 1)
            {
                string asd = "Data Source=localhost;User ID=system;Password=oracle";
                try
                {
                    conn = null;

                    conn = new OracleConnection(asd);

                    conn.Open();
                    string sql = "DELETE  from CITYSMART.STOCKENTRY where item_barcode = '" + cusbarcode.Text + "'  ";

                    cmd = new OracleCommand(sql, conn);
                    cmd.ExecuteNonQuery();


                      try
                       {
                            MemoryStream ms1 = new MemoryStream();
                            this.pictureBox1.Image.Save(ms1, ImageFormat.Bmp);

                            conn = new OracleConnection(asd);
                            conn.Open();

                           string sql2 = "insert into CITYSMART.SALEPRODUCTSADD values(" + cus_id.Text + ",'" + cusname.Text + "'," + phone.Text + ",'" + cusbarcode.Text + "'," + itemid.Text + ",'" + itemname.Text + "','" + itemmodel.Text + "','" + itemsize.Text + "'," + itemprice.Text + ",'" + dateTimePicker1.Text + "'," + cus_quantity.Text + ",:barcode_image," + purchace_price.Text + ")";


                            cmd = new OracleCommand(sql2, conn);

                            cmd.CommandType = CommandType.Text;
                           OracleParameter param1 = new OracleParameter("@barcode_image", OracleDbType.Blob, ms1.GetBuffer().Length);
                              // OracleParameter param = new OracleParameter("@BarcodeImage",Oracle.DataAccess.Client.OracleDbType.Blob,pictureBox1.Image);

                            param1.Value = ms1.GetBuffer();
                            cmd.Parameters.Add(param1);
                            cmd.ExecuteNonQuery();

                            try
                            {

                                MemoryStream ms = new MemoryStream();
                                this.pictureBox1.Image.Save(ms, ImageFormat.Bmp);

                                conn = new OracleConnection(asd);
                                conn.Open();

                                string sql1 = "insert into CITYSMART.CUSTOMERADD1 values(" + cus_id.Text + ",'" + cusname.Text + "','" + cusbarcode.Text + "'," + itemid.Text + ",'" + itemname.Text + "'," + itemprice.Text + ",'" + itemsize.Text + "','" + itemcolor.Text + "','" + itemmodel.Text + "','" + dateTimePicker1.Text + "'," + cus_quantity.Text + ",:barcode_image," + phone.Text + ")";


                                cmd = new OracleCommand(sql1, conn);

                                cmd.CommandType = CommandType.Text;
                                OracleParameter param = new OracleParameter("@barcode_image", OracleDbType.Blob, ms.GetBuffer().Length);
                                //    OracleParameter param = new OracleParameter("@BarcodeImage",Oracle.DataAccess.Client.OracleDbType.Blob,pictureBox1.Image);

                                param.Value = ms.GetBuffer();
                                cmd.Parameters.Add(param);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Save Successfully");

                                conn.Close();
                            }
  catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                      

                    }
                    

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                string asd = "Data Source=localhost;User ID=system;Password=oracle";
               
                try
                {

                    code = cusbarcode.Text;
                    id = Int32.Parse(itemid.Text);
                    name = itemname.Text;
                    price = Int32.Parse(itemprice.Text);
                    size = itemsize.Text;
                    model = itemmodel.Text;
                    color = itemcolor.Text;
                    quanty = Int32.Parse(quantity.Text);
                    quanty = quanty - 1;
                    quantity.Text = quanty.ToString();
                    conn = null;

                    conn = new OracleConnection(asd);

                    conn.Open();
                    string sql = "UPDATE CITYSMART.STOCKENTRY SET QUANTITY= '" + quantity.Text + "' where item_barcode = '" + cusbarcode.Text + "'  ";

                    cmd = new OracleCommand(sql, conn);
                    cmd.ExecuteNonQuery();


                  

                            try
                            {


                                MemoryStream ms1 = new MemoryStream();
                                this.pictureBox1.Image.Save(ms1, ImageFormat.Bmp);

                                conn = new OracleConnection(asd);
                                conn.Open();

                                string sql2 = "insert into CITYSMART.SALEPRODUCTSADD values(" + cus_id.Text + ",'" + cusname.Text + "'," + phone.Text + ",'" + cusbarcode.Text + "'," + itemid.Text + ",'" + itemname.Text + "','" + itemmodel.Text + "','" + itemsize.Text + "'," + itemprice.Text + ",'" + dateTimePicker1.Text + "'," + cus_quantity.Text + ",:barcode_image," + purchace_price.Text + ")";


                                cmd = new OracleCommand(sql2, conn);

                                cmd.CommandType = CommandType.Text;
                                OracleParameter param1 = new OracleParameter("@barcode_image", OracleDbType.Blob, ms1.GetBuffer().Length);
                                // OracleParameter param = new OracleParameter("@BarcodeImage",Oracle.DataAccess.Client.OracleDbType.Blob,pictureBox1.Image);

                                param1.Value = ms1.GetBuffer();
                                cmd.Parameters.Add(param1);
                                cmd.ExecuteNonQuery();

                                try
                                {

                                    MemoryStream ms = new MemoryStream();
                                    this.pictureBox1.Image.Save(ms, ImageFormat.Bmp);

                                    conn = new OracleConnection(asd);
                                    conn.Open();

                                    string sql1 = "insert into CITYSMART.CUSTOMERADD1 values(" + cus_id.Text + ",'" + cusname.Text + "','" + cusbarcode.Text + "'," + itemid.Text + ",'" + itemname.Text + "'," + itemprice.Text + ",'" + itemsize.Text + "','" + itemcolor.Text + "','" + itemmodel.Text + "','" + dateTimePicker1.Text + "'," + cus_quantity.Text + ",:barcode_image," + phone.Text + ")";


                                    cmd = new OracleCommand(sql1, conn);

                                    cmd.CommandType = CommandType.Text;
                                    OracleParameter param = new OracleParameter("@barcode_image", OracleDbType.Blob, ms.GetBuffer().Length);
                                    //    OracleParameter param = new OracleParameter("@BarcodeImage",Oracle.DataAccess.Client.OracleDbType.Blob,pictureBox1.Image);

                                    param.Value = ms.GetBuffer();
                                    cmd.Parameters.Add(param);
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Save Successfully");

                                    conn.Close();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                            }
 
                        

                    
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            
           

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
