using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading;
using System.Numerics;
using EpPathFinding.cs;
//using Algorithms;
using System.Globalization;


namespace rimworldripoff
{



    public class Cell
    {
        public int partid;
        public bool Alive;
        //  public bool AliveNext;
        public int type;
        public int life;
        public Point xy;
        public int vx;
        public int vy;
        public int[] color = new int[4];
        public string Fullname;
        public string Name;
        public int[] colour = new int[4];
        public int Strtlife;
        // public bool redraw = true;
        public Size PartSize;
        public bool created = false;
        public int redrawid;
        readonly Random rand = new Random();
        public List<GridPos> path;
       // public List<GridPos> secpath;
        public bool pathfinding;
      //  public bool secpathfinding;
        public int counter;
        public int speedtimer;
        public int speeddelay;
        public Point destination;
        public int curpathindex;
        // public string[,] elements = new string[5,20];

        // elements[0,0] = "Air";


        /*  public readonly List<Cell> neighbors = new List<Cell>();



          public void Create()
          {
              xy = new Point(Form1.board.partids[partid][1], Form1.board.partids[partid][2]);
          /*    switch (type)
              {
                  case 0:
                      Colourargb = new int[] { 255, 0, 0, 0 };
                      Fullname = "Nothing";
                      Name = "Nothing";
                      Strtlife = 0;

                      PartSize =  new Size(Form1.board.CellSize, Form1.board.CellSize);// 1 = pixel sizee?
                      break;
                  case 1:
                      Colourargb = new int[] { 127, 127, 127, 127 };
                      Fullname = "Solid wall";
                      Name = "Wall";


                      Strtlife = 10000;

                      break;
                  case 2:
                      Colourargb = new int[] { 127, 144, 238, 144 };
                      Fullname = "IDK";
                      Name = "IDK";
                      Strtlife = 100;
                      break;
                  case 3:
                      Colourargb = new int[] { 127, 76, 69, 50 };
                      Fullname = "Sandbag";
                      Name = "Sandbag";

                      Strtlife = 100;
                      break;
              }


              created = true;
          }

          public void Update()
          {
              try
              {
                  //  if (!created)
                  //    Create();

                  if (type == 1 && rand.Next(1, 10) == 1)
                      switch (rand.Next(1, 4))
                      {
                          case 1:
                              vx++;
                              break;
                         // case 2:
                        //    vy++;
                       //       break;
                          case 3:
                              vx--;
                              break;
                          case 2:
                              vy--;
                              break;
                      }
                  /*            //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                              //Any live cell with more than three live neighbours dies, as if by overpopulation.
                              //Any live cell with two or three live neighbours lives on to the next generation.
                              //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

                  //      int liveNeighbors = neighbors.Where(x => x.IsAlive).Count();

                  //       if (IsAlive)
                  //         IsAliveNext = liveNeighbors == 2 || liveNeighbors == 3;
                  //      else
                  if (partid != Form1.board.Cells[xy.X, xy.Y].partid && Form1.board.Cells[xy.X, xy.Y].type == 0)
                  {
                      xy = MoveCell(xy, 0, 0, partid, new Point(Form1.board.partids[partid][1], Form1.board.partids[partid][2]));
                  }
                  if (Math.Abs(vx) > 0 || Math.Abs(vy) > 0)
                  {
                      xy = MoveCell(xy, vx, vy, partid, new Point(-1, -1));
                    //  Form1 form1 = new Form1();
                      //staticbs.MoveCells(partid, xy);
                      //xy = new Point(xy.X + vx, xy.Y + vy);
                      //    redraw = true;
                  }



                  // if()




                  //  if (life > 0)
                  //   {
                  //   Form1.board.redrawcells.Add(new int[3] { xy.X, xy.Y, partid });
                  //   AliveNext = true;
                  //   redraw = true;
                  //   }




              }
              catch { }

          }

          public void Advance()
          {
              //           Alive = AliveNext;
          }


          public Point MoveCell(Point xy, int vx, int vy, int partid, Point newcoord)
          {
              Point newxypos = xy;

              if (newcoord == new Point(-1,-1))
              {
                  if (Form1.board.Cells[xy.X, xy.Y].type == 0 && !(xy.X == 0 || xy.Y == 0 || xy.X == (Form1.board.Width / Form1.board.CellSize) - 1 || xy.Y == (Form1.board.Height / Form1.board.CellSize) - 1))
                  {
                      Point newxy = new Point(xy.X + vx, xy.Y + vy);
                      newxypos = newxy;
                   //   Form1.board.redrawcells.Add(new int[3] { xy.X, xy.Y, partid });
                  }
              }
              else
              {
                  if (Form1.board.Cells[newcoord.X, newcoord.Y].type == 0 && !(newcoord.X == 0 || newcoord.Y == 0 || newcoord.X == (Form1.board.Width / Form1.board.CellSize) - 1 || newcoord.Y == (Form1.board.Height / Form1.board.CellSize) - 1))
                  {
                      Point newxy = new Point(newcoord.X + vx, newcoord.Y + vy);
                      newxypos = newxy;
                     // Form1.board.redrawcells.Add(new int[3] { newcoord.X, newcoord.Y, partid });
                  }
              }
              return newxypos;
          }
  */
    }
}