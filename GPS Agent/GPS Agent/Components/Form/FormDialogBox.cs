using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPSAgent.Components.Form
{
    public partial class FormDialogBox : System.Windows.Forms.Form
    {
        public FormDialogBox()
        {
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            FormAccountMain i = (FormAccountMain)Application.OpenForms["FormAccountMain"];
            i.CreateAccountForUser(textBoxUserName.Text);
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {

        }
    }
}
