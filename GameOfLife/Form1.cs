using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Text;

using System.IO;

using System.Threading;
using System.Collections;

using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpPathFinding.cs;
//using Algorithms;
//using System.Globalization;


namespace rimworldripoff
{
    public partial class Form1 : Form
    {
        public int totalticks = 0;
        public int curbuild = 1;
        public Stopwatch totaltime = new Stopwatch();
        public int tps = 0;
        public int lastsec = 0;
        public int lastticks = 0;
        public Point lastmousecell = new Point();
        public bool mousedown = false;
        public static Board board;
        readonly Random rand = new Random();
        public Bitmap bmp;
        public Graphics gfx;
        public int totalparticles = 0;
        public Point lastmousedown = new Point();
        public int lasttickss;


        //  private Thread mPFThread = null;
        // private IPathFinder mPathFinder = null;
        // private int mDelay;
        //     private bool mPaused;
        //   private bool mRunning;


        //   
        //  int partid;
        //  Point xy;
        //Point oldxy;
      //  public int[,] grid;



        //  public Bitmap bmp;
        //     Graphics gfx;
        public Form1()
        {

            InitializeComponent();
            SizeNud.Value = 10;
            Reset(0);
        }
       /* public int NextPowerOf2(int x)
        {

            return (int)Math.Pow(2, (int)Math.Log(x - 1, 2));

                while (number > 0)
                {
                    pos++;
                    number = number >> 1;
                }


        }*/
        // GUI actions that require a board reset
        private void ResetButton_Click(object sender, EventArgs e) { Reset(0); }
        private void pictureBox1_SizeChanged(object sender, EventArgs e) { }
        private void SizeNud_ValueChanged(object sender, EventArgs e) { }
        private void DensityNud_ValueChanged(object sender, EventArgs e) { }

        private void Reset(int gamemode)
        {
         /*   //   int tempx = pictureBox1.Width / (int)SizeNud.Value, tempy = pictureBox1.Height / (int)SizeNud.Value, lessorx = 0, lessory = 0;;
            if (Math.Log(pictureBox1.Width / (int)SizeNud.Value, 2) != (int)Math.Log(pictureBox1.Width / (int)SizeNud.Value, 2))
            {
                pictureBox1.Width = NextPowerOf2(pictureBox1.Width / (int)SizeNud.Value) * (int)SizeNud.Value;// 1024 + (int)SizeNud.Value;//
            }
            if (Math.Log(pictureBox1.Height / (int)SizeNud.Value, 2) != (int)Math.Log(pictureBox1.Height / (int)SizeNud.Value, 2))    
                {
                pictureBox1.Height = NextPowerOf2(pictureBox1.Height / (int)SizeNud.Value) * (int)SizeNud.Value;//512 + (int)SizeNud.Value; //
            }*/
            board = new Board(pictureBox1.Width, pictureBox1.Height, (int)SizeNud.Value);
            try
            {
                board.redrawcells.Clear();

            }
            catch { }
        
            //grid = new int[pictureBox1.Width / board.CellSize, pictureBox1.Height / board.CellSize];
            totalparticles = 0;
            totalticks = 0;
            totaltime.Restart();

            if (gamemode == 0)
            {


                for (int i = 1; i < pictureBox1.Width / board.CellSize - 1; i++)
                {
                    for (int e = 1; e < pictureBox1.Height / board.CellSize - 1; e++)
                    {
                        if (rand.NextDouble() < (double)DensityNud.Value / 100)
                        {
                            CreateParticle(2, new Point(i, e));

                        }
                    }
                }

            }






            //     board = new Board(pictureBox1.Width, pictureBox1.Height, (int)SizeNud.Value);

            for (int i = 0; i < pictureBox1.Width / board.CellSize; i++)
            {
                for (int e = 0; e < pictureBox1.Height / board.CellSize; e++)
                {
                    if (e == 0 || i == 0 || i == (pictureBox1.Width / board.CellSize) - 1 || e == (pictureBox1.Height / board.CellSize) - 1)
                    {
                        CreateParticle(2, new Point(i, e));



                    }
                    else if(!board.Cells[i,e].Alive)
                    {
                        CreateParticle(0, new Point(i, e));
                    }
                }
            }
            //   board.Randomize((double)DensityNud.Value / 100);

            //  Render(true, 0, new Point(0,0), new int[0]);

        }

        //  private void Reset(int gamemode)
        //   {


        /*     
          //  int yOffset = (board.Rows - lines.Length) / 2;
         //    int xOffset = (board.Columns - lines[0].Length) / 2;


             for (int y = 0; y < lines.Length; y++)
                 for (int x = 0; x < lines[y].Length; x++)
                     try
                     {
                         board.Cells[x + xOffset, y + yOffset].Alive = lines[y].Substring(x, 1) == "X";
                     }
                     catch { }

        //Reset(randomize: false);
      //  string[] lines = startingPattern.Split('\n');
        for (int y = 0; y < lines.Length; y++)
            for (int x = 0; x < lines[y].Length; x++)
                try
                {
                    board.Cells[x + xOffset, y + yOffset].Alive;
                }
                catch { }*/
        //   Render();
        //   }

        // adjustments to timer
        private void RunCheckbox_CheckedChanged(object sender, EventArgs e) { timer1.Enabled = RunCheckbox.Checked; }
        private void DelayNud_ValueChanged(object sender, EventArgs e) { }// timer1.Interval = (int)DelayNud.Value; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(board.Width, board.Height);
            gfx = Graphics.FromImage(bmp);

            //     Bitmap bmp = new Bitmap(board.Width, board.Height);
            //  Graphics gfx = Graphics.FromImage(bmp);
            if (lastsec != (int)totaltime.Elapsed.TotalSeconds)
                try
                {
                    tps = lastticks;
                    lastticks = 0;
                }
                catch { }


            label4.Text = totalticks.ToString();

            label6.Text = tps.ToString();


            // if(tps != (int)DelayNud.Value)
            //   {
            //        timer1.Interval = (int)Convert.ToDouble(1 / DelayNud.Value * 1000);
            //    }
            lastsec = (int)totaltime.Elapsed.TotalSeconds;
            lastticks++;
            totalticks++;
            //  board.Advance();
            for (int cellnumb = 0; cellnumb < board.redrawcells.Count; cellnumb++)
            {

                UpdateCell(board.redrawcells[cellnumb][1], new Point(board.redrawcells[cellnumb][2], board.redrawcells[cellnumb][3]));
              }
/*            try
            {
                for (int xbyte = 0; xbyte < pictureBox1.Width / board.CellSize; xbyte++)
                {
                    for (int ybyte = 0; ybyte < pictureBox1.Height / board.CellSize; ybyte++)
                    {
                        if (board.Cells[xbyte, ybyte].Alive)
                        {
                            grid[xbyte, ybyte] = 1;
                        }
                        else
                        {
                            grid[xbyte, ybyte] = 0;
                        }
                    }
                }
            }
            catch { }*/

            Render(true, 0, new Point(0, 0), new int[0]);
            //   board.redrawcells.Clear();
        }

        // drawing the board
        public void Render(bool general, int type, Point xy, int[] color)
        {

            //   using (var brush = new SolidBrush(Color.FromArgb()))
            //  {
            //    gfx.Clear(ColorTranslator.FromHtml("#2f3539"));

            //   var cellSize = (GridCheckbox.Checked && board.CellSize > 1) ?
            //      new Size(board.CellSize - 1, board.CellSize - 1) :
            //           new Size(board.CellSize, board.CellSize);
            try
            {
                if (general)
                {

                    /*   for (int col = 0; col < board.Columns; col++)
                       {
                           for (int row = 0; row < board.Rows; row++)
                           {*/
                    // var cell = board.Cells[col, row];
                    for (int cellnumber = 0; cellnumber < board.redrawcells.Count; cellnumber++)
                    {
                        Point cellxy = new Point(board.redrawcells[cellnumber][2], board.redrawcells[cellnumber][3]);
                        //  int curpartid = board.redrawcells[cellnumber][2];
                        var cell = board.Cells[cellxy.X, cellxy.Y];

                        //    board.redrawcells[cellnumber]
                        //         var cellLocation = new Point(,);
                        //    cell.type = curbuild;
                        //   cell.xy = cellLocation;
                        //  cell.life = 100;

                        // var cellRect = new Rectangle(cellLocation, 2);
                        //     var cellRect = new Rectangle(cellxy, cellSize);
                        gfx.FillRectangle(new SolidBrush(Color.FromArgb(cell.colour[0], cell.colour[1], cell.colour[2], cell.colour[3])), new Rectangle(new Point(cellxy.X * board.CellSize, cellxy.Y * board.CellSize), cell.PartSize));
                    }
                    //   else if(!cell.Alive)
                    //   {
                    //         var cellLocation = new Point(col * board.CellSize, row * board.CellSize);
                    //        var cellRect = new Rectangle(cellLocation, cellSize);
                    //   gfx.FillRectangle(new SolidBrush(Color.Black), cellRect);
                    //    }
                    //     }
                    //  }
                    //  pictureBox1.Image?.Dispose();
                    //    pictureBox1.Image = (Bitmap)bmp.Clone();

                    // }

                }
                else //if (color != null)
                {



                    /*   for (int col = 0; col < board.Columns; col++)
                       {
                           for (int row = 0; row < board.Rows; row++)
                           {*/

                    // if (cell.redraw)








                    var cell = board.Cells[xy.X, xy.Y];

                    //    {
                    //   cell.xy = cellLocation;
                    //  cell.life = 100;

                    // var cellRect = new Rectangle(cellLocation, 2);






                    var cellLocation = new Point(xy.X * board.CellSize, xy.Y * board.CellSize);
                    //  cell.type = curbuild;



                    var cellRect = new Rectangle(cellLocation, cell.PartSize);
                    gfx.FillRectangle(new SolidBrush(Color.FromArgb(cell.colour[0], cell.colour[1], cell.colour[2], cell.colour[3])), cellRect);
                    // }










                    //   else if(!cell.Alive)
                    //   {
                    //         var cellLocation = new Point(col * board.CellSize, row * board.CellSize);
                    //        var cellRect = new Rectangle(cellLocation, cellSize);
                    //         gfx.FillRectangle(new SolidBrush(Color.Black), cellRect);
                    //    }
                    //     }
                    //}


                    //  }
                    //  }

                    //    else
                    // {

                }
                //    pictureBox1.Image?.Dispose();

            }
            catch { }
            pictureBox1.Image = (Bitmap)bmp.Clone();
        }

        private void GliderButton_Click(object sender, EventArgs e)
        {


            Reset(1);

        }

        private void RowButton_Click(object sender, EventArgs e)
        {
            curbuild = 1;
        }

        private void SpaceshipButton_Click(object sender, EventArgs e)
        {
            curbuild = 2;
        }

        private void GunButton_Click(object sender, EventArgs e)
        {
            curbuild = 3;
        }

        /*        private void pictureBox1_Click(object sender, EventArgs e)
                {


                }*/

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                MouseEventArgs me = (MouseEventArgs)e;
                /*   


                       if (lastmousecell != new Point(me.Location.X / board.CellSize, me.Location.Y / board.CellSize))
                       {
                           using (var bmp = new Bitmap(board.Width, board.Height))
                           using (var gfx = Graphics.FromImage(bmp))
                           {
                               //    gfx.Clear(ColorTranslator.FromHtml("#2f3539"));

                               var cellSize = new Size(board.CellSize, board.CellSize);

                           //    for (int col = 0; col < board.Columns; col++)
                             //  {
                                  // for (int row = 0; row < board.Rows; row++)
                                 //  {

                                      // var cell = board.Cells[col, row];

                                       var cellLocation = new Point(me.Location.X, me.Location.Y);

                                       // var cellRect = new Rectangle(cellLocation, 2);
                                       var cellRect = new Rectangle(cellLocation, cellSize);
                                       var cellRectold = new Rectangle(lastmousecell, cellSize);
                                       gfx.DrawRectangle(new Pen(Color.Black), cellRectold);
                                       gfx.DrawRectangle(new Pen(Color.LightGray), cellRect);


                              //     }
                          //     }

                                  //  pictureBox1.Image?.Dispose();
                            //     pictureBox1.Image = (Bitmap)bmp.Clone();
                           }
                       }



       */

                if (lastmousecell != me.Location && mousedown)
                {
                    MouseHandle(me.Location, me.Button);
                  
                }
                // lastmousedown = mousegrid;


                lastmousecell = new Point(me.Location.X / board.CellSize, me.Location.Y / board.CellSize);

                label5.Text = (me.Location.X / board.CellSize, me.Location.Y / board.CellSize).ToString();
                label7.Text = board.Cells[lastmousecell.X, lastmousecell.Y].type.ToString();
                if (lastmousecell != me.Location || lasttickss + 10 < totalticks)
                    {
                    richTextBox1.SuspendLayout();
                    richTextBox1.Clear();
                    richTextBox1.AppendText(Environment.NewLine + "Fullname " + board.Cells[lastmousecell.X, lastmousecell.Y].Fullname + Environment.NewLine + "xy " + board.Cells[lastmousecell.X, lastmousecell.Y].xy.ToString() + Environment.NewLine + "partid " + board.Cells[lastmousecell.X, lastmousecell.Y].partid + Environment.NewLine + "redrawid " + board.Cells[lastmousecell.X, lastmousecell.Y].redrawid + Environment.NewLine + "vx " + board.Cells[lastmousecell.X, lastmousecell.Y].vx + Environment.NewLine + "vy " + board.Cells[lastmousecell.X, lastmousecell.Y].vy) ;
                    richTextBox1.ResumeLayout();
                    lasttickss = totalticks;
                }








            }
            catch { }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            MouseEventArgs me = (MouseEventArgs)e;
            //      MouseEventArgs me = (MouseEventArgs)e;
            //     Point coordinates = me.Location;
            //   Point mousegrid = new Point(coordinates.X / board.CellSize, coordinates.Y / board.CellSize);
            MouseHandle(me.Location, me.Button);
            // me.
        }
        public void MouseHandle(Point mousecoords, MouseButtons mousebutton)
        {
            //      Point coordinates = me.Location;
            Point mousegrid = new Point(mousecoords.X / board.CellSize, mousecoords.Y / board.CellSize);



            if (mousebutton == MouseButtons.Left)
            {

                //  label5.Text = mousegrid.ToString();
                switch (curbuild)
                {
                    case 1:
                        CreateParticle(1, mousegrid);






                        break;
                    case 2:
                        CreateParticle(2, mousegrid);






                        break;
                    case 3:


                        string Pattern = "XX\n" +
                                         "-X\n" +
                                         "XX";
                        string[] lines = Pattern.Split('\n');
                        /*     for (int y = lines.Length; y > lines.Length; y--)
                                 for (int x = lines.Length; x > lines[y].Length; x--)
                                     try
                                     {
                                         if (lines[y].Substring(x, 1) == "X")
                                         {


                                         }
                                         //board.Cells[x + mousegrid.X, y + mousegrid.Y].Alive = lines[y].Substring(x, 1) == "X";
                                     }
                                     catch { }*/

                        //Reset(randomize: false);
                        //  string[] lines = startingPattern.Split('\n');
                        for (int y = 0; y < lines.Length; y++)
                            for (int x = 0; x < lines[y].Length; x++)
                                try
                                {
                                    // board.Cells[mousegrid.X, mousegrid.Y].Alive = true;
                                    //     board.Cells[mousegrid.X, mousegrid.Y].type = 2;
                                    //   board.Cells[mousegrid.X, mousegrid.Y].life = 100;
                                    CreateParticle(3, new Point(mousegrid.X + x, mousegrid.Y + y));
                                }
                                catch { }


                        //    Render();
                        break;
                }

            }
            if (mousebutton == MouseButtons.Right)
            {
                //   board.Cells[mousegrid.X, mousegrid.Y].Alive = true;
                //    board.Cells[mousegrid.X, mousegrid.Y].type = 1;
                //    board.Cells[mousegrid.X, mousegrid.Y].life = 0;
                CreateParticle(0, mousegrid);






            }

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        //   private void worker_search()
        //  {

        //   }


     /*   public void Movecellcell(int partid, Point xy)
            {
            GodDamnStatics(partid, xy);
        }
*/


        public void MoveCell(int partid, Point xy, Point oldxy)
        {
            
         if(board.Cells[xy.X, xy.Y].type == 0 && board.Cells[xy.X, xy.Y].partid != partid)
            {
               // Point oldxy = new Point(board.partids[partid][1], board.partids[partid][2]);
                board.Cells[xy.X, xy.Y].Name = board.Cells[oldxy.X, oldxy.Y].Name;
                board.Cells[xy.X, xy.Y].Fullname = board.Cells[oldxy.X, oldxy.Y].Fullname;
                board.Cells[xy.X, xy.Y].Alive = board.Cells[oldxy.X, oldxy.Y].Alive;
                board.Cells[xy.X, xy.Y].type = board.Cells[oldxy.X, oldxy.Y].type;
                board.Cells[xy.X, xy.Y].life = board.Cells[oldxy.X, oldxy.Y].life;
                board.Cells[xy.X, xy.Y].PartSize = board.Cells[oldxy.X, oldxy.Y].PartSize;

                board.Cells[xy.X, xy.Y].xy = xy;
                board.Cells[xy.X, xy.Y].vx = 0;//board.Cells[oldxy.X, oldxy.Y].vx;
                board.Cells[xy.X, xy.Y].vy = 0;//board.Cells[oldxy.X, oldxy.Y].vy;
                board.Cells[xy.X, xy.Y].colour = board.Cells[oldxy.X, oldxy.Y].colour;
                board.Cells[xy.X, xy.Y].color = board.Cells[oldxy.X, oldxy.Y].color;
                board.Cells[xy.X, xy.Y].path = board.Cells[oldxy.X, oldxy.Y].path;
                board.Cells[xy.X, xy.Y].pathfinding = board.Cells[oldxy.X, oldxy.Y].pathfinding;
                board.Cells[xy.X, xy.Y].created = true;
                board.Cells[xy.X, xy.Y].partid = board.Cells[oldxy.X, oldxy.Y].partid;

                //   board.partids.Add(new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                //board.redrawcells.RemoveAt(board.Cells[oldxy.X, oldxy.Y].partid);
                board.redrawcells.Add(new int[4] { board.Cells[xy.X, xy.Y].redrawid, board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
             //   board.redrawcells.Add(new int[4] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                board.Cells[xy.X, xy.Y].redrawid = board.redrawcells.Count - 1;
                CreateParticle(0, oldxy);
                // board.Cells[oldxy.X, oldxy.Y] = 


            }
        }



        public void CreateParticle(int type, Point xy)
        {
            try
            {
                if (board.Cells[xy.X, xy.Y].type == 0 || type == 0)
                {
                    //  type = rand.Next(1, 4);
                    try
                    {
                        if (board.Cells[xy.X, xy.Y].type == 0 && board.redrawcells[board.Cells[xy.X, xy.Y].partid][0] != 0)
                        {

                            //     board.redrawcells.RemoveAt(board.Cells[xy.X, xy.Y].partid);

                        }

                    }
                    catch { }
                    switch (type)
                    {
                        case 0:
                            board.Cells[xy.X, xy.Y].Name = "Nothing";
                            board.Cells[xy.X, xy.Y].Fullname = "Nothing";
                            board.Cells[xy.X, xy.Y].Alive = false;
                            board.Cells[xy.X, xy.Y].type = 0;
                            board.Cells[xy.X, xy.Y].life = 0;
                            board.Cells[xy.X, xy.Y].PartSize = new Size(board.CellSize, board.CellSize);
                            //board.Cells[xy.X, xy.Y].AliveNext = false;
                            board.Cells[xy.X, xy.Y].xy = new Point(xy.X, xy.Y);
                            board.Cells[xy.X, xy.Y].vx = 0;
                            board.Cells[xy.X, xy.Y].vy = 0;
                            board.Cells[xy.X, xy.Y].colour = new int[] { 255, 0, 0, 0 };
                            board.Cells[xy.X, xy.Y].color = new int[] { 255, 0, 0, 0 };
                            board.Cells[xy.X, xy.Y].path = null;
                            board.Cells[xy.X, xy.Y].pathfinding = false;
                            //     board.Cells[xy.X, xy.Y].redraw = true;
                            board.Cells[xy.X, xy.Y].created = false;
                            //totalparticles + 1;
                            // board.partids.Add(new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });


                            //    board.redrawcells.Add(new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                            //    totalparticles++;
                            //  Render(false, type, xy, board.Cells[xy.X, xy.Y].color);
                            try
                            {

                                if (board.Cells[xy.X, xy.Y].partid != 0 || board.Cells[xy.X, xy.Y].redrawid != 0)
                                {

                                    int[] partidredraw = new int[4] { board.Cells[xy.X, xy.Y].redrawid, board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y };
                                    int[] partidlistremove = new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y };
                                    int partidilist = board.partids.FindIndex(le => le[0] == partidlistremove[0] && le[1] == partidredraw[1] && le[2] == partidredraw[2]);
                                    int partidinredrawlist = board.redrawcells.FindIndex(le => le[0] == partidredraw[0] && le[1] == partidredraw[1]);//board.Cells[xy.X, xy.Y].redrawid);
                                    board.redrawcells.RemoveAt(partidinredrawlist);
                                    board.partids.RemoveAt(partidilist);
                                    board.Cells[xy.X, xy.Y].partid = 0;
                                    board.Cells[xy.X, xy.Y].redrawid = 0;
                                    // totalparticles--;
                                }
                            }
                            catch { }
                            board.Cells[xy.X, xy.Y].partid = 0;
                            board.Cells[xy.X, xy.Y].redrawid = 0;
                            break;
                        case 1:

                            board.Cells[xy.X, xy.Y].Name = "Test";
                            board.Cells[xy.X, xy.Y].Fullname = "Test Char";
                            board.Cells[xy.X, xy.Y].Alive = true;
                            board.Cells[xy.X, xy.Y].type = 1;
                            board.Cells[xy.X, xy.Y].life = 100;
                            board.Cells[xy.X, xy.Y].PartSize = new Size(board.CellSize / 2, board.CellSize / 2);
                            // board.Cells[xy.X, xy.Y].AliveNext;
                            board.Cells[xy.X, xy.Y].xy = new Point(xy.X, xy.Y);
                            board.Cells[xy.X, xy.Y].vx = 0;
                            board.Cells[xy.X, xy.Y].vy = 0;
                            board.Cells[xy.X, xy.Y].colour = new int[] { 127, 144, 238, 144 };
                            board.Cells[xy.X, xy.Y].color = new int[] { 127, 144, 238, 144 };
                            board.Cells[xy.X, xy.Y].path = null;
                            board.Cells[xy.X, xy.Y].pathfinding = false;



                            //  board.Cells[xy.X, xy.Y].redraw = true;
                            board.Cells[xy.X, xy.Y].created = false;
                            board.Cells[xy.X, xy.Y].partid = totalparticles + 1;
                            board.Cells[xy.X, xy.Y].redrawid = board.redrawcells.Count;
                            board.partids.Add(new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                            board.redrawcells.Add(new int[4] { board.Cells[xy.X, xy.Y].redrawid, board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });

                            totalparticles++;
                            //  Render(false, type, xy, board.Cells[xy.X, xy.Y].color);



                            break;
                        case 2:

                            board.Cells[xy.X, xy.Y].Alive = true;
                            board.Cells[xy.X, xy.Y].type = 2;
                            board.Cells[xy.X, xy.Y].life = 10000;
                            board.Cells[xy.X, xy.Y].Name = "Wall";
                            board.Cells[xy.X, xy.Y].Fullname = "Strong wall";
                            board.Cells[xy.X, xy.Y].PartSize = new Size(board.CellSize, board.CellSize);
                            // board.Cells[xy.X, xy.Y].AliveNext;
                            board.Cells[xy.X, xy.Y].xy = new Point(xy.X, xy.Y);
                            board.Cells[xy.X, xy.Y].vx = 0;
                            board.Cells[xy.X, xy.Y].vy = 0;
                            board.Cells[xy.X, xy.Y].colour = new int[] { 127, 127, 127, 127 };
                            board.Cells[xy.X, xy.Y].color = new int[] { 127, 127, 127, 127 };
                            // board.Cells[xy.X, xy.Y].redraw = true;
                            board.Cells[xy.X, xy.Y].path = null;
                            board.Cells[xy.X, xy.Y].pathfinding = false;



                            board.Cells[xy.X, xy.Y].created = false;
                            board.Cells[xy.X, xy.Y].partid = totalparticles + 1;
                            board.Cells[xy.X, xy.Y].redrawid = board.redrawcells.Count;
                            board.partids.Add(new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                            board.redrawcells.Add(new int[4] { board.Cells[xy.X, xy.Y].redrawid, board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                            totalparticles++;
                            //    Form1.board.redrawcells.Add(new int[3] { xy.X, xy.Y, board.Cells[xy.X, xy.Y].partid });

                            //     Render(false, type, xy, board.Cells[xy.X, xy.Y].color);

                            break;
                        case 3:

                            board.Cells[xy.X, xy.Y].Alive = true;
                            board.Cells[xy.X, xy.Y].Name = "Sandbag";
                            board.Cells[xy.X, xy.Y].Fullname = "Sandbag";

                            board.Cells[xy.X, xy.Y].type = 3;
                            board.Cells[xy.X, xy.Y].PartSize = new Size(board.CellSize / 10 * 7, board.CellSize / 10 * 5);
                            board.Cells[xy.X, xy.Y].life = 100;
                            // board.Cells[xy.X, xy.Y].AliveNext;
                            board.Cells[xy.X, xy.Y].xy = new Point(xy.X, xy.Y);
                            board.Cells[xy.X, xy.Y].vx = 0;
                            board.Cells[xy.X, xy.Y].vy = 0;
                            board.Cells[xy.X, xy.Y].colour = new int[] { 127, 76, 69, 50 };
                            board.Cells[xy.X, xy.Y].color = new int[] { 127, 76, 69, 50 };
                            board.Cells[xy.X, xy.Y].path = null;
                            board.Cells[xy.X, xy.Y].pathfinding = false;
                            board.Cells[xy.X, xy.Y].counter = 0;
                            board.Cells[xy.X, xy.Y].speedtimer = 5;
                            // board.Cells[xy.X, xy.Y].redraw = true;
                            board.Cells[xy.X, xy.Y].created = false;


                            board.Cells[xy.X, xy.Y].partid = totalparticles + 1;
                            board.Cells[xy.X, xy.Y].redrawid = board.redrawcells.Count;

                            board.partids.Add(new int[3] { board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                            board.redrawcells.Add(new int[4] { board.Cells[xy.X, xy.Y].redrawid, board.Cells[xy.X, xy.Y].partid, xy.X, xy.Y });
                            totalparticles++;

                            //     Render(false, type, xy, board.Cells[xy.X, xy.Y].color);

                            break;
                            /* case 1:


                                 string Pattern = "XX\n" +
                                                  "-X\n" +
                                                  "XX";
                                 string[] lines = Pattern.Split('\n');
                                 for (int y = lines.Length; y > lines.Length; y--)
                                     for (int x = lines.Length; x > lines[y].Length; x--)
                                         try
                                         {
                                             board.Cells[x + mousegrid.X, y + mousegrid.Y].Alive = lines[y].Substring(x, 1) == "X";
                                         }
                                         catch { }

                                 //Reset(randomize: false);
                                 //  string[] lines = startingPattern.Split('\n');
                                 for (int y = 0; y < lines.Length; y++)
                                     for (int x = 0; x < lines[y].Length; x++)
                                         try
                                         {
                                             board.Cells[mousegrid.X, mousegrid.Y].Alive = true;
                                             board.Cells[mousegrid.X, mousegrid.Y].type = 2;
                                             board.Cells[mousegrid.X, mousegrid.Y].life = 100;
                                         }
                                         catch { }


                                 //    Render();
                                 break;*/
                    }
                }
                //  board.redrawcells.Sort();
            }
            catch { }
        }
     

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try {
                DelayNud.Value = trackBar1.Value;
                timer1.Interval = (int)Convert.ToDouble(1 / DelayNud.Value * 1000);
                //DelayNud.Value = trackBar1.Value;
                   
            } 
            catch { }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            curbuild = domainUpDown1.SelectedIndex;
            /*switch (domainUpDown1.SelectedIndex)
            {
                case 0:
                    
                    break;
                case 1:
                   
                    break;
                case 2:

                    break;
                case 3:

                    break;
            }*/

            
           
        }
        public void UpdateCell(int partid, Point xy)
        {
            Point oneone = new Point(1, 1);
            try
            {
            if (!board.Cells[xy.X, xy.Y].created)
            {
                    
                 //  pathfindthread.Runpf();
               // board.Cells[xy.X, xy.Y].xy = new Point(board.partids[partid][1], board.partids[partid][2]);
                board.Cells[xy.X, xy.Y].created = true;
            }

            if(!board.Cells[xy.X, xy.Y].pathfinding && board.Cells[xy.X, xy.Y].path == null && board.Cells[xy.X, xy.Y].type == 1 && oneone != xy)
                {
                    board.Cells[xy.X, xy.Y].pathfinding = true;
                    Runpf(board.Cells[xy.X, xy.Y].partid, oneone, xy, false);
                }

           if(board.Cells[xy.X, xy.Y].path != null && board.Cells[xy.X, xy.Y].counter > 10 && board.Cells[xy.X, xy.Y].vx == 0 && board.Cells[xy.X, xy.Y].vy == 0)
                {
                  //  if (board.Cells[xy.X, xy.Y].secpath == null)
               //     {

                        int positiononpath = board.Cells[xy.X, xy.Y].path.IndexOf(new GridPos(xy.X, xy.Y));
                        if (board.Cells[xy.X, xy.Y].path.Count > positiononpath && positiononpath >= 0)
                        {
                            Point newvxy = new Point(xy.X - board.Cells[xy.X, xy.Y].path[positiononpath + 1].x, xy.Y - board.Cells[xy.X, xy.Y].path[positiononpath + 1].y);
                            board.Cells[xy.X, xy.Y].vx -= newvxy.X;
                            board.Cells[xy.X, xy.Y].vy -= newvxy.Y;
                            board.Cells[xy.X, xy.Y].counter = 0;
                        }
                        else if(board.Cells[xy.X, xy.Y].path.Count == positiononpath && oneone == xy)
                        {
                            board.Cells[xy.X, xy.Y].path = null;
                        }
                                
                        if (positiononpath == -1)
                        {
                          //  board.Cells[xy.X, xy.Y].pathfinding = true;
                           // Runpf(board.Cells[xy.X, xy.Y].partid, new Point(1, 1), xy, true);
                        }
               //     }
              /*      else
                    {
                        int positiononpathsec = board.Cells[xy.X, xy.Y].secpath.IndexOf(new GridPos(xy.X, xy.Y));
                        if (board.Cells[xy.X, xy.Y].secpath.Count > positiononpathsec && positiononpathsec >= 0)
                        {
                            Point newvxy = new Point(xy.X - board.Cells[xy.X, xy.Y].secpath[positiononpathsec + 1].x, xy.Y - board.Cells[xy.X, xy.Y].secpath[positiononpathsec + 1].y);
                            board.Cells[xy.X, xy.Y].vx += newvxy.X;
                            board.Cells[xy.X, xy.Y].vy += newvxy.Y;
                            board.Cells[xy.X, xy.Y].counter = 0;
                        }
                        else if (board.Cells[xy.X, xy.Y].secpath.Count == positiononpathsec || positiononpathsec == -1)
                        {
                            board.Cells[xy.X, xy.Y].secpath = null;
                        }
                        // if (positiononpath == -1)
                        //    {
                        //           Runpf(board.Cells[xy.X, xy.Y].partid, new Point(1, 1), xy, true);
                        //     }
                    }*/
                    
                }
                //  if (!created)
                //    Create();

          /*      if (board.Cells[xy.X, xy.Y].type == 1)
                    switch (rand.Next(1, 3))
                    {
                        case 1:
                            board.Cells[xy.X, xy.Y].vx++;
                            break;
                 //       case 2:
                   //         board.Cells[xy.X, xy.Y].vy++;
                 //           break;
                        case 3:
                            board.Cells[xy.X, xy.Y].vx--;
                            break;
                        case 2:
                            board.Cells[xy.X, xy.Y].vy--;
                            break;
                    }
                /*            //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                            //Any live cell with more than three live neighbours dies, as if by overpopulation.
                            //Any live cell with two or three live neighbours lives on to the next generation.
                            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.*/

                //      int liveNeighbors = neighbors.Where(x => x.IsAlive).Count();

                //       if (IsAlive)
                //         IsAliveNext = liveNeighbors == 2 || liveNeighbors == 3;
                //      else
              /*  if (board.Cells[xy.X, xy.Y].partid != board.Cells[xy.X, xy.Y].partid && board.Cells[xy.X, xy.Y].type == 0)
                {
                    board.Cells[xy.X, xy.Y].xy = CellMovement(xy, 0, 0, board.Cells[xy.X, xy.Y].partid, new Point(board.partids[board.Cells[xy.X, xy.Y].partid][1], board.partids[board.Cells[xy.X, xy.Y].partid][2]));
                }*/
                if (Math.Abs(board.Cells[xy.X, xy.Y].vx) > 0 || Math.Abs(board.Cells[xy.X, xy.Y].vy) > 0 && board.Cells[xy.X, xy.Y].speedtimer > board.Cells[xy.X, xy.Y].speeddelay)
                {
                    board.Cells[xy.X, xy.Y].xy = CellMovement(board.Cells[xy.X, xy.Y].xy, board.Cells[xy.X, xy.Y].vx, board.Cells[xy.X, xy.Y].vy);
                    //  Form1 form1 = new Form1();
                   MoveCell(partid, board.Cells[xy.X, xy.Y].xy, xy);

                    board.Cells[xy.X, xy.Y].vx = 0;
                    board.Cells[xy.X, xy.Y].vy = 0;
                    //xy = new Point(xy.X + vx, xy.Y + vy);
                    //    redraw = true;
                }
                // if(board.Cells[xy.X, xy.Y].xy != xy)
                //  {
                //        MoveCell(partid, board.Cells[xy.X, xy.Y].xy, xy);
                //     }


                // if()




                //  if (life > 0)
                //   {
                //   Form1.board.redrawcells.Add(new int[3] { xy.X, xy.Y, partid });
                //   AliveNext = true;
                //   redraw = true;
                //   }


                board.Cells[xy.X, xy.Y].speedtimer++;
                board.Cells[xy.X, xy.Y].counter++;
            }
            catch { }

























        }
        public Point CellMovement(Point xy, int vx, int vy)
        {
            Point newxypos = xy;

                if (board.Cells[xy.X + vx, xy.Y + vy].type == 0 && !(xy.X == 0 || xy.Y == 0 || xy.X == (board.Width / board.CellSize) - 1 || xy.Y == (board.Height / board.CellSize) - 1))
                {
                    Point newxy = new Point(xy.X + vx, xy.Y + vy);
                    newxypos = newxy;
                    //   Form1.board.redrawcells.Add(new int[3] { xy.X, xy.Y, partid });
                }
            
         /*   else
            {
                if (board.Cells[newcoord.X, newcoord.Y].type == 0 && !(newcoord.X == 0 || newcoord.Y == 0 || newcoord.X == (board.Width / board.CellSize) - 1 || newcoord.Y == (board.Height / board.CellSize) - 1))
                {
                    Point newxy = new Point(newcoord.X + vx, newcoord.Y + vy);
                    newxypos = newxy;
                    // Form1.board.redrawcells.Add(new int[3] { newcoord.X, newcoord.Y, partid });
                }
            }*/
            return newxypos;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        public void Runpf(int partid, Point oldxy, Point destinationxy, bool secpath)
        {
            pathfindthread pathfindtrheade = new pathfindthread();
            pathfindtrheade.Runpf(partid, oldxy, destinationxy, secpath);
            //   board.Cells.Refresh();
            //  BtnStartStop.Text = STOP;
            //    ToolStrp.Enabled = false;
            //   PnlSettings.Enabled = false;
            //   BtnPause.Enabled = true;

            //  Thread mPFThread = new Thread(RunPathFinder);
            //       mPFThread.Name = "Path Finder Thread";
            //       mPFThread.Start();
        }














        /*public void RunPathFinder(int partid, Point xy, Point newxy)
        {
         //   if (true)
       //     {
                if (!(mPathFinder is PathFinderFast))
                {
                    if (mPathFinder != null)
                        mPathFinder.PathFinderDebug -= new PathFinderDebugHandler(PathFinderDebug);
                byte[,] = new byte[];
                    mPathFinder = new PathFinderFast(PnlGUI.Matrix);
                    mPathFinder.PathFinderDebug += new PathFinderDebugHandler(PathFinderDebug);
                }
     //       }
        *//*    else
            {
                if (!(mPathFinder is PathFinder))
                {
                    if (mPathFinder != null)
                        mPathFinder.PathFinderDebug -= new PathFinderDebugHandler(PathFinderDebug);

                    mPathFinder = new PathFinder(PnlGUI.Matrix);
                    mPathFinder.PathFinderDebug += new PathFinderDebugHandler(PathFinderDebug);
                }
            }*//*

            mPathFinder.Formula = 0;
            mPathFinder.Diagonals = false;
            mPathFinder.HeavyDiagonals = false;
            mPathFinder.HeuristicEstimate = (int)2;
            mPathFinder.PunishChangeDirection = true;//ChkPunishChangeDirection.Checked;
            mPathFinder.TieBreaker = false;//ChkTieBraker.Checked;
            mPathFinder.SearchLimit = (int)100000;//NumSearchLimit.Value;
            mPathFinder.DebugProgress = false;//ChlShowProgress.Checked;
            mPathFinder.ReopenCloseNodes = true;//ChkReopenCloseNodes.Checked;
            mPathFinder.DebugFoundPath = true;

            List<PathFinderNode> path = mPathFinder.FindPath(PnlGUI.Start, PnlGUI.End);
            UpdateTimeLabel(mPathFinder.CompletedTime);

            if (path == null)
                MessageBox.Show("Path Not Found");

//            if (BtnStartStop.Text == STOP)
  //              BtnStartStop_Click(null, EventArgs.Empty);
        }*/

    }


    /*   public static class staticbs
       {
           public static void MoveCells(int partid, Point xy)
           {
               /*   try
                  {
                      if (InvokeRequired)
                      {
                          this.Invoke(null, new object[] { partid, xy});
                          return;
                      }

         //          Form1 form1 = new Form1();

          //     form1.MoveCell(partid, xy);
               //  }
               // catch { }
           }
       }*/
}