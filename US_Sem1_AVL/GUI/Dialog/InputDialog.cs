using System;
using System.Windows.Forms;

namespace US_Sem1_AVL.GUI.Dialog
{
    public partial class InputDialog : Form
    {
        public delegate void OnDispose(string value);
        public OnDispose onDispose;
        public InputDialog(string text, string value = "")
        {
            InitializeComponent();
            labelText.Text = text;
            textBox.Text = value;
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Dispose(); 

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                onDispose?.Invoke(textBox.Text);
                this.Dispose();
            } else
            {
                DialogResult result = MessageBox.Show("You did not fill input|\nDo you want to go back ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    this.Dispose();
            }
        }
    }
}
