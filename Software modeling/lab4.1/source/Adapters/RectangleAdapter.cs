using App.Interfaces;

namespace App.Adapters
{
    class RectangleAdapter : IRectangleAdapter
    {
        private readonly Figures.Rectangle rectangle;

        public RectangleAdapter(Figures.Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public void Display(int x1, int y1, int x2, int y2)
        {
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);
            int x = x1;
            int y = y1;

            rectangle.Display(width, height, x, y);
        }
    }
}
