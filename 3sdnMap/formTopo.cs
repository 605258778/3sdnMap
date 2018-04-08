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
    public partial class formTopo : Form
    {
        private formNewPro.DelegateRefreshTopo refreshTopo;

        public formTopo()
        {
            InitializeComponent();
        }

        public formTopo(formNewPro.DelegateRefreshTopo refreshTopo)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.refreshTopo = refreshTopo;
        }

        private void formTopo_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“makemoneyDataSet7.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter4.Fill(this.makemoneyDataSet7.工程参数表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet6.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter3.Fill(this.makemoneyDataSet6.工程参数表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet5.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter2.Fill(this.makemoneyDataSet5.工程参数表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet4.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter1.Fill(this.makemoneyDataSet4.工程参数表);
            // TODO: 这行代码将数据加载到表“makemoneyDataSet3.工程参数表”中。您可以根据需要移动或删除它。
            this.工程参数表TableAdapter.Fill(this.makemoneyDataSet3.工程参数表);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedText = this.comboBox2.SelectedItem.ToString();
            switch (selectedText) 
            {
                case "面内包含点个数":
                    this.groupBoxbjbxj.Visible = false;
                    this.groupBoxmbhd.Visible = true;
                    this.groupBoxmmcd.Visible = false;
                    this.groupBoxxmb.Visible = false;
                    this.groupBoxxmbxj.Visible = false;
                    break;
                case "面和线不相交":
                    this.groupBoxbjbxj.Visible = false;
                    this.groupBoxmbhd.Visible = false;
                    this.groupBoxmmcd.Visible = false;
                    this.groupBoxxmb.Visible = false;
                    this.groupBoxxmbxj.Visible = true;
                    break;
                case "跨边界面不相交":
                    this.groupBoxmbhd.Visible = false;
                    this.groupBoxmmcd.Visible = false;
                    this.groupBoxxmb.Visible = false;
                    this.groupBoxxmbxj.Visible = false;
                    this.groupBoxbjbxj.Visible = true;
                    break;
                case "跨图层面重叠":
                    this.groupBoxbjbxj.Visible = false;
                    this.groupBoxmbhd.Visible = false;
                    this.groupBoxmmcd.Visible = true;
                    this.groupBoxxmb.Visible = false;
                    this.groupBoxxmbxj.Visible = false;
                    break;
                case "细碎面":
                    this.groupBoxbjbxj.Visible = false;
                    this.groupBoxmbhd.Visible = false;
                    this.groupBoxmmcd.Visible = false;
                    this.groupBoxxmb.Visible = true;
                    this.groupBoxxmbxj.Visible = false;
                    break; 
                default:
                    this.groupBoxbjbxj.Visible = false;
                    this.groupBoxmbhd.Visible = false;
                    this.groupBoxmmcd.Visible = false;
                    this.groupBoxxmb.Visible = false;
                    this.groupBoxxmbxj.Visible = false;
                    break; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String selectedText = this.comboBox2.SelectedItem.ToString();
            string supFeatureClass = "";
            string supFeatureValue = "";
            switch (selectedText)
            {
                case "面内包含点个数":
                    supFeatureClass = this.comboBox6.Text;
                    supFeatureValue = this.textBox2.Text;
                    break;
                case "面和线不相交":
                    supFeatureClass = this.comboBox5.Text;
                    break;
                case "跨边界面不相交":
                    supFeatureClass = this.comboBox3.Text;
                    break;
                case "跨图层面重叠":
                    supFeatureClass = this.comboBox4.Text;
                    break;
                case "细碎面":
                    supFeatureValue = this.textBox4.Text;
                    break;
                default:
                    supFeatureClass = "";
                    break;
            }
            string checkName = this.textBox1.Text;
            string dataSourd = this.comboBox1.Text.ToString();
            string checkOption = this.comboBox2.Text.ToString();
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            string sql = "insert into 拓扑检查表 (检查项,检查内容,涉及表,辅助值,辅助表) VALUES('" + checkName + "','" + checkOption + "','" + dataSourd + "','" + supFeatureValue + "','" + supFeatureClass + "')";
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
                this.工程参数表TableAdapter.Fill(this.makemoneyDataSet3.工程参数表);
                this.Close();
                refreshTopo();
            }
        }
    }
}
