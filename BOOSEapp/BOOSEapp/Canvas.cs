using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BOOSEapp
{
    internal class Canvas
    {
        private Graphics graphics;
        public Canvas(Graphics g)
        {
            graphics = g;
        }
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
        }
        public void DrawRectangle(int x, int y, int width, int height)
        {
            graphics.DrawRectangle(Pens.Black, x, y, width, height);
        }

        public void DrawCircle(int x, int y, int radius)
        {
            graphics.DrawEllipse(Pens.Black, x - radius, y - radius, radius * 2, radius * 2);
        }
    }
}
