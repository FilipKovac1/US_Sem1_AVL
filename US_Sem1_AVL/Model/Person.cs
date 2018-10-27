using AVLTree;
using System;
using Static;

namespace Model
{
    class Person : INode<Person>
    {
        public string Name { get; set; }
        public string ID { get; set; }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth {
            set { _DateOfBirth = value; }
            get => _DateOfBirth == DateTime.MinValue ? DateTime.Now : _DateOfBirth;
        }

        private Property _Property;
        public Property Property {
            get { return _Property; }
            set {
                if (_Property != null && _Property.ID != value.ID)
                    _Property.Occupants.Remove(this);
                _Property = value;
            }
        } // where person live
        public AVLTree<PropertyList> PropertyLists { get; set; }

        public Person ()
        {
            this.PropertyLists = new AVLTree<PropertyList>();
        }

        public Person (string ID, string Name = "Unknown") : this()
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Person (string ID, string Name, DateTime DateOfBirth) : this(ID, Name)
        {
            this.DateOfBirth = DateOfBirth;
        }

        public int CompareTo(INode<Person> Node)
        {
            Person obj = (Person)Node;

            return Compare.StringC(this.ID, obj.ID);
        }

        public override string ToString()
        {
            return this.ID;
        }

        public string GetAddress() => this.Property != null ? this.Property.Address : "Does not have";

        public bool AddPropertyList(PropertyList propertyList)
        {
            return this.PropertyLists.Add(propertyList);
        }
    }
}
