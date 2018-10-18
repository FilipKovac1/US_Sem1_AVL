using System;
using System.Collections.Generic;
using AVLTree;
using Static;

namespace Model
{
    class CadastralAreaByID : INode<CadastralAreaByID>
    {
        public CadastralArea CadastralArea { get; set; }

        public CadastralAreaByID (CadastralArea c)
        {
            this.CadastralArea = c;
        }

        public int CompareTo(INode<CadastralAreaByID> Node)
        {
            CadastralAreaByID obj = (CadastralAreaByID)Node;
            return Compare.IntC(this.CadastralArea.ID, obj.CadastralArea.ID);
        }

        public override string ToString()
        {
            return this.CadastralArea.ID + "";
        }
    }
}