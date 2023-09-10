using App.Adapters;
using App.Interfaces;

namespace App
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        public void CreateLog(string log)
        {
            listBox1.Items.Add(log);
        }

        private void buttonAddByDefault_Click(object sender, EventArgs e)
        {
            Figures.Rectangle rectangle = new(this);

            rectangle.Display(
                (int)numericDefaultW.Value,
                (int)numericDefaultH.Value,
                (int)numericDefaultX.Value,
                (int)numericDefaultY.Value
            );
        }

        private void buttonAddByPosition_Click(object sender, EventArgs e)
        {
            Figures.Rectangle rectangle = new(this);

            IRectangleAdapter adapter = new RectangleAdapter(rectangle);

            adapter.Display(
                (int)numericPositionX1.Value,
                (int)numericPositionY1.Value,
                (int)numericPositionX2.Value,
                (int)numericPositionY2.Value
            );
        }
    }
}