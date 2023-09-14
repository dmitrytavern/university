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
            buttonDiagnose = new Button();
            label1 = new Label();
            textBoxPatientName = new TextBox();
            dateTimePickerPatientBirthday = new DateTimePicker();
            label2 = new Label();
            numericPatientTemperature = new NumericUpDown();
            label3 = new Label();
            checkBoxHasHeadache = new CheckBox();
            checkBoxHasSoreThroat = new CheckBox();
            checkBoxHasRunnyNose = new CheckBox();
            checkBoxHasCough = new CheckBox();
            listBox1 = new ListBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericPatientTemperature).BeginInit();
            SuspendLayout();
            // 
            // buttonDiagnose
            // 
            buttonDiagnose.Location = new Point(27, 530);
            buttonDiagnose.Name = "buttonDiagnose";
            buttonDiagnose.Size = new Size(400, 46);
            buttonDiagnose.TabIndex = 0;
            buttonDiagnose.Text = "Diagnose";
            buttonDiagnose.UseVisualStyleBackColor = true;
            buttonDiagnose.Click += buttonDiagnose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 25);
            label1.Name = "label1";
            label1.Size = new Size(159, 32);
            label1.TabIndex = 1;
            label1.Text = "Patient name:";
            // 
            // textBoxPatientName
            // 
            textBoxPatientName.Location = new Point(27, 60);
            textBoxPatientName.Name = "textBoxPatientName";
            textBoxPatientName.Size = new Size(400, 39);
            textBoxPatientName.TabIndex = 2;
            // 
            // dateTimePickerPatientBirthday
            // 
            dateTimePickerPatientBirthday.Location = new Point(27, 152);
            dateTimePickerPatientBirthday.Name = "dateTimePickerPatientBirthday";
            dateTimePickerPatientBirthday.Size = new Size(400, 39);
            dateTimePickerPatientBirthday.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 117);
            label2.Name = "label2";
            label2.Size = new Size(187, 32);
            label2.TabIndex = 4;
            label2.Text = "Patient birthday:";
            // 
            // numericPatientTemperature
            // 
            numericPatientTemperature.DecimalPlaces = 1;
            numericPatientTemperature.Location = new Point(27, 254);
            numericPatientTemperature.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            numericPatientTemperature.Minimum = new decimal(new int[] { 34, 0, 0, 0 });
            numericPatientTemperature.Name = "numericPatientTemperature";
            numericPatientTemperature.Size = new Size(400, 39);
            numericPatientTemperature.TabIndex = 5;
            numericPatientTemperature.Value = new decimal(new int[] { 366, 0, 0, 65536 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 219);
            label3.Name = "label3";
            label3.Size = new Size(231, 32);
            label3.TabIndex = 6;
            label3.Text = "Patient temperature:";
            // 
            // checkBoxHasHeadache
            // 
            checkBoxHasHeadache.AutoSize = true;
            checkBoxHasHeadache.Location = new Point(27, 308);
            checkBoxHasHeadache.Name = "checkBoxHasHeadache";
            checkBoxHasHeadache.Size = new Size(195, 36);
            checkBoxHasHeadache.TabIndex = 7;
            checkBoxHasHeadache.Text = "Has headache";
            checkBoxHasHeadache.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasSoreThroat
            // 
            checkBoxHasSoreThroat.AutoSize = true;
            checkBoxHasSoreThroat.Location = new Point(27, 350);
            checkBoxHasSoreThroat.Name = "checkBoxHasSoreThroat";
            checkBoxHasSoreThroat.Size = new Size(208, 36);
            checkBoxHasSoreThroat.TabIndex = 8;
            checkBoxHasSoreThroat.Text = "Has sore throat";
            checkBoxHasSoreThroat.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasRunnyNose
            // 
            checkBoxHasRunnyNose.AutoSize = true;
            checkBoxHasRunnyNose.Location = new Point(27, 392);
            checkBoxHasRunnyNose.Name = "checkBoxHasRunnyNose";
            checkBoxHasRunnyNose.Size = new Size(212, 36);
            checkBoxHasRunnyNose.TabIndex = 9;
            checkBoxHasRunnyNose.Text = "Has runny nose";
            checkBoxHasRunnyNose.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasCough
            // 
            checkBoxHasCough.AutoSize = true;
            checkBoxHasCough.Location = new Point(27, 434);
            checkBoxHasCough.Name = "checkBoxHasCough";
            checkBoxHasCough.Size = new Size(159, 36);
            checkBoxHasCough.TabIndex = 10;
            checkBoxHasCough.Text = "Has cough";
            checkBoxHasCough.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(472, 60);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(736, 516);
            listBox1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(472, 25);
            label4.Name = "label4";
            label4.Size = new Size(169, 32);
            label4.TabIndex = 12;
            label4.Text = "Patient course:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 598);
            Controls.Add(label4);
            Controls.Add(listBox1);
            Controls.Add(checkBoxHasCough);
            Controls.Add(checkBoxHasRunnyNose);
            Controls.Add(checkBoxHasSoreThroat);
            Controls.Add(checkBoxHasHeadache);
            Controls.Add(label3);
            Controls.Add(numericPatientTemperature);
            Controls.Add(label2);
            Controls.Add(dateTimePickerPatientBirthday);
            Controls.Add(textBoxPatientName);
            Controls.Add(label1);
            Controls.Add(buttonDiagnose);
            Name = "Form1";
            Text = "Laboratory Work 8.1";
            ((System.ComponentModel.ISupportInitialize)numericPatientTemperature).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDiagnose;
        private Label label1;
        private TextBox textBoxPatientName;
        private DateTimePicker dateTimePickerPatientBirthday;
        private Label label2;
        private NumericUpDown numericPatientTemperature;
        private Label label3;
        private CheckBox checkBoxHasHeadache;
        private CheckBox checkBoxHasSoreThroat;
        private CheckBox checkBoxHasRunnyNose;
        private CheckBox checkBoxHasCough;
        private ListBox listBox1;
        private Label label4;
    }
}