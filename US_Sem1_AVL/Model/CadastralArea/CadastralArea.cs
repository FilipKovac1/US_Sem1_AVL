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

        public bool AddPropertyList(PropertyList p, bool newID = false)
        {
            bool ret = this.PropertyLists.Add(p);
            p.Properties.PreOrder((property) =>
            {
                if (newID)
                    property.ID = this.Properties.Last().ID + 1; // unique ID because of duplicates
                this.Properties.Add(property);
            });
            return ret;
        }

        public override string ToString()
        {
            return String.Format("| {0} - {1} | ", this.ID, this.Name);
        }

        public PropertyList FindPropertyList(string text)
        {
            if (!Int32.TryParse(text, out int search))
                return default(PropertyList);

            return this.PropertyLists.Find(new PropertyList(search));
        }

        public Property FindProperty (string text)
        {
            if (!Int32.TryParse(text, out int search))
                return default(Property);

            return this.Properties.Find(new Property(search));
        }

        public void Merge(CadastralArea c)
        {
            c.PropertyLists.PreOrder((propertyList) =>
            {
                propertyList.ID = this.PropertyLists.Last().ID + 1;
                this.AddPropertyList(propertyList, true);
            });
        }
    }
}
