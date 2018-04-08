namespace _3sdnMap
{
    partial class formCalField
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listField = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblField = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listField);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字段";
            // 
            // listField
            // 
            this.listField.FormattingEnabled = true;
            this.listField.ItemHeight = 15;
            this.listField.Location = new System.Drawing.Point(10, 25);
            this.listField.Name = "listField";
            this.listField.Size = new System.Drawing.Size(290, 124);
            this.listField.TabIndex = 0;
            this.listField.DoubleClick += new System.EventHandler(this.listField_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExpression);
            this.groupBox2.Controls.Add(this.lblField);
            this.groupBox2.Location = new System.Drawing.Point(13, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表达式";
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(19, 24);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(0, 15);
            this.lblField.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "计算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtExpression
            // 
            this.txtExpression.Location = new System.Drawing.Point(10, 43);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(290, 74);
            this.txtExpression.TabIndex = 1;
            // 
            // formCalField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 385);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "formCalField";
            this.Text = "formCalField";
            this.Load += new System.EventHandler(this.formCalField_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ListBox listField;
        private System.Windows.Forms.TextBox txtExpression;
    }
}