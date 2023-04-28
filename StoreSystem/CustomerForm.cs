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
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class CustomerForm : Form
    {
        Context context = new Context();
        public CustomerForm()
        {
            InitializeComponent();
            custId.Enabled = false;

        }

        private void show_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillData();

        }

        private void Add_Click(object sender, EventArgs e)
        {
            string name = CustName.Text;
            string phone = CustPhone.Text;
            string email = Email.Text;
            string fax = Fax.Text;
            string mobile = Custobile.Text;
            string website = Website.Text;
            Customer newCustomer = new Customer()
            {
                Name = name,
                Email = email,
                Phone = phone,
                Mobile = mobile,
                Website = website,
                Fax = fax
            };
            context.Customer.Add(newCustomer);
            MessageBox.Show("added successfuly");
            context.SaveChanges();
            FillData();
            CustName.Text = custId.Text  = Custobile.Text =CustPhone.Text=Fax.Text= Website.Text=Email.Text= string.Empty;

        }


        private void FillData()
        {
            var customers = from s in context.Customer
                           where s != null
                           select s;
            foreach (var customer in customers)
            {
                listBox1.Items.Add(customer.Name);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems != null)
            {
                string customerName = listBox1.SelectedItems[0].ToString();
                Customer selectedCustomer = context.Customer.FirstOrDefault(x => x.Name == customerName);
                if(selectedCustomer != null)
                {
                    custId.Text =(selectedCustomer.Id).ToString();
                    CustName.Text = selectedCustomer.Name;
                    Email.Text = selectedCustomer.Email;
                    Custobile.Text = selectedCustomer.Mobile;
                    CustPhone.Text = selectedCustomer.Phone;
                    Fax.Text = selectedCustomer.Fax;
                    Website.Text = selectedCustomer.Website;
                    custId.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("no data found");
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(custId.Text);
            string name = CustName.Text;
            string phone = CustPhone.Text;
            string email = Email.Text;
            string fax = Fax.Text;
            string mobile = Custobile.Text;
            string website = Website.Text;

            Customer selectedCustomer = context.Customer.FirstOrDefault(s => s.Id == id);
            if (selectedCustomer != null)
            {
                selectedCustomer.Name = name; 
                selectedCustomer.Phone = phone;
                selectedCustomer.Email = email;
                selectedCustomer.Fax = fax;
                selectedCustomer.Website = website;
                selectedCustomer.Mobile= mobile;

            }
            else
            {
                MessageBox.Show("not valid data ");
            }

            context.Customer.AddOrUpdate(selectedCustomer);
            MessageBox.Show("Updated successfully");
            context.SaveChanges();
            listBox1.Items.Clear();
            FillData();
            CustName.Text = custId.Text = Custobile.Text = CustPhone.Text = Fax.Text = Website.Text = Email.Text = string.Empty;
        }

      
    }
}
