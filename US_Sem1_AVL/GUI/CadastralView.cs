using System;
using System.Data;
using System.Windows.Forms;
using Model;

namespace US_Sem1_AVL.GUI
{
    partial class CadastralView : Form
    {
        private CadastralArea CadastralArea;

        public delegate void OnDispose(CadastralArea cadastralArea, string oldName);
        public OnDispose onDispose;

        private DataRow row;
        private DataTable tablePLs;
        private BindingSource bindingSourcePLs = new BindingSource();

        public CadastralView(CadastralArea CadastralArea = null)
        {
            InitializeComponent();
            this.CadastralArea = CadastralArea;
            this.PrintCadastralArea();
            this.dataGridPropertyLists.DataSource = bindingSourcePLs;
            this.ReloadData();
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

                btnShowProperties.Visible = this.CadastralArea.Properties.Count > 0;
            }
            else
            {
                inputID.Enabled = true;
                inputID.Text = "";
                inputName.Text = "";

                inputPListsCount.Text = "0";
                inputPropCount.Text = "0";

                btnShowProperties.Visible = false;
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

        private void ReloadData ()
        {
            tablePLs = new DataTable();
            tablePLs.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Properties count", typeof(int))
            });

            if (this.CadastralArea.PropertyLists.Count > 0)
                this.CadastralArea.PropertyLists.InOrder((pl) => tablePLs.Rows.Add(this.CreateRow(pl)));

            this.bindingSourcePLs.DataSource = tablePLs;
        }

        private DataRow CreateRow (PropertyList pl)
        {
            row = this.tablePLs.NewRow();
            row[0] = pl.ID;
            row[1] = pl.Properties.Count;
            return row;
        }

        private void dataGridPropertyLists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                PropertyListView plv = new PropertyListView(this.CadastralArea.FindPropertyList(dataGridPropertyLists.Rows[e.RowIndex].Cells[0].Value.ToString()));
                plv.ShowDialog();
            }
        }
    }
}
