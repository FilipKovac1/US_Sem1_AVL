using AVLTree;
using Static;
using System;
using System.Collections.Generic;

namespace Model
{
    class PropertyList : INode<PropertyList>
    {
        public int ID { get; set; } // unique for cadastral area
        public CadastralArea CadastralArea { get; set; } 
        public AVLTree<Property> Properties { get; set; } // properties on property list

        public List<Owner> Owners { get; set; } // who owns this property (share percentage is in Share list)
        public int CompareTo(INode<PropertyList> Node)
        {
            PropertyList p = (PropertyList)Node;
            return Compare.IntC(this.ID, p.ID);
        }

        private bool CheckShares ()
        {
            double sum = 0;
            foreach (Owner o in Owners)
                sum += o.Share;
            if (sum != 1)
                return false;
            return true;
        }
    }
}
