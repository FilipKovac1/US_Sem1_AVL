using System;
using System.Windows.Forms;

namespace US_Sem1_AVL.GUI.Dialog
{
    public partial class InputDialog : Form
    {
        public delegate void OnDispose(string value);
        public OnDispose onDispose;

        private bool emptyVal;
        public InputDialog(string text, string value = "", bool emptyVal = false)
        {
            InitializeComponent();
            labelText.Text = text;
            textBox.Text = value;
            this.emptyVal = emptyVal;
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Dispose(); 

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "" || this.emptyVal)
            {
                string text = textBox.Text;
                this.Dispose();
                onDispose?.Invoke(text);
            } else
            {
                DialogResult result = MessageBox.Show("You did not fill input|\nDo you want to go back ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    this.Dispose();
            }
        }
    }
}
