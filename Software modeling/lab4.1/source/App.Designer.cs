namespace App
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            numericDefaultX = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            numericDefaultY = new NumericUpDown();
            label5 = new Label();
            numericDefaultW = new NumericUpDown();
            label6 = new Label();
            numericDefaultH = new NumericUpDown();
            buttonAddByDefault = new Button();
            buttonAddByPosition = new Button();
            label7 = new Label();
            numericPositionY2 = new NumericUpDown();
            label8 = new Label();
            numericPositionX2 = new NumericUpDown();
            label9 = new Label();
            numericPositionY1 = new NumericUpDown();
            label10 = new Label();
            numericPositionX1 = new NumericUpDown();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericDefaultX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDefaultY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDefaultW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDefaultH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionX2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionX1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(281, 50);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(616, 484);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 15);
            label1.Name = "label1";
            label1.Size = new Size(68, 32);
            label1.TabIndex = 1;
            label1.Text = "Logs:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(177, 32);
            label2.TabIndex = 2;
            label2.Text = "Add by default:";
            // 
            // numericDefaultX
            // 
            numericDefaultX.Location = new Point(86, 50);
            numericDefaultX.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericDefaultX.Name = "numericDefaultX";
            numericDefaultX.Size = new Size(171, 39);
            numericDefaultX.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 52);
            label3.Name = "label3";
            label3.Size = new Size(33, 32);
            label3.TabIndex = 4;
            label3.Text = "X:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 97);
            label4.Name = "label4";
            label4.Size = new Size(32, 32);
            label4.TabIndex = 6;
            label4.Text = "Y:";
            // 
            // numericDefaultY
            // 
            numericDefaultY.Location = new Point(86, 95);
            numericDefaultY.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericDefaultY.Name = "numericDefaultY";
            numericDefaultY.Size = new Size(171, 39);
            numericDefaultY.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 142);
            label5.Name = "label5";
            label5.Size = new Size(41, 32);
            label5.TabIndex = 8;
            label5.Text = "W:";
            // 
            // numericDefaultW
            // 
            numericDefaultW.Location = new Point(86, 140);
            numericDefaultW.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericDefaultW.Name = "numericDefaultW";
            numericDefaultW.Size = new Size(171, 39);
            numericDefaultW.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 187);
            label6.Name = "label6";
            label6.Size = new Size(36, 32);
            label6.TabIndex = 10;
            label6.Text = "H:";
            // 
            // numericDefaultH
            // 
            numericDefaultH.Location = new Point(86, 185);
            numericDefaultH.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericDefaultH.Name = "numericDefaultH";
            numericDefaultH.Size = new Size(171, 39);
            numericDefaultH.TabIndex = 9;
            // 
            // buttonAddByDefault
            // 
            buttonAddByDefault.Location = new Point(86, 230);
            buttonAddByDefault.Name = "buttonAddByDefault";
            buttonAddByDefault.Size = new Size(171, 39);
            buttonAddByDefault.TabIndex = 11;
            buttonAddByDefault.Text = "Add";
            buttonAddByDefault.UseVisualStyleBackColor = true;
            buttonAddByDefault.Click += buttonAddByDefault_Click;
            // 
            // buttonAddByPosition
            // 
            buttonAddByPosition.Location = new Point(86, 494);
            buttonAddByPosition.Name = "buttonAddByPosition";
            buttonAddByPosition.Size = new Size(171, 39);
            buttonAddByPosition.TabIndex = 21;
            buttonAddByPosition.Text = "Add";
            buttonAddByPosition.UseVisualStyleBackColor = true;
            buttonAddByPosition.Click += buttonAddByPosition_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 451);
            label7.Name = "label7";
            label7.Size = new Size(45, 32);
            label7.TabIndex = 20;
            label7.Text = "Y2:";
            // 
            // numericPositionY2
            // 
            numericPositionY2.Location = new Point(86, 449);
            numericPositionY2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericPositionY2.Name = "numericPositionY2";
            numericPositionY2.Size = new Size(171, 39);
            numericPositionY2.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 406);
            label8.Name = "label8";
            label8.Size = new Size(46, 32);
            label8.TabIndex = 18;
            label8.Text = "X2:";
            // 
            // numericPositionX2
            // 
            numericPositionX2.Location = new Point(86, 404);
            numericPositionX2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericPositionX2.Name = "numericPositionX2";
            numericPositionX2.Size = new Size(171, 39);
            numericPositionX2.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(34, 361);
            label9.Name = "label9";
            label9.Size = new Size(45, 32);
            label9.TabIndex = 16;
            label9.Text = "Y1:";
            // 
            // numericPositionY1
            // 
            numericPositionY1.Location = new Point(86, 359);
            numericPositionY1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericPositionY1.Name = "numericPositionY1";
            numericPositionY1.Size = new Size(171, 39);
            numericPositionY1.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(34, 316);
            label10.Name = "label10";
            label10.Size = new Size(46, 32);
            label10.TabIndex = 14;
            label10.Text = "X1:";
            // 
            // numericPositionX1
            // 
            numericPositionX1.Location = new Point(86, 314);
            numericPositionX1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericPositionX1.Name = "numericPositionX1";
            numericPositionX1.Size = new Size(171, 39);
            numericPositionX1.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 279);
            label11.Name = "label11";
            label11.Size = new Size(188, 32);
            label11.TabIndex = 12;
            label11.Text = "Add by position:";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 558);
            Controls.Add(buttonAddByPosition);
            Controls.Add(label7);
            Controls.Add(numericPositionY2);
            Controls.Add(label8);
            Controls.Add(numericPositionX2);
            Controls.Add(label9);
            Controls.Add(numericPositionY1);
            Controls.Add(label10);
            Controls.Add(numericPositionX1);
            Controls.Add(label11);
            Controls.Add(buttonAddByDefault);
            Controls.Add(label6);
            Controls.Add(numericDefaultH);
            Controls.Add(label5);
            Controls.Add(numericDefaultW);
            Controls.Add(label4);
            Controls.Add(numericDefaultY);
            Controls.Add(label3);
            Controls.Add(numericDefaultX);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "App";
            Text = "Laboratory Work 4.1";
            ((System.ComponentModel.ISupportInitialize)numericDefaultX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDefaultY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDefaultW).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDefaultH).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionX2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionY1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPositionX1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private NumericUpDown numericDefaultX;
        private Label label3;
        private Label label4;
        private NumericUpDown numericDefaultY;
        private Label label5;
        private NumericUpDown numericDefaultW;
        private Label label6;
        private NumericUpDown numericDefaultH;
        private Button buttonAddByDefault;
        private Button buttonAddByPosition;
        private Label label7;
        private NumericUpDown numericPositionY2;
        private Label label8;
        private NumericUpDown numericPositionX2;
        private Label label9;
        private NumericUpDown numericPositionY1;
        private Label label10;
        private NumericUpDown numericPositionX1;
        private Label label11;
    }
}