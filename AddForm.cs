using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample2_WindowsFormsApp
{
    public partial class AddForm : Form
    {
        public AdventureWorks2017Entities DbContext { get; set; }

        public AddForm(AdventureWorks2017Entities dbContext)
        {
            InitializeComponent();

            DbContext = dbContext;
            RefreshForm();
        }

        private void RefreshForm()
        {
            List<Product> list = new List<Product>()
            {
                new Product()
                {
                    Name = "InputData"
                }
            };

            dataGridViewAdd1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Product> products = (IEnumerable<Product>)dataGridViewAdd1.DataSource;
                DbContext.Product.Add(products.First());
                DbContext.SaveChanges();
                RefreshForm();
                MessageBox.Show("Added");
            }
            catch (DbEntityValidationException dbExc)
            {

                foreach (DbValidationError error in dbExc.EntityValidationErrors.First().ValidationErrors)
                {
                    Console.WriteLine("Error Property Name {0} : Error Message: {1}",
                                        error.PropertyName, error.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}
