using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace YAGE
{

    public partial class Form1 : Form
    {
        public static List<List<PictureBox>> StateList = new List<List<PictureBox>>();
        public static int gridWidth;
        public static int gridHeight;
        public static int cellSize = 64;
        public static Boolean Leftclick = false;
        public static Boolean Rightclick = false;
        public static Point gridOrigin = new Point(5, 78);
        public static String filePath = "";
        public static Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            populatePictures();
            if (cboLeft.Items.Count != 0)
            {
                cboLeft.SelectedIndex = 0;
                cboRight.SelectedIndex = 0;

            }

        }


        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            cellSize = Convert.ToInt32(txtSize.Text);
            gridWidth = Convert.ToInt32(txtWidth.Text);
            gridHeight = Convert.ToInt32(txtHeight.Text);
            for (int i = 0; i < gridHeight; i++)
            {
                StateList.Add(new List<PictureBox>());
            }


            for (int y = 0; y < gridHeight; y++)
            {

                for (int x = 0; x < gridWidth; x++)
                {

                    StateList[y].Add(new PictureBox());
                    StateList[y][x].Size = new Size(cellSize, cellSize);
                    Point tempoint = new Point();
                    tempoint.X = gridOrigin.X + x * cellSize;
                    tempoint.Y = gridOrigin.Y + y * cellSize;
                    StateList[y][x].Location = tempoint;

                    StateList[y][x].BackgroundImage = Image.FromFile(cboLeft.SelectedItem.ToString() + ".png");
                    StateList[y][x].BackgroundImageLayout = ImageLayout.Stretch;



                    if (chkBorder.Checked)
                    {
                        StateList[y][x].BorderStyle = BorderStyle.FixedSingle;

                    }
                    StateList[y][x].Tag = cboLeft.SelectedItem.ToString();

                    StateList[y][x].MouseDown += new MouseEventHandler(Form1_MouseDown);
                    StateList[y][x].MouseUp += new MouseEventHandler(Form1_MouseUp);
                    StateList[y][x].MouseMove += new MouseEventHandler(Form1_MouseMove);







                }

            }

            updateTiles();
            cmdGenerate.Enabled = false;
            cmdRandomize.Enabled = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {





        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Leftclick = true;
                if (Leftclick)
                {
                    int tempx = (Form1.MousePosition.X - gridOrigin.X) / cellSize;
                    int tempy = (Form1.MousePosition.Y - gridOrigin.Y) / cellSize;


                    if (tempx >= 0 & tempy >= 0)
                    {

                        if (tempy < StateList.Count)
                        {
                            if (tempx < StateList[tempy].Count)
                            {



                                StateList[tempy][tempx].Tag = cboLeft.SelectedItem.ToString();
                                StateList[tempy][tempx].BackgroundImage = Image.FromFile(cboLeft.SelectedItem + ".png");
                            }
                        }

                    }

                }
            }


            if (e.Button == MouseButtons.Right)
            {
                Rightclick = true;
                if (Rightclick)
                {
                    int tempx = (Form1.MousePosition.X - gridOrigin.X) / cellSize;
                    int tempy = (Form1.MousePosition.Y - gridOrigin.Y) / cellSize;


                    if (tempx >= 0 & tempy >= 0)
                    {

                        if (tempy < StateList.Count)
                        {
                            if (tempx < StateList[tempy].Count)
                            {



                                StateList[tempy][tempx].Tag = cboRight.SelectedItem.ToString();
                                StateList[tempy][tempx].BackgroundImage = Image.FromFile(cboRight.SelectedItem + ".png");
                            }
                        }

                    }

                }
            }

        }
        private void updateTiles()
        {

            for (int x = 0; x < StateList.Count; x++)
            {


                for (int y = 0; y < StateList[x].Count; y++)
                {
                    Controls.Add(StateList[x][y]);
                }

            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (Leftclick)
            {

                int tempx = (Form1.MousePosition.X - gridOrigin.X) / cellSize;
                int tempy = (Form1.MousePosition.Y - gridOrigin.Y - 15) / cellSize;


                if (tempx >= 0 & tempy >= 0)
                {

                    if (tempy < StateList.Count)
                    {
                        if (tempx < StateList[tempy].Count)
                        {



                            StateList[tempy][tempx].Tag = cboLeft.SelectedItem.ToString();
                            StateList[tempy][tempx].BackgroundImage = Image.FromFile(cboLeft.SelectedItem + ".png");


                        }
                    }
                }
            }
            if (Rightclick)
            {

                int tempx = (Form1.MousePosition.X - gridOrigin.X) / cellSize;
                int tempy = (Form1.MousePosition.Y - gridOrigin.Y - 15) / cellSize;


                if (tempx >= 0 & tempy >= 0)
                {

                    if (tempy < StateList.Count)
                    {
                        if (tempx < StateList[tempy].Count)
                        {



                            StateList[tempy][tempx].Tag = cboRight.SelectedItem.ToString();
                            StateList[tempy][tempx].BackgroundImage = Image.FromFile(cboRight.SelectedItem + ".png");

                        }
                    }
                }
            }



        }

        private void cboTile_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Form1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Leftclick = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                Rightclick = false;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {


        }

        private void cmdPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            filePath = openFile.FileName;
            txtPath.Text = filePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFIle();

        }


        private void cmdDisplayLayout_Click(object sender, EventArgs e)
        {

            StreamReader reader = new StreamReader(filePath);
            string line = reader.ReadLine();
            int y = 0;

            while ((line != null))
            {

                StateList.Add(new List<PictureBox>());


                for (int x = 0; x < line.Count(); x++)
                {
                    StateList[y].Add(new PictureBox());
                    StateList[y][x].Size = new Size(cellSize, cellSize);
                    Point tempoint = new Point();
                    tempoint.X = gridOrigin.X + x * cellSize;
                    tempoint.Y = gridOrigin.Y + y * cellSize;
                    StateList[y][x].Location = tempoint;
                    StateList[y][x].BackgroundImage = Image.FromFile(line[x] + ".png");
                    StateList[y][x].BackgroundImageLayout = ImageLayout.Stretch;

                    if (chkBorder.Checked)
                    {
                        StateList[y][x].BorderStyle = BorderStyle.FixedSingle;

                    }
                    StateList[y][x].Tag = line[x].ToString();
                    StateList[y][x].MouseDown += new MouseEventHandler(Form1_MouseDown);
                    StateList[y][x].MouseUp += new MouseEventHandler(Form1_MouseUp);
                    StateList[y][x].MouseMove += new MouseEventHandler(Form1_MouseMove);

                }
                y++;
                line = reader.ReadLine();

            }

            updateTiles();
            reader.Close();
            cmdGenerate.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFIle();

            Application.Exit();

        }

        private void chkBorder_CheckedChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < StateList.Count; x++)
            {


                for (int y = 0; y < StateList[x].Count; y++)
                {
                    if (chkBorder.Checked)
                    {
                        StateList[x][y].BorderStyle = BorderStyle.FixedSingle;
                    }
                    else
                    {
                        StateList[x][y].BorderStyle = BorderStyle.None;
                    }


                }
            }
            updateTiles();

        }

        private void cboRight_SelectedIndexChanged(object sender, EventArgs e)
        {

            pbRight.BackgroundImage = Image.FromFile(cboRight.SelectedItem + ".png");

        }

        private void cboLeft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLeft_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            pbLeft.BackgroundImage = Image.FromFile(cboLeft.SelectedItem + ".png");

        }

        private void pbLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (cboLeft.SelectedIndex + 1 == cboLeft.Items.Count)
            {
                cboLeft.SelectedIndex = 0;
            }
            else
            {
                cboLeft.SelectedIndex++;

            }
        }

        private void pbRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (cboRight.SelectedIndex + 1 == cboRight.Items.Count)
            {
                cboRight.SelectedIndex = 0;
            }
            else
            {
                cboRight.SelectedIndex++;

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            populatePictures();

        }
        private void populatePictures()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (File.Exists(c + ".png"))
                {
                    cboLeft.Items.Add(c);
                    cboRight.Items.Add(c);
                }
            }


        }

        private void cmdClear_Click(object sender, EventArgs e)
        {

        }
        public static void SaveFIle()
        {
            if (StateList.Count != 0)
            {



                string savePath = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("HH_mm_ss--MM_d") + ".txt";
                Console.Out.Write(filePath);


                StreamWriter writer = new StreamWriter(savePath, false);



                for (int y = 0; y < StateList.Count; y++)
                {
                    String templine = "";


                    for (int x = 0; x < StateList[y].Count; x++)
                    {
                        templine += StateList[y][x].Tag;

                    }
                    writer.WriteLine(templine, true);

                }
                writer.Close();
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            throw new Exception();


        }

        private void cmdRandomize_Click(object sender, EventArgs e)
        {
            cellSize = Convert.ToInt32(txtSize.Text);
            gridWidth = Convert.ToInt32(txtWidth.Text);
            gridHeight = Convert.ToInt32(txtHeight.Text);
            for (int i = 0; i < gridHeight; i++)
            {
                StateList.Add(new List<PictureBox>());
            }


            for (int y = 0; y < gridHeight; y++)
            {

                for (int x = 0; x < gridWidth; x++)
                {

                    StateList[y].Add(new PictureBox());
                    StateList[y][x].Size = new Size(cellSize, cellSize);
                    Point tempoint = new Point();
                    tempoint.X = gridOrigin.X + x * cellSize;
                    tempoint.Y = gridOrigin.Y + y * cellSize;
                    StateList[y][x].Location = tempoint;
                    // Console.Out.(tempoint);
                    string tempFile = cboLeft.Items[rnd.Next(0, cboLeft.Items.Count - 1)].ToString();


                    while (tempFile.Equals("P"))
                    {

                        tempFile = cboLeft.Items[rnd.Next(0, cboLeft.Items.Count - 1)].ToString();

                    }

                    StateList[y][x].BackgroundImage = Image.FromFile(tempFile + ".png");



                    StateList[y][x].BackgroundImageLayout = ImageLayout.Stretch;



                    if (chkBorder.Checked)
                    {
                        StateList[y][x].BorderStyle = BorderStyle.FixedSingle;

                    }
                    StateList[y][x].Tag = tempFile;

                    StateList[y][x].MouseDown += new MouseEventHandler(Form1_MouseDown);
                    StateList[y][x].MouseUp += new MouseEventHandler(Form1_MouseUp);
                    StateList[y][x].MouseMove += new MouseEventHandler(Form1_MouseMove);







                }

            }

            updateTiles();
            cmdGenerate.Enabled = false;
            cmdRandomize.Enabled = false;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveFIle();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            SaveFIle();
        }

    }
}