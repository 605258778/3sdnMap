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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Data.OleDb;

namespace _3sdnMap
{
    public partial class Form1 : Form
    {
        private ESRI.ArcGIS.Controls.IMapControl3 m_mapControl = null;
        private ESRI.ArcGIS.Controls.IPageLayoutControl2 m_pageLayoutControl = null;
        private ControlsSynchronizer m_controlsSynchronizer = null;
        //TOCControl控件变量
        private ITOCControl2 m_tocControl = null;
        //TOCControl中Map菜单
        private IToolbarMenu m_menuMap = null;
        //TOCControl中图层菜单
        private IToolbarMenu m_menuLayer = null;
        private IActiveViewEvents_Event m_MapActiveViewEvents;
        private TextBox TextBoxGlob = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //在Form1_Load函数进行初始化，即菜单的创建：
            m_menuMap = new ToolbarMenuClass();
            //添加自定义菜单项到TOCCOntrol的图层菜单中
            m_menuLayer = new ToolbarMenuClass();

            m_tocControl = (ITOCControl2)this.axTOCControl1.Object;
            // 取得 MapControl 和 PageLayoutControl 的引用
            m_mapControl = (IMapControl3)this.axMapControl1.Object;
            m_pageLayoutControl = (IPageLayoutControl2)this.axPageLayoutControl1.Object;

            //初始化controls synchronization calss
            m_controlsSynchronizer = new ControlsSynchronizer(m_mapControl, m_pageLayoutControl);
            //把MapControl和PageLayoutControl绑定起来(两个都指向同一个Map),然后设置MapControl为活动的Control
            m_controlsSynchronizer.BindControls(true);
            //为了在切换MapControl和PageLayoutControl视图同步，要添加Framework Control
            m_controlsSynchronizer.AddFrameworkControl(axToolbarControl1.Object);
            m_controlsSynchronizer.AddFrameworkControl(this.axTOCControl1.Object);
            // 添加打开命令按钮到工具条
            OpenNewMapDocument openMapDoc = new OpenNewMapDocument(m_controlsSynchronizer);
            axToolbarControl1.AddItem(openMapDoc, -1, 0, false, -1, esriCommandStyles.esriCommandStyleIconOnly);

             //添加自定义菜单项到TOCCOntrol的Map菜单中
            //打开文档菜单
             m_menuMap.AddItem(new OpenNewMapDocument(m_controlsSynchronizer), -1, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
            //添加数据菜单
             m_menuMap.AddItem(new ControlsAddDataCommandClass(), -1, 1, false, esriCommandStyles.esriCommandStyleIconAndText);
             //打开全部图层菜单
             m_menuMap.AddItem(new LayerVisibility(), 1, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            //关闭全部图层菜单
             m_menuMap.AddItem(new LayerVisibility(), 2, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
             //以二级菜单的形式添加内置的“选择”菜单
             m_menuMap.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 4, true);
            //以二级菜单的形式添加内置的“地图浏览”菜单
             m_menuMap.AddSubMenu("esriControls.ControlsMapViewMenu",5, true);
            
            //添加“移除图层”菜单项
             m_menuLayer.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            //添加“放大到整个图层”菜单项
             m_menuLayer.AddItem(new ZoomToLayer(), -1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
             //查看属性表  
             m_menuLayer.AddItem(new OpenAttribute(this.axMapControl1), -1, 2, true, esriCommandStyles.esriCommandStyleTextOnly); 
             //设置菜单的Hook
             m_menuLayer.SetHook(m_mapControl);
             m_menuMap.SetHook(m_mapControl);

        }

        private void New_Click(object sender, EventArgs e)
        {
            //询问是否保存当前地图
            DialogResult res = MessageBox.Show("是否保存当前地图?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //如果要保存，调用另存为对话框
                ICommand command = new ControlsSaveAsDocCommandClass();
                if (m_mapControl != null)
                    command.OnCreate(m_controlsSynchronizer.MapControl.Object);
                else
                    command.OnCreate(m_controlsSynchronizer.PageLayoutControl.Object);
                command.OnClick();
            }
            //创建新的地图实例
            IMap map = new MapClass();
            map.Name = "Map";
            m_controlsSynchronizer.MapControl.DocumentFilename = string.Empty;
            //更新新建地图实例的共享地图文档
            m_controlsSynchronizer.ReplaceMap(map);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (this.axMapControl1.LayerCount > 0)
            {
                DialogResult result = MessageBox.Show("是否保存当前地图？", "警告",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes) this.Save_Click(null, null);
            }
            OpenNewMapDocument openMapDoc = new OpenNewMapDocument(m_controlsSynchronizer);
            openMapDoc.OnCreate(m_controlsSynchronizer.MapControl.Object);
            openMapDoc.OnClick();
        }

        private void AddData_Click(object sender, EventArgs e)
        {
            int currentLayerCount = this.axMapControl1.LayerCount;
            ICommand pCommand = new ControlsAddDataCommandClass();
            pCommand.OnCreate(this.axMapControl1.Object);
            pCommand.OnClick();

            IMap pMap = this.axMapControl1.Map;
            this.m_controlsSynchronizer.ReplaceMap(pMap);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            {
                // 首先确认当前地图文档是否有效
                if (null != m_pageLayoutControl.DocumentFilename && m_mapControl.CheckMxFile(m_pageLayoutControl.DocumentFilename))
                {
                    // 创建一个新的地图文档实例
                    IMapDocument mapDoc = new MapDocumentClass();
                    // 打开当前地图文档
                    mapDoc.Open(m_pageLayoutControl.DocumentFilename, string.Empty);
                    // 用 PageLayout 中的文档替换当前文档中的 PageLayout 部分
                    mapDoc.ReplaceContents((IMxdContents)m_pageLayoutControl.PageLayout);
                    // 保存地图文档
                    mapDoc.Save(mapDoc.UsesRelativePaths, false);
                    mapDoc.Close();
                }
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            //如果当前视图为MapControl时，提示用户另存为操作将丢失PageLayoutControl中的设置
            if (m_controlsSynchronizer.ActiveControl is IMapControl3)
            {
                if (MessageBox.Show("另存为地图文档将丢失制版视图的设置\r\n您要继续吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            // 调用另存为命令
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_controlsSynchronizer.ActiveControl);
            command.OnClick();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // 调用另存为命令
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_controlsSynchronizer.ActiveControl);
            command.OnClick();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl2.SelectedIndex == 0)
            {
                //激活MapControl
                m_controlsSynchronizer.ActivateMap();
            }
            else
            {
                //激活PageLayoutControl
                m_controlsSynchronizer.ActivatePageLayout();
            }
        }

        private void axToolbarControl1_OnMouseMove(object sender, IToolbarControlEvents_OnMouseMoveEvent e)
        {
            // 取得鼠标所在工具的索引号
            int index = axToolbarControl1.HitTest(e.x, e.y, false);
            if (index != -1)
            {
                // 取得鼠标所在工具的 ToolbarItem
                IToolbarItem toolbarItem = axToolbarControl1.GetItem(index);
                // 设置状态栏信息
                MessageLabel.Text = toolbarItem.Command.Message;
            }
            else
            {
                MessageLabel.Text = " 就绪 ";
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            // 显示当前比例尺
            ScaleLabel.Text = " 比例尺 1:" + ((long)this.axMapControl1.MapScale).ToString();
            // 显示当前坐标
            CoordinateLabel.Text = " 当前坐标 X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + this.axMapControl1.MapUnits.ToString().Substring(4);
        }

        

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
             //如果不是右键按下直接返回
            if (e.button != 2) return;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            //判断所选菜单的类型
            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            //确定选定的菜单类型，Map或是图层菜单
            if (item == esriTOCControlItem.esriTOCControlItemMap)
                m_tocControl.SelectItem(map, null);
            else
                m_tocControl.SelectItem(layer, null);
            //设置CustomProperty为layer (用于自定义的Layer命令)                  
            m_mapControl.CustomProperty = layer;
            //弹出右键菜单
            if (item == esriTOCControlItem.esriTOCControlItemMap)
                m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
            if (item == esriTOCControlItem.esriTOCControlItemLayer)
                m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
                {
                    //弹出右键菜单
                    m_menuMap.PopupMenu(e.x,e.y,m_mapControl.hWnd);
                }
        }

        private void Configure_Click(object sender, EventArgs e)
        {
            formConfigur configur = new formConfigur();
            configur.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开目标数据库
            IWorkspaceFactory pAccessWorkspaceFactory;
            pAccessWorkspaceFactory = new AccessWorkspaceFactoryClass();
            IWorkspace fWorkspace = pAccessWorkspaceFactory.OpenFromFile("E://2018年工作//数据验收平台测试//test.gdb", 0);
            IFeatureWorkspace fW = fWorkspace as IFeatureWorkspace;
            IEnumDataset penumDatasets = fWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
             penumDatasets.Reset();
            IDataset pesriDataset = penumDatasets.Next();
            while (pesriDataset == null)
            {
                IFeatureClass pFeatureClass = fW.OpenFeatureClass("Ⅰ级保护林地范围");
            }
            //启动编辑
            IWorkspaceEdit workspaceEdit = (IWorkspaceEdit)fWorkspace;
            workspaceEdit.StartEditing(true);
            workspaceEdit.StartEditOperation();
            //调用创建拓朴的方法
            ITopology topology = Create_Topology(fW, "datset", "Ⅰ级保护林地范围", "Polygon_Topo");
            //停止编辑
            workspaceEdit.StopEditOperation();
            workspaceEdit.StopEditing(true);
            if (topology != null)
            {
                MessageBox.Show("创建拓朴成功！");
            }
            
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

        private void newPro_Click(object sender, EventArgs e)
        {
            formNewPro fromNewProDig = new formNewPro();
            fromNewProDig.ShowDialog();
        }

        private void 测试工程设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(strFilePath);
            try
            {
                FormSetpara FormSetparaDig = new FormSetpara(); 
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string sqlstr = "select * from 工程参数表";
                DataSet ds = new DataSet();
                conn.Open();
                adapter.SelectCommand = new OleDbCommand(sqlstr, conn);
                adapter.Fill(ds, "工程参数表");
                DataTable dt = ds.Tables["工程参数表"];
                DataRow[] dr = dt.Select("1=1");
                conn.Close();
                for (int i = 0; i < dr.Length; i++) 
                {
                    Label lb = new Label();
                    lb.Location = new System.Drawing.Point(75, 60*(i+1)-30);
                    lb.Text = dr[i]["参数名称"].ToString()+":";
                    lb.Name = "lable" + i.ToString();
                    lb.AutoSize = true;
                    TextBox tx = new TextBox();
                    tx.Location = new System.Drawing.Point(75, 30 * 2 * (i + 1));
                    tx.Size = new System.Drawing.Size(400, 25);
                    tx.Tag = dr[i]["ID"].ToString();
                    tx.Name = dr[i]["参数名称"].ToString();
                    Button bt = new Button();
                    bt.Location = new System.Drawing.Point(500, 30 * 2 * (i + 1));
                    bt.Text = "浏览";
                    bt.Name = dr[i]["参数名称"].ToString()+"Add";
                    bt.Click += (se, a) => addFile(tx);
                    FormSetparaDig.Controls.Add(lb);
                    FormSetparaDig.Controls.Add(tx);
                    FormSetparaDig.Controls.Add(bt);
                }
                Button btok = new Button();
                btok.Location = new System.Drawing.Point(500, 30 * 2 * (dr.Length + 1));
                btok.Text = "确定";
                btok.Click += (se, a) => SelectOk(FormSetparaDig);
                FormSetparaDig.Controls.Add(btok);
                FormSetparaDig.ShowDialog();
            }
            catch (Exception exc)
            {
                throw (new Exception("数据库出错:" + exc.Message));
            }
        }

        private void SelectOk(FormSetpara FormSetparaDig)
        {
            FormSetparaDig.Close();
        }

        private void addFile(TextBox tx) 
        {
            TextBoxGlob = tx;
            initMapEvents();
            //var layers = SelectDataUtils.OpenLayers();
            axMapControl2.ClearLayers();
            ICommand cmd = new ControlsAddDataCommand();
            cmd.OnCreate(axMapControl2.Object);
            cmd.OnClick();
        }

        private void 工程设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetpara FormSetparaDig = new FormSetpara();
            FormSetparaDig.ShowDialog();
        }

        private void initMapEvents() 
        {
            m_MapActiveViewEvents = axMapControl2.Map as IActiveViewEvents_Event;
            //对于Map，在添加图层后触发，对于PageLayout在添加任何要素时都会触发
            m_MapActiveViewEvents.ItemAdded += new IActiveViewEvents_ItemAddedEventHandler(m_MapActiveViewEvents_ItemAdded);
        }
        void m_MapActiveViewEvents_ItemAdded(object Item)
        {
            for (int i = 1; i <= axMapControl2.LayerCount; i++)
            {

                ILayer layer = axMapControl2.get_Layer(axMapControl2.LayerCount - i);
                axMapControl2.ClearLayers();
                IDataset dataset = layer as IDataset;
                IWorkspace workspace = dataset.Workspace;
                string outname = layer.Name;
                string outpath = workspace.PathName;
                TextBoxGlob.Text = outpath +"\\"+ outname;
                string strFilePath = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath + "\\makemoney.mdb";
                string sql = "update 工程参数表 set 路径 = '" + outpath + "\\" + outname + "' where ID = " + TextBoxGlob.Tag;
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
                }
            }
        }

        private void ttttToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 数据质检_Click(object sender, EventArgs e)
        {

        }
    }
}
