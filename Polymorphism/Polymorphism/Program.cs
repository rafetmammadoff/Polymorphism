using Polymorphism.Exceptions;
using System;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library Kitabxana =new Library();
            string option=null;
            do
            {
                Selection(out option);

                switch (option)
                {
                    case "1":
                        Product newBook= CreateNewBook();
                        Kitabxana.AddProduct(newBook);
                        break;
                    case "2":
                        Product newJurnal = CreateNewJournall();
                        Kitabxana.AddProduct(newJurnal);
                        break;
                    case "3":
                        ShowBooksCount(Kitabxana);
                        break;
                    case "4":
                        ShowJournalCount(Kitabxana);
                        break;
                    case "5":
                        ShowBooksOrJournal(Kitabxana);
                        break;
                    case "6":
                        ShowAllProductInfo(Kitabxana);
                        break;
                    default:
                        Console.WriteLine("Yanlis secim etdiniz");
                        break;
                }
            } while (option != "7");

            
        }
        static void Selection(out string option)
        {
            Console.WriteLine("   ");
            Console.WriteLine("Kitabxanaya xos geldiniz");
            Console.WriteLine("1-Kitab elave edin");
            Console.WriteLine("2-Jurnal elave edin");
            Console.WriteLine("3-Kitablarin sayina baxin");
            Console.WriteLine("4-Jurnallarin sayina baxin");
            Console.WriteLine("5-Kitab veya Jurnallari goruntule");
            Console.WriteLine("6-Butun mehsullarin melumatlarini goruntuleyin");
            Console.WriteLine("7-Cixis edin");
            option = Console.ReadLine();
            
        }

        static Product CreateNewBook()
        {
            Console.WriteLine("Kitabin adini daxil edin:");
            string name = Console.ReadLine();
            Console.WriteLine("Kitabin muellifini daxil edin");
            string author = Console.ReadLine();
            Console.WriteLine("Kitabin novunu daxil edin");
            string genre = Console.ReadLine();

            string priceStr;
            int price;
            do
            {
                Console.WriteLine("Kitabin qiymetini daxil edin");
                priceStr = Console.ReadLine();
            } while (!int.TryParse(priceStr, out price) || price < 0);
            Product book = new Book()
            {
                Name = name,
                Price = price,
                Author = author,
                Genre = genre
            };
            return book;
        }
        static Product CreateNewJournall()
        {
            Console.WriteLine("Jurnalin adini daxil edin:");
            string name = Console.ReadLine();
            Console.WriteLine("Jurnal sirketinin adini daxil edin");
            string company=Console.ReadLine();
            string priceStr;
            int price;
            do
            {
                Console.WriteLine("Jurnalin qiymetini daxil edin");
                priceStr = Console.ReadLine();
            } while (!int.TryParse(priceStr, out price) || price < 0);
            Product journal = new Journal()
            {
                Name = name,
                Price = price,
                Company=company
            };
            return journal;
        }
        static void ShowBooksCount(Library Kitabxana)
        {
            try
            {
                Console.WriteLine($"Kitablarin sayi--{Kitabxana.GetBooksCount()}");
            }
            catch (EmptyLibraryException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xata bas verdi");
            }
        }
        static void ShowJournalCount(Library Kitabxana)
        {
            try
            {
                Console.WriteLine($"Jurnallarin sayi--{Kitabxana.GetJournalsCount()}");
            }
            catch (EmptyLibraryException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi");
            }
        }
        static void ShowBooksOrJournal(Library kitabxana)
        {
            string isTrueStr;
            bool isTrue;
            do
            {
                Console.WriteLine("isTrue deyerini daxil edin(true-kitablari goruntule ; false-jurnallari goruntule)");
                isTrueStr = Console.ReadLine();
            } while (!bool.TryParse(isTrueStr, out isTrue));
            try
            {
                Console.WriteLine(kitabxana.GetProducts(isTrue));
            }
            catch (BookNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xata bas verdi");
            }
        }
        static void ShowAllProductInfo(Library kitabxana)
        {
            foreach (var item in kitabxana.products)
            {
                item.GetInfo();
            }
        }
    }
}
