using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVLTree;
using Model;

namespace US_Sem1_AVL
{
    class MyProgram
    {

        public AVLTree<Person> Persons { get; set; }
        public AVLTree<CadastralAreaByID> CadastralAreasByID { get; set; }
        public AVLTree<CadastralAreaByName> CadastralAreasByName { get; set; }

        public MyProgram ()
        {
            this.Persons = new AVLTree<Person>();
            this.CadastralAreasByID = new AVLTree<CadastralAreaByID>();
            this.CadastralAreasByName = new AVLTree<CadastralAreaByName>();
        }

        public MyProgram (bool Generate) : this()
        {
            if (Generate)
            {
                Random personsR = new Random(100);
                Random cadR = new Random(101);
                for (int i = 0; i < 1000; i++)
                {
                    Persons.Insert(new Person(personsR.Next(1000000).ToString()));
                }
                CadastralArea c = null;
                for (int i = 0; i < 100; i++)
                {
                    c = new CadastralArea(cadR.Next(10000));
                    CadastralAreasByID.Insert(new CadastralAreaByID(c));
                    CadastralAreasByName.Insert(new CadastralAreaByName(c));
                }
            } 
        }
    }
}
