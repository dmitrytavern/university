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
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 35);
            label1.Name = "label1";
            label1.Size = new Size(200, 32);
            label1.TabIndex = 0;
            label1.Text = "Enter order name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(423, 35);
            label2.Name = "label2";
            label2.Size = new Size(160, 32);
            label2.TabIndex = 1;
            label2.Text = "Enter delivery";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 234);
            label3.Name = "label3";
            label3.Size = new Size(158, 32);
            label3.TabIndex = 2;
            label3.Text = "Your price: $0";
            // 
            // button1
            // 
            button1.Location = new Point(36, 162);
            button1.Name = "button1";
            button1.Size = new Size(745, 46);
            button1.TabIndex = 3;
            button1.Text = "Calcucate price";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(358, 39);
            textBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(423, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(358, 40);
            comboBox1.TabIndex = 5;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 297);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "App";
            Text = "Exam";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox1;
    }
}