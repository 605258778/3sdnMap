using System;
using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Linq;  
using System.Windows.Forms;  
using ESRI.ArcGIS.DataManagementTools;  
using ESRI.ArcGIS.Geodatabase;  
using ESRI.ArcGIS.Carto;  
using ESRI.ArcGIS.Geoprocessor;

namespace _3sdnMap
{
    public partial class formCalField : Form
    {
        private IFeatureLayer _FeatureLayer = null;  
        private DataGridView Gridviwe;  
        private string Field = "";  
        public formCalField(IFeatureLayer pFeatureLayer,DataGridView dataGridView,string strField)
        {
            InitializeComponent();
            _FeatureLayer = pFeatureLayer;
            Field = strField;
            Gridviwe = dataGridView;  
        }

        private void formCalField_Load(object sender, EventArgs e)
        {

            IFeatureClass pFeatureCls = _FeatureLayer.FeatureClass;
            int FieldCount = pFeatureCls.Fields.FieldCount;
            for (int i = 0; i < FieldCount; i++)
            {
                IField pField = pFeatureCls.Fields.get_Field(i);
                //去除shape字段  
                if (!pField.Editable || pField.Type.ToString() == "esriFieldTypeGeometry")
                {
                    continue;
                }
                listField.Items.Add(pField.Name);
            }
            lblField.Text = Field + "=";  
        }

        private void listField_DoubleClick(object sender, System.EventArgs e)
        {
            string strSelectField = this.listField.SelectedItem.ToString();
            txtExpression.Text += "!"+strSelectField+"!";  
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string strResult = FieldCal(_FeatureLayer, Field, txtExpression.Text);
            MessageBox.Show(strResult);
            this.Close();
            RefreshTable refreshtable = new RefreshTable();
            refreshtable.Refresh(Gridviwe, _FeatureLayer); 
        }

        private string FieldCal(IFeatureLayer pFtLayer, string strField, string strExpression)
        {
            try
            {
                Geoprocessor Gp = new Geoprocessor();
                Gp.OverwriteOutput = true;
                CalculateField calField = new CalculateField();
                calField.in_table = pFtLayer as ITable;
                calField.field = strField;
                calField.expression = strExpression;
                calField.expression_type = "PYTHON";
                Gp.Execute(calField, null);
                return "计算成功";
            }
            catch (Exception e)
            {
                return "计算失败" + e.Message;
            }
        }  
    }
}
