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
            checkBoxKick = new CheckBox();
            checkBoxPunch = new CheckBox();
            checkBoxJump = new CheckBox();
            checkBoxRoll = new CheckBox();
            label1 = new Label();
            buttonStartBattle = new Button();
            listBox1 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            textBoxFighterName = new TextBox();
            SuspendLayout();
            // 
            // checkBoxKick
            // 
            checkBoxKick.AutoSize = true;
            checkBoxKick.Checked = true;
            checkBoxKick.CheckState = CheckState.Checked;
            checkBoxKick.Enabled = false;
            checkBoxKick.Location = new Point(44, 161);
            checkBoxKick.Name = "checkBoxKick";
            checkBoxKick.Size = new Size(89, 36);
            checkBoxKick.TabIndex = 0;
            checkBoxKick.Text = "Kick";
            checkBoxKick.UseVisualStyleBackColor = true;
            // 
            // checkBoxPunch
            // 
            checkBoxPunch.AutoSize = true;
            checkBoxPunch.Checked = true;
            checkBoxPunch.CheckState = CheckState.Checked;
            checkBoxPunch.Enabled = false;
            checkBoxPunch.Location = new Point(44, 198);
            checkBoxPunch.Name = "checkBoxPunch";
            checkBoxPunch.Size = new Size(112, 36);
            checkBoxPunch.TabIndex = 1;
            checkBoxPunch.Text = "Punch";
            checkBoxPunch.UseVisualStyleBackColor = true;
            // 
            // checkBoxJump
            // 
            checkBoxJump.AutoSize = true;
            checkBoxJump.Location = new Point(44, 235);
            checkBoxJump.Name = "checkBoxJump";
            checkBoxJump.Size = new Size(104, 36);
            checkBoxJump.TabIndex = 2;
            checkBoxJump.Text = "Jump";
            checkBoxJump.UseVisualStyleBackColor = true;
            // 
            // checkBoxRoll
            // 
            checkBoxRoll.AutoSize = true;
            checkBoxRoll.Location = new Point(44, 272);
            checkBoxRoll.Name = "checkBoxRoll";
            checkBoxRoll.Size = new Size(85, 36);
            checkBoxRoll.TabIndex = 3;
            checkBoxRoll.Text = "Roll";
            checkBoxRoll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 116);
            label1.Name = "label1";
            label1.Size = new Size(153, 32);
            label1.TabIndex = 4;
            label1.Text = "Use in battle:";
            // 
            // buttonStartBattle
            // 
            buttonStartBattle.Location = new Point(29, 469);
            buttonStartBattle.Name = "buttonStartBattle";
            buttonStartBattle.Size = new Size(279, 46);
            buttonStartBattle.TabIndex = 5;
            buttonStartBattle.Text = "Start battle";
            buttonStartBattle.UseVisualStyleBackColor = true;
            buttonStartBattle.Click += buttonStartBattle_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(351, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(807, 452);
            listBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(351, 21);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 7;
            label2.Text = "Fighter logs:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 21);
            label3.Name = "label3";
            label3.Size = new Size(161, 32);
            label3.TabIndex = 8;
            label3.Text = "Fighter name:";
            // 
            // textBoxFighterName
            // 
            textBoxFighterName.Location = new Point(29, 63);
            textBoxFighterName.Name = "textBoxFighterName";
            textBoxFighterName.Size = new Size(279, 39);
            textBoxFighterName.TabIndex = 9;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 538);
            Controls.Add(textBoxFighterName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(buttonStartBattle);
            Controls.Add(label1);
            Controls.Add(checkBoxRoll);
            Controls.Add(checkBoxJump);
            Controls.Add(checkBoxPunch);
            Controls.Add(checkBoxKick);
            Name = "App";
            Text = "Laboratory Work 8.2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxKick;
        private CheckBox checkBoxPunch;
        private CheckBox checkBoxJump;
        private CheckBox checkBoxRoll;
        private Label label1;
        private Button buttonStartBattle;
        private ListBox listBox1;
        private Label label2;
        private Label label3;
        private TextBox textBoxFighterName;
    }
}