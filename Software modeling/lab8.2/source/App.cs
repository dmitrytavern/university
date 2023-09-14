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
        }

        private void buttonStartBattle_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxFighterName.Text))
            {
                return;
            }

            IFighter fighter = new Fighter(textBoxFighterName.Text);

            Context context = new();

            context.SetStrategy(new KenStrategy());

            if (checkBoxJump.Checked)
            {
                context.SetStrategy(new RyuStrategy());
            }

            if (checkBoxRoll.Checked)
            {
                context.SetStrategy(new AlexStrategy());
            }

            if (checkBoxJump.Checked &&
                checkBoxRoll.Checked)
            {
                context.SetStrategy(new ChunLIStrategy());
            }

            context.ExecuteTactic(fighter);

            RenderList(fighter);
        }

        private void RenderList(IFighter fighter)
        {
            List<string> history = fighter.GetHistory();

            listBox1.Items.Clear();

            foreach (string historyItem in history)
            {
                listBox1.Items.Add(historyItem);
            }
        }
    }
}