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

            while (true)
            {
                // TODO insert and balance
                break;
            }

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

            // Make rotaion
            Node.Right = Right.Left;
            Right.Left = Node;
            Right.Parent = Node.Parent;
            Node.Parent = Right;

            // Update balance 
            this.UpdateHeight(Node);
            this.UpdateHeight(Right);

            // Return new parent
            return Right;
        }

        private Node<T> RightRotation (Node<T> Node)
        {
            Node<T> Left = Node.Left;

            // Make rotaion
            Node.Left = Left.Right;
            Left.Right = Node;
            Left.Parent = Node.Parent;
            Node.Parent = Left;

            // Update balance 
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
