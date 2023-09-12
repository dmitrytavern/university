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
            comboBoxAgency = new ComboBox();
            label2 = new Label();
            textBoxPersonName = new TextBox();
            label3 = new Label();
            comboBoxPersonVacancy = new ComboBox();
            buttonAddPerson = new Button();
            label4 = new Label();
            comboBoxVacancy = new ComboBox();
            buttonAddVacancy = new Button();
            buttonComfirmVacancy = new Button();
            listBox1 = new ListBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 30);
            label1.Name = "label1";
            label1.Size = new Size(166, 32);
            label1.TabIndex = 0;
            label1.Text = "Select agency:";
            // 
            // comboBoxAgency
            // 
            comboBoxAgency.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAgency.FormattingEnabled = true;
            comboBoxAgency.Location = new Point(29, 65);
            comboBoxAgency.Name = "comboBoxAgency";
            comboBoxAgency.Size = new Size(306, 40);
            comboBoxAgency.TabIndex = 1;
            comboBoxAgency.SelectedIndexChanged += comboBoxAgency_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 128);
            label2.Name = "label2";
            label2.Size = new Size(221, 32);
            label2.TabIndex = 2;
            label2.Text = "Enter person name:";
            // 
            // textBoxPersonName
            // 
            textBoxPersonName.Location = new Point(29, 163);
            textBoxPersonName.Name = "textBoxPersonName";
            textBoxPersonName.Size = new Size(306, 39);
            textBoxPersonName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 206);
            label3.Name = "label3";
            label3.Size = new Size(254, 32);
            label3.TabIndex = 4;
            label3.Text = "Select person vacancy:";
            // 
            // comboBoxPersonVacancy
            // 
            comboBoxPersonVacancy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPersonVacancy.FormattingEnabled = true;
            comboBoxPersonVacancy.Location = new Point(29, 241);
            comboBoxPersonVacancy.Name = "comboBoxPersonVacancy";
            comboBoxPersonVacancy.Size = new Size(306, 40);
            comboBoxPersonVacancy.TabIndex = 5;
            // 
            // buttonAddPerson
            // 
            buttonAddPerson.Location = new Point(29, 325);
            buttonAddPerson.Name = "buttonAddPerson";
            buttonAddPerson.Size = new Size(306, 46);
            buttonAddPerson.TabIndex = 6;
            buttonAddPerson.Text = "Add person";
            buttonAddPerson.UseVisualStyleBackColor = true;
            buttonAddPerson.Click += buttonAddPerson_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(369, 30);
            label4.Name = "label4";
            label4.Size = new Size(174, 32);
            label4.TabIndex = 7;
            label4.Text = "Select vacancy:";
            // 
            // comboBoxVacancy
            // 
            comboBoxVacancy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVacancy.FormattingEnabled = true;
            comboBoxVacancy.Location = new Point(369, 65);
            comboBoxVacancy.Name = "comboBoxVacancy";
            comboBoxVacancy.Size = new Size(306, 40);
            comboBoxVacancy.TabIndex = 8;
            // 
            // buttonAddVacancy
            // 
            buttonAddVacancy.Location = new Point(704, 64);
            buttonAddVacancy.Name = "buttonAddVacancy";
            buttonAddVacancy.Size = new Size(306, 40);
            buttonAddVacancy.TabIndex = 9;
            buttonAddVacancy.Text = "Add vacancy";
            buttonAddVacancy.UseVisualStyleBackColor = true;
            buttonAddVacancy.Click += buttonAddVacancy_Click;
            // 
            // buttonComfirmVacancy
            // 
            buttonComfirmVacancy.Location = new Point(29, 377);
            buttonComfirmVacancy.Name = "buttonComfirmVacancy";
            buttonComfirmVacancy.Size = new Size(306, 46);
            buttonComfirmVacancy.TabIndex = 10;
            buttonComfirmVacancy.Text = "Comfirm vacancy";
            buttonComfirmVacancy.UseVisualStyleBackColor = true;
            buttonComfirmVacancy.Click += buttonComfirmVacancy_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(369, 163);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(641, 260);
            listBox1.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 128);
            label5.Name = "label5";
            label5.Size = new Size(268, 32);
            label5.TabIndex = 12;
            label5.Text = "Free selected vacancies:";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 450);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(buttonComfirmVacancy);
            Controls.Add(buttonAddVacancy);
            Controls.Add(comboBoxVacancy);
            Controls.Add(label4);
            Controls.Add(buttonAddPerson);
            Controls.Add(comboBoxPersonVacancy);
            Controls.Add(label3);
            Controls.Add(textBoxPersonName);
            Controls.Add(label2);
            Controls.Add(comboBoxAgency);
            Controls.Add(label1);
            Name = "App";
            Text = "Form1";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxAgency;
        private Label label2;
        private TextBox textBoxPersonName;
        private Label label3;
        private ComboBox comboBoxPersonVacancy;
        private Button buttonAddPerson;
        private Label label4;
        private ComboBox comboBoxVacancy;
        private Button buttonAddVacancy;
        private Button buttonComfirmVacancy;
        private ListBox listBox1;
        private Label label5;
    }
}