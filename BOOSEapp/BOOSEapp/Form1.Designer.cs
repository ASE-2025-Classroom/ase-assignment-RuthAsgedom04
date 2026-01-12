namespace BOOSEapp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            programTextBox = new TextBox();
            canvas = new PictureBox();
            runButton = new Button();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // programTextBox
            // 
            programTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            programTextBox.Location = new Point(12, 12);
            programTextBox.Multiline = true;
            programTextBox.Name = "programTextBox";
            programTextBox.ScrollBars = ScrollBars.Vertical;
            programTextBox.Size = new Size(625, 78);
            programTextBox.TabIndex = 0;
         
            // 
            // canvas
            // 
            canvas.BorderStyle = BorderStyle.FixedSingle;
            canvas.Location = new Point(12, 111);
            canvas.Name = "canvas";
            canvas.Size = new Size(600, 300);
            canvas.TabIndex = 1;
            canvas.TabStop = false;
            // 
            // runButton
            // 
            runButton.Location = new Point(638, 162);
            runButton.Name = "runButton";
            runButton.Size = new Size(150, 46);
            runButton.TabIndex = 2;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(runButton);
            Controls.Add(canvas);
            Controls.Add(programTextBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox programTextBox;
        private PictureBox canvas;
        private Button runButton;
    }
}
