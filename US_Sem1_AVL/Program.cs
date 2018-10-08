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
            Tree.Insert(new Kniha(1, "Filip Kovac"));
            Tree.Insert(new Kniha(100, "Laco Borbely"));
            Tree.Insert(new Kniha(6, "Ignac Vseved"));
            Tree.Insert(new Kniha(4, "Preco Dalsie Meno"));
            Tree.Insert(new Kniha(120, "AAAAA"));
            Tree.Insert(new Kniha(3, "BBBBB"));

            Console.WriteLine(Tree.ToString());
        }
    }
}
