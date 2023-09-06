using Lab2.CafeItems;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private readonly CafeItemFactory cafeItemFactory;
        private readonly List<CafeItem> orderItems;

        public Form1()
        {
            InitializeComponent();
            cafeItemFactory = new CafeItemFactory();
            orderItems = new List<CafeItem>();
            comboBoxCafeItems.Items.Add("Ice cream");
            comboBoxCafeItems.Items.Add("Pancake");
            comboBoxCafeItems.Items.Add("Pastry");
            comboBoxCafeItems.SelectedIndex = 0;
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            int menuItemNumber = comboBoxCafeItems.SelectedIndex + 1;
            int quantity = (int)numericCafeItemQuantity.Value;

            CafeItem cafeItem = cafeItemFactory.CreateCafeItem(menuItemNumber, quantity);

            orderItems.Add(cafeItem);

            listBoxOrder.Items.Add($"{cafeItem.Name} x{quantity} - ${cafeItem.CalculatePrice()}");
        }

        private void buttonCalculateTotal_Click(object sender, EventArgs e)
        {
            double totalCost = 0;

            foreach (var item in orderItems)
            {
                totalCost += item.CalculatePrice();
            }

            labelTotalPrice.Text = $"Your price: ${totalCost}";
        }
    }
}