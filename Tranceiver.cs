using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatACARS.Properties;

namespace vatACARS
{
    public class Tranceiver
    {

        private static readonly HttpClient webclient = new HttpClient();
        private string logonCode = Settings.Default.UserLogonCode;
        public string callsign = Settings.Default.UserCallsign;
        public object receivedMsgs;

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
                if (_write && messageType != "poll")
                {

                }

                var response = await webclient.PostAsync(Properties.Settings.Default.ServerURL, content);
                var responseString = await response.Content.ReadAsStringAsync();
                string printString = responseString.ToString().ToUpper().Trim();
                MessageBox.Show(printString, "Received from ACARS Server:");
            } catch
            {
                throw new Exception("");
            }
        }

        public void ProcessCPDLCMessage(string data)
        {
            
        }

        public static incomingMessage[] RetrieveCPDLCMessages()
        {
            return new incomingMessage[] {
                new incomingMessage("QFA123", "POSITION REPORT OVHD LEGAN AT 0047Z/12800 PPOS:3240.0N/09717.9W AT 0047Z/12800 TO CHAAR AT 0051Z NEXT BOBIN WIND 334/13 SAT 1 ETA 0054Z SPEED 233 GND SPEED 283 VERT SPEED -1300FPM HDG 49 TRK 50"),
                new incomingMessage("JST123", "REQUEST CLIMB TO 390", "stby"),
                new incomingMessage("ANZ123", "WHEN CAN WE EXPECT HIGHER ALT", "ack")
            };
        }

        public class incomingMessage
        {
            internal string callsign;
            internal string raw;
            internal string state;

            public incomingMessage(string inCallsign, string inRaw, string inState = "new")
            {
                callsign = inCallsign.ToUpper();
                raw = inRaw.ToUpper();
                state = inState.ToUpper();
            }
        }
    }
}
