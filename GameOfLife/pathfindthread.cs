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


using EpPathFinding;
using System.Globalization;

namespace rimworldripoff
{
    
    class pathfindthread
    {

        private Thread mPFThread;
      //  private IPathFinder mPathFinder = null;
     //   private int mDelay;
     //   private bool mPaused;
   //     private bool mRunning;
        int partid;
        Point xy;
        Point destinationxy;
        byte[,] grid;
        public void Runpf(int partide, Point destinationxye, Point xye, byte[,] gridgamer)
        {
            //   board.Cells.Refresh();
            //  BtnStartStop.Text = STOP;
            //    ToolStrp.Enabled = false;
            //   PnlSettings.Enabled = false;
            //   BtnPause.Enabled = true;
            partid = partide;
            destinationxy = destinationxye;
            xy = xye;
            grid = gridgamer;
           mPFThread = new Thread(RunPathFinder);
            mPFThread.Name = "PathFinder Thread";
            mPFThread.Start();
        }














        public void RunPathFinder()
        {
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



            //    List<PathFinderNode> path = mPathFinder.FindPath(xy, destinationxy);
            Form1.board.Cells[xy.X, xy.Y].path = null;//path;
            Form1.board.Cells[xy.X, xy.Y].pathfinding = false;

            //   UpdateTimeLabel(mPathFinder.CompletedTime);

            //  if (path == null)
            //      MessageBox.Show("Path Not Found");

            //            if (BtnStartStop.Text == STOP)
            //              BtnStartStop_Click(null, EventArgs.Empty);
        }
    }
}
