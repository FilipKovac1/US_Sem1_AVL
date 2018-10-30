using AVLTree;
using System;

namespace Model
{
    class Owner : INode<Owner>
    {
        public Person Person { get; set; }
        public double Share { get; set; }

        public Owner (Person Person, double Share = 1)
        {
            this.Person = Person;
            this.Share = Share;
        }

        public int CompareTo (INode<Owner> Node)
        {
            Owner o = (Owner)Node;
            return this.Person.CompareTo(o.Person);
        }

        public static string GetCsvHeaders() => "PersonID;CadastralAreaID;PropertyListID;Share";

        public string ToCSV(PropertyList pl) => String.Format("{0};{1};{2};{3}", this.Person.ID, pl.CadastralArea.ID, pl.ID, this.Share);
    }
}
