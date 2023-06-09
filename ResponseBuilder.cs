using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using vatsys;

namespace vatACARS
{
    public partial class ResponseBuilder : BaseForm
    {
        ListViewGroup groupNew;
        ListViewGroup groupStandby;
        ListViewGroup groupAnswered;
        List<Tranceiver.incomingMessage> messages;

        public ResponseBuilder()
        {
            InitializeComponent();
            InitializeListViewGroups();

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

            AddMessage(Tranceiver.RetrieveCPDLCMessages()[0]);
        }

        private void InitializeListViewGroups()
        {
            groupNew = new ListViewGroup("New");
            groupStandby = new ListViewGroup("Standby");
            groupAnswered = new ListViewGroup("Replied");

            lvw_messages.Groups.Add(groupNew);
            lvw_messages.Groups.Add(groupStandby);
            lvw_messages.Groups.Add(groupAnswered);
        }

        public void AddMessageSelectorItem(string label)
        {
            ListViewItem itm = lvw_messageSelector.Items.Add(label);
        }

        public void AddMessage(Tranceiver.incomingMessage msgInfo)
        {
            if (messages == null)
                messages = new List<Tranceiver.incomingMessage>();

            messages.Add(msgInfo);

            var item = lvw_messages.Items.Add(string.Format(" {0}: {1} ", msgInfo.callsign, msgInfo.raw));

            if (msgInfo.state == "NEW")
            {
                item.Group = groupNew;
                item.BackColor = Colours.GetColour(Colours.Identities.Warning);
            }
            else if (msgInfo.state == "STBY")
            {
                item.Group = groupStandby;
                item.BackColor = Colours.GetColour(Colours.Identities.IdentFlash);
            }
            else
            {
                item.Group = groupAnswered;
            }
        }

        private void lvw_messages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_messages.FocusedItem != null && lvw_messages.FocusedItem.Group == groupAnswered)
            {
                btn_escape.Enabled = false;
                btn_standby.Enabled = false;
            }
            else
            {
                btn_escape.Enabled = true;
                btn_standby.Enabled = true;
            }

            if (lvw_messages.FocusedItem != null && lvw_messages.FocusedItem.Group == groupStandby)
            {
                btn_standby.Enabled = false;
            }
        }

        private void btn_standby_Click(object sender, EventArgs e)
        {
            if (lvw_messages.FocusedItem != null)
            {
                lvw_messages.FocusedItem.Group = groupStandby;
                lvw_messages.FocusedItem.BackColor = Colours.GetColour(Colours.Identities.IdentFlash);
            }
        }

        private void btn_reply_Click(object sender, EventArgs e)
        {
            lvw_messageSelector.Items.Clear();
            lvw_freetextInput.Clear();
            lvw_messages.Clear();
        }

        private async void scr_messageSelector_Scroll(object sender, EventArgs e)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                lvw_messageSelector.SetScrollPosVert(scr_messageSelector.PercentageValue);
            });
        }

        private void btn_suspend_Click(object sender, EventArgs e)
        {
            PDCWindow pw = new PDCWindow();
            pw.Show();
        }

        private void btn_level_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(1);
        }

        private void btn_route_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(2);
        }

        private void btn_transfr_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(3);
        }

        private void btn_cross_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(4);
        }

        private void btn_enq_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(5);
        }

        private void btn_surv_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(6);
        }

        private void btn_expect_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(7);
        }

        private void btn_blk_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(8);
        }

        private void btn_wx_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(9);
        }

        private void btn_comm_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(10);
        }

        private void btn_speed_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(11);
        }

        private void btn_cfm_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(12);
        }

        private void btn_misc_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(13);
        }

        private void btn_emerg_Click(object sender, EventArgs e)
        {
            UpdateListBasedOnGroup(14);
        }


        private void UpdateListBasedOnGroup(int group)
     {
        string assemblyPath = Assembly.GetExecutingAssembly().Location;
        string groupsFilePath = Path.Combine(Path.GetDirectoryName(assemblyPath), "groups.csv");
        lvw_messageSelector.Items.Clear();

        List<string> messageElements = new List<string>();

        try
        {
            string[] groupsLines = File.ReadAllLines(groupsFilePath);

            for (int i = 1; i < groupsLines.Length; i++) // Start from index 1 to skip the header line
            {
                string line = groupsLines[i];
                string[] values = line.Split(',');

                if (values.Length >= 2)
                {
                    string refNumber = values[0].Trim();
                    string groupNumber = values[1].Trim();

                    if (groupNumber == group.ToString()) // Check if the group number matches the desired group value
                    {
                        string messageElement = GetMessageElementFromUplinks(refNumber);

                        if (!string.IsNullOrEmpty(messageElement))
                        {
                            messageElements.Add(messageElement);
                        }
                    }
                }
            }

            foreach (string messageElement in messageElements)
            {
                AddMessageSelectorItem(messageElement);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error occurred while reading the groups.csv file: " + ex.Message);
        }

            // Update the scroll bar height
            scr_messageSelector.PreferredHeight = lvw_messageSelector.Items.Count * 20;
            scr_messageSelector.ActualHeight = (lvw_messageSelector.Items.Count * 20) / 2;
        }


        private string GetMessageElementFromUplinks(string refNumber)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string uplinksFilePath = Path.Combine(Path.GetDirectoryName(assemblyPath), "uplinks.csv");

            try
            {
                string[] uplinksLines = File.ReadAllLines(uplinksFilePath);

                for (int i = 1; i < uplinksLines.Length; i++) // Start from index 1 to skip the header line
                {
                    string line = uplinksLines[i];
                    string[] values = line.Split(',');

                    if (values.Length >= 3)
                    {
                        string refFromUplinks = values[0].Trim();
                        string messageElement = values[1].Trim();

                        if (refFromUplinks == refNumber)
                        {
                            return messageElement;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while reading the uplinks.csv file: " + ex.Message);
            }

            return null;
        }
    }
}
