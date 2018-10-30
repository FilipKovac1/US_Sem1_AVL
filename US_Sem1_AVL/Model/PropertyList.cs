using AVLTree;
using Static;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    class PropertyList : INode<PropertyList>
    {
        public int ID { get; set; } // unique for cadastral area
        public CadastralArea CadastralArea { get; set; } 
        public AVLTree<Property> Properties { get; set; } // properties on property list

        public AVLTree<Owner> Owners { get; set; } // who owns this property (share percentage is in Share list)

        public PropertyList(int ID) { this.ID = ID; this.Properties = new AVLTree<Property>(); this.Owners = new AVLTree<Owner>(); }

        public PropertyList(int ID, CadastralArea c) : this(ID) => this.CadastralArea = c; 

        public PropertyList (int ID, CadastralArea c, AVLTree<Property> Properties, AVLTree<Owner> Owners) : this(ID, c)
        {
            this.Properties = Properties;
            this.Owners = Owners;
        }
        
        public int CompareTo(INode<PropertyList> Node)
        {
            PropertyList p = (PropertyList)Node;
            return Compare.IntC(this.ID, p.ID);
        }

        private bool CheckShares ()
        {
            double sum = Owners.Count == 0 ? 1 : 0;
            Owners.PreOrder((o) => sum += o.Share);
            if (sum != 1)
                return false;
            return true;
        }

        public bool ChangeOwner(Person oldOwner, Person newOwner)
        {
            Owner o = this.Owners.Find(new Owner(oldOwner));
            o.Person = newOwner;
            oldOwner.RemovePropertyList(this);
            newOwner.AddPropertyList(this);

            return true;
        }

        public bool AddOwner (Person p, double share = 1, bool check = true)
        {
            if (p == null || this.Owners.Find(new Owner(p)) != null) // if owner is already added
                return false;
            if (Owners.Count == 0)
                share = 1;
            else
            {
                if (check)
                {
                    double minusShare = share / (double)Owners.Count;
                    Owners.PreOrder((o) => o.Share -= minusShare);
                }
            }
            this.Owners.Add(new Owner(p, share));
            p.AddPropertyList(this);
            return this.CheckShares();
        }

        public bool AddProperty (Property p)
        {
            if (p == null)
                return false;
            if (!this.CadastralArea.Properties.Add(p))
                return false;
            return this.Properties.Add(p);
        }

        public double GetOwnersShare(Person person)
        {
            Owner o = this.Owners.Find(new Owner(person));
            if (o != null)
                return o.Share;
            return 0;
        }

        public void ChangeShare (Owner o, double newValue)
        {
            if (this.Owners.Count <= 1)
                goto End;
            double diff = 0.0;
            if (newValue <= 0)
            {
                o.Person.PropertyLists.Remove(this);
                this.Owners.Remove(o);
                diff = o.Share / this.Owners.Count;
            } else
            {
                diff = (o.Share - (newValue <= 0 ? 0 : newValue)) / (this.Owners.Count - 1);
                o.Share = newValue;
            }

            this.Owners.PreOrder((ow) =>
            {
                if (o.Person.ID != ow.Person.ID)
                    ow.Share += diff;
            });
            End:;
        }

        public Property FindProperty(Property property) => this.Properties.Find(property);

        public bool DeleteProperty(int ID)
        {
            Property property = new Property(ID);
            property = this.Properties.Find(property);
            property.Occupants.PreOrder((p) => p.Property = null);

            if (!this.CadastralArea.Properties.Remove(property))
                return false;
            return this.Properties.Remove(property);
        }

        public bool DeleteOwner(string personId)
        {
            int changed = this.Owners.Count;
            this.ChangeShare(this.Owners.Find(new Owner(new Person(personId))), 0);
            
            return changed > this.Owners.Count;
        }

        public override string ToString() => this.ID + "";

        public void Delete() => this.CadastralArea.PropertyLists.Remove(this); // remove from cadastral area

        public void Merge(PropertyList toDelete)
        {
            toDelete.Properties.PreOrder((p) => {
                p.PropertyList = this;
                this.Properties.Add(p);
            });

            this.Owners.PreOrder((o) => o.Share /= 2);
            Owner o2 = null;
            toDelete.Owners.PreOrder((o) => {
                o.Share /= 2;
                o2 = this.Owners.Find(o); // comparing person
                if (o2 == null)
                {
                    this.Owners.Add(o); // add new owner
                    o.Person.AddPropertyList(this); // add new property list to person
                }
                else
                    o2.Share += o.Share; // do nothing it is there
                o.Person.RemovePropertyList(toDelete); // remove old from person
            });
        }

        public static string GetCsvHeaders() => "ID;CadastralArea";

        public string ToCSV() => String.Format("{0};{1}", this.ID, this.CadastralArea.ID);
    }
}
