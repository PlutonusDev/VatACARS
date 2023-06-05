using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using vatsys;

namespace vatACARS
{
    public partial class ResponseBuilder : BaseForm
    {
        ListViewGroup groupNew = new ListViewGroup("New");
        ListViewGroup groupStandby = new ListViewGroup("Standby");
        ListViewGroup groupAnswered = new ListViewGroup("Replied");
        Tranceiver.incomingMessage[] messages = new Tranceiver.incomingMessage[] { };

        public ResponseBuilder()
        {
            InitializeComponent();

            lbl_receivedMsgs.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messages.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_messageSelector.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messageSelector.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_freetextInput.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_freetextInput.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_send.ForeColor = Colours.GetColour(Colours.Identities.CPDLCUplink);

            scr_messageSelector.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messageSelector.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);

            lvw_messages.Groups.Add(groupNew);
            lvw_messages.Groups.Add(groupStandby);
            lvw_messages.Groups.Add(groupAnswered);

            AddMessageSelectorItem("CLIMB TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("DESCEND TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("PROCEED DIRECT TO [POSITION]");
            AddMessageSelectorItem("MAINTAIN [SPEED] OR GREATER");
            AddMessageSelectorItem("MAINTAIN [SPEED] OR LESS");
            AddMessageSelectorItem("CONTACT [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("REQUEST RECEIVED RESPONSE WILL BE VIA VOICE");

            AddMessage(Tranceiver.RetrieveCPDLCMessages()[0]); 
        }

        public void AddMessageSelectorItem(string label)
        {
            ListViewItem itm = lvw_messageSelector.Items.Add(label);
        }

        public void AddMessage(Tranceiver.incomingMessage msgInfo)
        {
            //messages[messages.Length] = msgInfo;
            var item = lvw_messages.Items.Add(string.Format(" {0}: {1} ", msgInfo.callsign, msgInfo.raw));

            if(msgInfo.state == "NEW")
            {
                item.Group = groupNew;
                item.BackColor = Colours.GetColour(Colours.Identities.Warning);
            } else if(msgInfo.state == "STBY")
            {
                item.Group = groupStandby;
                item.BackColor = Colours.GetColour(Colours.Identities.IdentFlash);
            } else
            {
                item.Group = groupAnswered;
            }
        }

        private void lvw_messages_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvw_messages.FocusedItem != null && lvw_messages.FocusedItem.Group == groupAnswered)
            {
                btn_escape.Enabled = false;
                btn_standby.Enabled = false;
            } else
            {
                btn_escape.Enabled = true;
                btn_standby.Enabled = true;
            }

            if(lvw_messages.FocusedItem != null && lvw_messages.FocusedItem.Group == groupStandby)
            {
                btn_standby.Enabled = false;
            }
        }

        private void btn_standby_Click(object sender, System.EventArgs e)
        {
            if (lvw_messages.FocusedItem != null)
            {
                lvw_messages.FocusedItem.Group = groupStandby;
                lvw_messages.FocusedItem.BackColor = Colours.GetColour(Colours.Identities.IdentFlash);
            }
        }

        private void btn_reply_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void btn_level_Click(object sender, System.EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            AddMessageSelectorItem("WHEN CAN YOU ACCEPT [LEVEL]");
            AddMessageSelectorItem("CAN YOU ACCEPT [LEVEL] AT [POSITION]");
            AddMessageSelectorItem("CAN YOU ACCEPT [LEVEL] AT [TIME]");
            AddMessageSelectorItem("MAINTAIN [LEVEL]");
            AddMessageSelectorItem("CLIMB TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("CLIMB VIA SID TO [LEVEL]");
            AddMessageSelectorItem("AT [TIME] CLIMB TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("AT [POSITION] CLIMB TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("DESCEND TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("DESCEND VIA STAR TO [LEVEL]");
            AddMessageSelectorItem("AT [TIME] DESCEND TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("AT [POSITION] DESCEND TO AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("CLIMB TO REACH [LEVEL] BY [TIME]");
            AddMessageSelectorItem("CLIMB TO REACH [LEVEL] BY [POSITION]");
            AddMessageSelectorItem("REACH [LEVEL] BY [TIME]");
            AddMessageSelectorItem("REACH [LEVEL] BY [POSITION]");
            AddMessageSelectorItem("MAINTAIN BLOCK [LEVEL] TO [LEVEL]");
            AddMessageSelectorItem("CLIMB TO AND MAINTAIN BLOCK [LEVEL] TO [LEVEL]");
            AddMessageSelectorItem("DESCEND TO AND MAINTAIN BLOCK [LEVEL] TO [LEVEL]");
            AddMessageSelectorItem("LEAVE CONTROL AREA DESCENDING");
            AddMessageSelectorItem("CRUISE CLIMB NOT AVAILABLE IN AUSTRALIAN ADMINISTERED AIRSPACE");
            AddMessageSelectorItem("CRUISE [LEVEL]");
            AddMessageSelectorItem("CRUISE CLIMB TO [LEVEL]");
            AddMessageSelectorItem("CRUISE CLIMB ABOVE [LEVEL]");
            AddMessageSelectorItem("EXPEDITE CLIMB TO [LEVEL]");
            AddMessageSelectorItem("EXPEDITE DESCENT TO [LEVEL]");
            AddMessageSelectorItem("IMMEDIATELY CLIMB TO [LEVEL]");
            AddMessageSelectorItem("IMMEDIATELY DESCEND TO [LEVEL]");
            AddMessageSelectorItem("IMMEDIATELY STOP CLIMB AT [LEVEL]");
            AddMessageSelectorItem("IMMEDIATELY STOP DESCENT AT [LEVEL]");
            AddMessageSelectorItem("CLIMB AT [RATE] MINIMUM");
            AddMessageSelectorItem("CLIMB AT [RATE] MAXIMUM");
            AddMessageSelectorItem("DESCEND AT [RATE] MINIMUM");
            AddMessageSelectorItem("DESCEND AT [RATE] MAXIMUM");
            AddMessageSelectorItem("EXPECT [LEVEL]");
            AddMessageSelectorItem("EXPECT CLIMB AT [TIME]");
            AddMessageSelectorItem("EXPECT CLIMB AT [POSITION]");
            AddMessageSelectorItem("AT [TIME] EXPECT CLIMB TO [LEVEL]");
            AddMessageSelectorItem("AT [POSITION] EXPECT CLIMB TO [LEVEL]");
            AddMessageSelectorItem("AT [TIME] EXPECT DESCENT TO [LEVEL]");
            AddMessageSelectorItem("AT [POSITION] EXPECT DESCENT TO [LEVEL]");
            AddMessageSelectorItem("AT [TIME] EXPECT CRUISE CLIMB TO [LEVEL]");
            AddMessageSelectorItem("AT [POSITION] EXPECT CRUISE CLIMB TO [LEVEL]");

            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;
        }
        private void btn_route_Click(object sender, System.EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            AddMessageSelectorItem("PROCEED DIRECT TO [POSITION]");
            AddMessageSelectorItem("WHEN ABLE PROCEED DIRECT TO [POSITION]");
            AddMessageSelectorItem("AT [TIME] PROCEED DIRECT TO [POSITION]");
            AddMessageSelectorItem("AT [POSITION] PROCEED DIRECT TO [POSITION]");
            AddMessageSelectorItem("AT [LEVEL] PROCEED DIRECT TO [POSITION]");
            AddMessageSelectorItem("CLEARED TO [POSITION] VIA [ROUTE]");
            AddMessageSelectorItem("CLEARED [ROUTE]");
            AddMessageSelectorItem("CLEARED [STAR] [TEXT]");
            AddMessageSelectorItem("CLEARED TO DEVIATE UP TO [DISTANCE] [DIRECTION] OF ROUTE");
            AddMessageSelectorItem("AT [POSITION] CLEARED [ROUTE]");
            AddMessageSelectorItem("AT [POSITION] CLEARED [STAR] [TEXT]");
            AddMessageSelectorItem("HOLD AT [POSITION] MAINTAIN [LEVEL] INBOUND TRACK [DEGREES] [DIRECTION] TURN LEG TIME [TIME]");
            AddMessageSelectorItem("HOLD AT [POSITION] AS PUBLISHED MAINTAIN [LEVEL]");
            AddMessageSelectorItem("TURN [DIRECTION] HEADING [DEGREES]");
            AddMessageSelectorItem("TURN [DIRECTION] GROUND TRACK [DEGREES]");
            AddMessageSelectorItem("FLY PRESENT HEADING");
            AddMessageSelectorItem("AT [POSITION] FLY HEADING [DEGREES]");
            AddMessageSelectorItem("IMMEDIATELY TURN [DIRECTION] HEADING [DEGREES]");
            AddMessageSelectorItem("EXPECT [ROUTE]");
            AddMessageSelectorItem("AT [POSITION] EXPECT [ROUTE]");
            AddMessageSelectorItem("EXPECT DIRECT TO [POSITION]");
            AddMessageSelectorItem("AT [POSITION] EXPECT DIRECT TO [POSITION]");
            AddMessageSelectorItem("AT [TIME] EXPECT DIRECT TO [POSITION]");
            AddMessageSelectorItem("AT [LEVEL] EXPECT DIRECT TO [POSITION]");
            AddMessageSelectorItem("EXPECT FURTHER CLEARANCE AT [TIME]");
            AddMessageSelectorItem("EXPECT [STAR] [TEXT]");

            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;
        }

        private void btn_cross_Click(object sender, System.EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            AddMessageSelectorItem("CROSS [POSITION] AT [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR ABOVE [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR BELOW [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] BETWEEN [LEVEL] AND [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT [TIME]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR BEFORE [TIME]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR AFTER [TIME]");
            AddMessageSelectorItem("CROSS [POSITION] BETWEEN [TIME] AND [TIME]");
            AddMessageSelectorItem("CROSS [POSITION] AT [SPEED]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR LESS THAN [SPEED]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR GREATER THAN [SPEED]");
            AddMessageSelectorItem("CROSS [POSITION] AT [TIME] AT [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR BEFORE [TIME] AT [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT OR AFTER [TIME] AT [LEVEL]");
            AddMessageSelectorItem("CROSS [POSITION] AT AND MAINTAIN [LEVEL] AT [SPEED]");
            AddMessageSelectorItem("AT [TIME] CROSS [POSITION] AT AND MAINTAIN [LEVEL]");
            AddMessageSelectorItem("AT [TIME] CROSS [POSITION] AT AND MAINTAIN [LEVEL] AT [SPEED]");
            AddMessageSelectorItem("EXPECT TO CROSS [POSITION] AT [LEVEL]");
            AddMessageSelectorItem("EXPECT TO CROSS [POSITION] AT OR ABOVE [LEVEL]");
            AddMessageSelectorItem("EXPECT TO CROSS [POSITION] AT OR BELOW [LEVEL]");
            AddMessageSelectorItem("EXPECT TO CROSS [POSITION] AT AND MAINTAIN [LEVEL]");

            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;

        }

        private void btn_speed_Click(object sender, System.EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            AddMessageSelectorItem("MAINTAIN [SPEED]");
            AddMessageSelectorItem("MAINTAIN PRESENT SPEED");
            AddMessageSelectorItem("MAINTAIN [SPEED] OR GREATER");
            AddMessageSelectorItem("MAINTAIN [SPEED] OR LESS");
            AddMessageSelectorItem("MAINTAIN [SPEED] TO [SPEED]");
            AddMessageSelectorItem("INCREASE SPEED TO [SPEED]");
            AddMessageSelectorItem("INCREASE SPEED TO [SPEED] OR GREATER");
            AddMessageSelectorItem("REDUCE SPEED TO [SPEED]");
            AddMessageSelectorItem("REDUCE SPEED TO [SPEED] OR LESS");
            AddMessageSelectorItem("DO NOT EXCEED [SPEED]");
            AddMessageSelectorItem("RESUME NORMAL SPEED");
            AddMessageSelectorItem("NO SPEED RESTRICTION");
            AddMessageSelectorItem("AT [TIME] EXPECT [SPEED]");
            AddMessageSelectorItem("AT [POSITION] EXPECT [SPEED]");
            AddMessageSelectorItem("AT [LEVEL] EXPECT [SPEED]");
            AddMessageSelectorItem("AT [TIME] EXPECT [SPEED] TO [SPEED]");
            AddMessageSelectorItem("AT [POSITION] EXPECT [SPEED] TO [SPEED]");
            AddMessageSelectorItem("AT [LEVEL] EXPECT [SPEED] TO [SPEED]");
            AddMessageSelectorItem("WHEN CAN YOU ACCEPT [SPEED]");

            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;
        }

        private void btn_comm_Click(object sender, System.EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            AddMessageSelectorItem("CONTACT [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("AT [POSITION] CONTACT [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("AT [TIME] CONTACT [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("MONITOR [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("AT [POSITION] MONITOR [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("AT [TIME] MONITOR [UNIT] [FREQUENCY]");
            AddMessageSelectorItem("SQUAWK [SSR]");
            AddMessageSelectorItem("STOP SQUAWK");
            AddMessageSelectorItem("SQUAWK ALTITUDE");
            AddMessageSelectorItem("STOP SQUAWK ALTITUDE");
            AddMessageSelectorItem("SQUAWK IDENT");
            AddMessageSelectorItem("ALTIMETER [QNH]");
            AddMessageSelectorItem("IDENTIFICATION");
            AddMessageSelectorItem("IDENTIFIED");
            AddMessageSelectorItem("IDENTIFICATION TERMINATED");
            AddMessageSelectorItem("TRANSMIT ADS-B IDENT");
            AddMessageSelectorItem("CONFIRM ADS-C EMERGENCY");
            AddMessageSelectorItem("CHECK STUCK MICROPHONE [FREQUENCY]");
            AddMessageSelectorItem("ATIS [CODE]");

            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;
        }

        private void btn_misc_Click(object sender, System.EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            AddMessageSelectorItem("REQUEST RECEIVED RESPONSE WILL BE VIA VOICE");
            AddMessageSelectorItem("WHEN READY");
            AddMessageSelectorItem("THEN");
            AddMessageSelectorItem("DUE TO TRAFFIC");
            AddMessageSelectorItem("DUE TO AIRSPACE RESTRICTION");
            AddMessageSelectorItem("DISREGARD");
            AddMessageSelectorItem("MAINTAIN OWN SEPARATION AND VMC");
            AddMessageSelectorItem("AT PILOTS DISCRETION");
            AddMessageSelectorItem("STANDBY");
            AddMessageSelectorItem("UNABLE");
            AddMessageSelectorItem("ROGER");
            AddMessageSelectorItem("AFFIRM");
            AddMessageSelectorItem("NEGATIVE");
            AddMessageSelectorItem("ROGER MAYDAY");
            AddMessageSelectorItem("ROGER PAN");

            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;
        }

        private async void scr_messageSelector_Scroll(object sender, System.EventArgs e)
        {
            await new System.Threading.Tasks.Task(() =>
            {
                lvw_messageSelector.SetScrollPosVert(scr_messageSelector.PercentageValue);
            });
        }

        private void btn_suspend_Click(object sender, System.EventArgs e)
        {
            PDCWindow pw = new PDCWindow();
            pw.Show();
        }

    }
}
