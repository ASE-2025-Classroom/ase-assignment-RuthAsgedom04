
using BOOSE;
using System.Diagnostics;
using System.Drawing;

namespace BOOSEapp
{
    public partial class Form1 : Form
    {
        private Canvas canvasHelper;
        private Bitmap canvasBitmap;
        private int currentX = 0;
        private int currentY = 0;

        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = canvasBitmap;

            Graphics g = Graphics.FromImage(canvasBitmap);

            canvasHelper = new Canvas(g);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                g.Clear(Color.White);
            }

            string program = programTextBox.Text;
            string[] lines = program.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (trimmed == "") continue;

                string[] parts = trimmed.Split(' ');
                string cmd = parts[0].ToLower();

                try
                {
                    if (cmd == "moveto" && parts.Length == 3)
                    {
                        int x = int.Parse(parts[1]);
                        int y = int.Parse(parts[2]);
                        currentX = x;
                        currentY = y;
                    }
                    else if (cmd == "drawto" && parts.Length == 3)
                    {
                        int x = int.Parse(parts[1]);
                        int y = int.Parse(parts[2]);
                        canvasHelper.DrawLine(currentX, currentY, x, y);
                        currentX = x;
                        currentY = y;
                    }
                    else if (cmd == "rect" && parts.Length == 3)
                    {
                        int width = int.Parse(parts[1]);
                        int height = int.Parse(parts[2]);
                        canvasHelper.DrawRectangle(currentX, currentY, width, height);
                    }
                    else if (cmd == "circle" && parts.Length == 2)
                    {
                        int radius = int.Parse(parts[1]);
                        canvasHelper.DrawCircle(currentX, currentY, radius);
                    }
                    else
                    {
                        MessageBox.Show("Unknown command: " + line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in line: '" + line + "'\n" + ex.Message);
                }
            }
            canvas.Invalidate();
        }
    }
}