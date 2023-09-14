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
            label1 = new Label();
            numericEarnings = new NumericUpDown();
            numericCredit = new NumericUpDown();
            label2 = new Label();
            numericPrice = new NumericUpDown();
            label3 = new Label();
            buttonGetResult = new Button();
            label4 = new Label();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            label5 = new Label();
            labelResult = new Label();
            ((System.ComponentModel.ISupportInitialize)numericEarnings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCredit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 121);
            label1.Name = "label1";
            label1.Size = new Size(227, 32);
            label1.TabIndex = 0;
            label1.Text = "Enter your earnings:";
            // 
            // numericEarnings
            // 
            numericEarnings.Location = new Point(44, 156);
            numericEarnings.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numericEarnings.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEarnings.Name = "numericEarnings";
            numericEarnings.Size = new Size(240, 39);
            numericEarnings.TabIndex = 1;
            numericEarnings.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericCredit
            // 
            numericCredit.Location = new Point(319, 156);
            numericCredit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCredit.Name = "numericCredit";
            numericCredit.Size = new Size(240, 39);
            numericCredit.TabIndex = 3;
            numericCredit.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(319, 121);
            label2.Name = "label2";
            label2.Size = new Size(169, 32);
            label2.TabIndex = 2;
            label2.Text = "Years of credit:";
            // 
            // numericPrice
            // 
            numericPrice.Location = new Point(600, 156);
            numericPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numericPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(240, 39);
            numericPrice.TabIndex = 5;
            numericPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(600, 121);
            label3.Name = "label3";
            label3.Size = new Size(146, 32);
            label3.TabIndex = 4;
            label3.Text = "House price:";
            // 
            // buttonGetResult
            // 
            buttonGetResult.Location = new Point(44, 225);
            buttonGetResult.Name = "buttonGetResult";
            buttonGetResult.Size = new Size(796, 46);
            buttonGetResult.TabIndex = 6;
            buttonGetResult.Text = "Get result";
            buttonGetResult.UseVisualStyleBackColor = true;
            buttonGetResult.Click += buttonGetResult_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 28);
            label4.Name = "label4";
            label4.Size = new Size(236, 32);
            label4.TabIndex = 7;
            label4.Text = "Enter your firstname:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(44, 63);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(387, 39);
            textBoxFirstName.TabIndex = 8;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(453, 63);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(387, 39);
            textBoxLastName.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(453, 28);
            label5.Name = "label5";
            label5.Size = new Size(232, 32);
            label5.TabIndex = 9;
            label5.Text = "Enter your lastname:";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(44, 296);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(83, 32);
            labelResult.TabIndex = 11;
            labelResult.Text = "Result:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 362);
            Controls.Add(labelResult);
            Controls.Add(textBoxLastName);
            Controls.Add(label5);
            Controls.Add(textBoxFirstName);
            Controls.Add(label4);
            Controls.Add(buttonGetResult);
            Controls.Add(numericPrice);
            Controls.Add(label3);
            Controls.Add(numericCredit);
            Controls.Add(label2);
            Controls.Add(numericEarnings);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Laboratory Work 5.1";
            ((System.ComponentModel.ISupportInitialize)numericEarnings).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCredit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericEarnings;
        private NumericUpDown numericCredit;
        private Label label2;
        private NumericUpDown numericPrice;
        private Label label3;
        private Button buttonGetResult;
        private Label label4;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private Label label5;
        private Label labelResult;
    }
}