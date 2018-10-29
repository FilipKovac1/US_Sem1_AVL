using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace US_Sem1_AVL.GUI
{
    partial class PropertyView : Form
    {
        private Property Property;

        public delegate void OnDispose(Property Property);
        public OnDispose onDispose;

        private BindingSource BindingSourceOccupants = new BindingSource();

        public PropertyView(Property Property)
        {
            InitializeComponent();

            this.Property = Property;
            this.dataGridOccupants.DataSource = BindingSourceOccupants;
            this.PrintProperty();
        }

        private void PrintProperty()
        {
            if (this.Property != null) {
                this.inputID.Enabled = this.Property.ID < 0;
                this.inputID.Text = this.Property.ID.ToString();
                this.inputAddress.Text = this.Property.Address;
                this.inputDesc.Text = this.Property.Description;
                this.inputList.Text = this.Property.PropertyList.ID.ToString();
            } else { 
                this.inputID.Enabled = true;
                this.inputID.Text = "";
                this.inputAddress.Text = "";
                this.inputDesc.Text = "";
                this.inputList.Text = "";
            }
            this.ReloadOccupants();
        }

        private void ReloadOccupants ()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(string)),
                new DataColumn("Name", typeof(string)),
            });

            DataRow row = null;
            this.Property.Occupants.PreOrder((p) =>
            {
                row = dt.NewRow();
                row["ID"] = p.ID;
                row["Name"] = p.Name;
                dt.Rows.Add(row);
            });

            BindingSourceOccupants.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(inputID.Text, out int id))
                MessageBox.Show("ID has to by integer");
            else
            {
                this.Property.ID = id;
                this.Property.Address = this.inputAddress.Text;
                this.Property.Description = this.inputDesc.Text;

                onDispose?.Invoke(this.Property);
                this.Dispose();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.Property.PropertyList != null)
            {
                PropertyListView plv = new PropertyListView(this.Property.PropertyList);
                plv.ShowDialog();
            }
        }
    }
}
