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
            listBox1 = new ListBox();
            comboBoxSoldierType = new ComboBox();
            comboBoxSoldierRank = new ComboBox();
            label2 = new Label();
            comboBoxSoldierRang = new ComboBox();
            label3 = new Label();
            buttonAdd = new Button();
            label4 = new Label();
            label5 = new Label();
            comboBoxIterator = new ComboBox();
            label6 = new Label();
            buttonSort = new Button();
            label7 = new Label();
            textBoxSoldierName = new TextBox();
            listBox2 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 136);
            label1.Name = "label1";
            label1.Size = new Size(215, 32);
            label1.TabIndex = 0;
            label1.Text = "Select soldier type:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(386, 82);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(623, 388);
            listBox1.TabIndex = 1;
            // 
            // comboBoxSoldierType
            // 
            comboBoxSoldierType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSoldierType.FormattingEnabled = true;
            comboBoxSoldierType.Location = new Point(35, 171);
            comboBoxSoldierType.Name = "comboBoxSoldierType";
            comboBoxSoldierType.Size = new Size(295, 40);
            comboBoxSoldierType.TabIndex = 2;
            // 
            // comboBoxSoldierRank
            // 
            comboBoxSoldierRank.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSoldierRank.FormattingEnabled = true;
            comboBoxSoldierRank.Location = new Point(37, 258);
            comboBoxSoldierRank.Name = "comboBoxSoldierRank";
            comboBoxSoldierRank.Size = new Size(295, 40);
            comboBoxSoldierRank.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 223);
            label2.Name = "label2";
            label2.Size = new Size(214, 32);
            label2.TabIndex = 3;
            label2.Text = "Select soldier rank:";
            // 
            // comboBoxSoldierRang
            // 
            comboBoxSoldierRang.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSoldierRang.FormattingEnabled = true;
            comboBoxSoldierRang.Location = new Point(35, 350);
            comboBoxSoldierRang.Name = "comboBoxSoldierRang";
            comboBoxSoldierRang.Size = new Size(295, 40);
            comboBoxSoldierRang.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 315);
            label3.Name = "label3";
            label3.Size = new Size(216, 32);
            label3.TabIndex = 5;
            label3.Text = "Select soldier rang:";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(35, 424);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(295, 46);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Add soldier";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(386, 47);
            label4.Name = "label4";
            label4.Size = new Size(103, 32);
            label4.TabIndex = 8;
            label4.Text = "Soldiers:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1038, 48);
            label5.Name = "label5";
            label5.Size = new Size(126, 32);
            label5.TabIndex = 10;
            label5.Text = "Sorted list:";
            // 
            // comboBoxIterator
            // 
            comboBoxIterator.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIterator.FormattingEnabled = true;
            comboBoxIterator.Location = new Point(1707, 82);
            comboBoxIterator.Name = "comboBoxIterator";
            comboBoxIterator.Size = new Size(295, 40);
            comboBoxIterator.TabIndex = 11;
            comboBoxIterator.SelectedIndexChanged += comboBoxIterator_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1707, 47);
            label6.Name = "label6";
            label6.Size = new Size(167, 32);
            label6.TabIndex = 12;
            label6.Text = "Select iterator:";
            // 
            // buttonSort
            // 
            buttonSort.Location = new Point(1707, 424);
            buttonSort.Name = "buttonSort";
            buttonSort.Size = new Size(295, 46);
            buttonSort.TabIndex = 13;
            buttonSort.Text = "Sort";
            buttonSort.UseVisualStyleBackColor = true;
            buttonSort.Click += buttonSort_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(35, 47);
            label7.Name = "label7";
            label7.Size = new Size(219, 32);
            label7.TabIndex = 14;
            label7.Text = "Enter solider name:";
            // 
            // textBoxSoldierName
            // 
            textBoxSoldierName.Location = new Point(35, 83);
            textBoxSoldierName.Name = "textBoxSoldierName";
            textBoxSoldierName.Size = new Size(295, 39);
            textBoxSoldierName.TabIndex = 15;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 32;
            listBox2.Location = new Point(1038, 83);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(623, 388);
            listBox2.TabIndex = 16;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2040, 522);
            Controls.Add(listBox2);
            Controls.Add(textBoxSoldierName);
            Controls.Add(label7);
            Controls.Add(buttonSort);
            Controls.Add(label6);
            Controls.Add(comboBoxIterator);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(buttonAdd);
            Controls.Add(comboBoxSoldierRang);
            Controls.Add(label3);
            Controls.Add(comboBoxSoldierRank);
            Controls.Add(label2);
            Controls.Add(comboBoxSoldierType);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "App";
            Text = "Form1";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private ComboBox comboBoxSoldierType;
        private ComboBox comboBoxSoldierRank;
        private Label label2;
        private ComboBox comboBoxSoldierRang;
        private Label label3;
        private Button buttonAdd;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxIterator;
        private Label label6;
        private Button buttonSort;
        private Label label7;
        private TextBox textBoxSoldierName;
        private ListBox listBox2;
    }
}