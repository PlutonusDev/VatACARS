using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatACARS;
using vatsys;
using vatsys.Plugin;

namespace vStripsPlugin
{
    [Export(typeof(IPlugin))]
    public class vatACARS : IPlugin
    {
        /// Plugin Name
        public string Name { get => "vatACARS"; }

        private static SetupWindow setupWindow;
        private static EditorWindow editorWindow;

        private CustomToolStripMenuItem setupWindowMenu;
        private CustomToolStripMenuItem acarsWindowMenu;

        public vatACARS()
        {
            Tranceiver tranciver = new Tranceiver();
            Updater updater = new Updater();

            _ = Task.Run(() => updater.CheckForUpdatesAsync());

            acarsWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("Editor"));
            acarsWindowMenu.CustomCategoryName = "ACARS";
            acarsWindowMenu.Item.Click += EditorWindowMenu_Click;
            MMI.AddCustomMenuItem(acarsWindowMenu);

            setupWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("Setup"));
            setupWindowMenu.CustomCategoryName = "ACARS";
            setupWindowMenu.Item.Click += SetupWindowMenu_Click;
            MMI.AddCustomMenuItem(setupWindowMenu);

            //_ = Task.Run(() => tranciver.MakeCPDLCMessage("TEST", "POLL", "/data2/t/t/N/t"));
        }
        
        public void OnFDRUpdate(FDP2.FDR updated)
        {
            return;
        }      

        public void OnRadarTrackUpdate(RDP.RadarTrack updated)
        {
            return;
        }

        private void SetupWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(delegate () { DoShowSetupWindow(); });
        }

        private static void DoShowSetupWindow()
        {
            if (setupWindow == null || setupWindow.IsDisposed)            
                setupWindow = new SetupWindow();            
            else if (setupWindow.Visible)
                return;

            setupWindow.ShowDialog();
        }

        private void EditorWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(delegate () { DoShowEditorWindow(); });
        }

        private static void DoShowEditorWindow()
        {
            if (editorWindow == null || editorWindow.IsDisposed)
                editorWindow = new EditorWindow();
            else if (editorWindow.Visible)
                return;

            editorWindow.ShowDialog();
        }
    }
}
