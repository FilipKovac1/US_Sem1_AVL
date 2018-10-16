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

            Program = new MyProgram();
        }
    }
}
