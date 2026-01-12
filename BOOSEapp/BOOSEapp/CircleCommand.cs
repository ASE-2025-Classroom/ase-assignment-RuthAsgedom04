using System;

namespace BOOSEapp
{
    public class CircleCommand : ICommand
    {
        private readonly string _radiusToken;

        public CircleCommand(string radiusToken)
        {
            _radiusToken = radiusToken ?? throw new ArgumentNullException(nameof(radiusToken));
        }

        public void Execute(CommandContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            int radius;

            // If it's a literal number: circle 40
            if (int.TryParse(_radiusToken, out radius))
            {
                context.Canvas.DrawCircle(radius);
                return;
            }

            // Otherwise treat it as a variable name: circle x
            // Prefer int var; if not, allow real var (cast to int)
            try
            {
                radius = context.Vars.GetInt(_radiusToken);
            }
            catch
            {
                // try real
                double real = context.Vars.GetReal(_radiusToken);
                radius = (int)Math.Round(real);
            }

            context.Canvas.DrawCircle(radius);
        }
    }
}
