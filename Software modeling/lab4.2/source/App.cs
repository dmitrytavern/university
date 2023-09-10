using App.Enums;
using App.Adapters;
using App.Interfaces;
using App.Fighters;

namespace App
{
    public partial class App : Form
    {
        private IFighter fighter;

        public App()
        {
            InitializeComponent();
            comboBoxFighter.Items.Add(FightersEnum.Wizard);
            comboBoxFighter.Items.Add(FightersEnum.Dragon);
            comboBoxFighter.SelectedIndex = 0;

            fighter = new WizardAdapter(new Wizard(this));
        }

        public void CreateLog(string log)
        {
            listBox1.Items.Add(log);
        }

        private void comboBoxFighter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFighter.SelectedItem)
            {
                case FightersEnum.Wizard:
                    fighter = new WizardAdapter(new Wizard(this));
                    break;
                case FightersEnum.Dragon:
                    fighter = new DragonAdapter(new Dragon(this));
                    break;
                default:
                    throw new Exception("Fighter is invalid.");
            }
        }

        private void buttonAttack_Click(object sender, EventArgs e)
        {
            fighter.Attack();
        }

        private void buttonDefend_Click(object sender, EventArgs e)
        {
            fighter.Defend();
        }

        private void buttonEscape_Click(object sender, EventArgs e)
        {
            fighter.Escape();
        }
    }
}