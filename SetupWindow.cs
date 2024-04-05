using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using vatACARS.Properties;
using vatsys;

namespace vatACARS
{
    public partial class SetupWindow : BaseForm
    {
        private readonly string firsCsvPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "firs.csv");

        public SetupWindow()
        {
            InitializeComponent();
            InitializeTextBoxes();
        }

        private void InitializeTextBoxes()
        {
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

        private void SetupWindow_Shown(object sender, EventArgs e)
        {
            UpdateICAOCode();
        }

        private void UpdateICAOCode()
        {
            if (!Network.IsConnected)
            {
                MessageBox.Show("Please connect before setting up.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            string callsign = Network.Me.Callsign;
            string callsignICAO = null;

            // First, try getting ICAO from callsign
            callsignICAO = GetICAOFromCallsign(callsign);

            // If callsignICAO is still null and if callsign matches the APAC prefix format, XXXX_CTR format, or ends with _GND, _DEL, _TWR, _FSS, _APP, or _DEP, try getting ICAO from CSV
            if (callsignICAO == null &&
                ((callsign.Length >= 5 && callsign[2] == '-') ||
                (callsign.Length >= 8 && (callsign.EndsWith("_CTR") || callsign.EndsWith("_GND") || callsign.EndsWith("_DEL") || callsign.EndsWith("_TWR") || callsign.EndsWith("_FSS") || callsign.EndsWith("_APP") || callsign.EndsWith("_DEP")))))
            {
                callsignICAO = GetICAOFromCSV(callsign);
            }


            // If callsignICAO is still null, use backup method
            if (callsignICAO == null)
            {
                callsignICAO = Airspace2.FindClosestAirport(Network.Me.Position)?.ICAOName;
            }

            tbx_stationCode.Text = string.IsNullOrEmpty(callsignICAO) ? "" : callsignICAO;
        }

        private string GetICAOFromCallsign(string callsign)
        {
            try
            {
                // Extract ICAO code from callsign
                string icao = callsign.Split('_').First();
                return Airspace2.FindClosestAirport(Network.Me.Position)?.ICAOName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extracting ICAO from callsign: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string GetICAOFromCSV(string callsign)
        {
            try
            {
                string callsignWithoutSuffix = callsign.Split('_')[0];
                var lines = File.ReadAllLines(firsCsvPath);
                var line = lines.FirstOrDefault(l => l.StartsWith(callsignWithoutSuffix + ","));

                if (line != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        return parts[1];
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving ICAO from CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
