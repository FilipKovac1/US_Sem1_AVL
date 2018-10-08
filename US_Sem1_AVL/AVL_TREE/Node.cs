namespace AVLTree
{
    class Node<T> where T : INode<T>
    {
        public int Balance { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Data { get; set; }

        public Node (T Data) : this(Data, null)
        {
        }
        public Node (T Data, Node<T> Parent)
        {
            this.Parent = Parent;
            this.Left = null;
            this.Right = null;
            this.Balance = 0;
            this.Data = Data;
        }

        public void SetBalance ()
        {
            this.Balance = 0;
            if (this.Left != null)
                this.Balance = this.Left.Balance - 1;
            if (this.Right != null)
                this.Balance += this.Right.Balance + 1;
            if (this.Parent != null)
                this.Parent.SetBalance();
        }

        public int GetBalance (bool left)
        {
            if (left && this.Left != null)
                return this.Left.Balance;
            else if (!left && this.Right != null)
                return this.Right.Balance;
            return 0;
        }
    }
}
