using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace _3sdnMap
{
    /// <summary>
    /// Command that works in ArcGlobe or GlobeControl
    /// </summary>
    [Guid("0400ed99-7bce-48f4-93a3-bdc51673060f")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("_3sdnMap.OpenNewMapDocument")]
    public sealed class OpenNewMapDocument : BaseCommand
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            GMxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            GMxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IGlobeHookHelper m_globeHookHelper = null;
        private ControlsSynchronizer m_controlsSynchronizer = null;


        public OpenNewMapDocument(ControlsSynchronizer controlsSynchronizer)
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Generic"; //localizable text
            base.m_caption = "Open";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "Open";  //localizable text
            base.m_name = "Generic_Open";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            //≥ı ºªØm_controlsSynchronizer
            m_controlsSynchronizer = controlsSynchronizer;

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_globeHookHelper = new GlobeHookHelperClass();
                m_globeHookHelper.Hook = hook;
                if (m_globeHookHelper.ActiveViewer == null)
                {
                    m_globeHookHelper = null;
                }
            }
            catch
            {
                m_globeHookHelper = null;
            }

            if (m_globeHookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add OpenNewMapDocument.OnClick implementation
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Map Documents (*.mxd)|*.mxd";
            dlg.Multiselect = false;
            dlg.Title = "Open Map Document";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string docName = dlg.FileName;
                IMapDocument mapDoc = new MapDocumentClass();
                if (mapDoc.get_IsPresent(docName) && !mapDoc.get_IsPasswordProtected(docName))
                {
                    mapDoc.Open(docName, string.Empty);
                    IMap map = mapDoc.get_Map(0);
                    m_controlsSynchronizer.ReplaceMap(map);
                    mapDoc.Close();
                }
            }
        }

        #endregion
    }
}
