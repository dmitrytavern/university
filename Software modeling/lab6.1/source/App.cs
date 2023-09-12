using App.Collections;
using App.Enums;
using App.Factories;
using App.Interfaces;

namespace App
{
    public partial class App : Form
    {
        private readonly SoldiersCollection collection = new();

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            comboBoxIterator.Items.Clear();
            comboBoxIterator.Items.Add(IteratorsEnum.ByDefault);
            comboBoxIterator.Items.Add(IteratorsEnum.ByRank);
            comboBoxIterator.Items.Add(IteratorsEnum.ByRang);
            comboBoxIterator.Items.Add(IteratorsEnum.ByGroup);
            comboBoxIterator.SelectedIndex = 0;

            comboBoxSoldierType.Items.Clear();
            comboBoxSoldierType.Items.Add(SoldiersEnum.Infantryman);
            comboBoxSoldierType.Items.Add(SoldiersEnum.Paratrooper);
            comboBoxSoldierType.Items.Add(SoldiersEnum.Artilleryman);
            comboBoxSoldierType.SelectedIndex = 0;

            comboBoxSoldierRang.Items.Clear();
            comboBoxSoldierRang.Items.Add(RangsEnum.Private);
            comboBoxSoldierRang.Items.Add(RangsEnum.Sergeant);
            comboBoxSoldierRang.Items.Add(RangsEnum.Corporal);
            comboBoxSoldierRang.SelectedIndex = 0;

            comboBoxSoldierRank.Items.Clear();
            comboBoxSoldierRank.Items.Add(RanksEnum.FirstClass);
            comboBoxSoldierRank.Items.Add(RanksEnum.SecondClass);
            comboBoxSoldierRank.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSoldierName.Text))
            {
                throw new Exception("Enter solider name");
            }

            ISoldier soldier = SoldierFactory.CreateSoldier(
                textBoxSoldierName.Text,
                (SoldiersEnum)comboBoxSoldierType.SelectedItem,
                (RangsEnum)comboBoxSoldierRang.SelectedItem,
                (RanksEnum)comboBoxSoldierRank.SelectedItem
            );

            collection.AddItem(soldier);

            RenderList();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            RenderList();
        }

        private void buttonRemoveSoldier_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                foreach (ISoldier item in listBox1.SelectedItems)
                {
                    collection.RemoveItem(item);
                }

                RenderList();
            }
        }

        private void comboBoxIterator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyIterator();
        }

        private void RenderList()
        {
            collection.SetIterator(IteratorsEnum.ByDefault);

            listBox1.Items.Clear();

            foreach (ISoldier soldier in collection)
            {
                listBox1.Items.Add(soldier);
            }

            ApplyIterator();

            listBox2.Items.Clear();

            foreach (ISoldier soldier in collection)
            {
                listBox2.Items.Add(soldier);
            }
        }

        private void ApplyIterator()
        {
            collection.SetIterator((IteratorsEnum)comboBoxIterator.SelectedItem);
        }
    }
}