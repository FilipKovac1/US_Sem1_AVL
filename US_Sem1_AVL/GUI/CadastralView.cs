using System;
using System.Windows.Forms;
using Model;

namespace US_Sem1_AVL.GUI
{
    partial class CadastralView : Form
    {
        private CadastralArea CadastralArea;

        public delegate void OnDispose(CadastralArea cadastralArea, string oldName);
        public OnDispose onDispose;

        public CadastralView()
        {
            InitializeComponent();
            this.CadastralArea = null;
            this.PrintCadastralArea();
        }

        public CadastralView(CadastralArea CadastralArea = null) : this()
        {
            this.CadastralArea = CadastralArea;
            this.PrintCadastralArea();
        }

        private void PrintCadastralArea()
        {
            if (this.CadastralArea != null)
            {
                inputID.Enabled = false;
                inputID.Text = this.CadastralArea.ID.ToString();
                inputName.Text = this.CadastralArea.Name;

                inputPListsCount.Text = this.CadastralArea.PropertyLists.Count.ToString();
                inputPropCount.Text = this.CadastralArea.Properties.Count.ToString();

                btnShowPropertyLists.Visible = this.CadastralArea.Properties.Count > 0;
            }
            else
            {
                inputID.Enabled = true;
                inputID.Text = "";
                inputName.Text = "";

                inputPListsCount.Text = "0";
                inputPropCount.Text = "0";

                btnShowPropertyLists.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.CadastralArea == null)
                this.CadastralArea = new CadastralArea(0);

            if (!Int32.TryParse(inputID.Text, out int id)) goto DoNothing;

            this.CadastralArea.ID = id;
            string oldName = this.CadastralArea.Name;
            this.CadastralArea.Name = inputName.Text;

            if (this.CadastralArea == null || this.CadastralArea.ID == 0)
                MessageBox.Show("ID is mandatory field, please fill it up");
            onDispose?.Invoke(this.CadastralArea, oldName);
            this.Dispose();
            goto Finish;

            DoNothing:;
                MessageBox.Show("ID has to be integer");
            Finish:;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void btnShowPropertyLists_Click(object sender, EventArgs e)
        {
        }

        private void btnShowProperties_Click(object sender, EventArgs e)
        {
            if (this.CadastralArea.PropertyLists.Count > 0)
            {
                PropertiesView plv = new PropertiesView(this.CadastralArea.Properties.InOrder(), null);
                plv.ShowDialog();
            }
            else
            {
                MessageBox.Show("This should not happen");
            }
        }
    }
}
