namespace StoreSystem
{
    using StoreEntities;
    using System;
    using System.Data;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    public partial class ProductForm : Form
    {
        Context context = new Context();

        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillData();

        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            AddDate.Enabled = false;
            string name = Name.Text;
            string code = Code.Text;
            string MegurementUnit = UnitOfMeasurement.Text;
            string storename = comboBox1.SelectedItem.ToString();
            
            // string selectedOption = Stores.SelectedItem.ToString();
            Store selectedStore = context.Store.FirstOrDefault(x => x.Name == storename);
            if(selectedStore == null) { MessageBox.Show("no extst Store"); }
            Product newProduct = new Product()
            {
                Name = name,
                Code = code,
                UnitOfMeasurement = MegurementUnit,
                Store = selectedStore,
                AddDate = DateTime.Now,
                ExpirationDate = ExpirationDate.Value
            };
            context.Product.Add(newProduct);
            MessageBox.Show("added succeully");
            context.SaveChanges();
            listBox1.Items.Clear();
            FillData();
            Name.Text = Code.Text  = UnitOfMeasurement.Text = string.Empty;
            comboBox1.SelectedItem = null;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IDTB.Text);
            IDTB.Enabled = false;
            string name = Name.Text;
            string Measurement = UnitOfMeasurement.Text;
            string code = Code.Text;
            string storename = comboBox1.SelectedItem.ToString();


            Product selectedProduct = context.Product.FirstOrDefault(x => x.Id == id);
            Store SelectedStore = context.Store.FirstOrDefault(x =>x.Name == storename);
            if (selectedProduct != null && SelectedStore != null)
            {
                selectedProduct.Name = name;
                selectedProduct.Code = code;
                selectedProduct.UnitOfMeasurement = Measurement;
                selectedProduct.Store = SelectedStore;
                selectedProduct.AddDate = AddDate.Value;
                selectedProduct.ExpirationDate = ExpirationDate.Value;
            }

            context.Product.AddOrUpdate(selectedProduct);
            MessageBox.Show("Updated succeully");
            context.SaveChanges();
            listBox1.Items.Clear();
            FillData();
            Name.Text = Code.Text = UnitOfMeasurement.Text  = string.Empty;
            comboBox1.SelectedItem = null;

        }

        private void FillData()
        {
            var products = from s in context.Product
                         where s != null
                         select s;
            foreach (var item in products)
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectdProductName = listBox1.SelectedItem.ToString();
                var selectedProduct = context.Product.FirstOrDefault(s => s.Name == selectdProductName);
                if (selectedProduct != null)
                {
                    IDTB.Text = selectedProduct.Id.ToString();
                    Name.Text = selectedProduct.Name;
                    Code.Text = selectedProduct.Code;
                    UnitOfMeasurement.Text= selectedProduct.UnitOfMeasurement.ToString();
                    comboBox1.SelectedItem = selectedProduct.Store.Name;
                    ExpirationDate.Value = selectedProduct.ExpirationDate;
                    AddDate.Value = selectedProduct.AddDate;
                    IDTB.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("no data found");
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var allStores= from emp in context.Store
                              where emp != null
                              select emp;
            foreach (var store in allStores)
            {
                comboBox1.Items.Add(store.Name);
            }
        }
    }
}
