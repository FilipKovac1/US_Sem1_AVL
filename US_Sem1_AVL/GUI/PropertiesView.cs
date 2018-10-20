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
            dataGridView1.DataSource = bindingSource1;
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

            table.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Address", typeof(string)),
                new DataColumn("Description", typeof(string)),
            });

            if (per)
                table.Columns.Add(new DataColumn("Share", typeof(string)));

            // Add rows.
            if (this.Properties != null)
                foreach (Property p in this.Properties)
                    table.Rows.Add(this.CreateRow(p, per, table));
            else if (this.PropertiesList != null)
                foreach (PropertyList pl in this.PropertiesList)
                    foreach (Property p in pl.Properties.PostOrder())
                        table.Rows.Add(this.CreateRow(p, per, table));

            bindingSource1.DataSource = table;
        }

        private DataRow CreateRow (Property p, bool per, DataTable table)
        {
            row = table.NewRow();
            row["ID"] = p.ID;
            row["Address"] = p.Address;
            row["Description"] = p.Description;
            if (per)
                row["Share"] = (p.PropertyList.GetOwnersShare(this.Person) * 100) + " %";
            return row;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
