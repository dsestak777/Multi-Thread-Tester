using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows;

namespace MultiThread
{
    public partial class MultiThread : Form
    {

        private Graphics g;
        private static bool pause = false;
        private String tLabel = "Thread Count = ";
        private static int threadKey = 0; //thread counter
        private int selectedSpeed = 1; //default speed
        private String selectedShape = "Rectangle"; //default shape
        private Hashtable threadHolder = new Hashtable();
        public ColorDialog colorDialog;
        public Color selectedColor = Color.Blue;  //default shape color
        private List<Shapes> s = new List<Shapes>();

        public MultiThread()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            this.DoubleBuffered = true;

            //initalize event handlers
            pauseButton.Click += new EventHandler(pauseButton_Click);
            exitButton.Click += new EventHandler(exitButton_Click);
            colorButton.Click += new EventHandler(colorButton_Click);
            addShapeButton.Click += new EventHandler(addShapeButton_Click);
         //   pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            speedUpDown1.ValueChanged += new EventHandler(speedUpDown1_ValueChanged);
            shapeBox1.SelectedIndexChanged += new EventHandler(shapeBox1_SelectedIndexChanged);
            threadLabel.TextChanged += new EventHandler(threadLabel_TextChanged);

            threadLabel.Text = String.Format(tLabel + threadKey);
        
        }

       

        private void StartThread()
        {
            //local shape
            Shapes shape;

          
           
            //check shape selection
            if (selectedShape == "Rectangle")
            {
                //create rectangle object
                shape = new Rectangle(0, 0, 20, 20, selectedColor, this, selectedSpeed);

                s.Add(shape);

                //draw object
                while (true)
                {
                    shape.paint(g);

                    lock (this)
                    {

                        while (pause)
                        {
                            Monitor.Wait(this);  // loop until not suspended
                        }

                    }

                }



            } else if (selectedShape == "Circle") {

                shape = new Circle(0, 0, 20, 20, selectedColor, this, selectedSpeed);

              

                while (true)
                {
                    shape.paint(g);
                    lock (this)
                    {

                        while (pause)
                        {
                            Monitor.Wait(this);  // loop until not suspended
                        }

                    }
                }

            }
            else if (selectedShape == "Triangle")
            {

                shape = new Triangle(0, 0, 20, 20, selectedColor, this, selectedSpeed);

               

                while (true)
                {
                    shape.paint(g);
                    lock (this)
                    {

                        while (pause)
                        {
                            Monitor.Wait(this);  // loop until not suspended
                        }

                    }
                }

            }

            else 
            {

                shape = new Mickey(0, 0, 15, 15, selectedColor, this, selectedSpeed);



                while (true)
                {
                    shape.paint(g);
                    lock (this)
                    {

                        while (pause)
                        {
                            Monitor.Wait(this);  // loop until not suspended
                        }

                    }
                }

            }
        }


        private bool checkOverlap()
        {

            for (int i = 0; i < s.Count; i++)
            {
                int x1 = s[i].XLoc;
                int y1 = s[i].YLoc;
                int width1 = s[i].Width;
                int height1 = s[i].Height;

                for (int j = 0; j < s.Count; j++)
                {
                    int x2 = s[j].XLoc;
                    int y2 = s[j].YLoc;
                    int width2 = s[j].Width;
                    int height2 = s[j].Height;

                    if (i != j)
                    {
                        if (Math.Abs(x1 - x2) * 2 <= (width1 + width2) &&
                            (Math.Abs(y1 - y2) * 2 <= (height1 + height2))) {

                                return true;
                            }
                    }
                }                    
            
            }
            return false;

        }

      

        private void MultiThread_Load(object sender, EventArgs e)
        {
           //Do nothing
        }

        private void threadLabel_TextChanged(object sender, EventArgs e)
        {

            threadLabel.Text = String.Format("Thread Count = " + threadKey);
        }

        private void pauseButton_Click(object sender, EventArgs e) {

            if (pause == false)
            {
                pause = true;
                pauseButton.Text = "Resume";
            }
            else
            {
                pause = false;
                pauseButton.Text = "Pause";
            }

            lock (this)
            {

                if (!pause)
                {
                    Monitor.PulseAll(this);


                }
            }


        }

      

        private void exitButton_Click(object sender, EventArgs e)
        {
            
            //close all active threads
            foreach (Thread thread in threadHolder.Values) {

                thread.Abort();
                
            }
            
            //close form
            MultiThread.ActiveForm.Close();


        }
        private void colorButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            selectedColor = colorDialog.Color;

        }
        private void addShapeButton_Click(object sender, EventArgs e)
        {
           
            //crate new Thread
            Thread thread = new Thread(new ThreadStart(StartThread));
            threadKey++;

            //add thread to hashmap
            threadHolder.Add(threadKey,thread);
            thread.Start();


            threadLabel.Text = String.Format(tLabel + threadKey);
           // threadLabel.Invalidate();
           // threadLabel.Update(); 
        }

        private void speedUpDown1_ValueChanged(object sender, EventArgs e)
        {
            selectedSpeed = Convert.ToInt32(speedUpDown1.Text.Trim());

        }

        private void shapeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedShape = shapeBox1.Text.Trim();
        }

       
    }
}
