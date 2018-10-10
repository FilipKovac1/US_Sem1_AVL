using System;

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

            while (act != null) // go throught parent until root to check balance of changed tree and make rotation if necessary
            {
                this.UpdateHeight(act); // update height of actual node
                int Balance = this.GetBalance(act);
                int BalanceL = this.GetBalance(act.Left);
                int BalanceR = this.GetBalance(act.Right);

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

        /// <summary>
        /// Do not use // recurent methods should not be used here (stackOverFlow exception)
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
            else if (Right.Parent.Right != null && Right.Parent.Right.Data.CompareTo(Node.Data) == 0)
                Right.Parent.Right = Right;
            else
                Right.Parent.Left = Right;

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
            else if (Left.Parent.Left != null && Left.Parent.Left.Data.CompareTo(Node.Data) == 0)
                Left.Parent.Left = Left;
            else
                Left.Parent.Right = Left;

            // Update heihgts 
            this.UpdateHeight(Node);
            this.UpdateHeight(Left);

            // Return new parent
            return Left;
        }

        private int UpdateHeight(Node<T> Node) => Node.Height = Math.Max(this.Height(Node.Left), this.Height(Node.Right)) + 1;
        private int GetBalance(Node<T> Node) => Node == null ? 0 : this.Height(Node.Right) - this.Height(Node.Left);
        private int Height(Node<T> Node) => Node == null ? 0 : Node.Height;

        public override string ToString() => this.Root == null ? "Empty tree" : this.Vypis(this.Root);

        private string Vypis (Node<T> Node)
        {
            string ret = Node.Data.ToString() + " | ";
            if (Node.Left != null)
                ret += Node.Data.ToString() + " L:" + this.Vypis(Node.Left);
            if (Node.Right != null)
                ret += Node.Data.ToString() + " R:" + this.Vypis(Node.Right);

            return ret;
        }
    }
}
