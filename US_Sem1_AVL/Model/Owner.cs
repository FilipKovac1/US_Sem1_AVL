﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVLTree;

namespace Model
{
    class Owner : INode<Owner>
    {

        public Person Person { get; set; }
        public double Share { get; set; }

        public int CompareTo (INode<Owner> Node)
        {
            Owner o = (Owner)Node;
            return this.Person.CompareTo(o.Person);
        }
    }
}