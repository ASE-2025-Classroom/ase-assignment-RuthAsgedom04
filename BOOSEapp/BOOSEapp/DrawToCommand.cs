using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOSEapp
{
    public class DrawToCommand : ICommand
    {
        private readonly int x;
        private readonly int y;

        public DrawToCommand(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Execute(CommandContext context)
        {
            context.Canvas.DrawTo(x, y);
            context.CurrentX = x;
            context.CurrentY = y;
        }
    }
}
