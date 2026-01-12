using System;

namespace BOOSEapp
{
    /// <summary>
    /// Holds runtime state while a BOOSE program executes.
    /// </summary>
    public class CommandContext
    {
        public ICanvas Canvas { get; }

        // Current pen position (needed by MoveTo/DrawTo etc.)
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        // Variable storage (singleton)
        public VariableStore Vars { get; } = VariableStore.Instance;

        public CommandContext(ICanvas canvas)
        {
            Canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
            CurrentX = 0;
            CurrentY = 0;
        }
    }
}
