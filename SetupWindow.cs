using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatsys;

namespace vStripsPlugin
{
    public partial class SetupWindow : BaseForm
    {
        private bool closeDialog = false;

        public SetupWindow()
        {
            InitializeComponent();

            arrivalView.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            arrivalView.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            departureView.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            departureView.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
        }
    }
}
