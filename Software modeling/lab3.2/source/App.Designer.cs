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
            comboBoxEnv = new ComboBox();
            buttonAddVegetation = new Button();
            buttonAddTerrain = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBoxEnv
            // 
            comboBoxEnv.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnv.FormattingEnabled = true;
            comboBoxEnv.Location = new Point(33, 72);
            comboBoxEnv.Name = "comboBoxEnv";
            comboBoxEnv.Size = new Size(275, 40);
            comboBoxEnv.TabIndex = 0;
            comboBoxEnv.SelectedIndexChanged += comboBoxEnv_SelectedIndexChanged;
            // 
            // buttonAddVegetation
            // 
            buttonAddVegetation.Location = new Point(33, 170);
            buttonAddVegetation.Name = "buttonAddVegetation";
            buttonAddVegetation.Size = new Size(275, 46);
            buttonAddVegetation.TabIndex = 1;
            buttonAddVegetation.Text = "Add vegetation";
            buttonAddVegetation.UseVisualStyleBackColor = true;
            buttonAddVegetation.Click += buttonAddVegetation_Click;
            // 
            // buttonAddTerrain
            // 
            buttonAddTerrain.Location = new Point(33, 118);
            buttonAddTerrain.Name = "buttonAddTerrain";
            buttonAddTerrain.Size = new Size(275, 46);
            buttonAddTerrain.TabIndex = 2;
            buttonAddTerrain.Text = "Add terrain";
            buttonAddTerrain.UseVisualStyleBackColor = true;
            buttonAddTerrain.Click += buttonAddTerrain_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(339, 72);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(688, 356);
            listBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 34);
            label1.Name = "label1";
            label1.Size = new Size(129, 32);
            label1.TabIndex = 4;
            label1.Text = "Select env:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(339, 34);
            label2.Name = "label2";
            label2.Size = new Size(68, 32);
            label2.TabIndex = 5;
            label2.Text = "Logs:";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(buttonAddTerrain);
            Controls.Add(buttonAddVegetation);
            Controls.Add(comboBoxEnv);
            Name = "App";
            Text = "Laboratory Work 3.2";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxEnv;
        private Button buttonAddVegetation;
        private Button buttonAddTerrain;
        private ListBox listBox1;
        private Label label1;
        private Label label2;
    }
}