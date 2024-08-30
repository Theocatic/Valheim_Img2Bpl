namespace Valheim_Image_Converter
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
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            comboBox1 = new ComboBox();
            fileSystemWatcher1 = new FileSystemWatcher();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            button2 = new Button();
            richTextBox2 = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            checkBox3 = new CheckBox();
            label8 = new Label();
            checkBox4 = new CheckBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(541, 33);
            label1.Name = "label1";
            label1.Size = new Size(564, 65);
            label1.TabIndex = 0;
            label1.Text = "Valheim Image Generator";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1059, 138);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 1;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(326, 142);
            label2.Name = "label2";
            label2.Size = new Size(200, 32);
            label2.TabIndex = 2;
            label2.Text = "Image to Convert";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(549, 138);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(504, 34);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(406, 360);
            label5.Name = "label5";
            label5.Size = new Size(113, 32);
            label5.TabIndex = 6;
            label5.Text = "Pixel Size";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(320, 423);
            label6.Name = "label6";
            label6.Size = new Size(202, 32);
            label6.TabIndex = 7;
            label6.Text = "Transparent Color";
            // 
            // comboBox1
            // 
            comboBox1.FormatString = "N2";
            comboBox1.Location = new Point(531, 360);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 33);
            comboBox1.TabIndex = 8;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(1203, 33);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.MaximumSize = new Size(571, 800);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(571, 800);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(326, 192);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(289, 32);
            label7.TabIndex = 10;
            label7.Text = "ERROR MESSAGE!!!! GRRR";
            label7.Click += label7_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F);
            checkBox1.Location = new Point(292, 242);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(304, 36);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "    Do Not Shift Vertically";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Font = new Font("Segoe UI", 12F);
            checkBox2.Location = new Point(209, 288);
            checkBox2.Margin = new Padding(4, 5, 4, 5);
            checkBox2.Name = "checkBox2";
            checkBox2.RightToLeft = RightToLeft.Yes;
            checkBox2.Size = new Size(387, 36);
            checkBox2.TabIndex = 13;
            checkBox2.Text = "    Do Not Include Support Block";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F);
            button2.Location = new Point(611, 662);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(291, 75);
            button2.TabIndex = 14;
            button2.Text = "Create Blueprint";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 12F);
            richTextBox2.Location = new Point(531, 427);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(183, 39);
            richTextBox2.TabIndex = 15;
            richTextBox2.Text = "None";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(720, 432);
            label3.Name = "label3";
            label3.Size = new Size(403, 21);
            label3.TabIndex = 16;
            label3.Text = "(Hex values to make transparent, seperate by , and use #)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(309, 542);
            label4.Name = "label4";
            label4.Size = new Size(0, 32);
            label4.TabIndex = 17;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Font = new Font("Segoe UI", 12F);
            checkBox3.Location = new Point(346, 497);
            checkBox3.Name = "checkBox3";
            checkBox3.RightToLeft = RightToLeft.Yes;
            checkBox3.Size = new Size(250, 36);
            checkBox3.TabIndex = 18;
            checkBox3.Text = "Better Transparency";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(611, 508);
            label8.Name = "label8";
            label8.Size = new Size(404, 25);
            label8.TabIndex = 19;
            label8.Text = "(Make transparent pixels have more empty space)";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Font = new Font("Segoe UI", 12F);
            checkBox4.Location = new Point(414, 545);
            checkBox4.Name = "checkBox4";
            checkBox4.RightToLeft = RightToLeft.Yes;
            checkBox4.Size = new Size(177, 36);
            checkBox4.TabIndex = 20;
            checkBox4.Text = "Sign Backing";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // label9
            // 
            label9.Location = new Point(611, 552);
            label9.Name = "label9";
            label9.Size = new Size(559, 58);
            label9.TabIndex = 21;
            label9.Text = "(Creates blank signs behind your image to ensure proper visability. turn off for better performance or to use your own backing)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(69, 687);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(352, 32);
            label10.TabIndex = 22;
            label10.Text = "This will contain 9999 Objects!!!";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(69, 760);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(385, 32);
            label11.TabIndex = 23;
            label11.Text = "ERROR MESSAGE AGAIN!!!! ARGGG";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 18F);
            label13.Location = new Point(1203, 848);
            label13.Name = "label13";
            label13.Size = new Size(446, 48);
            label13.TabIndex = 25;
            label13.Text = "This Picture Is X by Y Pixels";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1867, 954);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(checkBox4);
            Controls.Add(label8);
            Controls.Add(checkBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(richTextBox2);
            Controls.Add(button2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Valheim Image Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Label label1;
        private Button button1;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label5;
        private Label label6;
        private ComboBox comboBox1;
        private FileSystemWatcher fileSystemWatcher1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox1;
        private Label label7;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button button2;
        private Label label3;
        private RichTextBox richTextBox2;
        private Label label4;
        private SaveFileDialog saveFileDialog1;
        private Label label8;
        private CheckBox checkBox3;
        private Label label11;
        private Label label10;
        private Label label9;
        private CheckBox checkBox4;
        private Label label13;
    }
}
