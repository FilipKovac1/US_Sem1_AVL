using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using US_Sem1_AVL.GUI.Dialog;

namespace US_Sem1_AVL.GUI
{
    partial class PropertiesView : Form
    {
        private LinkedList<Property> Properties;
        private List<PropertyList> PropertiesList;
        private Person Person;

        private BindingSource bindingSource1 = new BindingSource();
        private DataRow row;

        public PropertiesView()
        {
            InitializeComponent();
            this.Properties = new LinkedList<Property>();
            dataGridProperties.DataSource = bindingSource1;
            this.Person = null;
        }

        public PropertiesView(List<PropertyList> Properties, Person Person, int x) : this()
        {
            this.Properties = null;
            this.PropertiesList = Properties;
            this.Person = Person;
            ReloadData();
        }

        public PropertiesView(LinkedList<Property> Properties, Person Person) : this()
        {
            this.Properties = Properties;
            this.PropertiesList = null;
            this.Person = Person;
            ReloadData();
        }

        public PropertiesView(LinkedList<PropertyList> PropertyLists, Person Person) : this()
        {
            this.PropertiesList = null;
            foreach (PropertyList pl in PropertyLists)
                foreach (Property p in pl.Properties.InOrder())
                    this.Properties.AddLast(p);
            this.Person = Person;
            ReloadData();
        }

        private void ReloadData()
        {
            DataTable table = new DataTable();
            bool per = this.Person != null;

            DataColumn[] columns = null;
            if (per)
                columns = new DataColumn[]
                {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("Address", typeof(string)),
                    new DataColumn("Description", typeof(string)),
                    new DataColumn("Share", typeof(string))
                };
            else
                columns = new DataColumn[]
                {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("Address", typeof(string)),
                    new DataColumn("Description", typeof(string)),
                };

            table.Columns.AddRange(columns);

            // Add rows.
            if (this.Properties != null)
                foreach (Property p in this.Properties)
                    table.Rows.Add(this.CreateRow(p, per, table));
            else if (this.PropertiesList != null)
                foreach (PropertyList pl in this.PropertiesList)
                    foreach (Property p in pl.Properties.PreOrder())
                        table.Rows.Add(this.CreateRow(p, per, table));

            bindingSource1.DataSource = table;
        }

        private DataRow CreateRow (Property p, bool per, DataTable table)
        {
            row = table.NewRow();
            row[0] = p.ID;
            row[1] = p.Address;
            row[2] = p.Description;
            if (per)
                row[3] = (p.PropertyList.GetOwnersShare(this.Person) * 100) + " %";
            return row;
        }

        private void dataGridProperties_RowClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                Property p =
                    this.Properties != null ?
                        this.Properties.Where(po => po.ID == Int32.Parse(dataGridProperties.Rows[e.RowIndex].Cells[0].Value.ToString())).FirstOrDefault()
                        :
                        this.GetProperty(Int32.Parse(dataGridProperties.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    PropertyView pv = new PropertyView(p);
                    pv.onDispose += (ret) => this.ReloadData();
                    pv.ShowDialog();
                }
            }
        }

        private Property GetProperty (int id)
        {
            Property ret = new Property(id);
            Property temp = null;
            foreach (PropertyList pl in this.PropertiesList) {
                temp = pl.Properties.Find(ret);
                if (temp != null && temp.PropertyList != null)
                    return temp;
            }

            return default(Property);
        }
    }
}
