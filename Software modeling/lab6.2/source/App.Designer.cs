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
            comboBoxEmployeeType = new ComboBox();
            label2 = new Label();
            textBoxEmployeeName = new TextBox();
            buttonRemoveEmployee = new Button();
            comboBoxIterator = new ComboBox();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label3 = new Label();
            label4 = new Label();
            buttonSort = new Button();
            label5 = new Label();
            buttonAddEmployee = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 25);
            label1.Name = "label1";
            label1.Size = new Size(250, 32);
            label1.TabIndex = 0;
            label1.Text = "Select employee type:";
            // 
            // comboBoxEmployeeType
            // 
            comboBoxEmployeeType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEmployeeType.FormattingEnabled = true;
            comboBoxEmployeeType.Location = new Point(21, 60);
            comboBoxEmployeeType.Name = "comboBoxEmployeeType";
            comboBoxEmployeeType.Size = new Size(303, 40);
            comboBoxEmployeeType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 114);
            label2.Name = "label2";
            label2.Size = new Size(254, 32);
            label2.TabIndex = 2;
            label2.Text = "Enter employee name:";
            // 
            // textBoxEmployeeName
            // 
            textBoxEmployeeName.Location = new Point(21, 149);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(303, 39);
            textBoxEmployeeName.TabIndex = 3;
            // 
            // buttonRemoveEmployee
            // 
            buttonRemoveEmployee.Location = new Point(21, 370);
            buttonRemoveEmployee.Name = "buttonRemoveEmployee";
            buttonRemoveEmployee.Size = new Size(303, 46);
            buttonRemoveEmployee.TabIndex = 4;
            buttonRemoveEmployee.Text = "Remove employee";
            buttonRemoveEmployee.UseVisualStyleBackColor = true;
            buttonRemoveEmployee.Click += buttonRemoveEmployee_Click;
            // 
            // comboBoxIterator
            // 
            comboBoxIterator.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIterator.FormattingEnabled = true;
            comboBoxIterator.Location = new Point(1590, 60);
            comboBoxIterator.Name = "comboBoxIterator";
            comboBoxIterator.Size = new Size(242, 40);
            comboBoxIterator.TabIndex = 5;
            comboBoxIterator.SelectedIndexChanged += comboBoxIterator_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(356, 60);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(592, 356);
            listBox1.TabIndex = 6;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 32;
            listBox2.Location = new Point(973, 60);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(592, 356);
            listBox2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(356, 25);
            label3.Name = "label3";
            label3.Size = new Size(134, 32);
            label3.TabIndex = 8;
            label3.Text = "Employees:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(973, 25);
            label4.Name = "label4";
            label4.Size = new Size(212, 32);
            label4.TabIndex = 9;
            label4.Text = "Sorted employees:";
            // 
            // buttonSort
            // 
            buttonSort.Location = new Point(1590, 370);
            buttonSort.Name = "buttonSort";
            buttonSort.Size = new Size(242, 46);
            buttonSort.TabIndex = 10;
            buttonSort.Text = "Sort";
            buttonSort.UseVisualStyleBackColor = true;
            buttonSort.Click += buttonSort_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1590, 25);
            label5.Name = "label5";
            label5.Size = new Size(96, 32);
            label5.TabIndex = 11;
            label5.Text = "Iterator:";
            // 
            // buttonAddEmployee
            // 
            buttonAddEmployee.Location = new Point(21, 318);
            buttonAddEmployee.Name = "buttonAddEmployee";
            buttonAddEmployee.Size = new Size(303, 46);
            buttonAddEmployee.TabIndex = 12;
            buttonAddEmployee.Text = "Add employee";
            buttonAddEmployee.UseVisualStyleBackColor = true;
            buttonAddEmployee.Click += buttonAddEmployee_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1863, 450);
            Controls.Add(buttonAddEmployee);
            Controls.Add(label5);
            Controls.Add(buttonSort);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(comboBoxIterator);
            Controls.Add(buttonRemoveEmployee);
            Controls.Add(textBoxEmployeeName);
            Controls.Add(label2);
            Controls.Add(comboBoxEmployeeType);
            Controls.Add(label1);
            Name = "App";
            Text = "Form1";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxEmployeeType;
        private Label label2;
        private TextBox textBoxEmployeeName;
        private Button buttonRemoveEmployee;
        private ComboBox comboBoxIterator;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label3;
        private Label label4;
        private Button buttonSort;
        private Label label5;
        private Button buttonAddEmployee;
    }
}