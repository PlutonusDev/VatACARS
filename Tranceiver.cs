using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using vatACARS.Properties;

namespace vatACARS
{
    public class Tranceiver
    {
        private static readonly HttpClient webclient = new HttpClient();
        private string logonCode = Settings.Default.UserLogonCode;
        private string callsign = Settings.Default.UserCallsign;
        private Timer updateTimer;
        private List<incomingMessage> receivedMessages = new List<incomingMessage>();

        public Tranceiver()
        {
            // Initialize timer for periodic updates
            updateTimer = new Timer();
            updateTimer.Interval = 10000; // 10 seconds interval
            updateTimer.Tick += async (sender, e) => await UpdateMessages();
            updateTimer.Start();
        }

        private async Task UpdateMessages()
        {
            try
            {
                // Retrieve CPDLC messages from the server
                incomingMessage[] newMessages = await RetrieveCPDLCMessages("YSSY", "POLL", null);

                // Add new messages to the list
                receivedMessages.AddRange(newMessages);

                // Display the new messages
                foreach (var message in newMessages)
                {
                    //MessageBox.Show($"Received message from {message.callsign}: {message.raw}", "Received from ACARS Server");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error updating messages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<incomingMessage[]> RetrieveCPDLCMessages(string recipient, string messageType, string packetData, bool _write = true)
        {
            try
            {
                // Prepare request parameters
                var requestData = new Dictionary<string, string>
            {
                { "logon", logonCode },
                { "from", callsign },
                { "to", recipient },
                { "type", messageType },
                { "packet", packetData }
            };

                var content = new FormUrlEncodedContent(requestData);
                // Send request to server
                var response = await webclient.PostAsync(Settings.Default.ServerURL, content);

                // Read response content
                var responseContent = await response.Content.ReadAsStringAsync();

                // Log response content
                //MessageBox.Show("Response Content: " + responseContent);

                // Deserialize JSON response to incomingMessage array
                var messages = JsonConvert.DeserializeObject<incomingMessage[]>(responseContent);

                return messages;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving CPDLC messages: {ex.Message}");
            }
        }
        public async Task<incomingMessage[]> RetrieveAllMessages()
        {
            try
            {
                // Call RetrieveCPDLCMessages with appropriate parameters
                var messages = await RetrieveCPDLCMessages("YSSY", "POLL", null);
                return messages;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all CPDLC messages: {ex.Message}");
            }
        }


        // Method defined within the class but outside other methods
        public async Task ProcessMessages()
        {
            try
            {
                // Call RetrieveCPDLCMessages() to get the messages
                var task = RetrieveCPDLCMessages("YSSY", "POLL", null);

                // Await the task to get the result
                var messages = await task;

                // Now you can iterate over the messages
                foreach (var message in messages)
                {
                    // Process each message
                    //MessageBox.Show($"Callsign: {message.callsign}, Raw: {message.raw}, State: {message.state}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                //MessageBox.Show($"Error processing messages: {ex.Message}");
            }
        }


        public class incomingMessage
        {
            public string callsign;
            public string raw;
            public string state;

            public incomingMessage(string inCallsign, string inRaw, string inState = "new")
            {
                callsign = inCallsign.ToUpper();
                raw = inRaw.ToUpper();
                state = inState.ToUpper();
            }
        }
    }
}