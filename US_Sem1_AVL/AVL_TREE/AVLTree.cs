namespace AVLTree
{
    class AVLTree <T> where T : INode<T>
    {

        public Node<T> Root { get; set; }

        public AVLTree ()
        {
            this.Root = null;
        }

        public bool Insert (T Data)
        {
            if (this.Root == null) { // if root is null parent does not matter
                this.Root = this.Insert2(null, Data);
                return true;
            }

            this.Root = this.Insert2(this.Root, Data);
            return true;
        }

        private Node<T> Insert2 (Node<T> Node, T Data)
        {
            if (Node == null)
                return new Node<T>(Data);

            switch (Node.Data.CompareTo(Data))
            {
                case 1:
                    if (Node.Right == null)
                        Node.Right = new Node<T>(Data, Node);
                    else
                        this.Insert2(Node.Right, Data);
                    Node.Balance += 1; 
                    break;
                case -1:
                    if (Node.Left == null)
                        Node.Left = new Node<T>(Data, Node);
                    else
                        Node.Left = this.Insert2(Node.Left, Data);
                    Node.Balance -= 1;
                    break;
                case 0:
                    return Node;
            }

            if (Node.Balance == 0)
                return Node;

            // LL rotation
            if (Node.Balance > 0 && Node.GetBalance(false) > 0)
            {
                Node<T> ret = LeftRotation(Node);
                if (ret.Parent != null)
                    ret.Parent.Right = ret;
            }

            // RR rotation 
            if (Node.Balance < 0 && Node.GetBalance(true) < 0)
            {
                Node<T> ret = RightRotation(Node);
                if (ret.Parent != null)
                    ret.Parent.Left = ret;
            }

            // LR rotation
            if (Node.Balance < 0 && Node.GetBalance(true) > 0)
            {
                Node.Left = this.LeftRotation(Node.Left);
                Node<T> ret = RightRotation(Node);
                if (ret.Parent != null)
                    ret.Parent.Left = ret;
                return ret;
            }

            // RL rotation
            if (Node.Balance > 0 && Node.GetBalance(false) < 0)
            {
                Node.Right = this.RightRotation(Node.Right);
                Node<T> ret = LeftRotation(Node);
                if (ret.Parent != null)
                    ret.Parent.Right = ret;
                return ret;
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
            Node.SetBalance();
            Right.SetBalance();

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
            Node.SetBalance();
            Left.SetBalance();

            // Return new parent
            return Left;
        }

        public override string ToString()
        {
            if (this.Root == null)
                return "Empty tree";

            return this.Vypis(this.Root);
        }

        private string Vypis (Node<T> Node)
        {
            string ret = Node.Data.ToString() + " -> ";
            if (Node.Left != null)
                ret += "L:" + this.Vypis(Node.Left);
            if (Node.Right != null)
                ret += "R:" + this.Vypis(Node.Right);

            return ret;
        }
    }
}
