namespace Cafe
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
            comboBoxProducts = new ComboBox();
            listBoxOrder = new ListBox();
            labelProductSelector = new Label();
            numericProductQuantity = new NumericUpDown();
            labelProductQuantity = new Label();
            labelOrderList = new Label();
            buttonCalculateOrder = new Button();
            labelTotal = new Label();
            buttonAddProduct = new Button();
            labelTotalPrice = new Label();
            buttonClearOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)numericProductQuantity).BeginInit();
            SuspendLayout();
            // 
            // comboBoxProducts
            // 
            comboBoxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProducts.FormattingEnabled = true;
            comboBoxProducts.Location = new Point(60, 76);
            comboBoxProducts.Name = "comboBoxProducts";
            comboBoxProducts.Size = new Size(242, 40);
            comboBoxProducts.TabIndex = 0;
            // 
            // listBoxOrder
            // 
            listBoxOrder.FormattingEnabled = true;
            listBoxOrder.ItemHeight = 32;
            listBoxOrder.Location = new Point(60, 205);
            listBoxOrder.Name = "listBoxOrder";
            listBoxOrder.Size = new Size(445, 228);
            listBoxOrder.TabIndex = 1;
            // 
            // labelProductSelector
            // 
            labelProductSelector.AutoSize = true;
            labelProductSelector.Location = new Point(60, 31);
            labelProductSelector.Name = "labelProductSelector";
            labelProductSelector.Size = new Size(173, 32);
            labelProductSelector.TabIndex = 2;
            labelProductSelector.Text = "Select product:";
            // 
            // numericProductQuantity
            // 
            numericProductQuantity.Location = new Point(327, 77);
            numericProductQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericProductQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericProductQuantity.Name = "numericProductQuantity";
            numericProductQuantity.Size = new Size(178, 39);
            numericProductQuantity.TabIndex = 3;
            numericProductQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelProductQuantity
            // 
            labelProductQuantity.AutoSize = true;
            labelProductQuantity.Location = new Point(327, 31);
            labelProductQuantity.Name = "labelProductQuantity";
            labelProductQuantity.Size = new Size(178, 32);
            labelProductQuantity.TabIndex = 4;
            labelProductQuantity.Text = "Select quantity:";
            // 
            // labelOrderList
            // 
            labelOrderList.AutoSize = true;
            labelOrderList.Location = new Point(60, 159);
            labelOrderList.Name = "labelOrderList";
            labelOrderList.Size = new Size(167, 32);
            labelOrderList.TabIndex = 5;
            labelOrderList.Text = "Your order list:";
            // 
            // buttonCalculateOrder
            // 
            buttonCalculateOrder.Location = new Point(560, 205);
            buttonCalculateOrder.Name = "buttonCalculateOrder";
            buttonCalculateOrder.Size = new Size(212, 97);
            buttonCalculateOrder.TabIndex = 6;
            buttonCalculateOrder.Text = "Calculate order";
            buttonCalculateOrder.UseVisualStyleBackColor = true;
            buttonCalculateOrder.Click += buttonCalculateOrder_Click;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotal.Location = new Point(385, 467);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(120, 51);
            labelTotal.TabIndex = 7;
            labelTotal.Text = "Total:";
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(560, 76);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(212, 40);
            buttonAddProduct.TabIndex = 8;
            buttonAddProduct.Text = "Add";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalPrice.ForeColor = Color.Green;
            labelTotalPrice.Location = new Point(560, 467);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(66, 51);
            labelTotalPrice.TabIndex = 11;
            labelTotalPrice.Text = "$0";
            // 
            // buttonClearOrder
            // 
            buttonClearOrder.Location = new Point(560, 336);
            buttonClearOrder.Name = "buttonClearOrder";
            buttonClearOrder.Size = new Size(212, 97);
            buttonClearOrder.TabIndex = 12;
            buttonClearOrder.Text = "Clear";
            buttonClearOrder.UseVisualStyleBackColor = true;
            buttonClearOrder.Click += buttonClearOrder_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 545);
            Controls.Add(buttonClearOrder);
            Controls.Add(labelTotalPrice);
            Controls.Add(buttonAddProduct);
            Controls.Add(labelTotal);
            Controls.Add(buttonCalculateOrder);
            Controls.Add(labelOrderList);
            Controls.Add(labelProductQuantity);
            Controls.Add(numericProductQuantity);
            Controls.Add(labelProductSelector);
            Controls.Add(listBoxOrder);
            Controls.Add(comboBoxProducts);
            Name = "App";
            Text = "Laboratory Work 2";
            ((System.ComponentModel.ISupportInitialize)numericProductQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxProducts;
        private ListBox listBoxOrder;
        private Label labelProductSelector;
        private NumericUpDown numericProductQuantity;
        private Label labelProductQuantity;
        private Label labelOrderList;
        private Button buttonCalculateOrder;
        private Label labelTotal;
        private Button buttonAddProduct;
        private Label labelTotalPrice;
        private Button buttonClearOrder;
    }
}