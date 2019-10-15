using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace City_Smart_Solution
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            stockentry ab = new stockentry();
            ab.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer ab = new customer();
            ab.Show();
            this.Hide();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.button1.Image = new Bitmap(City_Smart_Solution.Properties.Resources.add_customer64);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(City_Smart_Solution.Properties.Resources.addcustomer_128);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(City_Smart_Solution.Properties.Resources.add_customer64);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            this.button1.Image = new Bitmap(City_Smart_Solution.Properties.Resources.addcustomer_128);
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            this.button5.Image = new Bitmap(City_Smart_Solution.Properties.Resources.stockentry);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            this.button5.Image = new Bitmap(City_Smart_Solution.Properties.Resources.stockentry128);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.button5.Image = new Bitmap(City_Smart_Solution.Properties.Resources.stockentry);
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            this.button5.Image = new Bitmap(City_Smart_Solution.Properties.Resources.stockentry128);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            this.button3.Image = new Bitmap(City_Smart_Solution.Properties.Resources.saverecord64);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.button3.Image = new Bitmap(City_Smart_Solution.Properties.Resources.saverecord128);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.Image = new Bitmap(City_Smart_Solution.Properties.Resources.saverecord64);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            this.button3.Image = new Bitmap(City_Smart_Solution.Properties.Resources.saverecord128);
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            this.button4.Image = new Bitmap(City_Smart_Solution.Properties.Resources.employee64);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.button4.Image = new Bitmap(City_Smart_Solution.Properties.Resources.employee1281);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.button4.Image = new Bitmap(City_Smart_Solution.Properties.Resources.employee64);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            this.button4.Image = new Bitmap(City_Smart_Solution.Properties.Resources.employee1281);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            this.button2.Image = new Bitmap(City_Smart_Solution.Properties.Resources.poweroff64);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(City_Smart_Solution.Properties.Resources.poweroff128);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(City_Smart_Solution.Properties.Resources.poweroff64);
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            this.button2.Image = new Bitmap(City_Smart_Solution.Properties.Resources.poweroff128);

        }
    }
}
