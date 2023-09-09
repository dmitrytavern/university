using PizzaApp.Enums;
using PizzaApp.Products;

namespace PizzaApp
{
    public partial class App : Form
    {
        private Pizza? currentPizza;

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            comboBoxPizza.Items.Add(ProductsEnum.ClamPizza);
            comboBoxPizza.Items.Add(ProductsEnum.VeggiePizza);
            comboBoxPizza.Items.Add(ProductsEnum.PepperoniPizza);
            comboBoxPizza.Items.Add(ProductsEnum.CheesePizza);
            buttonPrepare.Enabled = false;
            buttonBake.Enabled = false;
            buttonCut.Enabled = false;
            buttonBox.Enabled = false;
        }

        private void comboBoxPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPizza = PizzaStore.OrderPizza((int)comboBoxPizza.SelectedItem);
            buttonPrepare.Enabled = true;
            buttonBake.Enabled = true;
            buttonCut.Enabled = true;
            buttonBox.Enabled = true;
        }

        private void buttonPrepare_Click(object sender, EventArgs e)
        {
            if (currentPizza == null)
            {
                throw new Exception("Pizza not selected.");
            }

            ApplyList("Prepare", currentPizza.Prepare());
        }

        private void buttonBake_Click(object sender, EventArgs e)
        {
            if (currentPizza == null)
            {
                throw new Exception("Pizza not selected.");
            }

            ApplyList("Bake", currentPizza.Bake());
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            if (currentPizza == null)
            {
                throw new Exception("Pizza not selected.");
            }

            ApplyList("Cut", currentPizza.Cut());
        }

        private void buttonBox_Click(object sender, EventArgs e)
        {
            if (currentPizza == null)
            {
                throw new Exception("Pizza not selected.");
            }

            ApplyList("Box", currentPizza.Box());
        }

        private void ApplyList(string actionName, List<string> actionLogs)
        {
            listBox1.Items.Clear();

            listBox1.Items.Add("Aciton: " + actionName);

            foreach (string actionLog in actionLogs)
            {
                listBox1.Items.Add(actionLog);
            }
        }
    }
}
