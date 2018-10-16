using System;
using System.Collections.Generic;
using AVLTree;
using Static;

namespace Model
{
    class Property : INode<Property>
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public List<Person> Owners { get; set; } // who owns this property (share percentage is in Share list)
        public List<Double> Shares { get; set; } // share of property
        public List<Person> Occupants { get; set; } // people who live here 

        public PropertyList PropertyList { get; set; } // property list where is property listed

        public int CompareTo(INode<Property> Node)
        {
            Property p = (Property)Node;

            return Compare.IntC(this.ID, p.ID);
        }
    }
}
