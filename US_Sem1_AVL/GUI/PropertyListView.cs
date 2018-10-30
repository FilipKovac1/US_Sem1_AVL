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
    partial class PropertyListView : Form
    {
        private PropertyList PropertyList;

        public delegate void OnDispose(PropertyList PropertyList);
        public OnDispose onDispose;

        private BindingSource BindSourceOwners = new BindingSource();
        private DataRow row;

        private MainForm MainForm;

        public PropertyListView(PropertyList PropertyList, MainForm form = null)
        {
            InitializeComponent();
            this.PropertyList = PropertyList;
            this.PrintPropertyList();
            this.MainForm = form;
        }

        private void PrintPropertyList()
        {
            if (this.PropertyList != null)
            {
                this.inputName.Text = this.PropertyList.CadastralArea.Name;
                this.inputID.Text = this.PropertyList.ID.ToString();

                this.btnShowProperties.Visible = this.PropertyList.Properties.Count > 0;
            } else
            {
                this.inputName.Text = "";
                this.inputID.Text = "";

                this.btnShowProperties.Visible = false;
            }

            Owners.DataSource = BindSourceOwners;
            ReloadData();
        }

        private void btnShowProperties_Click(object sender, EventArgs e)
        {
            if (this.PropertyList.Properties.Count > 0)
            {
                PropertiesView plv = new PropertiesView(this.PropertyList.Properties.InOrder(), null);
                plv.ShowDialog();
            }
            else
            {
                MessageBox.Show("This should not happen");
            }
        }

        private void ReloadData()
        {
            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Share", typeof(string)),
            });

            // Add rows.
            if (this.PropertyList.Owners.Count > 0)
                this.PropertyList.Owners.PreOrder((o) => table.Rows.Add(this.CreateOwnerRow(o, table)));

            BindSourceOwners.DataSource = table;
        }

        private DataRow CreateOwnerRow(Owner o, DataTable table)
        {
            row = table.NewRow();
            row["ID"] = o.Person.ID;
            row["Name"] = o.Person.Name;
            row["Share"] = o.Share * 100 + " %";
            return row;
        }

        private void Owners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) {
                if (this.PropertyList.Owners.Count <= 1)
                    MessageBox.Show("To change share values, property list has to have at least 2 owners");
                else
                {
                    Owner o = this.PropertyList.Owners.Find(new Owner(new Person(Owners.Rows[e.RowIndex].Cells["ID"].Value.ToString())));
                    if (o != null)
                    {
                        InputDialog id = new InputDialog("New share", o.Share.ToString());
                        id.onDispose += (share) =>
                        {
                            if (!Double.TryParse(share, out double s))
                                MessageBox.Show("Share has to be in range <0.00;1.00>");
                            else if (o.Share != s)
                            {
                                if (checkShares.Checked)
                                    this.PropertyList.ChangeShare(o, s);
                                else
                                    o.Share = s;
                                this.ReloadData();
                            }
                        };
                        id.ShowDialog();
                    }
                    else
                        MessageBox.Show("Cannot find owner");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void btnOk_Click(object sender, EventArgs e)
        { 
            if (!Int32.TryParse(inputID.Text, out int id))
            {
                MessageBox.Show("Type of ID has to be integer");
                goto End;
            }

            this.PropertyList.ID = id;
            this.onDispose?.Invoke(this.PropertyList);
            this.Dispose();

            End:;
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                InputDialog id = new InputDialog("New owner ID");
                id.onDispose += (pID) =>
                {
                    Person p = this.MainForm.FindPerson(new Person(pID));
                    if (p != null)
                    {
                        this.PropertyList.AddOwner(p, 0);
                        this.ReloadData();
                    }
                    else
                        MessageBox.Show("This person does not exists");
                };
                id.ShowDialog();
            }
            else
                MessageBox.Show("To do this action, you have to navigate from main window");
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            PropertyView pv = new PropertyView(new Property(-1, "", "", this.PropertyList));
            pv.onDispose += (p) =>
            {
                if (p.ID >= 0 && this.PropertyList.AddProperty(p))
                    MessageBox.Show("Property was added");
                else
                    MessageBox.Show("Property was not added");
            };
            pv.ShowDialog();
        }

        private void btnFindProperty_Click(object sender, EventArgs e)
        {
            InputDialog id = new InputDialog("Property ID:");
            id.onDispose += (pID) =>
            {
                if (!Int32.TryParse(pID, out int pIDint)) {
                    MessageBox.Show("Value has to be integer");
                }  else {
                    Property p = this.PropertyList.FindProperty(new Property(pIDint));
                    if (p != null)
                    {
                        PropertyView pv = new PropertyView(p);
                        pv.ShowDialog();
                    }
                    else
                        MessageBox.Show("This property does not exists");
                }
            };
            id.ShowDialog();
        }

        private void btnDeleteProperty_Click(object sender, EventArgs e)
        {
            InputDialog id = new InputDialog("Property ID:");
            id.onDispose += (pID) =>
            {
                if (!Int32.TryParse(pID, out int pIDint))
                    MessageBox.Show("Value has to be integer");
                else
                {
                    if (this.PropertyList.DeleteProperty(pIDint))
                        MessageBox.Show("Property was deleted");
                    else
                        MessageBox.Show("This property does not exists");
                }
            };
            id.ShowDialog();
        }

        private void btnRemoveOwner_Click(object sender, EventArgs e)
        {
            int rowIndex = Owners.CurrentCell.RowIndex;
            if (rowIndex > -1)
            {
                if (this.PropertyList.DeleteOwner(Owners.Rows[rowIndex].Cells["ID"].Value.ToString()))
                {
                    this.ReloadData();
                }
            }
        }
    }
}
