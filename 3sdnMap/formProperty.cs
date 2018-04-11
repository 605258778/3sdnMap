using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3sdnMap
{
    public partial class formProperty : Form
    {
        private TreeView treeView;
        private formNewPro.DelegateRefreshTree RefreshTree;
        public formProperty()
        {
            InitializeComponent();
        }

        public formProperty(TreeView treeView, formNewPro.DelegateRefreshTree RefreshTree)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.treeView = treeView;
            this.RefreshTree = RefreshTree;
        }

        private void FormProperty_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“makemoneyDataSet8.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter.Fill(this.makemoneyDataSet8.工程参数表);
            //// TODO: 这行代码将数据加载到表“makemoneyDataSet4.工程参数表”中。您可以根据需要移动或删除它。
            //this.工程参数表TableAdapter.Fill(this.makemoneyDataSet4.工程参数表);
            //fromNewPro fromNewProDig = new fromNewPro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string level = this.treeView.SelectedNode != null ? this.treeView.SelectedNode.Tag.ToString() : "0";
            string checkName = this.textBox1.Text;
            string dataSource = this.comboBox1.Text;
            string checkOption = this.comboBox2.Text;
            string checkwhere = this.textBox3.Text;
            string checkResult = this.textBox4.Text;

            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            string sql = "insert into 属性检查表 (父节点,检查项,涉及表,辅助表,检查类型,筛选,条件,结果,是否质检项) VALUES(" + level
                + ",'" + checkName + "','" + dataSource + "','','','" + checkOption + "','" + checkwhere + "','" + checkResult + "','1')";
            System.Data.OleDb.OleDbConnection con = new OleDbConnection(strFilePath);
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                this.Close();
                RefreshTree();
            }
        }
    }
}
