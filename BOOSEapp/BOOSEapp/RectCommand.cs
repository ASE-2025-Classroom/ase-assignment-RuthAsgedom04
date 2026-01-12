using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOSEapp
{
    public class RectCommand : ICommand
    {
        private readonly int w;
        private readonly int h;

        public RectCommand(int w, int h)
        {
            this.w = w;
            this.h = h;
        }

        public void Execute(CommandContext context)
        {
            context.Canvas.DrawRectangle(w, h);
        }
    }
}
