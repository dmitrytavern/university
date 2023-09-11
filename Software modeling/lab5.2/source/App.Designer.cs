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
            comboBoxCountry = new ComboBox();
            label2 = new Label();
            textBoxCity = new TextBox();
            textBoxAddress = new TextBox();
            label3 = new Label();
            label4 = new Label();
            comboBoxProduct = new ComboBox();
            listBoxOrder = new ListBox();
            label5 = new Label();
            buttonAddProduct = new Button();
            buttonCreateOrder = new Button();
            labelResult = new Label();
            labelResultAddress = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 38);
            label1.Name = "label1";
            label1.Size = new Size(104, 32);
            label1.TabIndex = 0;
            label1.Text = "Country:";
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Items.AddRange(new object[] { "USA", "Ukraine" });
            comboBoxCountry.Location = new Point(39, 73);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(242, 40);
            comboBoxCountry.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(321, 38);
            label2.Name = "label2";
            label2.Size = new Size(60, 32);
            label2.TabIndex = 2;
            label2.Text = "City:";
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(321, 73);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(242, 39);
            textBoxCity.TabIndex = 3;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(604, 74);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(242, 39);
            textBoxAddress.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(604, 39);
            label3.Name = "label3";
            label3.Size = new Size(103, 32);
            label3.TabIndex = 4;
            label3.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 149);
            label4.Name = "label4";
            label4.Size = new Size(173, 32);
            label4.TabIndex = 6;
            label4.Text = "Select product:";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Items.AddRange(new object[] { "USA", "Ukraine" });
            comboBoxProduct.Location = new Point(39, 184);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(242, 40);
            comboBoxProduct.TabIndex = 7;
            // 
            // listBoxOrder
            // 
            listBoxOrder.FormattingEnabled = true;
            listBoxOrder.ItemHeight = 32;
            listBoxOrder.Location = new Point(321, 184);
            listBoxOrder.Name = "listBoxOrder";
            listBoxOrder.Size = new Size(525, 228);
            listBoxOrder.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(321, 149);
            label5.Name = "label5";
            label5.Size = new Size(80, 32);
            label5.TabIndex = 9;
            label5.Text = "Order:";
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(39, 242);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(242, 46);
            buttonAddProduct.TabIndex = 10;
            buttonAddProduct.Text = "Add product";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(39, 294);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(242, 46);
            buttonCreateOrder.TabIndex = 11;
            buttonCreateOrder.Text = "Create order";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += buttonCreateOrder_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(321, 439);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(158, 32);
            labelResult.TabIndex = 12;
            labelResult.Text = "Your price: $0";
            // 
            // labelResultAddress
            // 
            labelResultAddress.AutoSize = true;
            labelResultAddress.Location = new Point(321, 481);
            labelResultAddress.Name = "labelResultAddress";
            labelResultAddress.Size = new Size(154, 32);
            labelResultAddress.TabIndex = 13;
            labelResultAddress.Text = "Your address:";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 575);
            Controls.Add(labelResultAddress);
            Controls.Add(labelResult);
            Controls.Add(buttonCreateOrder);
            Controls.Add(buttonAddProduct);
            Controls.Add(label5);
            Controls.Add(listBoxOrder);
            Controls.Add(comboBoxProduct);
            Controls.Add(label4);
            Controls.Add(textBoxAddress);
            Controls.Add(label3);
            Controls.Add(textBoxCity);
            Controls.Add(label2);
            Controls.Add(comboBoxCountry);
            Controls.Add(label1);
            Name = "App";
            Text = "Form1";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxCountry;
        private Label label2;
        private TextBox textBoxCity;
        private TextBox textBoxAddress;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxProduct;
        private ListBox listBoxOrder;
        private Label label5;
        private Button buttonAddProduct;
        private Button buttonCreateOrder;
        private Label labelResult;
        private Label labelResultAddress;
    }
}