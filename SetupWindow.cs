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
            if (Network.Me.Callsign.Length > 0)
            {
                if (Network.Me.Callsign.EndsWith("_FSS"))
                {
                    callsign = Network.Me.Callsign.Split('-')[0] == "ML" ? "YMMM" : Network.Me.Callsign.Split('-')[0] == "BN" ? "YBBB" : "";
                }
                else if (Network.Me.Callsign.EndsWith("_CTR"))
                {
                    string suffix = Network.Me.Callsign.Split('-')[1].Substring(0, 3);
                    callsign = "Y" + suffix;
                }
                else
                {
                    callsign = Airspace2.FindClosestAirport(Network.Me.Position).ICAOName;
                }
            }
            else
            {
                callsign = "";
            }


            tbx_stationCode.Text = callsign;
        }

    }
}
