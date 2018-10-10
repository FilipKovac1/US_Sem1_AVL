using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVLTree;
using US_Sem1_AVL.Model;

namespace US_Sem1_AVL
{
    static class Program
    {
        private static AVLTree<Kniha> Tree;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Tree = new AVLTree<Kniha>();
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int repl = 0;
            while (repl < 5000000)
            {
                Tree.Insert(new Kniha(r.Next(1, Int32.MaxValue), "")); // be careful because without generate ID it's way faster (5mil 50s)
                repl++;
            }
            //Tree.Insert(new Kniha(1, "Filip Kovac"));
            //Tree.Insert(new Kniha(100, "Laco Borbely"));
            //Tree.Insert(new Kniha(6, "Ignac Vseved"));
            //Tree.Insert(new Kniha(4, "Preco Dalsie Meno"));
            //Tree.Insert(new Kniha(120, "AAAAA"));
            //Tree.Insert(new Kniha(2, "BBBBB"));
            //Tree.Insert(new Kniha(3, "BBBBB"));
            //Tree.Insert(new Kniha(5, "BBBBB"));
            //Tree.Insert(new Kniha(7, "BBBBB"));
            //Tree.Insert(new Kniha(11, "BBBBB"));
            //Tree.Insert(new Kniha(80, "BBBBB"));
            //Tree.Insert(new Kniha(99, "BBBBB"));
            //Tree.Insert(new Kniha(110, "BBBBB"));
            //Tree.Insert(new Kniha(130, "BBBBB"));
            //Tree.Insert(new Kniha(8, "BBBBB"));
            //Tree.Insert(new Kniha(9, "BBBBB"));
            //Tree.Insert(new Kniha(22, "BBBBB"));
            //Tree.Insert(new Kniha(10, "BBBBB"));
            //Tree.Insert(new Kniha(115, "Toto mi najdi"));
            //Tree.Insert(new Kniha(13, "BBBBB"));
            //Tree.Insert(new Kniha(12, "BBBBB"));
            //Tree.Insert(new Kniha(55, "BBBBB"));
            //Tree.Insert(new Kniha(66, "BBBBB"));
            //Tree.Insert(new Kniha(44, "Toto by malo byt viac schovane"));
            //Tree.Insert(new Kniha(33, "BBBBB"));
            //Tree.Insert(new Kniha(14, "BBBBB"));
            //Tree.Insert(new Kniha(15, "BBBBB"));
            //Tree.Insert(new Kniha(16, "BBBBB"));
            //Tree.Insert(new Kniha(17, "BBBBB"));
            //Tree.Insert(new Kniha(18, "BBBBB"));
            //Tree.Insert(new Kniha(19, "BBBBB"));
            //Tree.Insert(new Kniha(20, "BBBBB"));
            //Tree.Insert(new Kniha(21, "BBBBB"));
            //Tree.Insert(new Kniha(23, "BBBBB"));
            //Tree.Insert(new Kniha(24, "BBBBB"));

            Console.WriteLine(Tree.ToString());
        }
    }
}
