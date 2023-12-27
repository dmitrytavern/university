using App.Enums;
using App.Entities;
using App.Interfaces;
using App.Strategies;

namespace App
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();

            comboBox1.Items.Add(DeliveryEnum.Standart);
            comboBox1.Items.Add(DeliveryEnum.Express);
            comboBox1.Items.Add(DeliveryEnum.Selfdelivery);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }

            IOrder order = new Order(textBox1.Text, 100);

            Context context = new();

            if ((DeliveryEnum)comboBox1.SelectedItem == DeliveryEnum.Standart)
            {
                context.SetStrategy(new StandartStrategy());
            }

            if ((DeliveryEnum)comboBox1.SelectedItem == DeliveryEnum.Express)
            {
                context.SetStrategy(new ExpressStrategy());
            }

            if ((DeliveryEnum)comboBox1.SelectedItem == DeliveryEnum.Selfdelivery)
            {
                context.SetStrategy(new SelfdeliveryStrategy());
            }

            context.CalculatePrice(order);

            label3.Text = "Your order '" + order.Name + "' cost: " + order.GetTotal();
        }
    }
}