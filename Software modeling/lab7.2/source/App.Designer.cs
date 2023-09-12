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
            buttonAddMessage = new Button();
            textBoxMessage = new TextBox();
            label2 = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 31);
            label1.Name = "label1";
            label1.Size = new Size(174, 32);
            label1.TabIndex = 0;
            label1.Text = "Enter message:";
            // 
            // buttonAddMessage
            // 
            buttonAddMessage.Location = new Point(795, 66);
            buttonAddMessage.Name = "buttonAddMessage";
            buttonAddMessage.Size = new Size(124, 39);
            buttonAddMessage.TabIndex = 1;
            buttonAddMessage.Text = "Add";
            buttonAddMessage.UseVisualStyleBackColor = true;
            buttonAddMessage.Click += buttonAddMessage_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(33, 66);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(734, 39);
            textBoxMessage.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 122);
            label2.Name = "label2";
            label2.Size = new Size(68, 32);
            label2.TabIndex = 3;
            label2.Text = "Logs:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(33, 157);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(886, 292);
            listBox1.TabIndex = 4;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 472);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(textBoxMessage);
            Controls.Add(buttonAddMessage);
            Controls.Add(label1);
            Name = "App";
            Text = "Form1";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonAddMessage;
        private TextBox textBoxMessage;
        private Label label2;
        private ListBox listBox1;
    }
}