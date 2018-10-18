using System;
using System.Windows.Forms;

namespace US_Sem1_AVL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //AVLTree<CadastralAreaByID> t = new AVLTree<CadastralAreaByID>();
            //Random r = new Random(100);
            //for (int i = 0; i < 5000000; i++)
            //{
            //    t.Insert(new CadastralAreaByID(new CadastralArea(r.Next(int.MaxValue))));
            //}

            //Console.WriteLine(t.ToString());
        }
    }
}
