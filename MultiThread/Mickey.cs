using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace MultiThread
{
    public class Mickey : Shapes
    {
        //mickey constructor
        public Mickey(int x, int y, int width, int height, Color color, MultiThread m,  int speed)
        {
            //instance variables
            this.xLoc = x;
            this.yLoc = y;
            this.width = width;
            this.height = height;
            this.color = color;
            this.multiThread = m;
            this.speed = speed;
            
        }

        public override void paint(System.Drawing.Graphics g)
        {
          //  threadName = Thread.CurrentThread.Name;

            try
            {
                //sleep thread based upon chosen speed
                Thread.Sleep(speed);

                //draw over object on screen in white
                g.DrawEllipse(new Pen(Color.White), xLoc -2 , yLoc - 5, width/3, height/3);
                g.DrawEllipse(new Pen(Color.White), xLoc + 11, yLoc - 5, width/3, height/3);
                g.DrawEllipse(new Pen(Color.White), xLoc, yLoc, width, height);

                //lock thread to update location
                lock (typeof(Thread))
                {
                    xLoc = xLoc + directionX;
                    yLoc = yLoc + directionY;
                    //check if it hits the edges of the screen
                    checkEdgeCollision();
                }
                //draw object in new location
                g.DrawEllipse(new Pen(color), xLoc - 2, yLoc - 5, width / 3, height / 3);
                g.DrawEllipse(new Pen(color), xLoc + 11, yLoc - 5, width / 3, height / 3);
                g.DrawEllipse(new Pen(color), xLoc, yLoc, width, height);

            }
            catch(Exception e )
            {
                System.Console.WriteLine("Error in Thread Drawing" + e);
            }


        }

    }
}
