using StoreSystem.Entities;
using StoreEntities;
using StoreSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Project2
{
    public partial class ExchangePermitForm : Form
	{
		Context context = new Context();
		public ExchangePermitForm()
		{
			InitializeComponent();
		
			textBox2.Enabled = false;
		}
        private void ExchangePermitForm_Load(object sender, EventArgs e)
        {
            var allStores = from store in context.Store
                            where store != null
                            select store;
            foreach (var store in allStores)
            {
                if (store != null)
                {
                    comboBox1.Items.Add(store.Name);
                }
            }
            var allSupplier = from supplier in context.Supplier
                              where supplier != null
                              select supplier;
            foreach (var supplier in allSupplier)
            {
                if (supplier != null)
                {
                    comboBox2.Items.Add(supplier.Name);
                }
            }
            var allProducts = from product in context.Product
                              where product != null
                              select product;
            foreach (var product in allProducts)
            {
                if (product != null)
                {
                    dataGridView1.Rows.Add(product.Name);
                }
            }
        }

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			RemoveGridViewCell();

			var selectedImportPermit = listBox1.SelectedItem?.ToString();
			var exchangePermit = context.ExchangePermit
				.Include(w => w.Items)
				.Include(w => w.Store)
				.Include(x => x.Supplier)
				.FirstOrDefault(x => x.PermitNumber == selectedImportPermit);

			if (exchangePermit != null)
			{
				comboBox1.SelectedItem = exchangePermit.Store.Name;
				textBox1.Text = exchangePermit.PermitNumber;
				dateTimePicker1.Value = exchangePermit.PermitDate;
				comboBox2.SelectedItem = exchangePermit.Supplier.Name;
				textBox2.Text = exchangePermit.Id.ToString();

				foreach (var item in exchangePermit.Items)
				{
					foreach (DataGridViewRow row in dataGridView1.Rows)
					{
						if (row.Cells[0].Value != null && row.Cells[0].Value == item.Product.Name)
						{
							row.Cells[1].Value = item.Quantity;
						}
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FillExchangePermit();
		}

		private void FillExchangePermit()
		{
			listBox1.Items.Clear();
			var allPermits = from permit in context.ExchangePermit
							 where permit != null
							 select permit;
			foreach (var permit in allPermits)
			{
				if (permit != null)
				{
					listBox1.Items.Add(permit.PermitNumber);
				}

			}
		}
		private void RemoveGridViewCell()
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[1].Value != null)
				{
					row.Cells[1].Value = null;
				}
			}
		}
		private void button3_Click(object sender, EventArgs e)
		{
			string store = comboBox1.SelectedItem?.ToString();
			string permitNumber = textBox1.Text;
			DateTime permitDate = dateTimePicker1.Value;
			string supplier = comboBox2.SelectedItem.ToString();
			int importPermit = int.Parse(textBox2?.Text);

			ExchangePermit exchangePermitToEdit = context.ExchangePermit.FirstOrDefault(x => x.Id == importPermit);
			Supplier selectedSupplier = context.Supplier.FirstOrDefault(x => x.Name == supplier);
			Store selectedStore = context.Store.FirstOrDefault(x => x.Name == store);

			List<ExchangePermitItem> permitItems = new List<ExchangePermitItem>();
			List<Product> products = context.Product.ToList();

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[1].Value != null)
				{
					var productName = row.Cells[0].Value.ToString();
					ExchangePermitItem product = exchangePermitToEdit.Items.FirstOrDefault(x => x.Product.Name == productName);
					if (product != null)
					{
						product.Quantity = int.Parse(row.Cells[1].Value.ToString());
						permitItems.Add(product);
					}
					else
					{
						ExchangePermitItem exhangePermitItem = new ExchangePermitItem()
						{
							Product = context.Product.FirstOrDefault(x => x.Name == productName),
							ProductId = context.Product.FirstOrDefault(x => x.Name == productName).Id,
							Quantity = int.Parse(row.Cells[1].Value.ToString()),
							ExchangePermitId = exchangePermitToEdit.Id,
							ExchangePermit = exchangePermitToEdit
						};
						permitItems.Add(exhangePermitItem);
					}
				}
			}
			exchangePermitToEdit.PermitDate = permitDate;
			exchangePermitToEdit.PermitNumber = permitNumber;
			exchangePermitToEdit.Items = permitItems;
			exchangePermitToEdit.Supplier = selectedSupplier;
			exchangePermitToEdit.SupplierId = selectedSupplier.Id;
			exchangePermitToEdit.Store = selectedStore;
			exchangePermitToEdit.StoreId = selectedStore.Id;

			context.ExchangePermit.AddOrUpdate(exchangePermitToEdit);
			context.SaveChanges();

			MessageBox.Show("Updates Successfully");
			FillExchangePermit();
			textBox1.Text = string.Empty;
			comboBox1.SelectedItem = null;
			comboBox2.SelectedItem = null;
			RemoveGridViewCell();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string store = comboBox1.SelectedItem?.ToString();
			string permitNumber = textBox1.Text;
			DateTime permitDate = dateTimePicker1.Value;
			string supplier = comboBox2.SelectedItem.ToString();

			var selectedSupplier = context.Supplier.FirstOrDefault(x => x.Name == supplier);
			var selectedStore = context.Store.FirstOrDefault(x => x.Name == store);

			List<ExchangePermitItem> permitItems = new List<ExchangePermitItem>();
			List<Product> products = context.Product.ToList();

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[1].Value != null)
				{
					var productName = row.Cells[0].Value.ToString();
					var product = products.FirstOrDefault(x => x.Name == productName);
					if (product != null)
					{
						ExchangePermitItem exhangePermitItem = new ExchangePermitItem()
						{
							Product = product,
							ProductId = product.Id,
							Quantity = int.Parse(row.Cells[1].Value.ToString())
						};
						permitItems.Add(exhangePermitItem);
					}
				}
			}

			ExchangePermit exchangePermit = new ExchangePermit()
			{
				Items = permitItems,
				PermitDate = permitDate,
				PermitNumber = permitNumber,
				Store = selectedStore,
				StoreId = selectedStore.Id,
				Supplier = selectedSupplier,
				SupplierId = selectedSupplier.Id
			};
			context.ExchangePermit.Add(exchangePermit);
			context.SaveChanges();

			MessageBox.Show("Added Successfully");
			FillExchangePermit();
			textBox1.Text = string.Empty;
			comboBox1.SelectedItem = null;
			comboBox1.SelectedItem = null; 
			RemoveGridViewCell();
		
        }

    }
}
