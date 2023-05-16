using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatACARS.Properties;

namespace vatACARS
{
    internal class Tranceiver
    {

        private static readonly HttpClient webclient = new HttpClient();
        private string logonCode = Properties.Settings.Default.UserLogonCode;
        public string callsign = Properties.Settings.Default.UserCallsign;

        public async Task MakeCPDLCMessage(string recipient, string messageType, string packetData, bool _write = true)
        {
            var connectionValues = new Dictionary<string, string>
            {
                { "logon", logonCode },
                { "from", callsign },
                { "to", recipient },
                { "type", messageType },
                { "packet", packetData }
            };

            var content = new FormUrlEncodedContent(connectionValues);

            try
            {
                if(_write && messageType != "poll")
                {

                }

                var response = await webclient.PostAsync(Properties.Settings.Default.ServerURL, content);
                var responseString = await response.Content.ReadAsStringAsync();
                string printString = responseString.ToString().ToUpper().Trim();
                MessageBox.Show(printString, "Received from ACARS Server:");
            } catch
            {
                throw new Exception("lmao");
            }
        }
    }
}
