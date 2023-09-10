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
            buttonAttack = new Button();
            comboBoxFighter = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            buttonDefend = new Button();
            buttonEscape = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(277, 69);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(597, 356);
            listBox1.TabIndex = 0;
            // 
            // buttonAttack
            // 
            buttonAttack.Location = new Point(12, 142);
            buttonAttack.Name = "buttonAttack";
            buttonAttack.Size = new Size(242, 46);
            buttonAttack.TabIndex = 1;
            buttonAttack.Text = "Attack";
            buttonAttack.UseVisualStyleBackColor = true;
            buttonAttack.Click += buttonAttack_Click;
            // 
            // comboBoxFighter
            // 
            comboBoxFighter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFighter.FormattingEnabled = true;
            comboBoxFighter.Location = new Point(12, 69);
            comboBoxFighter.Name = "comboBoxFighter";
            comboBoxFighter.Size = new Size(242, 40);
            comboBoxFighter.TabIndex = 2;
            comboBoxFighter.SelectedIndexChanged += comboBoxFighter_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(161, 32);
            label1.TabIndex = 3;
            label1.Text = "Select fighter:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(277, 34);
            label2.Name = "label2";
            label2.Size = new Size(68, 32);
            label2.TabIndex = 4;
            label2.Text = "Logs:";
            // 
            // buttonDefend
            // 
            buttonDefend.Location = new Point(12, 194);
            buttonDefend.Name = "buttonDefend";
            buttonDefend.Size = new Size(242, 46);
            buttonDefend.TabIndex = 5;
            buttonDefend.Text = "Defend";
            buttonDefend.UseVisualStyleBackColor = true;
            buttonDefend.Click += buttonDefend_Click;
            // 
            // buttonEscape
            // 
            buttonEscape.Location = new Point(12, 246);
            buttonEscape.Name = "buttonEscape";
            buttonEscape.Size = new Size(242, 46);
            buttonEscape.TabIndex = 6;
            buttonEscape.Text = "Escape";
            buttonEscape.UseVisualStyleBackColor = true;
            buttonEscape.Click += buttonEscape_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 450);
            Controls.Add(buttonEscape);
            Controls.Add(buttonDefend);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxFighter);
            Controls.Add(buttonAttack);
            Controls.Add(listBox1);
            Name = "App";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button buttonAttack;
        private ComboBox comboBoxFighter;
        private Label label1;
        private Label label2;
        private Button buttonDefend;
        private Button buttonEscape;
    }
}