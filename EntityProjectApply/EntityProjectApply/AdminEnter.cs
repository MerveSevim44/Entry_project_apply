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
    public partial class AdminEnter : Form
    {
        public AdminEnter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityProductEntities en = new EntityProductEntities(); 
            var query = from x in en.Admin where x.UserName == textBox1.Text && x.Password == textBox2.Text select x;

            if(query.Any())
            {
                MainProgress main = new MainProgress();
                main.Show();    
                this.Hide();

            }

            else
            {
                MessageBox.Show("your user name or password incorrect!");
               
            }
        }
    }
}
