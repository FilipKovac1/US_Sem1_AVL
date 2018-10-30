using System;
using System.Linq;
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
            //if (this.TestStructure())
            //    Console.WriteLine("Vypni to uz ... nemusi to tu byt :D :D ");
            //else
            //    Console.WriteLine("False");
        }

        public MyProgram (bool Generate, int cadastralCount, int personsCount, int propertyListCount, int propertyCount) : this()
        {
            if (Generate)
            {
                Random personsR = new Random(100);
                Random cadR = new Random(101);
                for (int i = 0; i < personsCount; i++)
                    Persons.Add(new Person(personsR.Next(personsCount * 10).ToString()));
                CadastralArea c = null;
                PropertyList pl = null;
                Property p = null;
                for (int i = 0; i < cadastralCount; i++)
                {
                    c = new CadastralArea(cadR.Next(cadastralCount + 10));
                    if (CadastralAreasByID.Add(new CadastralAreaByID(c)))
                    {
                        CadastralAreasByName.Add(new CadastralAreaByName(c));
                        for (int j = 1; j <= propertyListCount; j++)
                        {
                            pl = new PropertyList(j, c);
                            if (c.AddPropertyList(pl))
                            {
                                pl.AddOwner(Persons.Find(), 1);
                                for (int k = 0; k < propertyCount; k++)
                                {
                                    p = new Property(c.Properties.Count, "Address" + (j + k), "Unknown", pl);
                                    p.AddOccupant(pl.Owners.GetRoot().Person);
                                    pl.AddProperty(p);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateCadastralArea(CadastralArea c, string oldName)
        {
            this.CadastralAreasByName.Remove(new CadastralAreaByName(new CadastralArea(0, oldName)));
            this.CadastralAreasByName.Add(new CadastralAreaByName(c));
        }

        public Person Find(Person data) => this.Persons.Find(data);
        public CadastralArea Find(CadastralAreaByID data)
        {
            CadastralAreaByID c = this.CadastralAreasByID.Find(data);
            return c?.CadastralArea;
        }
        public CadastralArea Find(CadastralAreaByName data)
        {
            CadastralAreaByName c = this.CadastralAreasByName.Find(data);
            return c?.CadastralArea;
        }

        public bool AddPerson(Person Person) => this.Persons.Add(Person);
        public bool AddCadastralArea(CadastralArea CadastralArea)
        {
            if (!this.CadastralAreasByID.Add(new CadastralAreaByID(CadastralArea)))
                return false;
            if (!this.CadastralAreasByName.Add(new CadastralAreaByName(CadastralArea)))
                return false;
            return true;
        }
        public bool AddPropertyList(PropertyList PropertyList)
        {
            PropertyList.Owners.PreOrder((o) => o.Person.AddPropertyList(PropertyList));       
            return PropertyList.CadastralArea.AddPropertyList(PropertyList);
        }

        public bool TestStructure ()
        {
            AVLTree<Person> test = new AVLTree<Person>();
            Random testR = new Random(100);
            int MaxValue = 100000;
            int ToDelete = 100;
            for (int i = 1; i <= MaxValue; i++)
                test.Add(new Person(testR.Next(MaxValue).ToString()));
            for (int i = 0; i < ToDelete; i++)
                test.Remove(test.Find()); // deletes random nodes from tree
            return test.TestAVL();
        }

        public void Merge(CadastralArea c, CadastralArea c2)
        {
            c2.Merge(c);
            this.CadastralAreasByID.Remove(new CadastralAreaByID(c)); // log n remove
            this.CadastralAreasByName.Remove(new CadastralAreaByName(c)); // log n remove
        }
        
        public void Merge(PropertyList toDelete, PropertyList toMerge)
        {
            toMerge.Merge(toDelete);
            toDelete.Delete();
        }
    }
}
