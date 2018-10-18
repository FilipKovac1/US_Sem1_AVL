using System;
using AVLTree;
using Model;

namespace US_Sem1_AVL
{
    class MyProgram
    {

        private AVLTree<Person> Persons { get; set; }
        private AVLTree<CadastralAreaByID> CadastralAreasByID { get; set; }
        private AVLTree<CadastralAreaByName> CadastralAreasByName { get; set; }

        public MyProgram ()
        {
            this.Persons = new AVLTree<Person>();
            this.CadastralAreasByID = new AVLTree<CadastralAreaByID>();
            this.CadastralAreasByName = new AVLTree<CadastralAreaByName>();
        }

        public MyProgram (bool Generate, int cadastralCount, int personsCount, int propertyListCount, int propertyCount) : this()
        {
            if (Generate)
            {
                Random personsR = new Random(100);
                Random cadR = new Random(101);
                for (int i = 0; i < personsCount; i++)
                {
                    Persons.Insert(new Person(personsR.Next(personsCount * 10).ToString()));
                }
                CadastralArea c = null;
                for (int i = 0; i < cadastralCount; i++)
                {
                    c = new CadastralArea(cadR.Next(cadastralCount + 10));
                    CadastralAreasByID.Insert(new CadastralAreaByID(c));
                    CadastralAreasByName.Insert(new CadastralAreaByName(c));
                }
            } 
        }

        public bool AddPerson(Person Person) => this.Persons.Insert(Person);
        public bool AddCadastralArea(CadastralArea CadastralArea)
        {
            if (!this.CadastralAreasByID.Insert(new CadastralAreaByID(CadastralArea)))
                return false;
            if (!this.CadastralAreasByName.Insert(new CadastralAreaByName(CadastralArea)))
                return false;
            return true;
        }
    }
}
