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

        private MainForm form;
        public PersonView(Person Person = null, MainForm form = null)
        {
            InitializeComponent();
            this.Person = Person;
            this.form = form;
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
            btnChangeAddress.Visible = this.form != null;
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
            onDispose?.Invoke(this.Person);
            this.Dispose(); // for now (next will do update or create :) ) 
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void btnShowProperties_Click(object sender, EventArgs e)
        {
            if (this.Person.PropertyLists.Count > 0)
            {
                InputDialog id = new InputDialog("Catastral area name:", "", true);
                id.onDispose += (search) =>
                {
                    List<PropertyList> pl = null;
                    if (search != "")
                    {
                        if (Int32.TryParse(search, out int ss))
                            pl = this.Person.PropertyLists.PreOrder().Where(c => c.CadastralArea.ID == ss).ToList();
                        else
                            pl = this.Person.PropertyLists.PreOrder().Where(c => c.CadastralArea.Name == search).ToList();
                    }
                    else
                        pl = this.Person.PropertyLists.PreOrder().ToList();
                        
                    if (pl.Count > 0)
                    {
                        PropertiesView plv = new PropertiesView(pl, this.Person, 0);
                        plv.ShowDialog();
                    }
                    else
                        MessageBox.Show("There is no properties in this cadastral area");
                };
                id.ShowDialog();
            } else
            {
                MessageBox.Show("This should not happen");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (this.Person.Property != null)
            {
                PropertyView pv = new PropertyView(this.Person.Property);
                pv.onDispose += (prop) => this.inputAddress.Text = prop.Address;
                pv.ShowDialog();
            }
        }

        private void btnChangeAddress_Click(object sender, EventArgs e)
        {
            if (form != null) {
                InputDialog caid = new InputDialog("Cadastral area id:");
                caid.onDispose += (caID) =>
                {
                    if (Int32.TryParse(caID, out int caIDint))
                    {
                        CadastralArea ca = new CadastralArea(caIDint);
                        ca = this.form.FindCadastralArea(new CadastralAreaByID(ca));
                        if (ca != null)
                        {
                            InputDialog pid = new InputDialog("Property id:");
                            pid.onDispose += (pID) =>
                            {
                                Property p = ca.FindProperty(pID);
                                if (p != null) {
                                    p.AddOccupant(this.Person);
                                    this.inputAddress.Text = p.Address;
                                }
                                else
                                    MessageBox.Show("Could not find this property");
                            };
                            pid.ShowDialog();
                        } else
                            MessageBox.Show("This cadastral area doesn't exist");
                    }
                    else
                        MessageBox.Show("Input value has to be integer");
                };
                caid.ShowDialog();
            }
        }
    }
}
