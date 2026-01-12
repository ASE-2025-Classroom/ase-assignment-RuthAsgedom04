using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace BOOSEapp
{
    public class CommandContext
    {
        public ICanvas Canvas { get; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public CommandContext(ICanvas canvas)
        {
            Canvas = canvas;
            CurrentX = 0;
            CurrentY = 0;
        }
    }
}
