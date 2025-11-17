using System;
using System.Drawing;
using System.Windows.Forms;
using BOOSE;

using System.Diagnostics;

namespace BOOSEapp
{
   
    //Main form for the BOOSE application that provides
    //text box and drawes the result on the canvas
    public partial class Form1 : Form
    {
        private Canvas canvasHelper;
        private Bitmap canvasBitmap;
        private int currentX = 0;
        private int currentY = 0;
        public int CurrentX => currentX;
        public int CurrentY => currentY;

        // Sets up the form and gets the canvas up fotr drawing
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;
        }

        //This is what controls the running of the program
        private void runButton_Click(object sender, EventArgs e)
        {
            RunProgram(programTextBox.Text);
        }

        public void RunProgram(string program)
        {
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                g.Clear(Color.White);
                canvasHelper = new Canvas(g);

                string[] lines = program.Split(
                    new[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string trimmed = line.Trim();
                    trimmed = trimmed.Replace(",", " ");
                    if (trimmed == "") continue;

                    string[] parts = trimmed.Split(
                        new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length == 0) continue;

                    string cmd = parts[0].ToLower();

                    if (cmd == "moveto")
                    {
                        if (parts.Length == 3 &&
                            int.TryParse(parts[1], out int x) &&
                            int.TryParse(parts[2], out int y))
                        {
                            currentX = x;
                            currentY = y;
                        }
                        else
                        {
                            MessageBox.Show($"Error in moveto command: {trimmed}");
                        }
                    }
                    else if (cmd == "drawto")
                    {
                        if (parts.Length == 3 &&
                            int.TryParse(parts[1], out int x) &&
                            int.TryParse(parts[2], out int y))
                        {
                            canvasHelper.DrawLine(currentX, currentY, x, y);
                            currentX = x;
                            currentY = y;
                        }
                        else
                        {
                            MessageBox.Show($"Error in drawto command: {trimmed}");
                        }
                    }
                    else if (cmd == "rect")
                    {
                        if (parts.Length == 3 &&
                            int.TryParse(parts[1], out int w) &&
                            int.TryParse(parts[2], out int h))
                        {
                            canvasHelper.DrawRectangle(currentX, currentY, w, h);
                        }
                        else
                        {
                            MessageBox.Show($"Error in rect command: {trimmed}");
                        }
                    }
                    else if (cmd == "circle")
                    {
                        if (parts.Length == 2 &&
                            int.TryParse(parts[1], out int radius))
                        {
                            canvasHelper.DrawCircle(currentX, currentY, radius);
                        }
                        else
                        {
                            MessageBox.Show($"Error in circle command: {trimmed}");
                        }
                    }
                    else if (cmd == "pencolour")
                    {
                        if (parts.Length == 4 &&
                            int.TryParse(parts[1], out int r) &&
                            int.TryParse(parts[2], out int green) &&
                            int.TryParse(parts[3], out int b))
                        {
                            canvasHelper.SetPenColour(Color.FromArgb(r, green, b));
                        }
                        else
                        {
                            MessageBox.Show($"Error in pencolour command: {trimmed}");
                        }
                    }
                    else if (cmd == "pen")
                    {
                        if (parts.Length == 4 &&
                            int.TryParse(parts[1], out int r) &&
                            int.TryParse(parts[2], out int green) &&
                            int.TryParse(parts[3], out int b))
                        {
                            canvasHelper.SetPenColour(Color.FromArgb(r, green, b));
                        }
                        else
                        {
                            MessageBox.Show($"Error in pen command: {trimmed}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Unknown command: {trimmed}");
                    }
                }
            }

            canvas.Refresh();
        }
    }
}
