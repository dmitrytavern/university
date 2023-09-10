using App.Enums;
using App.Factories;
using App.Interfaces;

namespace App
{
    public partial class App : Form
    {
        private IAbstractFactory _factory = new ForestFactory();
        private readonly List<IAbstractTerrain> _terrains = new();
        private readonly List<IAbstractVegetation> _vegetations = new();

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            comboBoxEnv.Items.Clear();
            comboBoxEnv.Items.Add(EnvironmentsEnum.Forest);
            comboBoxEnv.Items.Add(EnvironmentsEnum.Desert);
            comboBoxEnv.SelectedIndex = 0;
        }

        private void comboBoxEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEnv.SelectedItem)
            {
                case EnvironmentsEnum.Forest:
                    _factory = new ForestFactory();
                    break;
                case EnvironmentsEnum.Desert:
                    _factory = new DesertFactory();
                    break;
                default:
                    throw new Exception("Environment is invalid.");
            }
        }

        private void buttonAddTerrain_Click(object sender, EventArgs e)
        {
            IAbstractTerrain terrain = _factory.CreateTerrain();

            _terrains.Add(terrain);

            listBox1.Items.Add("Added " + terrain.GetName() + " with timestamp " + terrain.GetId());
        }

        private void buttonAddVegetation_Click(object sender, EventArgs e)
        {
            IAbstractVegetation vegetation = _factory.CreateVegetation();

            _vegetations.Add(vegetation);

            listBox1.Items.Add("Added " + vegetation.GetName() + " with timestamp " + vegetation.GetId());
        }
    }
}