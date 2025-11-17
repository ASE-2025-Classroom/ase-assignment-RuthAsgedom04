using System;

using System.Drawing;

namespace BOOSEapp
{
    internal class Canvas
    {
        private Graphics graphics;
        private Pen pen = new Pen(Color.Black);

        public Canvas(Graphics g)
        {
            graphics = g;
        }

        public void SetPenColour(Color c)
        {
            pen.Color = c;
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            graphics.DrawRectangle(pen, x, y, width, height);
        }

        public void DrawCircle(int x, int y, int radius)
        {
            graphics.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
        }
    }

}