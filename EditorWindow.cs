using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;
using System.Windows.Forms;
using vatsys;

namespace vatACARS
{
    public partial class EditorWindow : BaseForm
    {
        ListViewGroup groupNew = new ListViewGroup("New");
        ListViewGroup groupStandby = new ListViewGroup("Standby");
        ListViewGroup groupAnswered = new ListViewGroup("Replied");
        Dictionary<ListViewItem, storedMessage> messages = new Dictionary<ListViewItem, storedMessage>();

        public EditorWindow()
        {
            InitializeComponent();

            lbl_receivedMsgs.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messages.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            scr_cpdlc.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_cpdlc.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);

            lvw_messages.Groups.Add(groupNew);
            lvw_messages.Groups.Add(groupStandby);
            lvw_messages.Groups.Add(groupAnswered);

            foreach(Tranceiver.incomingMessage msg in Tranceiver.RetrieveCPDLCMessages())
            {
                AddMessage(msg);
            }
        }

        public void AddMessage(Tranceiver.incomingMessage msgInfo)
        {
            ListViewItem item = lvw_messages.Items.Add(string.Format("  {0}: {1}  ", msgInfo.callsign, msgInfo.raw));
            messages[item] = new storedMessage(item, msgInfo);

            if (msgInfo.state == "NEW")
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
                btn_reply.Enabled = false;
                btn_standby.Enabled = false;
            } else
            {
                btn_reply.Enabled = true;
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
                var newMsg = messages[lvw_messages.FocusedItem].message;
                messages.Remove(lvw_messages.FocusedItem);
                lvw_messages.FocusedItem.Remove();
                newMsg.state = "STBY";
                AddMessage(newMsg);
            }
        }

        private void btn_reply_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private class storedMessage
        {
            internal ListViewItem item;
            internal Tranceiver.incomingMessage message;

            public storedMessage(ListViewItem newItem, Tranceiver.incomingMessage newMessage)
            {
                item = newItem;
                message = newMessage;
            }
        }
    }
}
