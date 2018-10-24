using System;
using AVLTree;

namespace Model
{
    class CadastralArea
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public AVLTree<Property> Properties { get; set; }
        public AVLTree<PropertyList> PropertyLists { get; set; }

        public CadastralArea (int ID, string Name = "Unknown")
        {
            this.ID = ID;
            this.Name = Name == "Unknown" ? Name + ID : Name;
            this.Properties = new AVLTree<Property>();
            this.PropertyLists = new AVLTree<PropertyList>();
        }

        public bool AddPropertyList(PropertyList p)
        {
            bool ret = this.PropertyLists.Insert(p);
            foreach(Property prop in p.Properties.PreOrder()) 
                this.Properties.Insert(prop);
            return ret;
        }

        public override string ToString()
        {
            return String.Format("| {0} - {1} | ", this.ID, this.Name);
        }

        internal PropertyList FindPropertyList(string text)
        {
            if (!Int32.TryParse(text, out int search))
                return default(PropertyList);

            return this.PropertyLists.Find(new PropertyList(search));
        }
    }
}
