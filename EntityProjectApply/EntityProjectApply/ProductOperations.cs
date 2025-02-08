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
    public partial class ProductOperations : Form
    {
        public ProductOperations()
        {
            InitializeComponent();
        }
        EntityProductEntities en = new EntityProductEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from k in en.Products
                                        select new
                                        {
                                            k.ProductId,
                                            k.ProductName,
                                            k.Brand,
                                            k.Stock,
                                            k.Price,
                                            k.Categories.CategoryName,
                                            k.Situation
                                        }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.ProductId = int.Parse(txtId.Text);
            pro.ProductName = txtName.Text;
            pro.Brand = txtBrand.Text;
            pro.Price = decimal.Parse(txtPrice.Text);
            pro.CayegoryId = int.Parse(cmbCat.SelectedValue.ToString());
            pro.Situation = true;
            pro.Stock = int.Parse(txtStock.Text);
            en.Products.Add(pro);
            en.SaveChanges();
            MessageBox.Show("Product added!");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ıd = Convert.ToInt32(txtId.Text);
            var prd = en.Products.Find(ıd);
            en.Products.Remove(prd);
            en.SaveChanges();
            MessageBox.Show("Product deleted!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var prd = en.Products.Find(id);

            if (prd != null)
            {
                // Update the product details
                prd.ProductName = txtName.Text;
                prd.Brand = txtBrand.Text;
                prd.Price = decimal.Parse(txtPrice.Text);
                prd.Stock = int.Parse(txtStock.Text);

                // Save changes to the database
                en.SaveChanges();

                // Inform the user
                MessageBox.Show("Product updated!");
            }
            else
            {
                // Inform the user that the product was not found
                MessageBox.Show("Product not found with the specified Id.");
            }
        }

        private void ProductOperations_Load(object sender, EventArgs e)
        {
            var categories = (from x in en.Categories
                              select new
                              {
                                  x.CategoryId,
                                  x.CategoryName
                              }).ToList();

            cmbCat.ValueMember = "CategoryId";
            cmbCat.DisplayMember = "CategoryName";
            cmbCat.DataSource = categories;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Text = cmbCat.SelectedValue.ToString();
        }
    }
}
