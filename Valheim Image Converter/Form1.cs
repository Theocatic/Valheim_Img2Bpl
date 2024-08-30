using ImageMagick;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
namespace Valheim_Image_Converter
{
    public enum ErrorLocation
    {
        Top,
        Bottom
    }
    public partial class Form1 : Form
    {
        string BluePrint;
        string fileSavePath;
        Image currentImage;
        public Form1()
        {
            InitializeComponent();
            double[] PixelSizeOptions = { .2, .25, .3, .35, .4, .45, .5, .75, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            InitializeComboBox<double>(PixelSizeOptions, comboBox1);
            comboBox1.SelectedIndex = 8;
            pictureBox1.AllowDrop = true;
            pictureBox1.DragDrop += new DragEventHandler(Form1_DragDrop);
            pictureBox1.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            comboBox1.TextChanged += ComboBox1_OnTextChanged;

            if (File.Exists(Application.StartupPath + "\\SaveLocation.txt"))
                fileSavePath = File.ReadAllText(Application.StartupPath + "\\SaveLocation.txt");
            else
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Thunderstore Mod Manager\DataFolder\Valheim\profiles"))
                    fileSavePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Thunderstore Mod Manager\DataFolder\Valheim\profiles";

                else
                    fileSavePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            RefreshError();
            label13.Text = "";

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComboBox<T>(T[] items, ComboBox box)
        {
            for (int i = 0; i < items.Length; i++)
            {
                box.Items.Add(items[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.Text = openFileDialog1.FileName;
                try
                {
                    LoadNewFile(Image.FromFile(openFileDialog1.FileName));
                }
                catch { ThrowError("Could Not Load File. Make sure you selected an image", ErrorLocation.Top); }


            }

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;

        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files[0] != null)
            {
                e.Effect = DragDropEffects.Copy;
                richTextBox1.Text = files[0];
                LoadNewFile(Image.FromFile(files[0]));

            }
        }

        public void ThrowError(string error, ErrorLocation location)
        {
            if (location == ErrorLocation.Top)
                label7.Text = error;
            if (location == ErrorLocation.Bottom)
                label11.Text = error;
        }

        public void RefreshError()
        {
            label7.Text = "";
            label11.Text = "";
            label10.Text = "";
        }

        public void ConvertImage(string path)
        {
            var img2BplArgs = new string[]
                {
                    path, //Real File name with extension
                    Path.GetFileNameWithoutExtension(path), //file name without extension
                    checkBox1.Checked ? "1" : "0", //Vertical Shift
                    checkBox2.Checked ? "1" : "0", //Support Block
                    comboBox1.Text, //fontsize
                    richTextBox2.Text, //transparency color
                    checkBox3.Checked ? "1" : "0",
                    checkBox4.Checked ? "1" : "0",
                };
            label10.Text = "Converting Image";
            string BluePrintName = Path.GetFileName(comboBox1.Text);
            string test = Img2BP.ConvertImage(img2BplArgs);
            BluePrint = test;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ReloadObjectCount();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConvertImage(richTextBox1.Text);
            SaveBlueprint();
        }

        private void LoadNewFile(Image image)
        {
            if (image == null)
            {
                label13.Text = "";
                ThrowError("Something went wrong loading that image", ErrorLocation.Top);
            }
            label7.Text = "";
            label13.Text = $"This Picture is {image.Width} By {image.Height} Pixels";
            pictureBox1.Image = image;
            if (image.Width > 400 || image.Height > 480)
                ThrowError("Warning Large images may cause lag and take a while to generate", ErrorLocation.Top);
            currentImage = image;
            ReloadObjectCount();

        }

        private void ReloadObjectCount()
        {
            if (currentImage != null)
            {
                try
                {
                    int h = currentImage.Height;
                    int w = currentImage.Width;
                    if (h % 2 == 1)
                        h++;

                    double signWidth = 1 * .95;
                    double signHeight = .5 * .95;

                    double pixsz = 0.3 * double.Parse(comboBox1.Text) / 9.0;
                    int heightConversion = (int)Math.Ceiling((h * pixsz * 1.1) / signHeight);
                    if (heightConversion - ((h * pixsz * 1.1) / signHeight) < .01)
                        heightConversion--;
                    int widthConversion = (int)Math.Ceiling((w * pixsz * 1.1) / signWidth);
                    if (widthConversion - ((w * pixsz * 1.1) / signWidth) < .01)
                        widthConversion--;

                    //int heightConversion = (int)Math.Ceiling((double)h / (10 / double.Parse(comboBox1.Text)));
                    //int widthConversion = (int)Math.Ceiling((double)currentImage.Width / (20 / double.Parse(comboBox1.Text)));
                    int objects = w * 2;

                    objects += checkBox2.Checked ? 0 : 1;
                    objects += checkBox4.Checked ? heightConversion * widthConversion : 0;
                    label10.Text = $"This file will consist of {objects} Objects";
                }
                catch
                {
                    ThrowError("Could not calculate Data. Please make sure only numbers are in Pixel Size", ErrorLocation.Bottom);
                    label10.Text = "Error";
                }

            }
            else
                label10.Text = "";
        }
        private void SaveBlueprint()
        {
            saveFileDialog1.Filter = "Blueprint File | *.blueprint";
            saveFileDialog1.Title = "Save your blueprint file";
            saveFileDialog1.InitialDirectory = fileSavePath;
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();

            string path = saveFileDialog1.FileName;
            if (path == "")
                return;
            if (!File.Exists(path))
            {
                File.WriteAllText(path, BluePrint);
            }
            string path2 = Application.StartupPath + "SaveLocation.txt";
            string fileDirectory = Path.GetDirectoryName(path);

            if (fileSavePath != fileDirectory)
            {
                fileSavePath = fileDirectory;
                File.WriteAllText(path2, fileDirectory);
            }

            label10.Text = "Finished Converting " + System.IO.Path.GetFileName(path);

        }

        private void ThrowSaveError()
        {

        }

        private void ValidateSave()
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ReloadObjectCount();
        }

        private void ComboBox1_OnTextChanged(object sender, EventArgs e)
        {
            ReloadObjectCount();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
