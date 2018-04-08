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
    public partial class FormGroup : Form
    {
        private TreeView treeView;
        private formNewPro.DelegateRefreshTree RefreshTree;
        public FormGroup()
        {
            InitializeComponent();
        }

        public FormGroup(TreeView treeView, formNewPro.DelegateRefreshTree RefreshTree)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.treeView = treeView;
            this.RefreshTree = RefreshTree;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string level = this.treeView.SelectedNode != null ? this.treeView.SelectedNode.Tag.ToString() : "0";
            string groupText = this.textBox1.Text;
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            string sql = "insert into 属性检查表 (父节点,检查项) VALUES(" + level + ",'" + groupText + "')";
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
                //this.工程参数表TableAdapter.Fill(this.makemoneyDataSet.工程参数表);
                this.Close();
                RefreshTree();
            }
        }
    }
}
