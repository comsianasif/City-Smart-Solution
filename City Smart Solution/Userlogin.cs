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
    public partial class Userlogin : Form
    {
        public Userlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main ab = new Main();
            ab.Show();
            this.Hide();


           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loginnow ab = new Loginnow();
            ab.Show();
            this.Hide();
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
