using StoreEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Windows.Forms;

namespace StoreSystem
{
    public partial class ProductReportForm : Form
	{
		Context context = new Context();
		public ProductReportForm()
		{
			InitializeComponent();
			FillData();
		}
		private void FillData()
		{
			var products = (from s in context.Product 
							where s != null
							select s.Name).Distinct();
			foreach (var store in products)
			{
				listBox1.Items.Add(store);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

            if (listBox1.SelectedItems != null)
			{

				dataGridView1.Rows.Clear();
				string productName = listBox1.SelectedItem.ToString();
				var from = FromDate.Value;
				var to = ToDate.Value;	
				var storeName = comboBox1.SelectedItem;
				var products =new  List<Product>();
				if(storeName == null)
				{
					 products = context.Product.Where(p => p.Name == productName && p.AddDate >=from && p.AddDate <=to  ).ToList();
				}
				else
				{
                    products = context.Product.Where(p => p.Name == productName && p.AddDate >= from && p.AddDate <= to && p.Store.Name == storeName.ToString()).ToList();

                }
				if(from == null && to == null)
				{
					MessageBox.Show("select date ");
				}
				else
				{
					if (products != null)
				{
					foreach(var product in products)
					{
						var productStore = context.Store.FirstOrDefault(s => s.Id == product.StoreId);
						if (productStore != null)
						{
							DataGridViewRow row = new DataGridViewRow();
							DataGridViewCell cell1 = new DataGridViewTextBoxCell();
							DataGridViewCell cell2 = new DataGridViewTextBoxCell();
							DataGridViewCell cell3 = new DataGridViewTextBoxCell();
							DataGridViewCell cell4 = new DataGridViewTextBoxCell();
							DataGridViewCell cell5 = new DataGridViewTextBoxCell();

							cell1.Value = product.Name;
							cell2.Value = product.Code;
							cell3.Value = productStore.Name;
							cell4.Value = product.AddDate;
							cell5.Value = product.ExpirationDate;

							row.Cells.Add(cell1);
							row.Cells.Add(cell2);
							row.Cells.Add(cell3);
							row.Cells.Add(cell4);
							row.Cells.Add(cell5);

							dataGridView1.Rows.Add(row);
						}
					}
				}
				}

			}
		}

        private void ProductReportForm_Load(object sender, EventArgs e)
        {
			comboBox1.Items.Clear();
			var allStores = from s in context.Store
							where s != null
							select s;
			foreach ( var store in allStores )
			{
				comboBox1.Items.Add( store.Name );
			}
        }

    }
}
