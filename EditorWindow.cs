using System.Windows.Forms;
using vatsys;

namespace vatACARS
{
    public partial class EditorWindow : BaseForm
    {
        ListViewGroup unanswered;
        ListViewGroup acknowledged;

        public EditorWindow()
        {
            InitializeComponent();

            var unanswered = new ListViewGroup("Unanswered");
            var acknowledged = new ListViewGroup("Acknowledged");

            lbl_receivedMsgs.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lsv_test.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lsv_test.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            lsv_test.Groups.Add(unanswered);
            lsv_test.Groups.Add(acknowledged);

            var item1 = lsv_test.Items.Add("QFA113: LOGON/YSSY");
            item1.BackColor = Colours.GetColour(Colours.Identities.Warning);
            item1.Group = unanswered;
            
            var item2 = lsv_test.Items.Add("JST42D: HELLO!");
            item2.Group = acknowledged;
        }
    }
}
