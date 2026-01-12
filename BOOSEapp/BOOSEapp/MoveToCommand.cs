using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOSEapp
{
    public class MoveToCommand : ICommand
    {
        private readonly int x;
        private readonly int y;

        public MoveToCommand(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Execute(CommandContext context)
        {
            context.CurrentX = x;
            context.CurrentY = y;
            context.Canvas.MoveTo(x, y);
        }
    }
}
