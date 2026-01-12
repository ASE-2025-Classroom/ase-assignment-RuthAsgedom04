using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOSEapp
{
    public interface ICommand
    {
        void Execute(CommandContext context);
    }
}
