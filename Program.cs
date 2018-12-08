using System;
using System.Collections.Generic;
using System.Linq;


namespace Internship_1_ContactBook
{
    class Program
        {
            static void Main(string[] args)
            {
                var myDictionary = new List<Tuple<string, string, string, int>>();
                int choice = 1;

                while (choice != 0)
                {

                    Console.WriteLine("Unesite radnju koju zelite izvrsiti");
                    Console.WriteLine("1-za dodavanje novog upisa");
                    Console.WriteLine("2-za promjenu imena,adrese ili broja");
                    Console.WriteLine("3-za brisanje upisa");
                    Console.WriteLine("4-za pretragu po imenu");
                    Console.WriteLine("5-za pretragu po broju");

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case '1':
                            Console.WriteLine("Upisite novog clana");
                            Console.WriteLine("Unesite ime ");
                            var name = Console.ReadLine();
                            Console.WriteLine("Unesite prezime");
                            var surename = Console.ReadLine();
                            Console.WriteLine("Unesite adresu");
                            var adress = Console.ReadLine();
                            Console.WriteLine("Unesite telefonski broj bez razmaka");
                            var number = int.Parse(Console.ReadLine());

                            myDictionary.Add(new Tuple<string, string, string, int>(name, surename, adress, number));
                            myDictionary.Sort(Comparer<Tuple<string, string, string, int>>.Default);
                            break;
                        case '2':
                            Console.WriteLine("Unesi sto zelis promijeniti (1-za ime,2-za broj,3-za adresu)");
                            var choiceForChanging = int.Parse(Console.ReadLine());
                            if (choiceForChanging == 1)
                            {
                                Console.WriteLine("Unesi ime koje zelis promijeniti");
                                var nameToChange = Console.ReadLine();
                                Console.WriteLine("Unesi ime u koje zelis promijeniti staro ime");
                                var changedName = Console.ReadLine();
                                var FindTuple = myDictionary.Find(s => s.Item1 == nameToChange);
                                if (FindTuple == null)
                                {
                                    Console.WriteLine("Ime ne postoji u adresaru");
                                }
                                else
                                {
                                    Console.WriteLine("{0},{1},{2},{3}", FindTuple.Item1.ToString(), FindTuple.Item2.ToString(), FindTuple.Item3.ToString(), FindTuple.Item4.ToString());
                                    Console.WriteLine("Je li ovo osoba kojoj želite mijenjati ime?\t 1-da,0-ne");

                                    var choice1 = int.Parse(Console.ReadLine());
                                    if (choice1 == 1)
                                    {
                                        myDictionary.Add(new Tuple<string, string, string, int>(changedName, FindTuple.Item2, FindTuple.Item3, FindTuple.Item4));
                                        myDictionary.Sort(Comparer<Tuple<string, string, string, int>>.Default);
                                        myDictionary.RemoveAll(item => item.Item1 == nameToChange);
                                    }
                                    else if (choice1 == 0)
                                        Console.WriteLine("Pokušaj ponovno");
                                    else
                                    {
                                        Console.WriteLine("Pogresan unos");

                                    }
                                }
                            }
                            else if (choiceForChanging == 2)
                            {
                                Console.WriteLine("Unesi broj koji zelis promijeniti");
                                var numberToChange = int.Parse(Console.ReadLine());
                                Console.WriteLine("Unesi broj u koji zelis promijeniti");
                                var changedNumber = int.Parse(Console.ReadLine());
                                var FindTuple = myDictionary.Find(i => i.Item4 == numberToChange);
                                if (FindTuple == null)
                                {
                                    Console.WriteLine("Broj ne postoji u adresaru");
                                }
                                else
                                {
                                    Console.WriteLine("{0},{1},{2},{3}", FindTuple.Item1.ToString(), FindTuple.Item2.ToString(), FindTuple.Item3.ToString(), FindTuple.Item4.ToString());
                                    Console.WriteLine("Je li ovo osoba kojoj želite promijeniti broj?\t 1-da,0-ne");

                                    var choice1 = int.Parse(Console.ReadLine());
                                    if (choice1 == 1)
                                    {
                                        myDictionary.Add(new Tuple<string, string, string, int>(FindTuple.Item1, FindTuple.Item2, FindTuple.Item3, changedNumber));
                                        myDictionary.Sort(Comparer<Tuple<string, string, string, int>>.Default);
                                        myDictionary.RemoveAll(item => item.Item4 == numberToChange);
                                    }
                                    else if (choice1 == 0)
                                        Console.WriteLine("Pokušaj ponovno");
                                    else
                                    {
                                        Console.WriteLine("Pogresan unos");

                                    }
                                }

                            }
                            else if (choiceForChanging == 3)
                            {
                                Console.WriteLine("Unesi adresu koju zelis promijeniti");
                                var adressToChange = Console.ReadLine();
                                Console.WriteLine("Unesi adresu u koju zelis promijeniti");
                                var changedAdress = Console.ReadLine();
                                var FindTuple = myDictionary.Find(s => s.Item3 == adressToChange);
                                if (FindTuple == null)
                                {
                                    Console.WriteLine("Adresa ne postoji u adresaru");
                                }
                                else
                                {
                                    Console.WriteLine("{0},{1},{2},{3}", FindTuple.Item1.ToString(), FindTuple.Item2.ToString(), FindTuple.Item3.ToString(), FindTuple.Item4.ToString());
                                    Console.WriteLine("Je li ovo osoba kojoj želite promijeniti adresu?\t 1-da,0-ne");

                                    var choice1 = int.Parse(Console.ReadLine());
                                    if (choice1 == 1)
                                    {
                                        myDictionary.Add(new Tuple<string, string, string, int>(FindTuple.Item1, FindTuple.Item2, changedAdress, FindTuple.Item4));
                                        myDictionary.Sort(Comparer<Tuple<string, string, string, int>>.Default);
                                        myDictionary.RemoveAll(item => item.Item1 == adressToChange);
                                    }
                                    else if (choice1 == 0)
                                        Console.WriteLine("Pokušaj ponovno");
                                    else
                                    {
                                        Console.WriteLine("Pogresan unos");

                                    }
                                }

                            }
                            break;
                        case '3':
                            Console.WriteLine("Po kojem kriteriju zelite pronaci člana kojeg zelite izbrisati?");
                            Console.WriteLine("1-po imenu");
                            Console.WriteLine("2-po adresi");
                            Console.WriteLine("3-po broju");

                            var choiceForDeleting = int.Parse(Console.ReadLine());

                            if (choiceForDeleting == 1)
                            {

                                Console.WriteLine("Unesi ime koje zelis izbrisati");
                                var nameToDelete = Console.ReadLine();

                                var findPerson = myDictionary.Find(s => s.Item1 == nameToDelete);
                                if (findPerson == null)
                                {
                                    Console.WriteLine("Osoba ne postoji u adresaru");
                                }
                                else
                                {
                                    Console.WriteLine("{0},{1},{2},{3}", findPerson.Item1.ToString(), findPerson.Item2.ToString(), findPerson.Item3.ToString(), findPerson.Item4.ToString());
                                    Console.WriteLine("Je li ovo osoba koju ste tražili?\t 1-da,0-ne");

                                    var choice1 = int.Parse(Console.ReadLine());
                                    if (choice1 == 1)
                                    {
                                        myDictionary.RemoveAll(item => item.Item1 == nameToDelete);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pogresan unos");
                                    }

                                }
                            }
                            else if (choiceForDeleting == 2)
                            {

                                Console.WriteLine("Unesite adresu clana kojeg zelite izbaciti");
                                var adressToDelete = Console.ReadLine();
                                var findPerson = myDictionary.Find(s => s.Item2 == adressToDelete);
                                if (findPerson== null)
                                {
                                    Console.WriteLine("Clan nije pronaden,pokusajte ponovo");
                                }

                                else
                                {

                                    Console.WriteLine("{0},{1},{2},{3}", findPerson.Item1.ToString(),findPerson.Item2.ToString(), findPerson.Item3.ToString(),findPerson.Item4.ToString());
                                    Console.WriteLine("Zelite li izbrisati ovu osobu? 1-da,0-ne");

                                    var choice1 = int.Parse(Console.ReadLine());
                                    if (choice1 == 1)
                                    {
                                        myDictionary.RemoveAll(item => item.Item3 == adressToDelete);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pogresan unos");

                                    }


                                }
                            }
                            else if (choiceForDeleting == 3)
                            {

                                Console.WriteLine("Unesite broj člana kojeg želite izbaciti");
                                var numberToDelete = int.Parse(Console.ReadLine());

                                var findPerson = myDictionary.Find(i => i.Item4 == numberToDelete);
                                if (findPerson== null)
                                {
                                    Console.WriteLine("Osoba ne postoji u adresaru");

                                }
                                else
                                {

                                    Console.WriteLine("{0},{1},{2},{3}", findPerson.Item1.ToString(), findPerson.Item2.ToString(), findPerson.Item3.ToString(), findPerson.Item4.ToString());
                                    Console.WriteLine("Je li ovo osoba koju ste tražili?\t 1-da,0-ne");

                                    var choice1 = int.Parse(Console.ReadLine());
                                    if (choice1 == 1)
                                    {
                                        myDictionary.RemoveAll(item => item.Item4 == numberToDelete);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pogresan unos");

                                    }

                                }
                            }
                            break;
                        case '4':
                            Console.WriteLine("Unesi ime koje zelis pronaci.");
                            var nameToFind = Console.ReadLine();

                            var findName = myDictionary.Find(s => s.Item1 == nameToFind);
                            if (findName == null)
                                Console.WriteLine("Osoba ne postoji u adresaru");
                            else
                            {
                                Console.WriteLine("Pronađena osoba:");
                                Console.WriteLine("{0},{1},{2},{3}", findName.Item1.ToString(), findName.Item2.ToString(), findName.Item3.ToString(), findName.Item4.ToString());
                            }
                            break;
                        case '5':
                            Console.WriteLine("Unesi broj osobe koje zelis pronaci");
                            var numberToFind = int.Parse(Console.ReadLine());

                            var findNumber = myDictionary.Find(i => i.Item4 == numberToFind);

                            /*  char[] delimiterChars = { ' ', ',', '.', ':','/','-','\t' };

                              var text = numberToFind;
                              System.Console.WriteLine($"Original text: '{text}'");

                              string[] words = text.Split(delimiterChars);
                              System.Console.WriteLine($"{words.Length} words in text:");

                              foreach (var word in words)
                              {
                                  System.Console.WriteLine($"<{word}>");
                              } */

                            if (findNumber == null)
                                Console.WriteLine("Taj broj ne postoji u adresaru");
                            else
                            {
                                Console.WriteLine("Pronadena osoba");
                                Console.WriteLine("{0},{1},{2},{3}", findNumber.Item1.ToString(), findNumber.Item2.ToString(), findNumber.Item3.ToString(), findNumber.Item4.ToString());

                            }
                            break;
                        case '0':
                        default:
                            Console.WriteLine("Krivi unos");
                            Console.WriteLine("Izlaz iz programa");
                            break;

                    }
                }

                Console.WriteLine("Ispis adresara:");

                foreach (var tuple in myDictionary)
                {
                    Console.WriteLine(" {0} \n {1} \n {2} \n {3}\n", tuple.Item1.ToString(), tuple.Item2.ToString(), tuple.Item3.ToString(), tuple.Item4.ToString());
                }
            }
        }
    }
