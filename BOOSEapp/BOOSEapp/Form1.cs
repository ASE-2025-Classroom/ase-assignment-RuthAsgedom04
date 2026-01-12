using System;
using System.Drawing;
using System.Windows.Forms;
using BOOSE;
using System.Diagnostics;

namespace BOOSEapp
{
    // Main form for the BOOSE application that provides
    // a text box and draws the result on the canvas
    public partial class Form1 : Form
    {
        private ICanvas canvasHelper;
        private Bitmap canvasBitmap;

        // Sets up the form and gets the canvas ready for drawing
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
        }

        // Run button click handler
        private void runButton_Click(object sender, EventArgs e)
        {
            RunProgram(programTextBox.Text);
        }

        // Runs the BOOSE program entered by the user
        public void RunProgram(string program)
        {
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                // Create canvas and clear it
                canvasHelper = new Canvas(g, canvas.Width, canvas.Height);
                canvasHelper.Clear();

                // Split program into lines
                string[] lines = program.Split(
                    new[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                // Create command execution context
                var context = new CommandContext(canvasHelper);

                // Execute each line using the Factory + Command pattern
                foreach (string line in lines)
                {
                    try
                    {
                        ICommand command = CommandFactory.Create(line);
                        command.Execute(context);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Error: {ex.Message}\nLine: {line}",
                            "BOOSE Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }
                }
            }

            canvas.Refresh();
        }

        private void programTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

