namespace AVLTree
{
    class Node<T> where T : INode<T>
    {
        public int Height { get; set; }
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
            this.Data = Data;
            this.Height = 1;
        }

        public override string ToString() => this.Data.ToString();

        public bool HasChild() => this.Left != null && this.Right != null;
        public int CompareTo(Node<T> Node) => this.Data.CompareTo(Node.Data);
    }
}
