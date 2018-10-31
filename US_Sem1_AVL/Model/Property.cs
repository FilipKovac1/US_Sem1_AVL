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

        /// <summary>
        /// Add occupant to this property and set property of person to this
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool AddOccupant (Person p)
        {
            this.Occupants.Add(p);
            p.Property = this;
            return true;
        }

        public int CompareTo(INode<Property> Node)
        {
            Property p = (Property)Node;

            return Compare.IntC(this.ID, p.ID);
        }

        public override string ToString() => String.Format("{0}", this.ID);

        /// <summary>
        /// Change owner in property
        /// </summary>
        /// <param name="oldOwner"></param>
        /// <param name="newOwner"></param>
        /// <returns></returns>
        public bool ChangeOwner(Person oldOwner, Person newOwner) => this.PropertyList.ChangeOwner(oldOwner, newOwner);

        public static string GetCsvHeaders() => "ID;Address;Description;CadastralAreaID;PropertyListID";
        public static string OccupantsCsvHeader() => "PersonID;PropertyID;CadastralAreaID";

        public string ToCSV() => String.Format("{0};{1};{2};{3};{4}", this.ID, this.Address, this.Description, this.PropertyList.CadastralArea.ID, this.PropertyList.ID);
        public string OccupantToCsv(Person p) => String.Format("{0};{1};{2}", p.ID, this.ID, this.PropertyList.CadastralArea.ID);
    }
}
