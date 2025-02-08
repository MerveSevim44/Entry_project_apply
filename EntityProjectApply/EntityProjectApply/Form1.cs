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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EntityProductEntities en = new EntityProductEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
           var categories=en.Categories.ToList();
            dataGridView1.DataSource= categories;   
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categories c= new Categories();
            c.CategoryName = textBox2.Text;
            en.Categories.Add(c);
            en.SaveChanges();
            MessageBox.Show("Category added!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ıd = Convert.ToInt32(textBox1.Text);
            var ctgr = en.Categories.Find(ıd);
            ctgr.CategoryName = textBox2.Text;
            en.SaveChanges();
            MessageBox.Show("Category updated");
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           int ıd = Convert.ToInt32(textBox1.Text);
            var ctgr = en.Categories.Find(ıd);
            en.Categories.Remove(ctgr); 
            en.SaveChanges();
            MessageBox.Show("Category deleted!");
        }
    }
}
