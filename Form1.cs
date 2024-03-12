using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample2_WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public AdventureWorks2017Entities dbContext = new AdventureWorks2017Entities();

        public DbSet<Product> Products;

        public Form1()
        {
            InitializeComponent();

            RefreshForm1();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbContext.SaveChanges();
            RefreshForm1();
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(dbContext);
            addForm.ShowDialog();
            RefreshForm1();
        }

        private void RefreshForm1()
        {
            Products = dbContext.Product;
            dataGridView1.DataSource = Products.ToList();
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            List<int> selected = new List<int>();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    selected.Add((int)dataGridView1.SelectedRows[i].Cells["ProductID"].Value);
                }
            }
            else
            {
                List<int> rowIndex = new List<int>();

                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    int value = dataGridView1.SelectedCells[i].RowIndex;

                    if (!rowIndex.Contains(value))
                    {
                        rowIndex.Add(value);
                    }
                }

                foreach (int value in rowIndex)
                {
                    selected.Add((int)dataGridView1.Rows[value].Cells["ProductID"].Value);
                }
            }
            List<Product> products = (from p in Products
                                     join id in selected
                                     on p.ProductID equals id
                                     select p).ToList();

            dbContext.Product.RemoveRange(products);
            dbContext.SaveChanges();
            RefreshForm1();
        }
    }
}
