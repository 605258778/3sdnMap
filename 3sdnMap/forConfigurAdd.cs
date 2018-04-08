using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3sdnMap
{
    public partial class forConfigurAdd : Form
    {
        private IActiveViewEvents_Event m_MapActiveViewEvents;
        public forConfigurAdd()
        {
            InitializeComponent();
            m_MapActiveViewEvents = axMapControl1.Map as IActiveViewEvents_Event;
            //对于Map，在添加图层后触发，对于PageLayout在添加任何要素时都会触发
            m_MapActiveViewEvents.ItemAdded += new IActiveViewEvents_ItemAddedEventHandler(m_MapActiveViewEvents_ItemAdded);
        }

        void m_MapActiveViewEvents_ItemAdded(object Item)
        {
            //主地图发生变化时将图层同步添加到鹰眼窗口中。
            ReLoadLayersToHawkEye();
        }

        private void ReLoadLayersToHawkEye()
        {
            ILayer layer = axMapControl1.get_Layer(0);
            if (layer != null)
            {
                //获取相关属性
                IDataset dataset = layer as IDataset;
                IWorkspace workspace = dataset.Workspace;
                string outname = layer.Name;
                string outpath = workspace.PathName + "\\" + outname;
                textBox2.Text = outpath;
            }
            //清空Map
            axMapControl1.ClearLayers();
        }

        private void forConfigurAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ControlsAddDataCommandClass();
            pCommand.OnCreate(this.axMapControl1.Object);
            pCommand.OnClick();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            Boolean a = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ////打开目标数据库
            //IWorkspace fWorkspace = open_pGDB_Workspace("e:\\Topo.mdb");
            //IFeatureWorkspace fW = fWorkspace as IFeatureWorkspace;
            ////启动编辑
            //IWorkspaceEdit workspaceEdit = (IWorkspaceEdit)fWorkspace;
            //workspaceEdit.StartEditing(true);
            //workspaceEdit.StartEditOperation();
            ////调用创建拓朴的方法
            //ITopology topology = Create_Topology(fW, "HN_DS", "HN", "Polygon_Topo");
            ////停止编辑
            //workspaceEdit.StopEditOperation();
            //workspaceEdit.StopEditing(true);
            //if (topology != null)
            //{
            //    MessageBox.Show("创建拓朴成功！");
            //}
        }

        public ITopology Create_Topology(IFeatureWorkspace featureWorkspace, string featuredatasetName, string featureClassName, string topologyName)
        {
            try
            {
                //1.---打开拓朴所在的要素数据集，并创建拓朴
                IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(featuredatasetName);
                if (featureDataset != null)
                {
                    ITopologyContainer topologyContainer = (ITopologyContainer)featureDataset;
                    ITopology topology = topologyContainer.CreateTopology("topo", topologyContainer.DefaultClusterTolerance, -1, ""); //在这个地方报错
                    //2.---给拓朴加入要素集
                    IFeatureClassContainer featureclassContainer = (IFeatureClassContainer)featureDataset;
                    IFeatureClass featureClass = featureclassContainer.get_ClassByName(featureClassName);
                    topology.AddClass(featureClass, 5, 1, 1, false);  // Parameters: AddClass(IClass, double weight, int xyrank, int zrank, Boolean EventNotificationOnValidate).       
                    //3.---返回拓朴
                    return topology;
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.ToString()); 
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
    }
}
