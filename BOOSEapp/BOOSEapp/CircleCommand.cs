using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOSEapp
{
    public class CircleCommand : ICommand
    {
        private readonly int radius;

        public CircleCommand(int radius)
        {
            this.radius = radius;
        }

        public void Execute(CommandContext context)
        {
            context.Canvas.DrawCircle(radius);
        }
    }
}
