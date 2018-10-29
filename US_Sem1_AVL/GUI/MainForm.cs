using AVLTree;
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
using US_Sem1_AVL.GUI;
using US_Sem1_AVL.GUI.Dialog;

namespace US_Sem1_AVL
{
    partial class MainForm : Form
    {

        private MyProgram Program { get; set; }

        private BindingSource BindSourcePersons = new BindingSource();
        private BindingSource BindSourceCadastralAreas = new BindingSource();
        private DataRow row;
        private DataTable tableCA;
        private DataTable tablePerson;

        public MainForm()
        {
            InitializeComponent();
            InitView init = new InitView();
            init.onDispose += (counts) =>
            {
                if (counts == null)
                    Program = new MyProgram();
                else 
                    Program = new MyProgram(true, counts[0], counts[1], counts[2], counts[3]);

                comboPType.SelectedIndex = 0;
                comboCAType.SelectedIndex = 0;
                comboTypes.SelectedIndex = 0;

                this.dataGridPerson.DataSource = BindSourcePersons;
                this.dataGridCA.DataSource = BindSourceCadastralAreas;

                this.InitPersons();
                this.InitCadastralAreas();
            };
            init.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            switch (comboTypes.SelectedIndex)
            {
                case 0: // Persons
                    Person p = this.Program.Find(new Person(textSearch.Text));
                    if (p == null)
                        goto Error;
                    PersonView pv = new PersonView(p, this);
                    pv.onDispose += (person) => {
                        p = person;
                    };
                    pv.ShowDialog();
                    goto Finish;
                case 1: // Cadastral Area
                    CadastralArea c = null;
                    if (Int32.TryParse(textSearch.Text, out int search))
                    {
                        c = new CadastralArea(search);
                        c = this.Program.Find(new CadastralAreaByID(new CadastralArea(search)));
                    }
                    else
                    {
                        c = new CadastralArea(0, textSearch.Text);
                        c = this.Program.Find(new CadastralAreaByName(c));
                    }
                    if (c == null)
                        goto Error;
                    CadastralView cv = new CadastralView(c);
                    cv.onDispose += (cArea, oldName) =>
                    {
                        if (oldName != c.Name)
                            this.Program.UpdateCadastralArea(c, oldName);
                    };
                    cv.ShowDialog();
                    goto Finish;
                case 2: // Property list 
                    InputDialog id = new InputDialog("Catastral area:");
                    id.onDispose += (caId) =>
                    {
                        if (caId != "")
                        {
                            CadastralArea ca = null;
                            if (Int32.TryParse(caId, out int s))
                                ca = this.Program.Find(new CadastralAreaByID(new CadastralArea(s, "")));
                            else
                                ca = this.Program.Find(new CadastralAreaByName(new CadastralArea(0, caId)));
                            if (ca != null)
                            {
                                PropertyList pl = ca.FindPropertyList(textSearch.Text);
                                if (pl == null)
                                    MessageBox.Show("Property list with this id does not exist");
                                else
                                {
                                    PropertyListView plv = new PropertyListView(pl, this);
                                    plv.ShowDialog();
                                }
                            }
                            else
                                MessageBox.Show("Cadastral area with this id/name does not exist");
                        }
                        else
                            MessageBox.Show("You have to write something");
                    };
                    id.ShowDialog();
                    goto Finish;
                case 3: // Property
                    InputDialog id2 = new InputDialog("Catastral area:");
                    id2.onDispose += (caId) =>
                    {
                        if (caId != "")
                        {
                            CadastralArea ca = null;
                            if (Int32.TryParse(caId, out int s))
                                ca = this.Program.Find(new CadastralAreaByID(new CadastralArea(s, "")));
                            else
                                ca = this.Program.Find(new CadastralAreaByName(new CadastralArea(0, caId)));
                            if (ca != null)
                            {
                                Property prop = ca.FindProperty(textSearch.Text);
                                if (prop == null)
                                    MessageBox.Show("Property with this id does not exist");
                                else
                                {
                                    PropertyView propv = new PropertyView(prop);
                                    propv.ShowDialog();
                                }
                            }
                            else
                                MessageBox.Show("Cadastral area with this id/name does not exist");
                        }
                        else
                            MessageBox.Show("You have to write something");
                    };
                    id2.ShowDialog();
                    goto Finish;
            }

            Error:
                MessageBox.Show("Could not find specified item");
            Finish:;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (comboTypes.SelectedIndex)
            {
                case 0: // Persons
                    PersonView pv = new PersonView(null, this);
                    pv.onDispose += (person) =>
                    {
                        if (this.Program.AddPerson(person))
                        {
                            MessageBox.Show("Person was successfully added!");
                            this.InitPersons();
                        } 
                        else
                            MessageBox.Show("Person could not be added, probably already added!");
                    };
                    pv.ShowDialog();
                    break;
                case 1: // Cadastral Area
                    CadastralView cv = new CadastralView();
                    cv.onDispose += (cArea, name) =>
                    {
                        if (this.Program.AddCadastralArea(cArea))
                        {
                            MessageBox.Show("Cadastral area was successfully added!");
                            this.InitCadastralAreas();
                        }
                        else
                            MessageBox.Show("Cadastral area could not be added, probably already added!");
                    };
                    cv.ShowDialog();
                    break;
                case 2: // Property list 
                    InputDialog id = new InputDialog("Catastral area name:");
                    id.onDispose += (search) =>
                    {
                        if (search != "")
                        {
                            CadastralArea ca = this.Program.Find(new CadastralAreaByName(new CadastralArea(0, (string)search)));
                            if (ca != null) {
                                PropertyListView plv = new PropertyListView(new PropertyList(-1, ca), this);
                                plv.onDispose += (pl) =>
                                {
                                    if (pl.ID >= 0)
                                    {
                                        if (this.Program.AddPropertyList(pl))
                                        {
                                            MessageBox.Show("Property list was successfully added!");
                                        }
                                        else
                                            MessageBox.Show("Cadastral area could not be added, probably already added!");
                                    }
                                };
                                plv.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Cadastral area with this name does not exist");
                            }
                        }
                    };
                    id.ShowDialog();
                    break;
                default:
                    MessageBox.Show("This option is not supported");
                    break;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            switch (comboTypes.SelectedIndex)
            {
                case 1: // cadastral area
                    CadastralArea c = null, c2 = null;
                    if (Int32.TryParse(textSearch.Text, out int search))
                    {
                        c = new CadastralArea(search);
                        c = this.Program.Find(new CadastralAreaByID(new CadastralArea(search)));
                    }
                    else
                    {
                        c = new CadastralArea(0, textSearch.Text);
                        c = this.Program.Find(new CadastralAreaByName(c));
                    }
                    if (c == null)
                        MessageBox.Show("This cadastral area does not exists");
                    else
                    {
                        InputDialog id = new InputDialog("Cadastral area to add this one (ID):");
                        id.onDispose += (idCa) =>
                        {
                            if (Int32.TryParse(idCa, out int idCAint) && c.ID != idCAint)
                            {
                                c2 = new CadastralArea(idCAint);
                                c2 = this.Program.Find(new CadastralAreaByID(c2));
                                if (c2 != null)
                                {
                                    this.Program.Merge(c, c2);
                                    this.InitCadastralAreas();
                                    MessageBox.Show(String.Format("Cadastal area {0} was remove and its property lists was moved under {1} ", c.Name, c2.Name));
                                }
                                else
                                    MessageBox.Show("Cadastral area does not exist");
                            }
                            else
                                MessageBox.Show("New cadastral are cannot be the same as removing one");
                        };
                        id.ShowDialog();
                    }
                    break;
                default:
                    MessageBox.Show("This option is not supported yet!");
                    break;
            }
        }

        public Person FindPerson(Person p) => this.Program.Find(p);
        public CadastralArea FindCadastralArea(CadastralAreaByID ca) => this.Program.Find(ca);

        private void InitPersons()
        {
            labelPersons.Text = String.Format("Persons ({0}):", Program.Persons.Count);
            this.tablePerson = new DataTable();

            tablePerson.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Birthday", typeof(string)),
                new DataColumn("Address", typeof(string)),
                new DataColumn("Property List count", typeof(int)),
            });

            // Add rows.
            LinkedList<Person> ps = null;
            switch (comboPType.SelectedItem)
            {
                case "PreOrder":
                    ps = this.Program.Persons.PreOrder(Order);
                    break;
                case "PostOrder":
                    ps = this.Program.Persons.PostOrder(Order);
                    break;
                case "InOrder":
                    ps = this.Program.Persons.InOrder(Order);
                    break;
            }

            BindSourcePersons.DataSource = tablePerson;
        }
        private void InitCadastralAreas()
        {
            labelCACount.Text = String.Format("Cadastral Areas ({0}):", Program.CadastralAreasByID.Count);
            this.tableCA = new DataTable();

            tableCA.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Property List count", typeof(int)),
                new DataColumn("Properties count", typeof(int)),
            });

            // Add rows.
            LinkedList<CadastralAreaByName> cans = null;
            switch (comboCAType.SelectedItem)
            {
                case "PreOrder":
                    cans = this.Program.CadastralAreasByName.PreOrder(Order);
                    break;
                case "PostOrder":
                    cans = this.Program.CadastralAreasByName.PostOrder(Order);
                    break;
                case "InOrder":
                    cans = this.Program.CadastralAreasByName.InOrder(Order);
                    break;
            }

            BindSourceCadastralAreas.DataSource = tableCA;
        }

        private void Order(CadastralAreaByName cao) => tableCA.Rows.Add(this.CreateCARow(cao.CadastralArea));
        private void Order(Person p) => tablePerson.Rows.Add(this.CreatePersonRow(p));

        private DataRow CreatePersonRow (Person p)
        {
            this.row = tablePerson.NewRow();
            row["ID"] = p.ID;
            row["Name"] = p.Name;
            row["Birthday"] = p.DateOfBirth.ToString("dd-MM-yyyy");
            row["Address"] = p.Property == null ? "Without" : p.Property?.Address;
            row["Property List count"] = p.PropertyLists.Count;
            return this.row;
        }

        private DataRow CreateCARow (CadastralArea ca)
        {
            this.row = tableCA.NewRow();
            row["ID"] = ca.ID;
            row["Name"] = ca.Name;
            row["Property List count"] = ca.PropertyLists.Count;
            row["Properties count"] = ca.Properties.Count;
            return this.row;
        }

        private void comboCAType_SelectedIndexChanged(object sender, EventArgs e) => InitCadastralAreas();

        private void comboPType_SelectedIndexChanged(object sender, EventArgs e) => InitPersons();

        private void dataGridPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                PersonView pv = new PersonView(this.Program.Find(new Person(dataGridPerson.Rows[e.RowIndex].Cells["ID"].Value.ToString())), this);
                pv.onDispose += (p) => this.InitPersons();
                pv.ShowDialog();
            }
        }
        private void dataGridCA_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                CadastralView cv = new CadastralView(this.Program.Find(new CadastralAreaByID(new CadastralArea(Int32.Parse(dataGridCA.Rows[e.RowIndex].Cells["ID"].Value.ToString())))));
                cv.onDispose += (ca, c) => this.InitCadastralAreas();
                cv.ShowDialog();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            switch (comboTypes.SelectedIndex)
            {
                case 0: // Persons
                    if (this.Program.Persons.TestAVL())
                        MessageBox.Show("Persons are in AVLTree!");
                    else
                        MessageBox.Show("Persons are not in AVLtree!");
                    break;
                case 1: // Cadastral Area
                    if (this.Program.CadastralAreasByID.TestAVL())
                        MessageBox.Show("Cadastral area is AVLTree!");
                    else
                        MessageBox.Show("Cadastral area is not AVLtree!");
                    break;
                default:
                    if (this.Program.TestStructure())
                        MessageBox.Show("AVLTree test run successfully!");
                    else
                        MessageBox.Show("Structure test failed!");
                    break;
            }
        }
    }
}
