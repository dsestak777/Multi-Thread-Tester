using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace MultiThread
{
    public abstract class Shapes
    {

        protected int xLoc;
        protected int yLoc;
        protected int width;
        protected int height;
        protected int speed;
        protected int directionX = 1;
        protected int directionY = 1;
        protected Color color;
        protected MultiThread multiThread;

        public Shapes()
        { }

        //implement in concrete classes
        public abstract void paint(Graphics g);

        //check if an object has hit the edge of the screen
        public void checkEdgeCollision()
        {
            int formHeight = multiThread.Size.Height - 240;// adjust for gui 
            int formWidth = multiThread.Size.Width - 30; // adjust for border
            if (yLoc >= formHeight || yLoc <=0) {
                //reverse direction
                directionY = -directionY;
            }
            if (xLoc >= formWidth || xLoc <= 0)
            {
                //reverse direction
                directionX = -directionX;
            }

        }

        public int XLoc
        {
            get{
                return xLoc;
            }
            set{
                xLoc=value;
            }
        }

        public int YLoc
        {
            get
            {
                return yLoc;
            }
            set
            {
                yLoc = value;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }

    
    

}
