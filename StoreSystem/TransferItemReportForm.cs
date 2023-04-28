using StoreSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace StoreSystem

{
    public partial class TransferItemReportForm : Form
	{
		Context context = new Context();
		public TransferItemReportForm()
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
				List<TransferItem> transferedItems = context.TransferItems.Include(x=>x.Product).Where(p => p.Product.Name == productName).ToList();
				var from = dateTimePicker1.Value;
				var to = dateTimePicker2.Value;
				if (transferedItems != null)
				{
					foreach (var product in transferedItems)
					{
						var transfered = context.Transfers.Include(x=>x.FromStore).Include(x=>x.ToStore).FirstOrDefault(s => s.Id == product.TransferId && s.TransferDate >= from && s.TransferDate <= to);
					
						if (transfered != null )
						{
							DataGridViewRow row = new DataGridViewRow();
							DataGridViewCell cell1 = new DataGridViewTextBoxCell();
							DataGridViewCell cell2 = new DataGridViewTextBoxCell();
							DataGridViewCell cell3 = new DataGridViewTextBoxCell();
							DataGridViewCell cell4 = new DataGridViewTextBoxCell();
							DataGridViewCell cell5 = new DataGridViewTextBoxCell();
							cell1.Value =productName;
							cell2.Value =transfered.TransferDate;
							cell3.Value = transfered.FromStore.Name;
							cell4.Value = transfered.ToStore.Name;
							cell5.Value = product.Quantity;

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
}
