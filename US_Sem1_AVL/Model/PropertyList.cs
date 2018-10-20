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

        public List<Owner> Owners { get; set; } // who owns this property (share percentage is in Share list)

        public PropertyList(int ID) { this.ID = ID; this.Properties = new AVLTree<Property>(); this.Owners = new List<Owner>(5); }

        public PropertyList(int ID, CadastralArea c) : this(ID) => this.CadastralArea = c; 

        public PropertyList (int ID, CadastralArea c, AVLTree<Property> Properties, List<Owner> Owners) : this(ID, c)
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
            foreach (Owner o in Owners)
                sum += o.Share;
            if (sum != 1)
                return false;
            return true;
        }

        public bool AddOwner (Person p, double share)
        {
            if (p == null)
                return false;
            if (Owners.Count == 0)
                share = 1;
            else
            {
                double minusShare = share / (double)Owners.Count;
                foreach (Owner o in Owners)
                    o.Share -= minusShare;
            }
            this.Owners.Add(new Owner(p, share));
            p.PropertyLists.Insert(this);
            return this.CheckShares();
        }

        public bool AddProperty (Property p)
        {
            if (p == null)
                return false;
            this.CadastralArea.Properties.Insert(p);
            return this.Properties.Insert(p);
        }

        public double GetOwnersShare(Person person)
        {
            Owner o = this.Owners.Where(w => w.Person.ID == person.ID).FirstOrDefault();
            if (o != null)
                return o.Share;
            return 0;
        }
    }
}
