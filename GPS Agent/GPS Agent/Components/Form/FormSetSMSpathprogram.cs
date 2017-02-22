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
    public partial class FormSetSMSpathprogram : System.Windows.Forms.Form
    {
        public FormSetSMSpathprogram()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.SMSpathprogram = textBox1.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Save");
            }
                catch(Exception f)
            {
                MessageBox.Show("Failed Save " + f.ToString());
            }
            
        }

        private void FormSetSMSpathprogram_Load(object sender, EventArgs e)
        {
            textBox1.Text=Properties.Settings.Default.SMSpathprogram ;
        }
    }
}
