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
                inputID.Text = this.Person.ID;
                inputName.Text = this.Person.Name;
            } else
            {
                inputID.Text = "";
                inputName.Text = "";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Person == null || this.Person.ID == "")
                MessageBox.Show("ID is mandatory field, please fill it up");
            onDispose(this.Person);
            this.Dispose(); // for now (next will do update or create :) ) 
        }

        private void inputID_TextChanged(object sender, EventArgs e)
        {
            if (this.Person == null)
                this.Person = new Person();

            this.Person.ID = inputID.Text;
        }

        private void inputName_TextChanged(object sender, EventArgs e)
        {
            if (this.Person == null)
                this.Person = new Person();

            this.Person.Name = inputName.Text;
        }
    }
}
