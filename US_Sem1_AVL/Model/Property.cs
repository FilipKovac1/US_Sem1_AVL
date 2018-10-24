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

        public AVLTree<Person> Occupants { get; set; } // people who live here 

        public PropertyList PropertyList { get; set; } // property list where is property listed

        public Property(int ID) { this.ID = ID; this.Occupants = new AVLTree<Person>(); }
        public Property(int ID, string Address) : this(ID) => this.Address = Address;
        public Property(int ID, string Address, string Description) : this(ID, Address) => this.Description = Description;
        public Property(int ID, string Address, string Description, PropertyList PropertyList) : this(ID, Address, Description) => this.PropertyList = PropertyList;

        public bool AddOccupant (Person p)
        {
            this.Occupants.Insert(p);
            p.Property = this;
            return true;
        }

        public int CompareTo(INode<Property> Node)
        {
            Property p = (Property)Node;

            return Compare.IntC(this.ID, p.ID);
        }
    }
}
