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
        private int selectedSpeed = 94; //default speed absolute val of (5-99)
        private String selectedShape = "Rectangle"; //default shape
        private Hashtable threadHolder = new Hashtable();
        public ColorDialog colorDialog;
        public Color selectedColor = Color.Blue;  //default shape color
      

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


            }
            else if (selectedShape == "Circle")
            {
                //create a circle object
                shape = new Circle(0, 0, 20, 20, selectedColor, this, selectedSpeed);


            }
            else if (selectedShape == "Triangle")
            {
                //create a triangle object
                shape = new Triangle(0, 0, 20, 20, selectedColor, this, selectedSpeed);


            }

            else
            {
                //create a Mickey Object
                shape = new Mickey(0, 0, 15, 15, selectedColor, this, selectedSpeed);


            }


            //draw object loop
            while (true)
            {

                //draw all objects calling shape class paint function
                shape.paint(g);

                lock (this)
                {
                    //if paused put all threads into waiting state
                    while (pause)
                    {
                        Monitor.Wait(this);  // loop until not suspended
                    }

                }

            }
        }

      

        private void MultiThread_Load(object sender, EventArgs e)
        {
           //Do nothing
        }

        private void threadLabel_TextChanged(object sender, EventArgs e)
        {
            //thread count label text
            threadLabel.Text = String.Format("Thread Count = " + threadKey);
        }

        private void pauseButton_Click(object sender, EventArgs e) {

            
            if (pause == false)
            {
                //if not paused set to pause
                pause = true;
                //change button text
                pauseButton.Text = "Resume";
            }
            else
            {
                //if paused set to unpaused
                pause = false;
                //change button text
                pauseButton.Text = "Pause";
            }

            lock (this)
            {
                //if not paused wake up all the threads 
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
            //create color chooser dialog
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

            //set  thread count label text
            threadLabel.Text = String.Format(tLabel + threadKey);
           
        }


        private void shapeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected shape from combo box
            selectedShape = shapeBox1.Text.Trim();
        }

        private void speedBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /** get selected speed from combo box
             * note: I used a combo box to highlight speed differences better
             **/
            selectedSpeed = Convert.ToInt32(speedBox1.Text.Trim());
            // make 100 fastest 1 slowest
            selectedSpeed = (Math.Abs(selectedSpeed - 99));  //note use 99 to avoid a 0 value 
        }

       
    }
}
