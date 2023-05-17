using vatsys;
using vatACARS.Properties;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace vatACARS
{
    public partial class SetupWindow : BaseForm
    {
        private bool closeDialog = false;
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
            if (Network.Me.Callsign.Length > 0 && Network.Me.Callsign.EndsWith("_CTR"))
            {
                callsign = Network.Me.Callsign.Split('-')[0] == "ML" ? "YMMM" : Network.Me.Callsign.Split('-')[0] == "BN" ? "YBBB" : "";
            }
            else
            {
                callsign = Airspace2.FindClosestAirport(Network.Me.Position).ICAOName;
            }

            tbx_stationCode.Text = callsign;
        }

        private void b_restartPlugin_Click(object sender, System.EventArgs e)
        {
            SoundPlayer plr = new SoundPlayer();
            plr.SoundLocation = "C:\\Program Files (x86)\\vatSys\\wav\\P1.wav";
            plr.Play();
        }
    }
}
