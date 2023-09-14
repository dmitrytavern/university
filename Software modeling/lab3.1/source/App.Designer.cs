namespace University
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
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            label3 = new Label();
            buttonAddDepartment = new Button();
            listBoxDepartments = new ListBox();
            textBoxDepartmentName = new TextBox();
            label2 = new Label();
            comboBoxDepartmentType = new ComboBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            comboBoxDepartments = new ComboBox();
            textBoxDisciplineName = new TextBox();
            label7 = new Label();
            label4 = new Label();
            buttonAddDescipline = new Button();
            label5 = new Label();
            comboBoxDisciplineType = new ComboBox();
            label6 = new Label();
            listBoxDisciplines = new ListBox();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(962, 611);
            tabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(buttonAddDepartment);
            tabPage1.Controls.Add(listBoxDepartments);
            tabPage1.Controls.Add(textBoxDepartmentName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(comboBoxDepartmentType);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(946, 557);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Add department";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(391, 41);
            label3.Name = "label3";
            label3.Size = new Size(157, 32);
            label3.TabIndex = 6;
            label3.Text = "Departments:";
            // 
            // buttonAddDepartment
            // 
            buttonAddDepartment.Location = new Point(20, 450);
            buttonAddDepartment.Name = "buttonAddDepartment";
            buttonAddDepartment.Size = new Size(305, 46);
            buttonAddDepartment.TabIndex = 5;
            buttonAddDepartment.Text = "Add department";
            buttonAddDepartment.UseVisualStyleBackColor = true;
            buttonAddDepartment.Click += buttonAddDepartment_Click;
            // 
            // listBoxDepartments
            // 
            listBoxDepartments.FormattingEnabled = true;
            listBoxDepartments.ItemHeight = 32;
            listBoxDepartments.Location = new Point(391, 76);
            listBoxDepartments.Name = "listBoxDepartments";
            listBoxDepartments.Size = new Size(549, 420);
            listBoxDepartments.TabIndex = 4;
            // 
            // textBoxDepartmentName
            // 
            textBoxDepartmentName.Location = new Point(20, 178);
            textBoxDepartmentName.Name = "textBoxDepartmentName";
            textBoxDepartmentName.Size = new Size(305, 39);
            textBoxDepartmentName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 143);
            label2.Name = "label2";
            label2.Size = new Size(273, 32);
            label2.TabIndex = 2;
            label2.Text = "Enter department name:";
            // 
            // comboBoxDepartmentType
            // 
            comboBoxDepartmentType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartmentType.FormattingEnabled = true;
            comboBoxDepartmentType.Location = new Point(20, 76);
            comboBoxDepartmentType.Name = "comboBoxDepartmentType";
            comboBoxDepartmentType.Size = new Size(305, 40);
            comboBoxDepartmentType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 41);
            label1.Name = "label1";
            label1.Size = new Size(269, 32);
            label1.TabIndex = 0;
            label1.Text = "Select department type:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listBoxDisciplines);
            tabPage2.Controls.Add(comboBoxDepartments);
            tabPage2.Controls.Add(textBoxDisciplineName);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(buttonAddDescipline);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(comboBoxDisciplineType);
            tabPage2.Controls.Add(label6);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(946, 557);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add discipline";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxDepartments
            // 
            comboBoxDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartments.FormattingEnabled = true;
            comboBoxDepartments.Location = new Point(17, 180);
            comboBoxDepartments.Name = "comboBoxDepartments";
            comboBoxDepartments.Size = new Size(305, 40);
            comboBoxDepartments.TabIndex = 16;
            // 
            // textBoxDisciplineName
            // 
            textBoxDisciplineName.Location = new Point(17, 282);
            textBoxDisciplineName.Name = "textBoxDisciplineName";
            textBoxDisciplineName.Size = new Size(305, 39);
            textBoxDisciplineName.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 247);
            label7.Name = "label7";
            label7.Size = new Size(248, 32);
            label7.TabIndex = 14;
            label7.Text = "Enter discipline name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(388, 43);
            label4.Name = "label4";
            label4.Size = new Size(132, 32);
            label4.TabIndex = 13;
            label4.Text = "Disciplines:";
            // 
            // buttonAddDescipline
            // 
            buttonAddDescipline.Location = new Point(17, 452);
            buttonAddDescipline.Name = "buttonAddDescipline";
            buttonAddDescipline.Size = new Size(305, 46);
            buttonAddDescipline.TabIndex = 12;
            buttonAddDescipline.Text = "Add discipline";
            buttonAddDescipline.UseVisualStyleBackColor = true;
            buttonAddDescipline.Click += buttonAddDescipline_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 145);
            label5.Name = "label5";
            label5.Size = new Size(215, 32);
            label5.TabIndex = 9;
            label5.Text = "Select department:";
            // 
            // comboBoxDisciplineType
            // 
            comboBoxDisciplineType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDisciplineType.FormattingEnabled = true;
            comboBoxDisciplineType.Location = new Point(17, 78);
            comboBoxDisciplineType.Name = "comboBoxDisciplineType";
            comboBoxDisciplineType.Size = new Size(305, 40);
            comboBoxDisciplineType.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 43);
            label6.Name = "label6";
            label6.Size = new Size(244, 32);
            label6.TabIndex = 7;
            label6.Text = "Select discipline type:";
            // 
            // listBoxDisciplines
            // 
            listBoxDisciplines.FormattingEnabled = true;
            listBoxDisciplines.ItemHeight = 32;
            listBoxDisciplines.Location = new Point(388, 78);
            listBoxDisciplines.Name = "listBoxDisciplines";
            listBoxDisciplines.Size = new Size(552, 420);
            listBoxDisciplines.TabIndex = 18;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 635);
            Controls.Add(tabControl);
            Name = "App";
            Text = "Laboratory Work 3.1";
            Load += App_Load;
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private ComboBox comboBoxDepartmentType;
        private Label label2;
        private TextBox textBoxDepartmentName;
        private ListBox listBoxDepartments;
        private Button buttonAddDepartment;
        private Label label3;
        private Label label4;
        private Button buttonAddDescipline;
        private Label label5;
        private ComboBox comboBoxDisciplineType;
        private Label label6;
        private TextBox textBoxDisciplineName;
        private Label label7;
        private ComboBox comboBoxDepartments;
        private ListBox listBoxDisciplines;
    }
}