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
    partial class PropertyListView : Form
    {
        private PropertyList PropertyList;

        public delegate void OnDispose(PropertyList PropertyList);
        public OnDispose onDispose;

        public PropertyListView(PropertyList PropertyList)
        {
            InitializeComponent();
            this.PropertyList = PropertyList;
            this.PrintPropertyList();
        }

        private void PrintPropertyList()
        {
            if (this.PropertyList != null)
            {

            } else
            {

            }
        }
    }
}
