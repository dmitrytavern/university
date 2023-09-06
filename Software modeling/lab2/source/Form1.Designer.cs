namespace Lab2
{
    partial class Form1
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
            comboBoxCafeItems = new ComboBox();
            listBoxOrder = new ListBox();
            labelCafeItemSelector = new Label();
            numericCafeItemQuantity = new NumericUpDown();
            labelCafeItemQuantity = new Label();
            labelOrderList = new Label();
            buttonCalculateTotal = new Button();
            labelTotalPrice = new Label();
            buttonAddCafeItem = new Button();
            ((System.ComponentModel.ISupportInitialize)numericCafeItemQuantity).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCafeItems
            // 
            comboBoxCafeItems.FormattingEnabled = true;
            comboBoxCafeItems.Location = new Point(60, 89);
            comboBoxCafeItems.Name = "comboBoxCafeItems";
            comboBoxCafeItems.Size = new Size(242, 40);
            comboBoxCafeItems.TabIndex = 0;
            // 
            // listBoxOrder
            // 
            listBoxOrder.FormattingEnabled = true;
            listBoxOrder.ItemHeight = 32;
            listBoxOrder.Location = new Point(60, 205);
            listBoxOrder.Name = "listBoxOrder";
            listBoxOrder.Size = new Size(620, 164);
            listBoxOrder.TabIndex = 1;
            // 
            // labelCafeItemSelector
            // 
            labelCafeItemSelector.AutoSize = true;
            labelCafeItemSelector.Location = new Point(60, 43);
            labelCafeItemSelector.Name = "labelCafeItemSelector";
            labelCafeItemSelector.Size = new Size(189, 32);
            labelCafeItemSelector.TabIndex = 2;
            labelCafeItemSelector.Text = "Select cafe item:";
            // 
            // numericCafeItemQuantity
            // 
            numericCafeItemQuantity.Location = new Point(332, 89);
            numericCafeItemQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericCafeItemQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCafeItemQuantity.Name = "numericCafeItemQuantity";
            numericCafeItemQuantity.Size = new Size(178, 39);
            numericCafeItemQuantity.TabIndex = 3;
            numericCafeItemQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelCafeItemQuantity
            // 
            labelCafeItemQuantity.AutoSize = true;
            labelCafeItemQuantity.Location = new Point(332, 43);
            labelCafeItemQuantity.Name = "labelCafeItemQuantity";
            labelCafeItemQuantity.Size = new Size(178, 32);
            labelCafeItemQuantity.TabIndex = 4;
            labelCafeItemQuantity.Text = "Select quantity:";
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
            // buttonCalculateTotal
            // 
            buttonCalculateTotal.Location = new Point(60, 390);
            buttonCalculateTotal.Name = "buttonCalculateTotal";
            buttonCalculateTotal.Size = new Size(212, 46);
            buttonCalculateTotal.TabIndex = 6;
            buttonCalculateTotal.Text = "Calculate price";
            buttonCalculateTotal.UseVisualStyleBackColor = true;
            buttonCalculateTotal.Click += buttonCalculateTotal_Click;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new Point(60, 459);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(158, 32);
            labelTotalPrice.TabIndex = 7;
            labelTotalPrice.Text = "Your price: $0";
            // 
            // buttonAddCafeItem
            // 
            buttonAddCafeItem.Location = new Point(550, 89);
            buttonAddCafeItem.Name = "buttonAddCafeItem";
            buttonAddCafeItem.Size = new Size(130, 40);
            buttonAddCafeItem.TabIndex = 8;
            buttonAddCafeItem.Text = "Add";
            buttonAddCafeItem.UseVisualStyleBackColor = true;
            buttonAddCafeItem.Click += buttonAddItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 545);
            Controls.Add(buttonAddCafeItem);
            Controls.Add(labelTotalPrice);
            Controls.Add(buttonCalculateTotal);
            Controls.Add(labelOrderList);
            Controls.Add(labelCafeItemQuantity);
            Controls.Add(numericCafeItemQuantity);
            Controls.Add(labelCafeItemSelector);
            Controls.Add(listBoxOrder);
            Controls.Add(comboBoxCafeItems);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericCafeItemQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCafeItems;
        private ListBox listBoxOrder;
        private Label labelCafeItemSelector;
        private NumericUpDown numericCafeItemQuantity;
        private Label labelCafeItemQuantity;
        private Label labelOrderList;
        private Button buttonCalculateTotal;
        private Label labelTotalPrice;
        private Button buttonAddCafeItem;
    }
}