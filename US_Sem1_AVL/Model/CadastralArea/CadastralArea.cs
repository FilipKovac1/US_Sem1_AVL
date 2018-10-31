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

        /// <summary>
        /// Add property list to this cadastral area and also all properties that are linked to property list are added to this cadastral area
        /// O(log pl + prop * log prop2) -> pl count of property lists in this area, prop count of properties in added property list, prop2 count of property in this area
        /// if (newID)
        ///     O(log pl + prop * (log prop2 + log prop2))
        /// </summary>
        /// <param name="p">PropertyList to add</param>
        /// <param name="newID">if is neccessary to set new id of property, if yes, new id is set as highest value in the tree + 1</param>
        /// <returns></returns>
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

        /// <summary>
        /// Find property list in this area
        /// </summary>
        /// <param name="text">ID of property list as string</param>
        /// <returns></returns>
        public PropertyList FindPropertyList(string text)
        {
            if (!Int32.TryParse(text, out int search))
                return default(PropertyList);

            return this.PropertyLists.Find(new PropertyList(search));
        }

        /// <summary>
        /// Find property in this arae
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Property FindProperty (string text)
        {
            if (!Int32.TryParse(text, out int search))
                return default(Property);

            return this.Properties.Find(new Property(search));
        }

        /// <summary>
        /// Merge two cadastral areas
        /// </summary>
        /// <param name="c"></param>
        public void Merge(CadastralArea c)
        {
            c.PropertyLists.PreOrder((propertyList) =>
            {
                propertyList.ID = this.PropertyLists.Last().ID + 1;
                this.AddPropertyList(propertyList, true);
            });
        }

        public static string GetCsvHeaders() => "ID;Name";

        public string ToCSV() => String.Format("{0};{1}", this.ID, this.Name);
    }
}
