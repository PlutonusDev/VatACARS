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

            AddMessageSelectorItem("REQUEST POSITION REPORT");
            AddMessageSelectorItem("SQUAWK [code]");
            AddMessageSelectorItem("AT [pos] CONTACT [unit name] [freq]");
            AddMessageSelectorItem("CONTACT [BRISBANE CTR] [124.95]");
            AddMessageSelectorItem("AT [pos] MONITOR [unit name] [freq]");
            AddMessageSelectorItem("END SERVICE");
            AddMessageSelectorItem("REPORT BACK ON ROUTE");
            AddMessageSelectorItem("CLIMB TO [lev]");

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
