using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOOSEapp;

namespace BOOSEappTests
{
    
    ///  simple unit tests for checking basic BOOSE commands
    /// like moveto, drawto and running a small program.
    
    [TestClass]
    public class CommandTests
    {
       
        /// Creates new form for each test.
       
        private Form1 CreateForm()
        {
            return new Form1();
        }

        
        /// Checks that the moveto command correctly updates
        /// the current X and Y positions.
        
        [TestMethod]
        public void MoveTo_SetsCurrentPosition()
        {
            var form = CreateForm();

            form.RunProgram("moveto 100 150");

            Assert.AreEqual(100, form.CurrentX);
            Assert.AreEqual(150, form.CurrentY);
        }


        /// Makes sure the drawto command moves the pen
        ///  updates the position afterwards!!
        
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

       
        /// Tests a short program with several commands to check that
        /// the final position is correct after everything runs.
       
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

