using System;
using System.IO;
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

        public void ToCSV(string path)
        {
            using (StreamWriter writer = new StreamWriter(path + "\\persons.csv"))
            {
                writer.AutoFlush = true;
                writer.WriteLine(Person.GetCsvHeaders());
                this.Persons.PreOrder((p) => writer.WriteLine(p.ToCSV()));
            }

            using (StreamWriter writer = new StreamWriter(path + "\\cadastralAreas.csv"))
            {
                writer.AutoFlush = true;
                writer.WriteLine(CadastralArea.GetCsvHeaders());
                StreamWriter writerOwners = new StreamWriter(path + "\\owners.csv");
                writerOwners.AutoFlush = true;
                writerOwners.WriteLine(Owner.GetCsvHeaders());
                StreamWriter writerProperties = new StreamWriter(path + "\\properties.csv");
                writerProperties.AutoFlush = true;
                writerProperties.WriteLine(Property.GetCsvHeaders());
                StreamWriter writerOccupants = new StreamWriter(path + "\\occupants.csv");
                writerOccupants.AutoFlush = true;
                writerOccupants.WriteLine(Property.OccupantsCsvHeader());
                this.CadastralAreasByID.PreOrder((p) => {
                    writer.WriteLine(p.CadastralArea.ToCSV());
                    p.CadastralArea.PropertyLists.PreOrder((pl) =>
                    {
                        pl.Owners.PreOrder((o) => writerOwners.WriteLine(o.ToCSV(pl)));
                        pl.Properties.PreOrder((prop) =>
                        {
                            writerProperties.WriteLine(prop.ToCSV());
                            prop.Occupants.PreOrder((occ) => writerOccupants.WriteLine(prop.OccupantToCsv(occ)));
                        });
                    });
                });
            }
        }

        public void FromCSV (string path)
        {
            string[] line;
            using (StreamReader reader = new StreamReader(@path + "\\persons.csv"))
            {
                string Headers = reader.ReadLine();
                string[] bd;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(';');
                    bd = line[2].Split('-');
                    this.AddPerson(new Person(line[0], line[1], new DateTime(Int32.Parse(bd[0]), Int32.Parse(bd[1]), Int32.Parse(bd[2]))));
                }
            }

            using (StreamReader reader = new StreamReader(@path + "\\cadastralAreas.csv"))
            {
                string Headers = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(';');
                    this.AddCadastralArea(new CadastralArea(Int32.Parse(line[0]), line[1]));
                }
            }

            using (StreamReader reader = new StreamReader(@path + "\\owners.csv"))
            {
                string Headers = reader.ReadLine();
                CadastralArea ca;
                PropertyList pl;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(';');
                    ca = this.Find(new CadastralAreaByID(new CadastralArea(Int32.Parse(line[1]))));
                    pl = ca.FindPropertyList(line[2]); // check if exists
                    if (pl == null) // add if not
                    {
                        pl = new PropertyList(Int32.Parse(line[2]), ca);
                        ca.AddPropertyList(pl); 
                    }
                    pl.AddOwner(this.Find(new Person(line[0])), Double.Parse(line[3]), false);
                }
            }

            using (StreamReader reader = new StreamReader(@path + "\\properties.csv"))
            {
                string Headers = reader.ReadLine();
                PropertyList pl;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(';');
                    pl = this.Find(new CadastralAreaByID(new CadastralArea(Int32.Parse(line[3])))).FindPropertyList(line[4]);
                    pl.AddProperty(new Property(Int32.Parse(line[0]), line[1], line[2], pl));
                }
            }

            using (StreamReader reader = new StreamReader(@path + "\\occupants.csv"))
            {
                string Headers = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(';');
                    this.Find(new CadastralAreaByID(new CadastralArea(Int32.Parse(line[2])))).FindProperty(line[1]).AddOccupant(this.Find(new Person(line[0])));
                }
            }
        }
    }
}
