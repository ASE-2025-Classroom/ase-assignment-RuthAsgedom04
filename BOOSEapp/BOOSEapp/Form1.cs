using System;
using System.Drawing;
using System.Windows.Forms;
using BOOSE;
using System.Diagnostics;

namespace BOOSEapp
{
    // Main form for the BOOSE application that provides
    // text box and draws the result on the canvas
    public partial class Form1 : Form
    {
        private ICanvas canvasHelper;
        private Bitmap canvasBitmap;

        // ✅ These make your existing tests pass again
        public int CurrentX => canvasHelper?.CurrentX ?? 0;
        public int CurrentY => canvasHelper?.CurrentY ?? 0;

        // Sets up the form and gets the canvas up for drawing
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
        }

        // This is what controls the running of the program
        private void runButton_Click(object sender, EventArgs e)
        {
            RunProgram(programTextBox.Text);
        }

        public void RunProgram(string program)
        {
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                canvasHelper = new Canvas(g, canvas.Width, canvas.Height);
                canvasHelper.Clear();

                string[] lines = program.Split(
                    new[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    try
                    {
                        ICommand command = CommandFactory.Create(line);
                        command.Execute(new CommandContext(canvasHelper));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\nLine: {line}");
                        break;
                    }
                }
            }

            canvas.Refresh();
        }
    }
}
