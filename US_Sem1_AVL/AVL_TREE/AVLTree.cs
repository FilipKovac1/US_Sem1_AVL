﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AVLTree
{
    class AVLTree <T> where T : INode<T>
    {

        private Node<T> Root { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Only for test purposes
        /// </summary>
        private Random RandomH = new Random();
        /// <summary>
        /// Only for test purposes
        /// </summary>
        private Random RandomS = new Random();

        public delegate void Iterate(T Data);
        private delegate void IterateThis(Node<T> Node);

        public AVLTree ()
        {
            this.Root = null;
            this.Count = 0;
        }

        /// <summary>
        /// Find item in the tree, if did not find anything return null
        /// n -> nuber of items in the tree
        /// O(log n)
        /// </summary>
        /// <param name="Data">object to find</param>
        /// <returns></returns>
        public T Find(T Data)
        {
            if (this.Root == null)
                return default(T);

            Node<T> act = this.Root;

            while (act.Data.CompareTo(Data) != 0)
            {
                if (act.Data.CompareTo(Data) < 0) {
                    if (act.Left != null)
                        act = act.Left;
                    else
                        break;
                } else {
                    if (act.Right != null)
                        act = act.Right;
                    else
                        break;
                }
            }

            return act.Data.CompareTo(Data) == 0 ? act.Data : default(T);
        }

        /// <summary>
        /// Returns the lowest object
        /// </summary>
        /// <returns></returns>
        public T First()
        {
            if (this.Root == null)
                return default(T);
            return FindLeftLeaf(this.Root, out int steps).Data;
        }

        /// <summary>
        /// Returns the highest object
        /// </summary>
        /// <returns></returns>
        public T Last()
        {
            if (this.Root == null)
                return default(T);
            Node<T> root = this.Root;
            while (true)
            {
                if (root.Right != null)
                    root = root.Right;
                else if (root.Left != null)
                    root = root.Left;
                else
                    return root.Data;
            }
        }

        /// <summary>
        /// Insert of Generic class to tree using loop
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Add (T Data)
        {
            if (this.Root == null) { // if root is null parent does not matter
                this.Root = new Node<T>(Data);
                this.Count++;
                return true;
            }

            Node<T> act = this.Root;
            Node<T> newNode = new Node<T>(Data);

            while (true)
            {
                // TODO insert and balance
                switch (act.Data.CompareTo(Data))
                {
                    case 1:
                        if (act.Right == null)
                        {
                            newNode.Parent = act;
                            act.Right = newNode;
                            this.Count++;
                            goto afterInsert;
                        }
                        else
                            act = act.Right;
                        break;
                    case -1:
                        if (act.Left == null)
                        {
                            newNode.Parent = act;
                            act.Left = newNode;
                            this.Count++;
                            goto afterInsert;
                        }
                        else
                            act = act.Left;
                        break;
                    case 0:
                        return false;
                }
            }
            afterInsert:;
            bool updateHeight = !act.HasChild();
            if (updateHeight)
                this.UpdateHeight(act);
            act = act.Parent;

            int Balance = 0, BalanceL = 0, BalanceR = 0;

            while (act != null) // go throught parent until root to check balance of changed tree and make rotation if necessary
            {
                if (updateHeight)
                    this.UpdateHeight(act); // update height of actual node
                Balance = this.GetBalance(act);
                BalanceL = this.GetBalance(act.Left);
                BalanceR = this.GetBalance(act.Right);

                if (Balance == 0)
                    break;

                // LL rotation
                if (Balance > 1 && BalanceR > 0)
                    act = LeftRotation(act);

                // RR rotation 
                if (Balance < -1 && BalanceL < 0)
                    act = RightRotation(act);

                // LR rotation
                if (Balance < -1 && BalanceL > 0)
                {
                    act.Left = this.LeftRotation(act.Left);
                    act = RightRotation(act);
                }

                // RL rotation
                if (Balance > 1 && BalanceR < 0)
                {
                    act.Right = this.RightRotation(act.Right);
                    act = LeftRotation(act);
                }

                act = act.Parent;
            }

            return true;
        }

        /// <summary>
        /// Delete object from the structure
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Remove (T Data)
        {
            if (this.Root == null || Data == null)
                return false;

            Node<T> act = this.Root;
            while (act.Data.CompareTo(Data) != 0)
            {
                if (act.Data.CompareTo(Data) < 0)
                {
                    if (act.Left != null)
                        act = act.Left;
                    else
                        return false;
                }
                else
                {
                    if (act.Right != null)
                        act = act.Right;
                    else
                        return false;
                }
            }
            
            if (act.Right == null || act.Left == null) // if i removing leaf or with one child
            {
                Node<T> child = act.Right == null ? act.Left : act.Right;
                if (act.Parent == null)
                { // it was root
                    if (child != null)
                        child.Parent = null;
                    this.Root = child;
                } 
                else
                {
                    this.SetParentChild(act, child, Data); // parent of deleted node set new child
                    this.SetParent(act, act.Parent); // child of the deleted node set new parent
                    act = act.Parent;
                }
            }
            else 
            {
                Node<T> minChild = this.FindLeftLeaf(act.Right, out int steps);
                if (steps == 0)
                {
                    act.Data = minChild.Data;
                    act.Right = minChild.Right;
                    if (act.Right != null)
                        act.Right.Parent = act;
                }
                else
                {
                    Node<T> minParent = minChild.Parent;
                    act.Data = minChild.Data;

                    int oldBal = this.GetBalance(minParent);
                    minParent.Left = minChild.Right;
                    if (minChild.Right != null)
                        minChild.Right.Parent = minParent;
                    if (oldBal == 0)
                        goto Finish;
                    act = minParent;
                }
            }

            int Balance = 0, BalanceL = 0, BalanceR = 0;
            bool first = true;
            while (act != null)
            {
                if (first)
                    first = false;
                else if (this.GetBalance(act) == 0)
                    break;
                this.UpdateHeight(act);
                Balance = this.GetBalance(act);
                BalanceL = this.GetBalance(act.Left);
                BalanceR = this.GetBalance(act.Right);

                // LL rotation
                if (Balance > 1 && BalanceR >= 0)
                    act = LeftRotation(act);

                // RR rotation 
                if (Balance < -1 && BalanceL <= 0)
                    act = RightRotation(act);

                // LR rotation
                if (Balance < -1 && BalanceL > 0)
                {
                    act.Left = this.LeftRotation(act.Left);
                    act = RightRotation(act);
                }

                // RL rotation
                if (Balance > 1 && BalanceR < 0)
                {
                    act.Right = this.RightRotation(act.Right);
                    act = LeftRotation(act);
                }

                act = act.Parent;
            }
            Finish:;
            this.Count--;
            return true;
        }

        /// <summary>
        /// Find left leaft return the lowest left leaf of node from param
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="steps">height from node to found node</param>
        /// <returns></returns>
        private Node<T> FindLeftLeaf(Node<T> Node, out int steps)
        {
            steps = 0;
            while (Node.Left != null)
            {
                steps++;
                Node = Node.Left;
            }
            return Node;
        }
        /// <summary>
        /// Find left leaf while saving the path to the stack 
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="s"></param>
        /// <param name="x"></param>
        private void FindLeftLeaf(Node<T> Node, Stack s, int x = 1)
        {
            while (Node != null)
            {
                for (int i = 0; i < x; i++)
                    s.Push(Node);
                Node = Node.Left;
            }
        }
        private void SetParentChild (Node<T> act, Node<T> child, T Data)
        {
            if (act.Parent != null)
            {
                if (act.Parent.Right != null && act.Parent.Right.Data.CompareTo(Data) == 0) // set parents right and left
                    act.Parent.Right = child;
                else
                    act.Parent.Left = child;
            }
        } 
        private void SetParent (Node<T> Root, Node<T> NewRoot)
        {
            if (Root.Left != null)
                Root.Left.Parent = NewRoot;
            if (Root.Right != null)
                Root.Right.Parent = NewRoot;
        }
        /// <summary>
        /// Do not use // recursion methods should not be used here (stackOverFlow exception)
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        private Node<T> Insert2 (Node<T> Node, T Data)
        {
            if (Node == null)
                return new Node<T>(Data);

            switch (Node.Data.CompareTo(Data))
            {
                case 1:
                    Node.Right = this.Insert2(Node.Right, Data);
                    break;
                case -1:
                    Node.Left = this.Insert2(Node.Left, Data);
                    break;
                case 0:
                    return Node;
            }
            this.UpdateHeight(Node);

            int Balance = this.GetBalance(Node);
            int BalanceL = this.GetBalance(Node.Left);
            int BalanceR = this.GetBalance(Node.Right);
            if (Balance == 0 && BalanceL == 0 && BalanceR == 0)
                return Node;

            // LL rotation
            if (Balance > 1 && BalanceR > 0)
                return LeftRotation(Node);
        
            // RR rotation 
            if (Balance < -1 && BalanceL < 0)
                return RightRotation(Node);

            // LR rotation
            if (Balance < -1 && BalanceL > 0)
            {
                Node.Left = this.LeftRotation(Node.Left);
                return RightRotation(Node);
            }

            // RL rotation
            if (Balance > 1 && BalanceR < 0)
            {
                Node.Right = this.RightRotation(Node.Right);
                return LeftRotation(Node);
            }

            return Node;
        }

        private Node<T> LeftRotation (Node<T> Node)
        {
            Node<T> Right = Node.Right;

            // Make rotation
            Node.Right = Right.Left;        // move T2 under new parent
            if (Node.Right != null)
                Node.Right.Parent = Node;       // update parent of T2
            Right.Left = Node;              // update left child of new root
            Right.Parent = Node.Parent;     // update parent of new root
            Node.Parent = Right;            // update changed tree parent to new root

            if (Right.Parent == null)
                this.Root = Right;
            else
                this.SetParentChild(Right, Right, Node.Data);

            // Update heights 
            this.UpdateHeight(Node);
            this.UpdateHeight(Right);

            // Return new parent
            return Right;
        }

        private Node<T> RightRotation (Node<T> Node)
        {
            Node<T> Left = Node.Left;

            // Make rotation
            Node.Left = Left.Right;
            if (Node.Left != null)
                Node.Left.Parent = Node;
            Left.Right = Node;
            Left.Parent = Node.Parent;
            Node.Parent = Left;

            if (Left.Parent == null)
                this.Root = Left;
            else
                this.SetParentChild(Left, Left, Node.Data);

            // Update heihgts 
            this.UpdateHeight(Node);
            this.UpdateHeight(Left);

            // Return new parent
            return Left;
        }

        private int UpdateHeight(Node<T> Node) => Node.Height = Math.Max(this.Height(Node.Left), this.Height(Node.Right)) + 1;
        private int GetBalance(Node<T> Node) => Node == null ? 0 : this.Height(Node.Right) - this.Height(Node.Left);
        private int Height(Node<T> Node) => Node == null ? 0 : Node.Height;
        public string ToString(string type)
        {
            if (this.Root == null)
                return "Empty tree";
            switch (type)
            {
                case "PostOrder":
                    return this.PostOrder(this.Root);
                case "InOrder":
                    return this.InOrder(this.Root);
                default: // PreOrder
                    return this.PreOrder(this.Root);
            }
        }
        private string PostOrder(Node<T> Root)
        {
            Stack s = new Stack(this.Count);
            Node<T> act = Root;
            int count = 0;
            string ret = "";
            while (this.Count > count)
            {
                this.FindLeftLeaf(act, s, 2);
                if (s.Count == 0)
                    break;

                act = (Node<T>) s.Pop();
                if (s.Count > 0 && (Node<T>)s.Peek() == act)
                    act = act.Right;
                else {
                    ret += this.PrintNode(act);
                    act = null;
                }
            }
            return ret;
        }
        private string InOrder(Node<T> Root)
        {
            Stack s = new Stack(this.Count / 2);
            Node<T> act = Root; // start at root
            string ret = "";
            int count = 0;
            while (count < this.Count) // go through all items in the tree
            {
                this.FindLeftLeaf(act, s); // save path to from act to the left leaf into stack
                act = (Node<T>) s.Pop(); // get last added to print

                ret += PrintNode(act);
                count++;

                act = act.Right; // don't forget about right side
            }

            return ret;
        }
        private string PreOrder(Node<T> Node)
        {
            Stack s = new Stack(this.Count / 2);
            s.Push(Node);
            Node<T> act = null;
            string ret = "";
            int count = 0;
            while (count < this.Count) // go through all items in the tree
            {
                act = (Node<T>)s.Pop(); // get last added to print

                ret += PrintNode(act);
                count++;

                if (act.Right != null)
                    s.Push(act.Right);
                if (act.Left != null)
                    s.Push(act.Left);
            }

            return ret;

        }
        private string PreOrderRec (Node<T> Node)
        {
            string ret = Node.ToString() + " | ";
            if (Node.Left != null)
                ret += Node.ToString() + " L:" + this.PreOrder(Node.Left);
            if (Node.Right != null)
                ret += Node.ToString() + " R:" + this.PreOrder(Node.Right);

            return ret;
        }
        private string PrintNode (Node<T> Node) => (Node.Parent != null ? Node.Parent.ToString() + ":" : "") + Node.ToString() + " | ";
        /// <summary>
        /// return LinkedList of generic class post order
        /// </summary>
        /// <param name="iterate"></param>
        /// <returns></returns>
        public LinkedList<T> PostOrder(Iterate iterate = null)
        {
            LinkedList<T> ret = new LinkedList<T>();
            if (this.Root == null)
                return ret;
            Stack s = new Stack(this.Count);
            Node<T> act = this.Root;
            int count = 0;
            while (this.Count > count)
            {
                this.FindLeftLeaf(act, s, 2);
                if (s.Count == 0)
                    break;

                act = (Node<T>)s.Pop();
                if (s.Count > 0 && (Node<T>)s.Peek() == act)
                    act = act.Right;
                else
                {
                    ret.AddLast(act.Data);
                    iterate?.Invoke(act.Data);
                    act = null;
                }
            }
            return ret;
        }
        /// <summary>
        /// returns LinkedList of generic class in order
        /// </summary>
        /// <param name="iterate"></param>
        /// <returns></returns>
        public LinkedList<T> InOrder(Iterate iterate = null)
        {
            LinkedList<T> ret = new LinkedList<T>();
            if (this.Root == null)
                return ret;
            Stack s = new Stack(this.Count / 2);
            Node<T> act = Root; // start at root
            int count = 0;
            while (count < this.Count) // go through all items in the tree
            {
                this.FindLeftLeaf(act, s); // save path to from act to the left leaf into stack
                act = (Node<T>)s.Pop(); // get last added to print

                ret.AddLast(act.Data);
                iterate?.Invoke(act.Data);
                count++;

                act = act.Right; // don't forget about right side
            }

            return ret;
        }
        /// <summary>
        /// return LinkedList of generic class in pre order
        /// </summary>
        /// <param name="iterate"></param>
        /// <returns></returns>
        public LinkedList<T> PreOrder(Iterate iterate = null)
        {
            LinkedList<T> ret = new LinkedList<T>();
            if (this.Root == null)
                return ret;
            Stack s = new Stack(this.Count / 2 + 1); // cannot be more than half of the nodes in the stack
            Node<T> act = this.Root;
            s.Push(act);
            int count = 0;
            while (count < this.Count) // go through all items in the tree
            {
                act = (Node<T>)s.Pop(); // get last added to print

                ret.AddLast(act.Data);
                iterate?.Invoke(act.Data);

                count++;

                if (act.Right != null)
                    s.Push(act.Right);
                if (act.Left != null)
                    s.Push(act.Left);
            }

            return ret;

        }
        private LinkedList<Node<T>> PreOrderNode(IterateThis iterate = null)
        {
            LinkedList<Node<T>> ret = new LinkedList<Node<T>>();
            if (this.Root == null)
                return ret;
            Stack s = new Stack(this.Count / 2 + 1); // cannot be more than half of the nodes in the stack
            Node<T> act = this.Root;
            s.Push(act);
            int count = 0;
            while (count < this.Count) // go through all items in the tree
            {
                act = (Node<T>)s.Pop(); // get last added to print

                ret.AddLast(act);
                iterate?.Invoke(act);

                count++;

                if (act.Right != null)
                    s.Push(act.Right);
                if (act.Left != null)
                    s.Push(act.Left);
            }

            return ret;

        }
        /// <summary>
        /// Find random object in the structure
        /// </summary>
        /// <returns></returns>
        public T Find()
        {
            if (this.Root == null)
                return default(T);

            int steps = RandomH.Next(this.Count / 2 + 1);
            Node<T> act = this.Root;
            while (steps > 0)
            {
                steps--;
                if (!act.HasChild())
                    return act.Data;
                if (RandomS.NextDouble() < 0.5 || act.Right == null)
                    act = act.Left;
                else
                    act = act.Right;
            }
            return act.Data;
        }
        public T GetRoot() => Root == null ? default(T) : Root.Data;

        public bool TestAVL()
        {
            if (this.Root == null)
                return true;

            bool ret = true;
            this.PreOrderNode((node) => {
                this.UpdateHeight(node);
                if (!this.CheckAVL(node))
                    ret = false;
            });

            return ret;
        }

        private bool CheckAVL(Node<T> Node) => Math.Abs(this.Height(Node.Left) - this.Height(Node.Right)) <= 1;
    }
}
