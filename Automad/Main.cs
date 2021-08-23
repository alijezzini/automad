using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automad
{
    public partial class Main : Form
    {
        private List<String> numbers;

        public Main()
        {
            InitializeComponent();
            numbers = new List<String>();
        }

        private void run_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numberbox.Enabled = true;
            ImportButton.Enabled = false;
            if (numberbox.Text.Length == 0)
            {
                runButton.Enabled = false;
            }
            else
            {
                runButton.Enabled = true;
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numberbox.Enabled = false;
            ImportButton.Enabled = true;
            if (numbers.Count == 0)
            {
                runButton.Enabled = false;
            }
            else
            {
                runButton.Enabled = true;
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

        }

        private void numberbox_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!numberbox.Text.Equals(""))
                {
                    runButton.Enabled = true;
                }
                else
                {
                    runButton.Enabled = false;
                }
            }
        }
    }
}
