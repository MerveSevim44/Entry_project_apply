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
    public partial class Stasistic : Form
    {
        public Stasistic()
        {
            InitializeComponent();
        }
        EntityProductEntities en = new EntityProductEntities();

        private void Stasistic_Load(object sender, EventArgs e)
        {
            label13.Text = en.Categories.Count().ToString();
            label14.Text = en.Products.Count().ToString();
            label15.Text = en.Customers.Count(x => x.Situation == true).ToString();
            label16.Text = en.Customers.Count(x => x.Situation == false).ToString();
            label18.Text = en.Products.Sum(y => y.Stock).ToString();
            label22.Text = en.Sales.Sum(z => z.Price).ToString() + "TL";
            label19.Text = (from x in en.Products orderby x.Price descending select x.ProductName).FirstOrDefault();
            label20.Text = (from x in en.Products orderby x.Price ascending select x.ProductName).FirstOrDefault();
            label17.Text = en.Products.Count(x => x.CayegoryId == 1).ToString();
            label24.Text = en.Products.Count(x => x.ProductName == "Refrigerator").ToString();
            label21.Text = (from x in en.Customers select x.City).Distinct().Count().ToString();
            label23.Text = en.BrandBring().FirstOrDefault();

        }
    }
}
