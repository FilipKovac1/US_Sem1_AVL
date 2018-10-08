using System;
namespace AVLTree
{
    interface INode<T> where T : INode<T>
    {
        int CompareTo(INode<T> Node);
    }
}
