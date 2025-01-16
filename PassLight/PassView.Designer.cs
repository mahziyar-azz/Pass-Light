namespace PassLight
{
    partial class PassView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.Close_button = new System.Windows.Forms.Button();
            this.Copy_button = new System.Windows.Forms.Button();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.name_textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Close_button, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Copy_button, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Password_textBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.15038F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 266);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // name_textBox
            // 
            this.name_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_textBox.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_textBox.Location = new System.Drawing.Point(3, 3);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(443, 25);
            this.name_textBox.TabIndex = 1;
            this.name_textBox.TextChanged += new System.EventHandler(this.name_textBox_TextChanged);
            // 
            // Close_button
            // 
            this.Close_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Close_button.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_button.Location = new System.Drawing.Point(3, 224);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(443, 39);
            this.Close_button.TabIndex = 2;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_Click);
            // 
            // Copy_button
            // 
            this.Copy_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Copy_button.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copy_button.Location = new System.Drawing.Point(3, 176);
            this.Copy_button.Name = "Copy_button";
            this.Copy_button.Size = new System.Drawing.Size(443, 42);
            this.Copy_button.TabIndex = 0;
            this.Copy_button.Text = "Copy Password";
            this.Copy_button.UseVisualStyleBackColor = true;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Password_textBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_textBox.Location = new System.Drawing.Point(3, 28);
            this.Password_textBox.Multiline = true;
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(443, 142);
            this.Password_textBox.TabIndex = 3;
            // 
            // PassView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PassView";
            this.Text = "Check Pass";
            this.Load += new System.EventHandler(this.PassView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button Copy_button;
        public System.Windows.Forms.TextBox name_textBox;
        public System.Windows.Forms.Button Close_button;
        public System.Windows.Forms.TextBox Password_textBox;
    }
}