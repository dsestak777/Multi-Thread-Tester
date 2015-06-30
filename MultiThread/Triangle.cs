using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace MultiThread
{
    public class Triangle : Shapes
    {

        private String threadName;
      
        
       //Triangle constructor
        public Triangle(int x, int y, int width, int height, Color color, MultiThread m,  int speed)
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
          

            try
            {
                //put thread to sleep based upon chosen speed
                Thread.Sleep(speed);
                
                //create array to hold triangle points
                Point[] points = new Point[] {new Point (xLoc,yLoc), new Point (xLoc+20, yLoc), new Point(xLoc+10,yLoc+20)};

                //draw over old location in white
                g.DrawPolygon(new Pen(Color.White), points);
                lock (typeof(Thread))
                {
                    //move the triangle
                    xLoc = xLoc + directionX;
                    yLoc = yLoc + directionY;
                    //check if it hits the edges of the screen
                    checkEdgeCollision();
                }
                //redraw in new location
                points = new Point[] { new Point(xLoc, yLoc), new Point(xLoc + 20, yLoc), new Point(xLoc + 10, yLoc + 20) }; 
                g.DrawPolygon(new Pen(color), points);
            }
            catch(Exception e )
            {
                System.Console.WriteLine("Error in Thread Drawing" + e);
            }


        }

       
       
    }
    
}
