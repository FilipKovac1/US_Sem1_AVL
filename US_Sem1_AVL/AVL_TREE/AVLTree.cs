using System;
using System.Collections;
using System.Collections.Generic;

namespace AVLTree
{
    class AVLTree <T> where T : INode<T>
    {

        private Node<T> Root { get; set; }
        private int Count { get; set; }

        public AVLTree ()
        {
            this.Root = null;
            this.Count = 0;
        }

        /// <summary>
        /// n -> nuber of items in the tree
        /// O(log n)
        /// </summary>
        /// <param name="Data"></param>
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
        /// Insert of Generic class to tree using loop
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Insert (T Data)
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
                        goto end;
                }
            }
            afterInsert:;

            this.UpdateHeight(act);
            act = act.Parent;

            int Balance = 0, BalanceL = 0, BalanceR = 0;

            while (act != null) // go throught parent until root to check balance of changed tree and make rotation if necessary
            {
                this.UpdateHeight(act); // update height of actual node
                Balance = this.GetBalance(act);
                BalanceL = this.GetBalance(act.Left);
                BalanceR = this.GetBalance(act.Right);

                if (Balance == 0)
                    goto end;

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
            end:;

            return true;
        }

        public bool Delete (T Data)
        {
            if (this.Root == null)
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
                if (act.Parent == null) // it was root
                    this.Root = child;
                else
                {
                    this.SetParentChild(act, child, Data);
                    this.SetParent(act, act.Parent);
                }

                if (child != null) 
                    act = child;
            }
            else 
            {
                Node<T> minChild = this.FindLeftLeaf(act.Right);

                act.Data = minChild.Data;
                this.SetParentChild(minChild, null, minChild.Data);
                act = minChild.Parent;
            }

            int Balance = 0, BalanceL = 0, BalanceR = 0;

            while (act != null)
            {
                this.UpdateHeight(act);
                Balance = this.GetBalance(act);
                BalanceL = this.GetBalance(act.Left);
                BalanceR = this.GetBalance(act.Right);

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

            this.Count--;
            return true;
        }

        private Node<T> FindLeftLeaf(Node<T> Node)
        {
            while (Node.Left != null)
                Node = Node.Left;
            return Node;
        }
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
    }
}
