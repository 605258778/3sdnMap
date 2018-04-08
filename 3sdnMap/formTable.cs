using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;

namespace _3sdnMap
{
    public partial class formTable : Form
    {
        AxMapControl _MapControl;
        IMapControl3 m_mapControl;
        public DataTable dt2;
        ITableSort pTs;//处理排序  
        bool up = true; 
        int row_index = 0;
        int col_index = 0;  
        public string strAddField = "";
        RowAndCol[] pRowAndCol = new RowAndCol[10000];
        int count = 0;
        //TOCControl中图层菜单
        private IToolbarMenu m_menuTableR = null;

        public formTable(AxMapControl pMapControl, IMapControl3 pMapCtrl)
        {
            InitializeComponent();
            _MapControl = pMapControl;
            m_mapControl = pMapCtrl;
        }

        private void formTable_Load(object sender, EventArgs e)
        {
            TableShow();
        }

        public struct RowAndCol
        {
            //字段  
            private int row;
            private int column;
            private string _value;

            //行属性  
            public int Row
            {
                get
                {
                    return row;
                }
                set
                {
                    row = value;
                }
            }
            //列属性  
            public int Column
            {
                get
                {
                    return column;
                }
                set
                {
                    column = value;
                }
            }
            //值属性  
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
        }

        public void TableShow()
        {
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFLayer.FeatureClass;

            if (pFeatureClass == null) return;

            DataTable dt = new DataTable();
            DataColumn dc = null;
            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                dt.Columns.Add(dc);
            }
            IFeatureCursor pFeatureCuror = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCuror.NextFeature();

            DataRow dr = null;
            while (pFeature != null)
            {
                dr = dt.NewRow();
                for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                {
                    if (pFeatureClass.FindField(pFeatureClass.ShapeFieldName) == j)
                    {

                        dr[j] = pFeatureClass.ShapeType.ToString();
                    }
                    else
                    {
                        dr[j] = pFeature.get_Value(j).ToString();

                    }
                }

                dt.Rows.Add(dr);
                pFeature = pFeatureCuror.NextFeature();
            }
            dataGridView1.DataSource = dt;
            dt2 = dt;
        }

        private void addfield_Click(object sender, EventArgs e)
        {
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            formAddField formaddfield = new formAddField(pFLayer, dataGridView1);
            formaddfield.Show();
        }

        private void toolEditor_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 2].Cells[0];  
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFLayer.FeatureClass;
            ITable pTable;
            //pTable = pFeatureClass.CreateFeature().Table;//很重要的一种获取shp表格的一种方式           
            pTable = pFLayer as ITable;
            //将改变的记录值传给shp中的表  
            int i = 0;
            while (pRowAndCol[i].Column != 0 || pRowAndCol[i].Row != 0)
            {
                IRow pRow;
                pRow = pTable.GetRow(pRowAndCol[i].Row);
                pRow.set_Value(pRowAndCol[i].Column, pRowAndCol[i].Value);
                pRow.Store();
                i++;
            }
            count = 0;
            for (int j = 0; j < i; j++)
            {
                pRowAndCol[j].Row = 0;
                pRowAndCol[j].Column = 0;
                pRowAndCol[j].Value = null;
            }
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK);  
        }

        private void toolDelSelect_Click(object sender, EventArgs e)
        {
            if (((MessageBox.Show("确定要删除吗", "警告", MessageBoxButtons.YesNo)) == DialogResult.Yes))
            {
                ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
                IFeatureLayer pFLayer = pLayer as IFeatureLayer;
                ITable pTable = pFLayer as ITable;
                IRow pRow = pTable.GetRow(dataGridView1.CurrentCell.RowIndex);
                pRow.Delete();
                TableShow();
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK);
                _MapControl.ActiveView.Refresh();
            }  
        }

        private void toolExpXLS_Click(object sender, EventArgs e)
        {
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFLayer.FeatureClass;
            IFields pFields = pFeatureClass.Fields;
            ExportExcel(dataGridView1, pFields);  
        }

        private void ExportExcel(DataGridView myDGV, IFields pFields)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消   

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

            //写入标题  
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                worksheet.Columns.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值  
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }

            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
                xlApp.Quit();
                GC.Collect();//强行销毁   
                MessageBox.Show("资料保存成功", "提示", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //记录值一旦改变触发此事件  
            //在dataGridView中获取改变记录的行数，列数和记录值  
            pRowAndCol[count].Row = dataGridView1.CurrentCell.RowIndex;
            pRowAndCol[count].Column = dataGridView1.CurrentCell.ColumnIndex;
            pRowAndCol[count].Value = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex].Value.ToString();
            count++;  
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IQueryFilter pQuery = new QueryFilterClass();
            int count = this.dataGridView1.SelectedRows.Count;
            string val;
            string col;
            col = this.dataGridView1.Columns[0].Name;
            //当只选中一行时  
            if (count == 1)
            {
                val = this.dataGridView1.SelectedRows[0].Cells[col].Value.ToString();
                //设置高亮要素的查询条件  
                pQuery.WhereClause = col + "=" + val;
            }
            else//当选中多行时  
            {
                int i;
                string str;
                for (i = 0; i < count - 1; i++)
                {
                    val = this.dataGridView1.SelectedRows[i].Cells[col].Value.ToString();
                    str = col + "=" + val + " OR ";
                    pQuery.WhereClause += str;
                }
                //添加最后一个要素的条件  
                val = this.dataGridView1.SelectedRows[i].Cells[col].Value.ToString();
                str = col + "=" + val;
                pQuery.WhereClause += str;
            }
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureSelection pFeatSelection;
            pFeatSelection = pFLayer as IFeatureSelection;
            pFeatSelection.SelectFeatures(pQuery, esriSelectionResultEnum.esriSelectionResultNew, false);
            _MapControl.ActiveView.Refresh();  
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IQueryFilter pQuery = new QueryFilterClass();
            int count = this.dataGridView1.SelectedRows.Count;
            string val;
            string col;
            col = this.dataGridView1.Columns[0].Name;
            //当只选中一行时  
            if (count == 1)
            {
                val = this.dataGridView1.SelectedRows[0].Cells[col].Value.ToString();
                //设置高亮要素的查询条件  
                pQuery.WhereClause = col + "=" + val;
            }
            else//当选中多行时  
            {
                int i;
                string str;
                for (i = 0; i < count - 1; i++)
                {
                    val = this.dataGridView1.SelectedRows[i].Cells[col].Value.ToString();
                    str = col + "=" + val + " OR ";
                    pQuery.WhereClause += str;
                }
                //添加最后一个要素的条件  
                val = this.dataGridView1.SelectedRows[i].Cells[col].Value.ToString();
                str = col + "=" + val;
                pQuery.WhereClause += str;
            }
            
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeature feature = (pLayer as IFeatureLayer).FeatureClass.GetFeature(int.Parse(val));
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureSelection pFeatSelection;
            pFeatSelection = pFLayer as IFeatureSelection;
            pFeatSelection.SelectFeatures(pQuery, esriSelectionResultEnum.esriSelectionResultNew, false);
            _MapControl.ActiveView.Extent = feature.ShapeCopy.Envelope;
            _MapControl.ActiveView.Refresh();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    //contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
                else if (e.RowIndex == -1)
                {
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            dataGridView1.Sort(dataGridView1.Columns[col_index], ListSortDirection.Ascending);
            _MapControl.ActiveView.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            dataGridView1.Sort(dataGridView1.Columns[col_index], ListSortDirection.Descending);
            _MapControl.ActiveView.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string strField = dataGridView1.Columns[col_index].HeaderText.ToString();
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            string strResult = "";
            if ((MessageBox.Show("确定要删除该字段吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                strResult = DeleteField(pFLayer, strField);
                dataGridView1.Columns.Remove(strField);
                MessageBox.Show(strResult, "提示", MessageBoxButtons.OK);
            }        
        }

        /// <summary>  
        /// 删除属性表字段  
        /// </summary>  
        /// <param name="layer">需要添加字段的IFeatureLayer</param>  
        /// <param name="fieldName">添加的字段的名称</param>  
        /// <returns></returns>  
        public string DeleteField(IFeatureLayer layer, string fieldName)
        {
            try
            {
                ITable pTable = (ITable)layer;
                IFields pfields;
                IField pfield;
                pfields = pTable.Fields;
                int fieldIndex = pfields.FindField(fieldName);
                pfield = pfields.get_Field(fieldIndex);
                if (pfield.Editable)
                {
                    pTable.DeleteField(pfield);
                    return "删除成功!";
                }
                else
                {
                    return "该字段不允许删除!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            row_index = this.dataGridView1.HitTest(e.X, e.Y).RowIndex; //行
            col_index = this.dataGridView1.HitTest(e.X, e.Y).ColumnIndex; //列
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string strField = dataGridView1.Columns[col_index].HeaderText.ToString();
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            formCalField formcalfield = new formCalField(pFLayer, dataGridView1, strField);
            formcalfield.Show();  
        }

    }
}
