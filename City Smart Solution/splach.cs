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
    public partial class splach : Form
    {
        public splach()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
            int prog = progressBar1.Value;


            if (prog == 100)
            {
                Loginnow abc = new Loginnow();
                timer1.Enabled = false;
                this.Hide();
                abc.Show();

            }
        }

        private void splach_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
