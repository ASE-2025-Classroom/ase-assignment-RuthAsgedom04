using System;
using System.Drawing;

namespace BOOSEapp
{
    /// <summary>
    /// Concrete implementation of ICanvas using System.Drawing.
    /// Holds pen position and provides primitive drawing operations.
    /// </summary>
    public class Canvas : ICanvas
    {
        private readonly Graphics graphics;
        private readonly Pen pen;

        private int currentX;
        private int currentY;

        public int CurrentX => currentX;
        public int CurrentY => currentY;

        public int Width { get; }
        public int Height { get; }

        public Canvas(Graphics g, int width, int height)
        {
            graphics = g ?? throw new ArgumentNullException(nameof(g));
            Width = width;
            Height = height;

            pen = new Pen(Color.Black);
            currentX = 0;
            currentY = 0;
        }

        public void SetPenColour(Color colour)
        {
            pen.Color = colour;
        }

        public void MoveTo(int x, int y)
        {
            currentX = x;
            currentY = y;
        }

        public void DrawTo(int x, int y)
        {
            graphics.DrawLine(pen, currentX, currentY, x, y);
            currentX = x;
            currentY = y;
        }

        public void DrawRectangle(int width, int height)
        {
            graphics.DrawRectangle(pen, currentX, currentY, width, height);
        }

        public void DrawCircle(int radius)
        {
            int diameter = radius * 2;
            graphics.DrawEllipse(pen, currentX - radius, currentY - radius, diameter, diameter);
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
        }
    }
}
