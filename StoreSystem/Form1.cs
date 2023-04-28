namespace StoreSystem
{
    using Project2;
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        Context context = new Context(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
           StoreForm stores = new StoreForm();
           stores.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplierForm supplier = new SupplierForm();
            supplier.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransferForm transferForm = new TransferForm();
            transferForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StoreReport storeReport = new StoreReport();
            storeReport.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExchangePermitForm exchangePermitForm = new ExchangePermitForm();
            exchangePermitForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ImportPermitForm import = new ImportPermitForm();
            import.Show();
        }

        private void ProductReport_Click(object sender, EventArgs e)
        {
            ProductReportForm productReport = new ProductReportForm();
            productReport.Show();
        }

        private void Report11_Click(object sender, EventArgs e)
        {
            ProductDateForm product   = new ProductDateForm();
            product.Show();
        }


        private void TransferReport_Click(object sender, EventArgs e)
        {
            TransferItemReportForm transfer = new TransferItemReportForm();
            transfer.Show();
        }
    }
}
