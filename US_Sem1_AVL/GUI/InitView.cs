using System;
using System.Windows.Forms;

namespace US_Sem1_AVL.GUI
{
    public partial class InitView : Form
    {
        public delegate void OnDispose(int[] counts);
        public OnDispose onDispose { get; set; }
        public InitView()
        {
            InitializeComponent();
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            this.RunMain();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int[] counts = new int[4];
            string error = String.Empty;

            if (!Int32.TryParse(inputCad.Text, out counts[0]) && counts[0] >= 0)
                error += "Count of cadastral areass has to be set as real number higher or equal 0\n";
            if (!Int32.TryParse(inputPer.Text, out counts[1]) && counts[1] >= 0)
                error += "Count of persons has to be set as real number higher or equal 0\n";
            if (!Int32.TryParse(inputPLists.Text, out counts[2]) && counts[2] >= 0)
                error += "Count of propertty lists has to be set as real number higher or equal 0\n";
            if (!Int32.TryParse(inputProps.Text, out counts[3]) && counts[3] >= 0)
                error += "Count of properties has to be set as real number higher or equal 0\n";

            if (error != String.Empty)
                this.ShowError(error);
            else
                this.RunMain(counts);
        }

        public void RunMain (int[] counts = null)
        {
            this.Dispose();
            this.onDispose?.Invoke(counts);
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
