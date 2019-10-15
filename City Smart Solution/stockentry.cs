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
    public partial class stockentry : Form
    {
       // variables

        int price, quan;
        double totalp;

        double salep, pruchp;
         
        

        public stockentry()
        {
            InitializeComponent();
           

        }
        // validdated check
        public void validcheck()
        {
            if(IsValidated())
            {
               
            }
        }

        private bool IsValidated()
        {
            if (comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("please select  Generate Or Read barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return false;
            }
           
            
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("please Select oR Read barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }
            if (item_name.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the item name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                item_name.Focus();
                return false;
            }
            if (Quantity.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Quantity.Focus();
                return false;
            }
            if (itemModel.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the itemModel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemModel.Focus();
                return false;
            }
            if (itemSize.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the itemSize", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemSize.Focus();
                return false;
            }
            if (itemColor.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the itemColor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemColor.Focus();
                return false;
            }
            if (itemPrice.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the itemPrice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemPrice.Focus();
                return false;
            }
            if (purchaceprice.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the PurchacePrice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                purchaceprice.Focus();
                return false;
            }
            if (itemsaleprice.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter the Saleprice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemsaleprice.Focus();
                return false;
            }



            return true;
        }
        // valid check finish 

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox2.Show();
                    comboBox2.Enabled = true;

                    item_name.Focus();


                    break;

                case 1:
                    
                    comboBox2.Enabled=false;
                    textBox1.Focus();
                    break;
            }

        }

        private void stockentry_Load(object sender, EventArgs e)



        {
            comboBox2.Enabled = false;
            fillcomboBox();
            autoidgenerate();
          



        }

        // auto id generate
        void autoidgenerate()
        {
            try
            {
                OracleConnection conn = null;


                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);

                conn.Open();
                
               String myquery = "select item_id from CITYSMART.STOCKENTRY";
                OracleCommand cmd = new OracleCommand(myquery,conn);
                
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count < 1)
                {
                    item_id.Text = "1";

                }
                else        
                {

                    OracleConnection conn1 = null;


                    string asdd = "Data Source=localhost;User ID=system;Password=oracle";

                    conn1 = new OracleConnection(asdd);

                    conn1.Open();

                    String myquery1 = "select max (item_id) from CITYSMART.STOCKENTRY";
                    OracleCommand cmd1 = new OracleCommand(myquery1, conn1);

                    OracleDataAdapter da1 = new OracleDataAdapter();
                    da1.SelectCommand = cmd1;
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    item_id.Text = ds1.Tables[0].Rows[0][0].ToString();
                    int a;
                    a = Convert.ToInt32(item_id.Text);
                    a++;
                    item_id.Text = a.ToString();
                    conn1.Close();

                   
                   
                }

              // OracleDataAdapter sda = new OracleDataAdapter("Select ISNULL(max(cast(item_id as int ) ),0)+1 from CITYSMART.STOCKENTRY", conn);
               // DataTable dt = new DataTable();
                //sda.Fill(dt);
                 //item_id.Text = dt.Rows[0][0].ToString();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          


        }
       
        // comboBox fill data from the database


        void fillcomboBox()
        {
           

            try
            {

                OracleConnection conn = null;


                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);

                conn.Open();
                string sql = "select item_name from CITYSMART.CREATEBARCODE  ";
              
                OracleCommand cmd = new OracleCommand(sql,conn);
                OracleDataReader myreader;
               // DataColumn reade;
              //  DbDataReader reader;
              myreader  = cmd.ExecuteReader();

                while(myreader.Read())
                {
         
                    
                   comboBox2.Items.Add(myreader.GetValue(0).ToString());
                  
                }
                myreader.Close();
             //   cmd.ExecuteNonQuery();



              

                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

          

        }


        //save button

        private void button1_Click(object sender, EventArgs e)
        {
          // string sql1 = "insert into CITYSMART.STOCKENTRY values(:barcode_image)";

            validcheck();

            //

            OracleConnection conn = null;
          
            try
            {

              

                MemoryStream ms = new MemoryStream();
                this.pictureBox1.Image.Save(ms, ImageFormat.Bmp);

               

                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);

                conn.Open();
                string sql = "insert into CITYSMART.STOCKENTRY values(" + item_id.Text + ",'" + item_name.Text + "','" + textBox1.Text + "'," + Quantity.Text + ",'" + itemModel.Text + "','" + itemSize.Text + "','" + itemColor.Text + "'," + itemPrice.Text + "," + itemtotalprice.Text + ",'" + dateTimePicker1.Text + "'," + purchaceprice.Text + ",:barcode_image, " + itemsaleprice.Text + ")";


                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
               
                

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


        }

       

      

      



       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {

                OracleConnection conn = null;


                string asd = "Data Source=localhost;User ID=system;Password=oracle";

                conn = new OracleConnection(asd);

                conn.Open();
                string sql = "select item_barcode from CITYSMART.CREATEBARCODE where item_name= '" + comboBox2.Text + "'  ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader myreader;
                // DataColumn reade;
                //  DbDataReader reader;
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {


                    // comboBox2.Items.Add(myreader.GetValue(0).ToString());
                    textBox1.Text = myreader.GetValue(0).ToString();

                }
                myreader.Close();
                //   cmd.ExecuteNonQuery();





                conn.Close();
                item_name.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

       

        private void keypressofcombobox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    string text1 = textBox1.Text;
                    Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                    pictureBox1.Image = barcode.Draw(text1, 50);
                    label6.Text = text1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main cd = new Main();
            cd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Text="";
            item_name.Clear();
            Quantity.Clear();
            itemModel.Clear();
            itemPrice.Clear();
            itemSize.Clear();
            itemtotalprice.Clear();
            itemColor.Clear();
            purchaceprice.Clear();
            itemsaleprice.Clear();
            autoidgenerate();

        }

        private void item_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (itemPrice.Text != "")
                {
                    quan = Int32.Parse(Quantity.Text);
                    price = Int32.Parse(itemPrice.Text);
                    totalp = quan * price;
                    itemtotalprice.Text = totalp.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void itemsaleprice_TextChanged(object sender, EventArgs e)
        {
          
            }

        private void quantitynumber(object sender, KeyPressEventArgs e)
        {
            
            
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    int qa = 7;
                    if (Quantity.Text.Length <= qa)


                    e.Handled = true;
                    MessageBox.Show("Only inter the number && only 7 digit enter");
                }
            
        }

        private void pricenumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                int qa = 7;
                if (Quantity.Text.Length <= qa)


                    e.Handled = true;
                MessageBox.Show("Only inter the number && only 7 digit enter");
            }
            

        }

        private void purprice(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                int qa = 7;
                if (Quantity.Text.Length <= qa)


                    e.Handled = true;
                MessageBox.Show("Only inter the number && only 7 digit enter");
            }
            
        }

        private void salepr(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                int qa = 7;
                if (Quantity.Text.Length <= qa)


                    e.Handled = true;
                MessageBox.Show("Only inter the number && only 7 digit enter");
            }
            
        }

        private void purchaceprice_TextChanged(object sender, EventArgs e)
        {
           

        }

     



    }
}