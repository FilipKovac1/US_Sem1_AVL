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
            foreach (Owner o in Owners.PreOrder())
                sum += o.Share;
            if (sum != 1)
                return false;
            return true;
        }

        public bool AddOwner (Person p, double share = 1)
        {
            if (p == null || this.Owners.Find(new Owner(p)) != null) // if owner is already added
                return false;
            if (Owners.Count == 0)
                share = 1;
            else
            {
                double minusShare = share / (double)Owners.Count;
                foreach (Owner o in Owners.PreOrder())
                    o.Share -= minusShare;
            }
            this.Owners.Add(new Owner(p, share));
            p.AddPropertyList(this);
            return this.CheckShares();
        }

        public bool AddProperty (Property p)
        {
            if (p == null)
                return false;
            this.CadastralArea.Properties.Add(p);
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
            if (newValue <= 0)
            {
                o.Person.PropertyLists.Remove(this);
                this.Owners.Remove(o);
            }
            double diff = (o.Share - (newValue <= 0 ? 0 : newValue)) / (this.Owners.Count - 1);
            o.Share = newValue;

            foreach (Owner ow in this.Owners.PreOrder())
                if (o.Person.ID != ow.Person.ID)
                    ow.Share += diff;

            End:;
        } 
    }
}
