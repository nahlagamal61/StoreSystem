namespace StoreSystem
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Data.Entity;

    public partial class ProductDateForm : Form
    {
        Context context = new Context();
        public ProductDateForm()
        {
            InitializeComponent();
        }

        private void ProductExpireDateForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var AllStores = from s in context.Store
                            where s != null
                            select s;
            foreach (var s in AllStores)
            {
                if (s != null)
                {
                    listBox1.Items.Add(s.Name);
                }
            }

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fromDate = FromDate.Value;
            var toDate = ToDate.Value;

            if(listBox1.SelectedItem.ToString() != null && fromDate != toDate)
            {
                string storeName = listBox1.SelectedItem.ToString();

                var items = context.Product.Include(w => w.Store)
                                           .Where(s => s.Store.Name == storeName && s.AddDate >= fromDate && s.AddDate <= toDate )
                                           .ToList();
                if (items.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var item in items)
                    {

                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                        DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                        DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                        DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                        DataGridViewCell cell5 = new DataGridViewTextBoxCell();

                        cell1.Value = item.Name;
                        cell2.Value = item.Code;
                        cell3.Value = item.Store.Name;
                        cell4.Value = item.AddDate;
                        cell5.Value = item.ExpirationDate;

                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                        row.Cells.Add(cell4);
                        row.Cells.Add(cell5);

                        dataGridView1.Rows.Add(row);

                    }

                }
                else
                    MessageBox.Show("not found data ");
                
            }
            else
            {
                    MessageBox.Show("please select the date ");
            }
        }

       
    }
}
