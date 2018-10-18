using AVLTree;
using System;
using Static;

namespace Model
{
    class Person : INode<Person>
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Property Property { get; set; } // where person live

        public Person () { }

        public Person (string ID, string Name = "Unknown")
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
    }
}
