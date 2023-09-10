namespace App.Figures
{
    class Rectangle
    {
        private readonly App app;

        public Rectangle(App _app)
        {
            app = _app;
        }

        public void Display(int width, int height, int x, int y)
        {
            app.CreateLog($"Rectangle: width {width}, height {height}, position ({x}, {y})");
        }
    }
}
