namespace YGOProComboCalculator
{
    partial class DeckWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeckListBox = new System.Windows.Forms.ListBox();
            this.ComboListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.AddAnotherButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.GoFirstCheckbox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // DeckListBox
            // 
            this.DeckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeckListBox.FormattingEnabled = true;
            this.DeckListBox.ItemHeight = 25;
            this.DeckListBox.Location = new System.Drawing.Point(12, 18);
            this.DeckListBox.Name = "DeckListBox";
            this.DeckListBox.Size = new System.Drawing.Size(369, 304);
            this.DeckListBox.TabIndex = 0;
            this.DeckListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DeckListBox_MouseDoubleClick);
            // 
            // ComboListBox
            // 
            this.ComboListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ComboListBox.FormattingEnabled = true;
            this.ComboListBox.ItemHeight = 25;
            this.ComboListBox.Location = new System.Drawing.Point(419, 18);
            this.ComboListBox.Name = "ComboListBox";
            this.ComboListBox.Size = new System.Drawing.Size(369, 304);
            this.ComboListBox.TabIndex = 1;
            this.ComboListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ComboListBox_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Double click the card name to move it between deck and combo list.";
            // 
            // CalculateButton
            // 
            this.CalculateButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CalculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CalculateButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CalculateButton.Location = new System.Drawing.Point(595, 408);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(193, 42);
            this.CalculateButton.TabIndex = 0;
            this.CalculateButton.Text = "Test the hands for combos";
            this.CalculateButton.UseVisualStyleBackColor = false;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // AddAnotherButton
            // 
            this.AddAnotherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddAnotherButton.Location = new System.Drawing.Point(213, 404);
            this.AddAnotherButton.Name = "AddAnotherButton";
            this.AddAnotherButton.Size = new System.Drawing.Size(168, 42);
            this.AddAnotherButton.TabIndex = 3;
            this.AddAnotherButton.Text = "Add another combo";
            this.AddAnotherButton.UseVisualStyleBackColor = true;
            this.AddAnotherButton.Click += new System.EventHandler(this.AddAnotherButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(12, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Reset combos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ResetCombosButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(595, 372);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(140, 26);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount of hands tested:";
            // 
            // GoFirstCheckbox
            // 
            this.GoFirstCheckbox.AutoSize = true;
            this.GoFirstCheckbox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GoFirstCheckbox.Checked = true;
            this.GoFirstCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GoFirstCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GoFirstCheckbox.Location = new System.Drawing.Point(735, 365);
            this.GoFirstCheckbox.Name = "GoFirstCheckbox";
            this.GoFirstCheckbox.Size = new System.Drawing.Size(53, 33);
            this.GoFirstCheckbox.TabIndex = 8;
            this.GoFirstCheckbox.Text = "Go First";
            this.GoFirstCheckbox.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(12, 413);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "Pick another deck";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DeckWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GoFirstCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.AddAnotherButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboListBox);
            this.Controls.Add(this.DeckListBox);
            this.Name = "DeckWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Combo Picker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeckWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox DeckListBox;
        private System.Windows.Forms.ListBox ComboListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button AddAnotherButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox GoFirstCheckbox;
        private System.Windows.Forms.Button button2;
    }
}