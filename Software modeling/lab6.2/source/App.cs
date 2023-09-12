using App.Collections;
using App.Enums;
using App.Factories;
using App.Interfaces;

namespace App
{
    public partial class App : Form
    {
        private readonly EmployeeCollection collection = new();

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            comboBoxIterator.Items.Clear();
            comboBoxIterator.Items.Add(IteratorsEnum.ByDefault);
            comboBoxIterator.Items.Add(IteratorsEnum.BySalaryOrder);
            comboBoxIterator.Items.Add(IteratorsEnum.ByMinimalSalary);
            comboBoxIterator.SelectedIndex = 0;

            comboBoxEmployeeType.Items.Clear();
            comboBoxEmployeeType.Items.Add(EmployeeEnum.Worker);
            comboBoxEmployeeType.Items.Add(EmployeeEnum.Manager);
            comboBoxEmployeeType.Items.Add(EmployeeEnum.Director);
            comboBoxEmployeeType.SelectedIndex = 0;
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEmployeeName.Text))
            {
                throw new Exception("Enter employee name");
            }

            IEmployee employee = EmployeeFactory.CreateEmployee(
                textBoxEmployeeName.Text,
                (EmployeeEnum)comboBoxEmployeeType.SelectedItem
            );

            collection.AddItem(employee);

            RenderList();
        }

        private void buttonRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                foreach (IEmployee item in listBox1.SelectedItems)
                {
                    collection.RemoveItem(item);
                }

                RenderList();
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            RenderList();
        }

        private void comboBoxIterator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyIterator();

        }

        private void RenderList()
        {
            collection.SetIterator(IteratorsEnum.ByDefault);

            listBox1.Items.Clear();

            foreach (IEmployee employee in collection)
            {
                listBox1.Items.Add(employee);
            }

            ApplyIterator();

            listBox2.Items.Clear();

            foreach (IEmployee employee in collection)
            {
                listBox2.Items.Add(employee);
            }
        }

        private void ApplyIterator()
        {
            collection.SetIterator((IteratorsEnum)comboBoxIterator.SelectedItem);
        }
    }
}