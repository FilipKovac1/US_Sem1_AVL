using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;
using US_Sem1_AVL.GUI.Dialog;

namespace US_Sem1_AVL.GUI
{
    partial class PersonView : Form
    {
        private Person Person { get; set; }

        public delegate void OnDispose(Person person);
        public OnDispose onDispose { get; set; }

        public PersonView()
        {
            InitializeComponent();
            this.Person = null;
            this.PrintPerson();
        }

        public PersonView(Person Person = null) : this()
        {
            this.Person = Person;
            this.PrintPerson();
        }

        private void PrintPerson ()
        {
            if (this.Person != null)
            {
                inputID.Enabled = false;
                inputID.Text = this.Person.ID;
                inputName.Text = this.Person.Name;
                inputBirthday.SelectionStart = this.Person.DateOfBirth;
                inputAddress.Text = this.Person.GetAddress();

                btnShowProperties.Visible = this.Person.PropertyLists.Count > 0;
            } else
            {
                inputID.Enabled = true;
                inputID.Text = "";
                inputName.Text = "";
                inputBirthday.SelectionStart = DateTime.Now;
                inputAddress.Text = "";
                btnShowProperties.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Person == null)
                this.Person = new Person();

            this.Person.Name = inputName.Text;
            this.Person.ID = inputID.Text;
            this.Person.DateOfBirth = inputBirthday.SelectionStart;

            if (this.Person == null || this.Person.ID == "")
                MessageBox.Show("ID is mandatory field, please fill it up");
            onDispose(this.Person);
            this.Dispose(); // for now (next will do update or create :) ) 
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void btnShowProperties_Click(object sender, EventArgs e)
        {
            if (this.Person.PropertyLists.Count > 0)
            {
                InputDialog id = new InputDialog("Catastral area name:");
                id.onDispose += (search) =>
                {
                    if (search != "")
                    {
                        List<PropertyList> pl = this.Person.PropertyLists.PreOrder().Where(c => c.CadastralArea.Name == search).ToList();
                        if (pl.Count > 0)
                        {
                            PropertiesView plv = new PropertiesView(pl, this.Person, 0);
                            plv.ShowDialog();
                        } else
                        {
                            MessageBox.Show("There is no properties in this cadastral area");
                        }
                    }
                };
                id.ShowDialog();
            } else
            {
                MessageBox.Show("This should not happen");
            }
        }
    }
}
