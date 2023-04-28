namespace StoreSystem
{
    using StoreEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class SupplierForm : Form
    {
        Context context = new Context();
        public SupplierForm()
        {
            InitializeComponent();
            Id.Enabled = false;

        }

        private void show_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillData();
        }




        private void FillData()
        {
            var supplieres = from s in context.Supplier
                            where s != null
                            select s;
            foreach (var supplier in supplieres)
            {
                listBox1.Items.Add(supplier.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                string SupplierName = listBox1.SelectedItems[0].ToString();
                Supplier selectedCustomer = context.Supplier.FirstOrDefault(x => x.Name == SupplierName);
                if (selectedCustomer != null)
                {
                    Id.Text = (selectedCustomer.Id).ToString();
                    Name.Text = selectedCustomer.Name;
                    Email.Text = selectedCustomer.Email;
                    Mobile.Text = selectedCustomer.Mobile;
                    Phone.Text = selectedCustomer.Phone;
                    Fax.Text = selectedCustomer.Fax;
                    Website.Text = selectedCustomer.Website;
                    Id.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("no data found");
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string phone = Phone.Text;
            string email = Email.Text;
            string fax = Fax.Text;
            string mobile = Mobile.Text;
            string website = Website.Text;
            Supplier newSupplier= new Supplier()
            {
                Name = name,
                Email = email,
                Phone = phone,
                Mobile = mobile,
                Website = website,
                Fax = fax
            };
            context.Supplier.Add(newSupplier);
            MessageBox.Show("added successfuly");
            context.SaveChanges();
            FillData();
            Name.Text = Id.Text = Mobile.Text = Phone.Text = Fax.Text = Website.Text = Email.Text = string.Empty;


        }

        private void Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Id.Text);
            string name = Name.Text;
            string phone = Phone.Text;
            string email = Email.Text;
            string fax = Fax.Text;
            string mobile = Mobile.Text;
            string website = Website.Text;

            Supplier selectedSupplier = context.Supplier.FirstOrDefault(s => s.Id == id);
            if (selectedSupplier != null)
            {
                selectedSupplier.Name = name;
                selectedSupplier.Phone = phone;
                selectedSupplier.Email = email;
                selectedSupplier.Fax = fax;
                selectedSupplier.Website = website;
                selectedSupplier.Mobile = mobile;

            }
            else
            {
                MessageBox.Show("not valid data ");
            }

            context.Supplier.AddOrUpdate(selectedSupplier) ;
            MessageBox.Show("Updated successfully");
            context.SaveChanges();
            listBox1.Items.Clear();
            FillData();
            Name.Text = Id.Text = Mobile.Text = Phone.Text = Fax.Text = Website.Text = Email.Text = string.Empty;

        }
    }
}
