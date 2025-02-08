using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjectApply
{
    public partial class MainProgress : Form
    {
        public MainProgress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm= new Form1();
            frm.Show();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ProductOperations pro = new ProductOperations(); 
            pro.Show(); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stasistic stasistic = new Stasistic();
            stasistic.Show();   
        }
    }
}
