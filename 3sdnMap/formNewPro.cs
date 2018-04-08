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
    public partial class formNewPro : Form
    {
        public formNewPro()
        {
            InitializeComponent();
        }
        public delegate void DelegateRefreshTree();
        public delegate void DelegateRefreshTopo();
        private void fromNewPro_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“makemoneyDataSet2.属性检查表”中。您可以根据需要移动或删除它。
            this.属性检查表TableAdapter.Fill(this.makemoneyDataSet2.属性检查表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet1.拓扑检查表”中。您可以根据需要移动或删除它。
            this.拓扑检查表TableAdapter.Fill(this.makemoneyDataSet1.拓扑检查表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter.Fill(this.makemoneyDataSet.工程参数表);

            this.dataGridView1.Controls.Add(comboBox1);
            bindTreeView1();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && comboBox1.SelectedIndex != -1)
                dataGridView1.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewColumn column = dataGridView1.CurrentCell.OwningColumn;
            if (column.DisplayIndex.Equals(2))
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                comboBox1.Left = rect.Left;
                comboBox1.Top = rect.Top;
                comboBox1.Width = rect.Width;
                comboBox1.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = comboBox1.Items.IndexOf(consultingRoom);

                comboBox1.SelectedIndex = index;
                comboBox1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
            }
        }


        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].DataPropertyName.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null) 
            {
                string strId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string strCell = dataGridView1.CurrentCell.Value.ToString();
                string strCellCol = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].DataPropertyName;
                string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
                string sql = "update 工程参数表 set " + strCellCol + " = '" + strCell + "' where id = " + strId;
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
                    this.工程参数表TableAdapter.Fill(this.makemoneyDataSet.工程参数表);

                }
            }
        }


        private void comboBox1_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
        }

        private void 参数新增_Click(object sender, EventArgs e)
        {
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            string sql = "insert into 工程参数表 (参数名称,参数类型,备注) VALUES('','','')";
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
                this.工程参数表TableAdapter.Fill(this.makemoneyDataSet.工程参数表);
            }
        }

        private void 参数删除_Click(object sender, EventArgs e)
        {
            string strId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            string sql = "delete from 工程参数表 where id = " + strId;
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
                this.工程参数表TableAdapter.Fill(this.makemoneyDataSet.工程参数表);

            }
        }

        private void 图形新增_Click(object sender, EventArgs e)
        {
            DelegateRefreshTopo refreshTopo = new DelegateRefreshTopo(RefreshTopoFun);
            formTopo formTopoDig = new formTopo(refreshTopo);
            formTopoDig.Show();
        }
        private void RefreshTopoFun() 
        {
            this.拓扑检查表TableAdapter.Fill(this.makemoneyDataSet1.拓扑检查表);
        }
        private void 属性新增_Click(object sender, EventArgs e)
        {
            formProperty formPropertyDIg = new formProperty();
            formPropertyDIg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formProperty formPropertyDig = new formProperty();
            formPropertyDig.Show();
        }

        private void bindTreeView1()
        {
            this.treeView1.Nodes.Clear();
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(strFilePath);
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string sqlstr = "select * from 属性检查表";
                DataSet ds = new DataSet();
                conn.Open();
                adapter.SelectCommand = new OleDbCommand(sqlstr, conn);
                adapter.Fill(ds, "属性检查表");
                DataTable dt = ds.Tables["属性检查表"];
                conn.Close();
                DataRow[] dr = dt.Select("父节点 = 0");

                TreeNode rootNode = new TreeNode();
                rootNode.Text = "属性检查";
                rootNode.Tag = "0";
                treeView1.Nodes.Add(rootNode);
                for (int i = 0; i < dr.Length; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dr[i]["检查项"].ToString();
                    tn.Tag = dr[i]["id"].ToString();
                    FillTree(tn, dt);
                    rootNode.Nodes.Add(tn);
                }
            }  
            catch (Exception e)
            {
                throw (new Exception("数据库出错:" + e.Message));
            }
        }

        private void FillTree(TreeNode node, DataTable dt)
        {
            DataRow[] drr = dt.Select("父节点='" + node.Tag.ToString() + "'");
            if (drr.Length > 0)
            {
                for (int i = 0; i < drr.Length; i++)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = drr[i]["检查项"].ToString();
                    tnn.Tag = drr[i]["id"].ToString();
                    if (drr[i]["父节点"].ToString() == node.Tag.ToString())
                    {
                        FillTree(tnn, dt);
                    }
                    node.Nodes.Add(tnn);
                }
            }
        }

        private void 添加分组_Click(object sender, EventArgs e)
        {
            DelegateRefreshTree RefreshTree = new DelegateRefreshTree(bindTreeView1);
            string level = this.treeView1.SelectedNode != null ? this.treeView1.SelectedNode.Tag.ToString():"0";
            FormGroup FormGroupDig = new FormGroup(this.treeView1, RefreshTree);
            FormGroupDig.Show();
            this.treeView1.Refresh();
        }
    }
}
