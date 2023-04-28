namespace StoreSystem
{
    using StoreEntities;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Forms;

    public partial class StoreForm : Form
    {
        Context context = new Context();
        public StoreForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillData();

        }

        private void FillData()
        {
            var stores = from s in context.Store
                         where s != null
                         select s;
            foreach (var store in stores)
            {
                listBox1.Items.Add(store.Name);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            IDTB.Enabled = false;
            string name = Name.Text;
            string address = Address.Text;
            string managerName = comboBox1.SelectedItem.ToString();

            Employee SelectedEmp = context.Employee.FirstOrDefault(x => x.Name == managerName);
            Store newStore = new Store()
            {
                Name = name,
                Address = address,
                ResponsablePerson = SelectedEmp
            };
            context.Store.Add(newStore);
            MessageBox.Show("added succeully");
            context.SaveChanges();
            FillData();
            Name.Text = Address.Text  = string.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IDTB.Text);
            string name = Name.Text;
            string address = Address.Text;
            string managername = comboBox1.SelectedItem.ToString() ;

            Store selectedStore = context.Store.FirstOrDefault(s => s.Id == id);
            Employee SelectedEmp = context.Employee.FirstOrDefault(x => x.Name == managername);
            if(selectedStore != null &&  SelectedEmp != null)
            {
                selectedStore.Name = name;
                selectedStore.Address = address;
                selectedStore.ResponsablePerson= SelectedEmp;
            }

            context.Store.AddOrUpdate(selectedStore);
            MessageBox.Show("Updated succeully");
            context.SaveChanges();
            listBox1.Items.Clear();
            FillData();
            IDTB.Text= Name.Text = Address.Text  = string.Empty;
            comboBox1.SelectedItem = null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectdStore = listBox1.SelectedItem.ToString();
                var selectedStore = context.Store.Include( w => w.ResponsablePerson).FirstOrDefault(s => s.Name == selectdStore);
                if (selectedStore != null)
                {
                    IDTB.Text = selectedStore.Id.ToString();
                    Name.Text = selectedStore.Name;
                    Address.Text = selectedStore.Address;
                    comboBox1.SelectedItem =selectedStore.ResponsablePerson.Name;
                    IDTB.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("no data found");
            }
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
             var allemployee = from emp in context.Employee
                               where emp!= null
                               select emp;
            foreach ( var emp in allemployee )
            {
                comboBox1.Items.Add(emp.Name);
            }
        }


    }
}
