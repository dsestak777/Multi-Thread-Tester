using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThread
{
    public class Rectangle : Shapes
    {

       
        private String threadName;
   
        
       //rectangle constructor
        public Rectangle(int x, int y, int width, int height, Color color, MultiThread m,  int speed)
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
            threadName = Thread.CurrentThread.Name;

          
            try

            {

              
                //sleep thread based upon chosen speed
                Thread.Sleep(speed);

                //draw over object on screen in white
                g.DrawRectangle(new Pen(Color.White), xLoc, yLoc, width, height);
                
                
                //lock thread to update location
                lock (typeof(Thread))
                {
                        xLoc = xLoc + base.directionX;
                        yLoc = yLoc + base.directionY;
                        //check if it hits the edges of the screen
                        base.checkEdgeCollision();
                  
                }
                

                //draw object in new location
                 g.DrawRectangle(new Pen(color), xLoc, yLoc, width, height);

        
            }
            catch(Exception e )
            {
                System.Console.WriteLine("Error in Thread Drawing" + e);
            }


        }

       
       
    }
}
