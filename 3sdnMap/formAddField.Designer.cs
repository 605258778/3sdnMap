namespace _3sdnMap
{
    partial class formAddField
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
            this.addfieldname = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.addfieldltype = new System.Windows.Forms.Label();
            this.cmbFieldType = new System.Windows.Forms.ComboBox();
            this.addfieldattribute = new System.Windows.Forms.GroupBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.txtPrecision = new System.Windows.Forms.TextBox();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.addfieldattribute.SuspendLayout();
            this.SuspendLayout();
            // 
            // addfieldname
            // 
            this.addfieldname.AutoSize = true;
            this.addfieldname.Location = new System.Drawing.Point(46, 26);
            this.addfieldname.Name = "addfieldname";
            this.addfieldname.Size = new System.Drawing.Size(45, 15);
            this.addfieldname.TabIndex = 0;
            this.addfieldname.Text = "名称:";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(104, 16);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(183, 25);
            this.txtFieldName.TabIndex = 1;
            // 
            // addfieldltype
            // 
            this.addfieldltype.AutoSize = true;
            this.addfieldltype.Location = new System.Drawing.Point(46, 65);
            this.addfieldltype.Name = "addfieldltype";
            this.addfieldltype.Size = new System.Drawing.Size(52, 15);
            this.addfieldltype.TabIndex = 2;
            this.addfieldltype.Text = "类型：";
            // 
            // cmbFieldType
            // 
            this.cmbFieldType.FormattingEnabled = true;
            this.cmbFieldType.Location = new System.Drawing.Point(104, 57);
            this.cmbFieldType.Name = "cmbFieldType";
            this.cmbFieldType.Size = new System.Drawing.Size(183, 23);
            this.cmbFieldType.TabIndex = 3;
            // 
            // addfieldattribute
            // 
            this.addfieldattribute.Controls.Add(this.lable1);
            this.addfieldattribute.Controls.Add(this.txtScale);
            this.addfieldattribute.Controls.Add(this.txtPrecision);
            this.addfieldattribute.Controls.Add(this.lblPrecision);
            this.addfieldattribute.Location = new System.Drawing.Point(49, 105);
            this.addfieldattribute.Name = "addfieldattribute";
            this.addfieldattribute.Size = new System.Drawing.Size(238, 165);
            this.addfieldattribute.TabIndex = 4;
            this.addfieldattribute.TabStop = false;
            this.addfieldattribute.Text = "字段属性";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(36, 65);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(37, 15);
            this.lable1.TabIndex = 4;
            this.lable1.Text = "比例";
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(92, 62);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(140, 25);
            this.txtScale.TabIndex = 2;
            // 
            // txtPrecision
            // 
            this.txtPrecision.Location = new System.Drawing.Point(92, 26);
            this.txtPrecision.Name = "txtPrecision";
            this.txtPrecision.Size = new System.Drawing.Size(140, 25);
            this.txtPrecision.TabIndex = 1;
            // 
            // lblPrecision
            // 
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Location = new System.Drawing.Point(36, 36);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(37, 15);
            this.lblPrecision.TabIndex = 0;
            this.lblPrecision.Text = "精度";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(141, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 31);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(231, 276);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(56, 31);
            this.btnCancle.TabIndex = 6;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // formAddField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 311);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.addfieldattribute);
            this.Controls.Add(this.cmbFieldType);
            this.Controls.Add(this.addfieldltype);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.addfieldname);
            this.Name = "formAddField";
            this.Text = "新增字段";
            this.Load += new System.EventHandler(this.formAddField_Load);
            this.addfieldattribute.ResumeLayout(false);
            this.addfieldattribute.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addfieldname;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Label addfieldltype;
        private System.Windows.Forms.ComboBox cmbFieldType;
        private System.Windows.Forms.GroupBox addfieldattribute;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.TextBox txtPrecision;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
    }
}