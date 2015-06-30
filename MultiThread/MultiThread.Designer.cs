namespace MultiThread
{
    partial class MultiThread
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeBox1 = new System.Windows.Forms.ComboBox();
            this.speedUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.colorButton = new System.Windows.Forms.Button();
            this.addShapeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.threadLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.speedUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 50);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shape";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Speed";
            // 
            // shapeBox1
            // 
            this.shapeBox1.FormattingEnabled = true;
            this.shapeBox1.Items.AddRange(new object[] {
            "Rectangle",
            "Circle",
            "Mickey",
            "Triangle"});
            this.shapeBox1.Location = new System.Drawing.Point(230, 18);
            this.shapeBox1.Name = "shapeBox1";
            this.shapeBox1.Size = new System.Drawing.Size(121, 24);
            this.shapeBox1.TabIndex = 4;
            this.shapeBox1.Text = "Rectangle";
            // 
            // speedUpDown1
            // 
            this.speedUpDown1.Location = new System.Drawing.Point(231, 51);
            this.speedUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speedUpDown1.Name = "speedUpDown1";
            this.speedUpDown1.Size = new System.Drawing.Size(120, 22);
            this.speedUpDown1.TabIndex = 5;
            this.speedUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(385, 19);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(87, 23);
            this.colorButton.TabIndex = 6;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // addShapeButton
            // 
            this.addShapeButton.Location = new System.Drawing.Point(385, 48);
            this.addShapeButton.Name = "addShapeButton";
            this.addShapeButton.Size = new System.Drawing.Size(87, 23);
            this.addShapeButton.TabIndex = 7;
            this.addShapeButton.Text = "Add Shape";
            this.addShapeButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(-6, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 424);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // threadLabel
            // 
            this.threadLabel.AutoSize = true;
            this.threadLabel.Location = new System.Drawing.Point(13, 574);
            this.threadLabel.Name = "threadLabel";
            this.threadLabel.Size = new System.Drawing.Size(46, 17);
            this.threadLabel.TabIndex = 9;
            this.threadLabel.Text = "label3";
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(12, 15);
          //  this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // MultiThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.threadLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.addShapeButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.speedUpDown1);
            this.Controls.Add(this.shapeBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Name = "MultiThread";
            this.Text = "Multi Thread Program";
            this.Load += new System.EventHandler(this.MultiThread_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speedUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox shapeBox1;
        private System.Windows.Forms.NumericUpDown speedUpDown1;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button addShapeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label threadLabel;
        private System.Windows.Forms.Button pauseButton;
    }
}

