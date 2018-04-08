using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3sdnMap
{
    public partial class fromNewPro111 : Form
    {
        public fromNewPro111()
        {
            InitializeComponent();
        }

        private void fromNewPro_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“makemoneyDataSet5.拓扑检查表”中。您可以根据需要移动或删除它。
            //this.拓扑检查表TableAdapter1.Fill(this.makemoneyDataSet5.拓扑检查表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet2.拓扑检查表”中。您可以根据需要移动或删除它。
            //this.拓扑检查表TableAdapter.Fill(this.makemoneyDataSet2.拓扑检查表);
            this.dataGridView2.Columns[0].Width = this.dataGridView2.Width - 45;
            this.dataGridView3.Columns[0].Width = this.dataGridView3.Width - 45;
            this.dataGridView1.Columns[0].Width = 45;
            this.dataGridView1.Columns[1].Width = this.dataGridView1.Width/2-50;
            this.dataGridView1.Columns[2].Width = this.dataGridView1.Width / 2 - 40;
            this.dataGridView1.Columns[1].ReadOnly = true;  
            this.dataGridView1.Controls.Add(comboBox1);
            //this.dataGridView1.BeginEdit(true);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet1.工程参数表”中。您可以根据需要移动或删除它。
            //this.工程参数表TableAdapter.Fill(this.makemoneyDataSet1.工程参数表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet.数据参数表”中。您可以根据需要移动或删除它。
            //this.数据参数表TableAdapter.Fill(this.makemoneyDataSet.数据参数表);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && comboBox1.SelectedIndex!= -1)
                dataGridView1.CurrentCell.Value = comboBox1.Items[comboBox1.SelectedIndex];
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewColumn column = dataGridView1.CurrentCell.OwningColumn;
            if (column.DisplayIndex.Equals(1))
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

        private void button1_Click(object sender, EventArgs e)
        {
            formTopo formtopoDig = new formTopo();
            formtopoDig.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            string sql = "select * from 工程参数表";
            System.Data.OleDb.OleDbConnection con = new OleDbConnection(strFilePath);
            System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            DataTable dt = new DataTable("工程参数表");
            dt = GetDgvToTable(this.dataGridView1);
            try
            {
                OleDbCommandBuilder cmBuilder = new OleDbCommandBuilder(da);
                da.Update(dt);
                //this.工程参数表TableAdapter.Fill(this.makemoneyDataSet1.工程参数表);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                da.Dispose();
            }
            
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            System.Data.OleDb.OleDbConnection con = new OleDbConnection(strFilePath);
            try
            {
                string strRow = dataGridView1.CurrentCell.Value.ToString();
                string sql = "delete from 工程参数表 Where 参数名称 = '" + strRow + "'";
                con.Open();
                System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                OleDbCommand thisCommand = new System.Data.OleDb.OleDbCommand(sql, con);
                thisCommand.ExecuteNonQuery();  
                //this.工程参数表TableAdapter.Fill(this.makemoneyDataSet1.工程参数表);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
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
    }
}
