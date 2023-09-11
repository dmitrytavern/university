using App.Bank;
using App.Bank.Entities;
using App.Bank.Factories;

namespace App
{
    public partial class Form1 : Form
    {
        private readonly MortgageFacade mortgage = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetResult_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text.Length == 0)
            {
                throw new Exception("Enter your first name");
            }

            if (textBoxLastName.Text.Length == 0)
            {
                throw new Exception("Enter your last name");
            }

            Customer customer = CustomerFactory.CreateCustomer(
                textBoxFirstName.Text, 
                textBoxLastName.Text, 
                numericEarnings.Value
            );

            Credit credit = CreditFactory.CreateCredit(
                (int)numericCredit.Value,
                numericPrice.Value
            );

            if (mortgage.TakeCredit(customer, credit))
            {
                labelResult.Text = "Result: You can take a credit";
            }
            else
            {
                labelResult.Text = "Result: You cannot take a credit";
            }
        }
    }
}