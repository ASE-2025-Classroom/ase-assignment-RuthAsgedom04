using System.Drawing;

namespace BOOSEapp
{
    /// <summary>
    /// Abstraction of the drawing surface used by the interpreter.
    /// Keeps UI (Form) separate from drawing logic for testability and cleaner design.
    /// </summary>
    public interface ICanvas
    {
        // Current pen position
        int CurrentX { get; }
        int CurrentY { get; }

        // Canvas size
        int Width { get; }
        int Height { get; }

        /// <summary>Changes the current pen colour.</summary>
        void SetPenColour(Color colour);

        /// <summary>Moves the current position without drawing.</summary>
        void MoveTo(int x, int y);

        /// <summary>Draws a line from current position to (x,y) and updates current position.</summary>
        void DrawTo(int x, int y);

        /// <summary>Draws a rectangle using current pen colour.</summary>
        void DrawRectangle(int width, int height);

        /// <summary>Draws a circle using current pen colour.</summary>
        void DrawCircle(int radius);

        /// <summary>Clears the canvas (optional but useful for programs/tests).</summary>
        void Clear();
    }
}
