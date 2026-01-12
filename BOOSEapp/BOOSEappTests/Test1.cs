using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using BOOSEapp;

namespace BOOSEappTests
{
    [TestClass]
    public class CommandTests
    {
        // A very small fake canvas for testing (no UI, no Graphics).
        // It tracks CurrentX/CurrentY exactly like your real Canvas should.
        private class FakeCanvas : ICanvas
        {
            public int CurrentX { get; private set; }
            public int CurrentY { get; private set; }

            public int Width { get; }
            public int Height { get; }

            public Color PenColour { get; private set; } = Color.Black;

            public FakeCanvas(int width = 600, int height = 300)
            {
                Width = width;
                Height = height;
                CurrentX = 0;
                CurrentY = 0;
            }

            public void SetPenColour(Color colour)
            {
                PenColour = colour;
            }

            public void MoveTo(int x, int y)
            {
                CurrentX = x;
                CurrentY = y;
            }

            public void DrawTo(int x, int y)
            {
                // For tests we only care that the "pen position" updates.
                CurrentX = x;
                CurrentY = y;
            }

            public void DrawRectangle(int width, int height)
            {
                // No position change required for rectangle in your spec
            }

            public void DrawCircle(int radius)
            {
                // No position change required for circle in your spec
            }

            public void Clear()
            {
                // Reset back to start like a typical canvas clear
                CurrentX = 0;
                CurrentY = 0;
            }
        }

        // Helper: runs a BOOSE program using your Factory + Commands
        private static void RunProgram(string program, ICanvas canvas)
        {
            var context = new CommandContext(canvas);

            string[] lines = program.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                ICommand command = CommandFactory.Create(line);
                command.Execute(context);
            }
        }

        [TestMethod]
        public void MoveTo_SetsCurrentPosition()
        {
            var canvas = new FakeCanvas();

            RunProgram("moveto 100 150", canvas);

            Assert.AreEqual(100, canvas.CurrentX);
            Assert.AreEqual(150, canvas.CurrentY);
        }

        [TestMethod]
        public void DrawTo_UpdatesCurrentPosition()
        {
            var canvas = new FakeCanvas();

            string program = @"moveto 50 50
drawto 80 90";

            RunProgram(program, canvas);

            Assert.AreEqual(80, canvas.CurrentX);
            Assert.AreEqual(90, canvas.CurrentY);
        }

        [TestMethod]
        public void MultiLineProgram_EndsInExpectedPosition()
        {
            var canvas = new FakeCanvas();

            string program = @"moveto 10 10
drawto 20 10
drawto 20 20
moveto 5 5";

            RunProgram(program, canvas);

            Assert.AreEqual(5, canvas.CurrentX);
            Assert.AreEqual(5, canvas.CurrentY);
        }
    }
}

