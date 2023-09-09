namespace PizzaApp
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
            comboBoxPizza = new ComboBox();
            label1 = new Label();
            listBox1 = new ListBox();
            buttonPrepare = new Button();
            buttonBake = new Button();
            buttonCut = new Button();
            buttonBox = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBoxPizza
            // 
            comboBoxPizza.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPizza.FormattingEnabled = true;
            comboBoxPizza.Location = new Point(36, 79);
            comboBoxPizza.Name = "comboBoxPizza";
            comboBoxPizza.Size = new Size(242, 40);
            comboBoxPizza.TabIndex = 0;
            comboBoxPizza.SelectedIndexChanged += comboBoxPizza_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 34);
            label1.Name = "label1";
            label1.Size = new Size(199, 32);
            label1.TabIndex = 1;
            label1.Text = "Select your pizza:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(311, 79);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(880, 324);
            listBox1.TabIndex = 2;
            // 
            // buttonPrepare
            // 
            buttonPrepare.Location = new Point(36, 144);
            buttonPrepare.Name = "buttonPrepare";
            buttonPrepare.Size = new Size(242, 46);
            buttonPrepare.TabIndex = 3;
            buttonPrepare.Text = "Prepare";
            buttonPrepare.UseVisualStyleBackColor = true;
            buttonPrepare.Click += buttonPrepare_Click;
            // 
            // buttonBake
            // 
            buttonBake.Location = new Point(36, 215);
            buttonBake.Name = "buttonBake";
            buttonBake.Size = new Size(242, 46);
            buttonBake.TabIndex = 4;
            buttonBake.Text = "Bake";
            buttonBake.UseVisualStyleBackColor = true;
            buttonBake.Click += buttonBake_Click;
            // 
            // buttonCut
            // 
            buttonCut.Location = new Point(36, 285);
            buttonCut.Name = "buttonCut";
            buttonCut.Size = new Size(242, 46);
            buttonCut.TabIndex = 5;
            buttonCut.Text = "Cut";
            buttonCut.UseVisualStyleBackColor = true;
            buttonCut.Click += buttonCut_Click;
            // 
            // buttonBox
            // 
            buttonBox.Location = new Point(36, 357);
            buttonBox.Name = "buttonBox";
            buttonBox.Size = new Size(242, 46);
            buttonBox.TabIndex = 6;
            buttonBox.Text = "Box";
            buttonBox.UseVisualStyleBackColor = true;
            buttonBox.Click += buttonBox_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(311, 34);
            label2.Name = "label2";
            label2.Size = new Size(143, 32);
            label2.TabIndex = 7;
            label2.Text = "Action Logs:";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 450);
            Controls.Add(label2);
            Controls.Add(buttonBox);
            Controls.Add(buttonCut);
            Controls.Add(buttonBake);
            Controls.Add(buttonPrepare);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(comboBoxPizza);
            Name = "App";
            Text = "Laboratory Work 2.2";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxPizza;
        private Label label1;
        private ListBox listBox1;
        private Button buttonPrepare;
        private Button buttonBake;
        private Button buttonCut;
        private Button buttonBox;
        private Label label2;
    }
}