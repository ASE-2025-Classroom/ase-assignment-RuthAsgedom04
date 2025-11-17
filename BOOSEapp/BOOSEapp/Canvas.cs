using System;
using System.Drawing;

namespace BOOSEapp
{
    
    /// A simple canvas 
    /// basic drawing functions used by the BOOSE commands.
   
    internal class Canvas
    {
        
        /// The graphics surface where everything is drawn.
        
        private Graphics graphics;

       
        /// The pen used for drawing shapes and lines.
    
        private Pen pen = new Pen(Color.Black);

        
        /// Creates a new canvas using the supplied Graphics object.
       
        public Canvas(Graphics g)
        {
            graphics = g;
        }

        
        /// Sets the current pen colour for drawing.
       
        public void SetPenColour(Color c)
        {
            pen.Color = c;
        }

        
        /// Draws a straight line between two points.
       
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        
        /// Draws a rectangle outline from the given position.
       
        public void DrawRectangle(int x, int y, int width, int height)
        {
            graphics.DrawRectangle(pen, x, y, width, height);
        }

        
        /// Draws a circle at the given centre point and radius.
       
        public void DrawCircle(int x, int y, int radius)
        {
            graphics.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
        }
    }
}
