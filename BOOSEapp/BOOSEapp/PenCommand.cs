using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace BOOSEapp
{
    public class PenCommand : ICommand
    {
        private readonly int r, g, b;

        public PenCommand(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public void Execute(CommandContext context)
        {
            context.Canvas.SetPenColour(Color.FromArgb(r, g, b));
        }
    }
}
