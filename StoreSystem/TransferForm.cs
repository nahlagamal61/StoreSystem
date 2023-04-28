﻿namespace StoreSystem
{
    using StoreEntities;
    using StoreSystem.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    public partial class TransferForm : Form
    {
        Context context= new Context();
        public TransferForm()
        {
            InitializeComponent();
        }
        
        private void FillData()
        {
            var products = from s in context.Product
                           where s != null
                         select s;
            foreach (var store in products)
            {
                listBox1.Items.Add(store.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillData();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItems != null)
            {

                string productName = listBox1.SelectedItem.ToString();
                var product = context.Product.FirstOrDefault(p => p.Name == productName);
                if (product != null)
                {
                    var fromstore = context.Store.FirstOrDefault(s => s.Id == product.StoreId);
                    if (fromstore != null)
                        textBox1.Text = fromstore.Name; 
                }
                
            }
        }

        

        private void TransferForm_Load(object sender, EventArgs e)
        {
            var allStore = from s in context.Store
                           where s != null
                           select s;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (var store in allStore)
            {
                comboBox1.Items.Add(store.Name);
            }

            var allSuppliers = from s in context.Supplier
                               where s != null
                               select s;
            foreach (var supplier in allSuppliers)
            {
                comboBox2.Items.Add(supplier.Name);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            var fromStore = context.Store.FirstOrDefault(s=> s.Name == textBox1.Text);
            var to =context.Store.FirstOrDefault(s => s.Name == comboBox1.SelectedItem.ToString());
            int quanity = int.Parse(textBox3.Text);
            var productionDate = dateTimePicker1.Value;
            var expirationDate = dateTimePicker2.Value;
            var transferDate = dateTimePicker3.Value;
            var product = context.Product.FirstOrDefault(p => p.Name == listBox1.SelectedItem.ToString());
            
            ICollection<TransferItem> items = new List<TransferItem>();
           
            TransferItem transferItem = new TransferItem()
            {
                Quantity = quanity,
                ProductionDate = productionDate,
                ExpirationDate = expirationDate,
                ProductId = product.Id
            };
            items.Add(transferItem);
            Transfer transfer = new Transfer()
            {
                FromStoreId = fromStore.Id,
                ToStoreId = to.Id,
                TransferDate = transferDate,
                Items = items
            };

            context.TransferItems.Add(transferItem);
            MessageBox.Show("Added Successfuly ");
            context.Transfers.Add(transfer);
            context.SaveChanges();
            textBox1.Text = textBox3.Text = string.Empty;


        }


    }
}
