using System.Security.AccessControl;
using System.Windows.Forms;
using vatsys;

namespace vatACARS
{
    public partial class PDCWindow : BaseForm
    {
        ListViewGroup groupNew = new ListViewGroup("New");
        ListViewGroup groupStandby = new ListViewGroup("Standby");
        ListViewGroup groupAnswered = new ListViewGroup("Replied");
        Tranceiver.incomingMessage[] messages = new Tranceiver.incomingMessage[] { };

        public PDCWindow()
        {
            InitializeComponent();
        }
    }
}
