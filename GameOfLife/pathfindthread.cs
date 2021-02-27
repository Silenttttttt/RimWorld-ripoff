using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using System.IO;

using System.Threading;
using System.Collections;

using System.ComponentModel;


using EpPathFinding.cs;
using System.Globalization;

namespace rimworldripoff
{
    
    class pathfindthread
    {

        //  private Thread mPFThread;
        //  private IPathFinder mPathFinder = null;
        //   private int mDelay;
        //   private bool mPaused;
        //     private bool mRunning;
      //  BaseGrid searchGrid;
      //  int partid;
       // Point xy;
       // Point destinationxy;
        //byte[,] grid;
        public async void Runpf(int partide, Point destinationxye, Point xye, bool secpath)
        {
            //   board.Cells.Refresh();
            //  BtnStartStop.Text = STOP;
            //    ToolStrp.Enabled = false;
            //   PnlSettings.Enabled = false;
            //   BtnPause.Enabled = true;
           
            /* mPFThread = new Thread(RunPathFinder);
              mPFThread.Name = "PathFinder Thread";
              mPFThread.Start();*/
            await Task.Run(() => RunPathFinder(partide, destinationxye, xye, secpath));
        }














        public async Task RunPathFinder(int partid, Point destinationxy, Point xy, bool secpath)
        {
            await Task.Run(() =>
            {


                //     partid = partide;
                //     destinationxy = destinationxye;
                //     xy = xye;
                //    grid = gridgamer;
                //   if (true)
                //     {
                //    if (!(mPathFinder is PathFinderFast))
                //      {
                //       if (mPathFinder != null)
                //     mPathFinder.PathFinderDebug -= new PathFinderDebugHandler(PathFinderDebug);
                //byte[,] = new byte[];

                //          mPathFinder = new PathFinderFast(grid);
                //    mPathFinder.PathFinderDebug += new PathFinderDebugHandler(PathFinderDebug);
                //     }
                //       }
                /*    else
                    {
                        if (!(mPathFinder is PathFinder))
                        {
                            if (mPathFinder != null)
                                mPathFinder.PathFinderDebug -= new PathFinderDebugHandler(PathFinderDebug);

                            mPathFinder = new PathFinder(PnlGUI.Matrix);
                            mPathFinder.PathFinderDebug += new PathFinderDebugHandler(PathFinderDebug);
                        }
                    }*/

                /*        mPathFinder.Formula = 0;
                        mPathFinder.Diagonals = false;
                        mPathFinder.HeavyDiagonals = false;
                        mPathFinder.HeuristicEstimate = (int)2;
                        mPathFinder.PunishChangeDirection = true;//ChkPunishChangeDirection.Checked;
                        mPathFinder.TieBreaker = false;//ChkTieBraker.Checked;
                        mPathFinder.SearchLimit = (int)100000;//NumSearchLimit.Value;
                        mPathFinder.DebugProgress = false;//ChlShowProgress.Checked;
                        mPathFinder.ReopenCloseNodes = true;//ChkReopenCloseNodes.Checked;
                        mPathFinder.DebugFoundPath = true;*/
              BaseGrid searchGrid = new StaticGrid(Form1.board.Width / Form1.board.CellSize, Form1.board.Height / Form1.board.CellSize);
                try
                {
                    for (int xbyte = 0; xbyte < Form1.board.Width / Form1.board.CellSize; xbyte++)
                    {
                        for (int ybyte = 0; ybyte < Form1.board.Height / Form1.board.CellSize; ybyte++)
                        {
                            if (!Form1.board.Cells[xbyte, ybyte].Alive)
                            {
                                searchGrid.SetWalkableAt(xbyte, ybyte, true);
                            }
          /*                  else
                            {
                                searchGrid.SetWalkableAt(xbyte, ybyte, true);
                            }*/
                        }
                    }
                }
                catch { }
                //    List<PathFinderNode> path = mPathFinder.FindPath(xy, destinationxy);
               GridPos startPos = new GridPos(xy.X, xy.Y);
                GridPos endPos = new GridPos(destinationxy.X, destinationxy.Y);
               JumpPointParam jpParam = new JumpPointParam(searchGrid, startPos, endPos, EndNodeUnWalkableTreatment.ALLOW, DiagonalMovement.OnlyWhenNoObstacles);

                //      jpParam = new JumpPointParam(searchGrid, EndNodeUnWalkableTreatment.ALLOW, DiagonalMovement.OnlyWhenNoObstacles);
                if (!secpath)
                {
                    Form1.board.Cells[xy.X, xy.Y].path = JumpPointFinder.FindPath(jpParam);//path;
                    Form1.board.Cells[xy.X, xy.Y].pathfinding = false;
                }
                else
                {
                    Form1.board.Cells[xy.X, xy.Y].secpath = JumpPointFinder.FindPath(jpParam);//path;
                    Form1.board.Cells[xy.X, xy.Y].pathfinding = false;
                }

                //   UpdateTimeLabel(mPathFinder.CompletedTime);

                //  if (path == null)
                //      MessageBox.Show("Path Not Found");

                //            if (BtnStartStop.Text == STOP)
                //              BtnStartStop_Click(null, EventArgs.Empty);

            });
        }
    }
}
