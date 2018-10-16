using AVLTree;
using Static;

namespace Model
{
    class PropertyList : INode<PropertyList>
    {
        public int ID { get; set; } // unique for cadastral area
        public CadastralArea CadastralArea { get; set; } 
        public AVLTree<Property> Properties { get; set; } // properties on property list with owners and shares

        public int CompareTo(INode<PropertyList> Node)
        {
            PropertyList p = (PropertyList)Node;
            return Compare.IntC(this.ID, p.ID);
        }
    }
}
