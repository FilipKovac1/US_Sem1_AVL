using System;
using System.Collections.Generic;
using AVLTree;
using Static;

namespace Model
{
    class CadastralAreaByName : INode<CadastralAreaByName>
    {
        public CadastralArea CadastralArea { get; set; }

        public CadastralAreaByName (CadastralArea c)
        {
            this.CadastralArea = c;
        }

        public override string ToString() => this.CadastralArea.Name;

        public int CompareTo(INode<CadastralAreaByName> Node)
        {
            CadastralAreaByName obj = (CadastralAreaByName)Node;
            return Compare.StringC(this.CadastralArea.Name, obj.CadastralArea.Name);
        }
    }
}