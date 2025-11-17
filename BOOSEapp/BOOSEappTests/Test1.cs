using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOOSEapp;

namespace BOOSEappTests
{
    [TestClass]
    public class CommandTests
    {
        // Helper to create the form for each test
        private Form1 CreateForm()
        {
            return new Form1();
        }

        // 1) Unit Test for moveto command (pen position)
        [TestMethod]
        public void MoveTo_SetsCurrentPosition()
        {
            // arrange
            var form = CreateForm();

            // act
            form.RunProgram("moveto 100 150");

            // assert
            Assert.AreEqual(100, form.CurrentX);
            Assert.AreEqual(150, form.CurrentY);
        }

        // 2) Unit Test for drawto command (pen moves correctly)
        [TestMethod]
        public void DrawTo_UpdatesCurrentPosition()
        {
            var form = CreateForm();

            string program = @"moveto 50 50
drawto 80 90";

            form.RunProgram(program);

            Assert.AreEqual(80, form.CurrentX);
            Assert.AreEqual(90, form.CurrentY);
        }

        // 3) Unit Test for a multiline program
        [TestMethod]
        public void MultiLineProgram_EndsInExpectedPosition()
        {
            var form = CreateForm();

            string program = @"moveto 10 10
drawto 20 10
drawto 20 20
moveto 5 5";

            form.RunProgram(program);

            Assert.AreEqual(5, form.CurrentX);
            Assert.AreEqual(5, form.CurrentY);
        }
    }
}
