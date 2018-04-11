namespace _3sdnMap
{
    partial class formNewPro
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.参数新增 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参数名称DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参数类型DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工程参数表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.makemoneyDataSet = new _3sdnMap.makemoneyDataSet();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.图形新增 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检查项DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.拓扑检查表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.makemoneyDataSet1 = new _3sdnMap.makemoneyDataSet1();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.属性删除 = new System.Windows.Forms.Button();
            this.属性编辑 = new System.Windows.Forms.Button();
            this.添加项 = new System.Windows.Forms.Button();
            this.添加分组 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.属性检查表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.makemoneyDataSet2 = new _3sdnMap.makemoneyDataSet2();
            this.工程参数表TableAdapter = new _3sdnMap.makemoneyDataSetTableAdapters.工程参数表TableAdapter();
            this.拓扑检查表TableAdapter = new _3sdnMap.makemoneyDataSet1TableAdapters.拓扑检查表TableAdapter();
            this.属性检查表TableAdapter = new _3sdnMap.makemoneyDataSet2TableAdapters.属性检查表TableAdapter();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.工程参数表BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.makemoneyDataSet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.拓扑检查表BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.makemoneyDataSet1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.属性检查表BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.makemoneyDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(705, 471);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.参数新增);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(697, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "要素类",
            "数据集",
            "文件夹",
            "工作空间",
            "文本框",
            "双精度"});
            this.comboBox1.Location = new System.Drawing.Point(24, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Visible = false;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem_1);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(603, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.参数删除_Click);
            // 
            // 参数新增
            // 
            this.参数新增.Location = new System.Drawing.Point(508, 7);
            this.参数新增.Name = "参数新增";
            this.参数新增.Size = new System.Drawing.Size(75, 23);
            this.参数新增.TabIndex = 1;
            this.参数新增.Text = "新增";
            this.参数新增.UseVisualStyleBackColor = true;
            this.参数新增.Click += new System.EventHandler(this.参数新增_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.参数名称DataGridViewTextBoxColumn,
            this.参数类型DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.工程参数表BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(690, 341);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // 参数名称DataGridViewTextBoxColumn
            // 
            this.参数名称DataGridViewTextBoxColumn.DataPropertyName = "参数名称";
            this.参数名称DataGridViewTextBoxColumn.HeaderText = "参数名称";
            this.参数名称DataGridViewTextBoxColumn.Name = "参数名称DataGridViewTextBoxColumn";
            this.参数名称DataGridViewTextBoxColumn.Width = 290;
            // 
            // 参数类型DataGridViewTextBoxColumn
            // 
            this.参数类型DataGridViewTextBoxColumn.DataPropertyName = "参数类型";
            this.参数类型DataGridViewTextBoxColumn.HeaderText = "参数类型";
            this.参数类型DataGridViewTextBoxColumn.Name = "参数类型DataGridViewTextBoxColumn";
            this.参数类型DataGridViewTextBoxColumn.Width = 305;
            // 
            // 工程参数表BindingSource
            // 
            this.工程参数表BindingSource.DataMember = "工程参数表";
            this.工程参数表BindingSource.DataSource = this.makemoneyDataSet;
            // 
            // makemoneyDataSet
            // 
            this.makemoneyDataSet.DataSetName = "makemoneyDataSet";
            this.makemoneyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.图形新增);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(697, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图形检查";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(614, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(528, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "编辑";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // 图形新增
            // 
            this.图形新增.Location = new System.Drawing.Point(447, 6);
            this.图形新增.Name = "图形新增";
            this.图形新增.Size = new System.Drawing.Size(75, 23);
            this.图形新增.TabIndex = 1;
            this.图形新增.Text = "新增";
            this.图形新增.UseVisualStyleBackColor = true;
            this.图形新增.Click += new System.EventHandler(this.图形新增_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.检查项DataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.拓扑检查表BindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(3, 48);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(691, 337);
            this.dataGridView2.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn1.Width = 50;
            // 
            // 检查项DataGridViewTextBoxColumn
            // 
            this.检查项DataGridViewTextBoxColumn.DataPropertyName = "检查项";
            this.检查项DataGridViewTextBoxColumn.HeaderText = "检查项";
            this.检查项DataGridViewTextBoxColumn.Name = "检查项DataGridViewTextBoxColumn";
            this.检查项DataGridViewTextBoxColumn.ReadOnly = true;
            this.检查项DataGridViewTextBoxColumn.Width = 595;
            // 
            // 拓扑检查表BindingSource
            // 
            this.拓扑检查表BindingSource.DataMember = "拓扑检查表";
            this.拓扑检查表BindingSource.DataSource = this.makemoneyDataSet1;
            // 
            // makemoneyDataSet1
            // 
            this.makemoneyDataSet1.DataSetName = "makemoneyDataSet1";
            this.makemoneyDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.属性删除);
            this.tabPage4.Controls.Add(this.属性编辑);
            this.tabPage4.Controls.Add(this.添加项);
            this.tabPage4.Controls.Add(this.添加分组);
            this.tabPage4.Controls.Add(this.treeView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(697, 442);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "属性检查";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button5_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(574, 398);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // 属性删除
            // 
            this.属性删除.Location = new System.Drawing.Point(586, 6);
            this.属性删除.Name = "属性删除";
            this.属性删除.Size = new System.Drawing.Size(75, 23);
            this.属性删除.TabIndex = 5;
            this.属性删除.Text = "删除";
            this.属性删除.UseVisualStyleBackColor = true;
            // 
            // 属性编辑
            // 
            this.属性编辑.Location = new System.Drawing.Point(500, 6);
            this.属性编辑.Name = "属性编辑";
            this.属性编辑.Size = new System.Drawing.Size(75, 23);
            this.属性编辑.TabIndex = 6;
            this.属性编辑.Text = "编辑";
            this.属性编辑.UseVisualStyleBackColor = true;
            // 
            // 添加项
            // 
            this.添加项.Location = new System.Drawing.Point(378, 6);
            this.添加项.Name = "添加项";
            this.添加项.Size = new System.Drawing.Size(116, 23);
            this.添加项.TabIndex = 7;
            this.添加项.Text = "添加项";
            this.添加项.UseVisualStyleBackColor = true;
            this.添加项.Click += new System.EventHandler(this.button6_Click);
            // 
            // 添加分组
            // 
            this.添加分组.Location = new System.Drawing.Point(266, 6);
            this.添加分组.Name = "添加分组";
            this.添加分组.Size = new System.Drawing.Size(106, 23);
            this.添加分组.TabIndex = 7;
            this.添加分组.Text = "添加分组";
            this.添加分组.UseVisualStyleBackColor = true;
            this.添加分组.Click += new System.EventHandler(this.添加分组_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 54);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(691, 326);
            this.treeView1.TabIndex = 0;
            // 
            // 属性检查表BindingSource
            // 
            this.属性检查表BindingSource.DataMember = "属性检查表";
            this.属性检查表BindingSource.DataSource = this.makemoneyDataSet2;
            // 
            // makemoneyDataSet2
            // 
            this.makemoneyDataSet2.DataSetName = "makemoneyDataSet2";
            this.makemoneyDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // 工程参数表TableAdapter
            // 
            this.工程参数表TableAdapter.ClearBeforeFill = true;
            // 
            // 拓扑检查表TableAdapter
            // 
            this.拓扑检查表TableAdapter.ClearBeforeFill = true;
            // 
            // 属性检查表TableAdapter
            // 
            this.属性检查表TableAdapter.ClearBeforeFill = true;
            // 
            // formNewPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 471);
            this.Controls.Add(this.tabControl1);
            this.Name = "formNewPro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fromNewPro";
            this.Load += new System.EventHandler(this.fromNewPro_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.工程参数表BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.makemoneyDataSet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.拓扑检查表BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.makemoneyDataSet1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.属性检查表BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.makemoneyDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private makemoneyDataSet makemoneyDataSet;
        private System.Windows.Forms.BindingSource 工程参数表BindingSource;
        private makemoneyDataSetTableAdapters.工程参数表TableAdapter 工程参数表TableAdapter;
        private makemoneyDataSet1 makemoneyDataSet1;
        private System.Windows.Forms.BindingSource 拓扑检查表BindingSource;
        private makemoneyDataSet1TableAdapters.拓扑检查表TableAdapter 拓扑检查表TableAdapter;
        private makemoneyDataSet2 makemoneyDataSet2;
        private System.Windows.Forms.BindingSource 属性检查表BindingSource;
        private makemoneyDataSet2TableAdapters.属性检查表TableAdapter 属性检查表TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数类型DataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button 参数新增;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检查项DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button 图形新增;
        private System.Windows.Forms.TabPage tabPage4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button 属性删除;
        private System.Windows.Forms.Button 属性编辑;
        private System.Windows.Forms.Button 添加分组;
        private System.Windows.Forms.Button 添加项;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
    }
}