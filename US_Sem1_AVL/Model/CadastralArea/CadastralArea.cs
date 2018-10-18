using System;
using System.Collections.Generic;
using AVLTree;

namespace Model
{
    internal class CadastralArea
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public AVLTree<Property> Properties { get; set; }

        public CadastralArea (int ID, string Name = "Unkonwn")
        {
            this.ID = ID;
            this.Name = Name;
        }

        public override string ToString()
        {
            return String.Format("| {0} - {1} | ", this.ID, this.Name);
        }
    }
}
