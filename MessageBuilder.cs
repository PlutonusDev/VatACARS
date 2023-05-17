using vatsys;
using vatACARS.Properties;
using System.Linq;
using System.Windows.Forms;

namespace vatACARS
{
    public partial class MessageBuilder : BaseForm
    {
        private bool closeDialog = false;
        string callsign = "";

        public MessageBuilder()
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

        }


        private void MessageBuilder_Shown(object sender, System.EventArgs e)
        {

        }
    }
}
