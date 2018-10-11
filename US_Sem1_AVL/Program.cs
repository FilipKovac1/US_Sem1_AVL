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
            while (repl < 100)
                Tree.Insert(new Kniha(repl++)); // be careful because without generate ID it's way faster (5mil 50s)

            Tree.Delete(new Kniha(50));
            Tree.Delete(new Kniha(25));
            Tree.Delete(new Kniha(75));

            Console.WriteLine(Tree.ToString());
        }
    }
}
