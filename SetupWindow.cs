using vatsys;
using vatACARS.Properties;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection;

namespace vatACARS
{
    public partial class SetupWindow : BaseForm
    {
        string callsign = "";

        public SetupWindow()
        {
            InitializeComponent();

            lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_acarsServer.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_logonCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            tbx_stationCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            tbx_acarsServer.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            tbx_logonCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            tbx_stationCode.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            tbx_acarsServer.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            tbx_logonCode.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            tbx_acarsServer.Text = Settings.Default.ServerURL;
            tbx_logonCode.Text = Settings.Default.UserLogonCode;
        }

        private void SetupWindow_Shown(object sender, System.EventArgs e)
        {
            if (Network.IsConnected)
            {
                if (!Network.Me.Callsign.EndsWith("_FSS") && !Network.Me.Callsign.EndsWith("_CTR"))
                {
                    callsign = Airspace2.FindClosestAirport(Network.Me.Position)?.ICAOName;
                }
                else if (Network.Me.Callsign.EndsWith("_TWR") || Network.Me.Callsign.EndsWith("_DEL") || Network.Me.Callsign.EndsWith("_GND"))
                {
                    callsign = Airspace2.FindClosestAirport(Network.Me.Position)?.ICAOName;
                }
                else
                {
                    callsign = GetICAOFromCSV(Network.Me.Callsign);
                }

                tbx_stationCode.Text = string.IsNullOrEmpty(callsign) ? "" : callsign;
            }
            else
            {
                MessageBox.Show("Please connect before setting up.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private string GetICAOFromCSV(string callsign)
        {
            string csvFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "firs.csv");

            string callsignWithoutSuffix = callsign.Split('_')[0];

            var lines = File.ReadAllLines(csvFilePath);

            var line = lines.FirstOrDefault(l => l.StartsWith(callsignWithoutSuffix + ","));

            if (line != null)
            {
                var parts = line.Split(',');
                if (parts.Length >= 2)
                {
                    return parts[1];
                }
            }

            return "";
        }


    }
}
