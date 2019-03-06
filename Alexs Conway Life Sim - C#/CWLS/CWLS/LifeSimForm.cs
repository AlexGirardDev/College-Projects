using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CWLS
{
    public partial class Form1 : Form
    {
        public static Boolean[,] Statelist = null;
        public static Boolean[,] TempStatelist = Statelist;
        public List<List<PictureBox>> PbList;

        public static Boolean Leftclick = false;
        public static Boolean Rightclick = false;
        public static Boolean Running = false;
        public static int SqrSize = 0;
        public Form1()
        { InitializeComponent(); }


        //Method used to checkt he state of all cells in grid
        public void Checkallstate()
        {
            //Copy array to temporary buffered array list
            Array.Copy(Statelist, TempStatelist, Statelist.Length);
            //Setup variables for nested loops
            int tempx = 0;
            int tempy = 0;
            int width = Convert.ToInt32(txtWidth.Text);
            int hieght = Convert.ToInt32(txtHieght.Text);

            while (tempy < hieght)
            {
                while (tempx < width)
                {
                    //check the current cell in the loop what its destiny is in its next life.
                    TempStatelist[tempx, tempy] = nextCellState(tempx, tempy);
                    tempx++;
                }
                tempy++;
                tempx = 0;

            }
            // after all cells are checked copy temp statelist to main statelist
            Array.Copy(TempStatelist, Statelist, Statelist.Length);

        }


        //Method to check the state of cell within given the x and y value 
        public Boolean nextCellState(int x, int y)
        {


            int count = 0;
            //Checking to make sure array isnt null
            if (Statelist != null)
            //All of the if statements for checking cell state
            {
                //bottom left
                if ((x != 0) && (y != Statelist.GetLength(1) - 1))
                { if (Statelist[x - 1, y + 1]) { count++; } }

                //middle left
                if ((x != 0))
                { if (Statelist[x - 1, y]) { count++; } }

                //top left
                if ((x != 0) && (y != 0))
                { if (Statelist[x - 1, y - 1]) { count++; } }


                //top middle
                if ((y != 0))
                { if (Statelist[x, y - 1]) { count++; } }

                //top right
                if ((x != Statelist.GetLength(0) - 1) && (y != 0))
                { if (Statelist[x + 1, y - 1]) { count++; } }

                //middle right
                if ((x != Statelist.GetLength(0) - 1))
                { if (Statelist[x + 1, y]) { count++; } }

                // bottom right
                if ((x != Statelist.GetLength(0) - 1) && (y != Statelist.GetLength(1) - 1))
                { if (Statelist[x + 1, y + 1]) { count++; } }

                // bottom middle
                if (y != Statelist.GetLength(1) - 1)
                { if (Statelist[x, y + 1]) { count++; } }
            }

            //Check how many alive neighbour cells there were and return determined cell state
            if (Statelist != null && Statelist[x, y])
            {
                return count == 2 || count == 3;
            }
            if (count == 3)
            {
                return true;

            }
            return false;
        }

        public void Step()
        {
            //steps the program 1 iteration
            Checkallstate();
            DrawAll();

        }
        //Method to redraw all of the squares
        public void DrawAll()
        {
            int tempx = 0;
            int tempy = 0;
            int width = Convert.ToInt32(txtWidth.Text);
            int hieght = Convert.ToInt32(txtHieght.Text);


            txtWidth.Text = Convert.ToString(width);
            txtHieght.Text = Convert.ToString(hieght);


            while (tempy < hieght)
            {
                while (tempx < width)
                {
                    //Draws squre on screen you pass in x and y cordinates mesured in pixex as well as the cell state pulled from cell list 
                    DrawSquare(tempx * SqrSize, tempy * SqrSize + 30, Statelist[tempx, tempy], null);

                    // iterate inner loop
                    tempx = tempx + 1;
                }

                //iterate outer loop
                tempy = tempy + 1;
                tempx = 0;

            }

        }

        //Draw cell on screen dependent on state
        public void DrawSquare(int x, int y, Boolean state, PaintEventArgs e)
        {


            //I realize now a year after i have made the program and learned alot that useing SolidBrush to do this is probably the most inefficient way to do this
            //since every iteration it creates a new paintbrush object and just draws over the old cells resulting in very slow single life cycles.

            if (state)
            {


                SolidBrush myBrush = new SolidBrush(Color.Green);
                Graphics formGraphics = CreateGraphics();
                formGraphics.FillRectangle(myBrush, new Rectangle(x, y, SqrSize, SqrSize));
                myBrush.Dispose();
                formGraphics.Dispose();
            }
            else
            {
                SolidBrush myBrush = new SolidBrush(Color.Black);
                Graphics formGraphics = CreateGraphics();
                formGraphics.FillRectangle(myBrush, new Rectangle(x, y, SqrSize, SqrSize));
                myBrush.Dispose();

                formGraphics.Dispose();
            }
        }






        //Click event for Create button were state / Temp statelist are intilized as well as the grid size is set and initially drawn
        private void cmdCreateClick(object sender, EventArgs e)
        {
            SqrSize = Convert.ToInt32(txtSize.Text);

            int width = Convert.ToInt32(txtWidth.Text);
            int hieght = Convert.ToInt32(txtHieght.Text);

            Statelist = new Boolean[width, hieght];
            TempStatelist = new Boolean[width, hieght];

            DrawAll();
            cmdCreate.Enabled = false;
            cmdRandom.Enabled = true;
            cmdStart.Enabled = true;
            cmdStep.Enabled = true;
            cmdStop.Enabled = true;





        }


        //Click event for Start Button
        private void CmdStartClick(object sender, EventArgs e)
        {
            timer1.Interval = 20;
            timer1.Start();

        }
        //Click event for Step button
        private void CmdStepClick(object sender, EventArgs e)
        {

            Checkallstate();
            DrawAll();
        }
        //Click event for Stop button
        private void CmdStopClick(object sender, EventArgs e)
        {
            timer1.Stop();


        }
        //Click event for when mouse is pressed down within form
        private void Form1MouseDown(object sender, MouseEventArgs e)
        {
            //Check if left or right click is pressed down
            if (e.Button == MouseButtons.Left)
            {
                Leftclick = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                Rightclick = true;
            }



            if (Statelist != null)
            {
                //Check to make sure mouse press was within cell grid
                Boolean checkX = Statelist.GetLength(0) * SqrSize > e.X;
                Boolean checkY = Statelist.GetLength(1) * SqrSize + 30 > e.Y;

                // if so then find what cell was clicked and change cell state dependent on click type
                if (checkX && checkY)
                {
                    int sqrx = e.X / SqrSize;
                    int sqry = (e.Y - 30) / SqrSize;

                    if (Leftclick)
                    {
                        Statelist[sqrx, sqry] = true;
                    }

                    if (Rightclick)
                    {
                        Statelist[sqrx, sqry] = false;
                    }

                    DrawAll();



                }
            }




        }
        //Mouse mouve event allowing you to draw with your mouse dead or alive cells
        private void Form1MouseMove(object sender, MouseEventArgs e)
        {
            if (Statelist == null) return;
            Boolean checkX = (Statelist.GetLength(0) * SqrSize > e.X && e.X > 0);
            Boolean checkY = (Statelist.GetLength(1) * SqrSize + 30 > e.Y && e.Y > 0);

            if (!checkX || !checkY) return;
            int sqrx = e.X / SqrSize;
            int sqry = (e.Y - 28) / SqrSize;

            if (Leftclick)
            {
                Statelist[sqrx, sqry] = true;
            }

            if (Rightclick)
            {
                Statelist[sqrx, sqry] = false;
            }

            DrawAll();
        }
        //mouse event for mouse relase Change apporiate click booleans
        private void Form1MouseUp(object sender, MouseEventArgs e)
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
        //Randomized every cell in the grid and redraws all celss
        private void CmdRandomClick(object sender, EventArgs e)
        {
            int tempx = 0;
            int tempy = 0;
            int width = Convert.ToInt32(txtWidth.Text);
            int hieght = Convert.ToInt32(txtHieght.Text);


            txtWidth.Text = Convert.ToString(width);
            txtHieght.Text = Convert.ToString(hieght);

            Random rnd = new Random();
            while (tempy < hieght)
            {
                while (tempx < width)
                {
                    Statelist[tempx, tempy] = rnd.Next(0, 10) > 5;

                    tempx = tempx + 1;
                }
                tempy = tempy + 1;
                tempx = 0;

            }
            DrawAll();


        }



        //Steps the Simulation every timer tick
        private void Timer1Tick(object sender, EventArgs e)
        {
            Step();
        }




    }



}



