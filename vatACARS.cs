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

        private CustomToolStripMenuItem setupWindowMenu;

        public vatACARS()
        {
            setupWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Settings, new ToolStripMenuItem("vatACARS Setup"));
            setupWindowMenu.Item.Click += SetupWindowMenu_Click;
            MMI.AddCustomMenuItem(setupWindowMenu);            
            
            Tranceiver tranciver = new Tranceiver();
            _ = Task.Run(() => tranciver.MakeCPDLCMessage("TEST", "POLL", "/data2/t/t/N/t"));
        }

        private void SetupWindowMenu_Click(object sender, EventArgs e)
        {
            DoShowSetupWindow();
        }

        
        public void OnFDRUpdate(FDP2.FDR updated)
        {
            return;
        }      

        public void OnRadarTrackUpdate(RDP.RadarTrack updated)
        {
            return;
        }

        public static void ShowSetupWindow()
        {
            MMI.InvokeOnGUI(delegate() { DoShowSetupWindow(); });
        }

        private static void DoShowSetupWindow()
        {
            if (setupWindow == null || setupWindow.IsDisposed)            
                setupWindow = new SetupWindow();            
            else if (setupWindow.Visible)
                return;

            setupWindow.ShowDialog();
        }
    }
}
