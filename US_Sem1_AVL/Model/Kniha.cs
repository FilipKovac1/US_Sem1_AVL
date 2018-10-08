using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVLTree;

namespace US_Sem1_AVL.Model
{
    class Kniha : INode<Kniha>
    {
        public int ID { get; } 
        public string Name { get; set; }

        public Kniha (int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public int CompareTo(INode<Kniha> Node)
        {
            Kniha kniha = (Kniha) Node;

            return kniha.ID > this.ID ? 1 : (kniha.ID < this.ID ? -1 : 0);
        }

        public override string ToString()
        {
            return this.ID + "";
        }
    }
}
