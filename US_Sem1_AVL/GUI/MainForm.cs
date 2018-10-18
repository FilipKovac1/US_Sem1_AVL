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
            bool didNotFind = false;
            switch (comboTypes.SelectedIndex)
            {
                case 0: // Persons
                    Person p = this.Program.Persons.Find(new Person(textSearch.Text));
                    if (p == null)
                    {
                        didNotFind = true;
                        break;
                    }
                    PersonView pv = new PersonView(p);
                    pv.onDispose += (person) => {
                        p = person;
                    };
                    pv.ShowDialog();
                    break;
                case 1: // Cadastral Area
                    break;
                case 2: // Property list 
                    break;
                case 3: // Property
                    break;
            }

            if (didNotFind)
                MessageBox.Show("Could not find specified item");
        }

        private void SetMainLabelText ()
        {
            labelAllInfo.Text = String.Format("Cadastral Areas ({0}), Persons ({1}), ", Program.CadastralAreasByID.Count, Program.Persons.Count);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (comboTypes.SelectedIndex)
            {
                case 0: // Persons
                    PersonView pv = new PersonView(null);
                    pv.onDispose += (person) =>
                    {
                        if (this.Program.Persons.Insert(person))
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
                    break;
                case 2: // Property list 
                    break;
                case 3: // Property
                    break;
            }
        }
    }
}
