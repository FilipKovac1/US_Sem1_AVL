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

namespace US_Sem1_AVL
{
    public partial class MainForm : Form
    {

        private MyProgram Program { get; set; }

        public MainForm()
        {
            InitializeComponent();
            comboTreePrint.SelectedIndex = 2;
            comboTrees.SelectedIndex = 0;
            comboTypes.SelectedIndex = 0;
            InitView init = new InitView();
            init.onDispose += (counts) =>
            {
                if (counts == null)
                    Program = new MyProgram();
                else
                    Program = new MyProgram(true, counts[0], counts[1], counts[2], counts[3]);

                this.SetMainLabelText();
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
                    PersonView pv = new PersonView(p);
                    pv.onDispose += (person) => {
                        p = person;
                    };
                    pv.ShowDialog();
                    goto Finish;
                case 1: // Cadastral Area
                    int search = 0;
                    CadastralArea c = Int32.TryParse(textSearch.Text, out search) ? this.Program.Find(new CadastralAreaByID(new CadastralArea(search))) : this.Program.Find(new CadastralAreaByName(new CadastralArea(0, textSearch.Text)));
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
                    break;
                case 3: // Property
                    break;
            }

            Error:
                MessageBox.Show("Could not find specified item");
            Finish:;
        }

        private void SetMainLabelText ()
        {
            labelAllInfo.Text = String.Format("Cadastral Areas ({0}), Persons ({1}), ", Program.GetCount("CadastralArea"), Program.GetCount("Person"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (comboTypes.SelectedIndex)
            {
                case 0: // Persons
                    PersonView pv = new PersonView(null);
                    pv.onDispose += (person) =>
                    {
                        if (this.Program.AddPerson(person))
                        {
                            MessageBox.Show("Person was successfully added!");
                            this.SetMainLabelText();
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
                            this.SetMainLabelText();
                        }
                        else
                            MessageBox.Show("Cadastral area could not be added, probably already added!");
                    };
                    cv.ShowDialog();
                    break;
                case 2: // Property list 
                    break;
                case 3: // Property
                    break;
            }
        }
    }
}
