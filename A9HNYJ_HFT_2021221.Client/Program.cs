using System;
using A9HNYJ_HFT_2021221.Data;
using A9HNYJ_HFT_2021221.Repository;
using A9HNYJ_HFT_2021221.Logic;
using ConsoleTools;
using System.Collections.Generic;
using System.Reflection;

namespace A9HNYJ_HFT_2021221.Endpoint
{
    /// <summary>
    /// Main program class, handles user interface, initialization.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// User interface and initialization.
        /// </summary>
        public static void Main()
        {
            BookStoreContext context = new BookStoreContext();
            BookRepository bookRepo = new (context);
            PublisherRepository pubRepo = new (context);
            AuthorRepository autRepo = new (context);
            UserLogic user = new (bookRepo, pubRepo, autRepo);
            AdminLogic admin = new (bookRepo, pubRepo, autRepo);
            SupplyManager supplyManager = new (bookRepo, pubRepo, autRepo);
            var supplymanagermenu = new ConsoleMenu()
                .Add("Könyv Hozzáadása", () => AddBookSupplyManager(supplyManager))
                .Add("Áru felvétele", () => AddSupply(supplyManager))
                .Add("Darabszám módosítása", () => ChangeSupply(supplyManager))
                .Add("Ár módosítása", () => ChangePrice(supplyManager))
                .Add("Vissza", ConsoleMenu.Close);
            var adminmenu = new ConsoleMenu()
                .Add("Elem módosítása", () => UpdateItem(admin))
                .Add("Könyv hozzáadása", () => AddBook(admin))
                .Add("Kiadó hozzáadása", () => AddPublisher(admin))
                .Add("Író hozzáadása", () => AddAuthor(admin))
                .Add("Kiadó törlése", () => DeletePublisher(admin))
                .Add("Író törlése", () => DeleteAuthor(admin))
                .Add("Könyv törlése", () => DeleteBook(admin))
                .Add("Vissza", ConsoleMenu.Close);
            var menu = new ConsoleMenu()
                .Add("Listázza az összes angol nyelvű könyvet angol szerzőktől ami 1990 után íródott és gyerekeknek való", () => EnglishBooksByEnglishAuthorsForKids(user))
                .Add("Listázza ki azokat a tételeket, amelyekből kevesebb mint 10 db áll rendelkezésre, és beszerezheőek 10 nap alatt", () => ListBooksWithLessThan10PcsWith10DayDelivery(user))
                .Add("Listázza, hogy az egyes íróknak hány kiadása érhető el", () => ListAllAuthorsNumberOfEditions(user))
                .Add("Listázza ki azokat a könyveket, amelyek új és antikvár kiadásban is elérhetőek", () => ListNewBooksWithOldEditions(user))
                .Add("Listázza ki azokat a könyveket, amelyek új és antikvár kiadásban is elérhetőek -- Async", () => ListNewBooksWithOldEditionsAsync(user))
                .Add("Listázza az összes angol nyelvű könyvet angol szerzőktől ami 1990 után íródott és gyerekeknek való -- Async", () => ListEnglishBookForKidsAsync(user))
                .Add("Listázza ki azokat a tételeket, amelyekből kevesebb mint 10 db áll rendelkezésre, és beszerezheőek 10 nap alatt -- Async", () => ListBooksWithLessThan10PcsWith10DayDeliveryAsync(user))
                .Add("Listázza, hogy az egyes íróknak hány kiadása érhető el -- Async", () => ListAllAuthorsHowManyEditionsAsync(user))
                .Add("Összes kiadó listázása", () => ListAllPublishers(user))
                .Add("Összes Író listárása", () => ListAllAuthors(user))
                .Add("Összes Könyv listázása", () => ListAllBooks(user))
                .Add("Admin funkciók", () => adminmenu.Show())
                .Add("Supply manager funkciók", () => supplymanagermenu.Show())
                .Add("Kilépés", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Calls query "ListNewBooksWithOldEditions" and outputs results to console.
        /// </summary>
        /// <param name="user"> UserLogic object. </param>
        public static void ListNewBooksWithOldEditions(UserLogic user)
        {
            var q = user.ListNewBooksWithOldEditions();
            int aut;
            int pub;
            string[] book;
            string resoult = string.Empty;
            foreach (var a in q)
            {
                aut = 0;
                pub = 0;
                book = a.ToString();
                if (int.TryParse(book[1], out aut))
                {
                    if (user.OneAuthor(aut) != null)
                    {
                        book[1] = user.OneAuthor(aut).AuthorName;
                    }
                }

                if (int.TryParse(book[2], out pub))
                {
                    if (user.OnePublisher(pub) != null)
                    {
                        book[2] = user.OnePublisher(pub).PublisherName;
                    }
                }

                foreach (var item in book)
                {
                    resoult += item + " || ";
                }

                Console.WriteLine(resoult);
                resoult = string.Empty;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Calls query "ListAllAuthorsHowManyEditions" and outputs results to console.
        /// </summary>
        /// <param name="user"> UserLogic object. </param>
        public static void ListAllAuthorsNumberOfEditions(UserLogic user)
        {
            var q = user.ListAllAuthorsHowManyEditions();
            foreach (var item in q)
            {
                Console.WriteLine(item.Name + "  ||  " + item.Editions);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Calls query "ListBooksWithLessThan10PcsWith10DayDelivery" and outputs results to console.
        /// </summary>
        /// <param name="user"> UserLogic object. </param>
        public static void ListBooksWithLessThan10PcsWith10DayDelivery(UserLogic user)
        {
            var q = user.ListBooksWithLessThan10PcsWith10DayDelivery();
            foreach (var item in q)
            {
                Console.WriteLine(item.Title + "  ||  " + item.Publisher + "  ||  " + item.Supply + "  ||  " + item.Days);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Calls query "ListEnglishBookForKids" and outputs results to console.
        /// </summary>
        /// <param name="user"> UserLogic object. </param>
        public static void EnglishBooksByEnglishAuthorsForKids(UserLogic user)
        {
            var q = user.ListEnglishBookForKids();
            int aut;
            int pub;
            string[] book;
            string resoult = string.Empty;
            foreach (var a in q)
            {
                aut = 0;
                pub = 0;
                book = a.ToString();
                if (int.TryParse(book[1], out aut))
                {
                    if (user.OneAuthor(aut) != null)
                    {
                        book[1] = user.OneAuthor(aut).AuthorName;
                    }
                }

                if (int.TryParse(book[2], out pub))
                {
                    if (user.OnePublisher(pub) != null)
                    {
                        book[2] = user.OnePublisher(pub).PublisherName;
                    }
                }

                foreach (var item in book)
                {
                    resoult += item + " || ";
                }

                Console.WriteLine(resoult);
                resoult = string.Empty;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Writes all books to console, and asks user to chose which item's price they whish to modify. Calls ChangePrice function whith chosen index and new price.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void ChangePrice(SupplyManager smen)
        {
            ListAllBooks(smen);
            Console.WriteLine("Kérem válasszon melyik termék árát szeretné módosítani");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg az új árat");
            int price = int.Parse(Console.ReadLine());
            smen.ChangePrice(index, price);
        }

        /// <summary>
        /// Writes all books to console, and asks user to chose which item's supply to add to. Calls AddSupply function to add value to current supply.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void AddSupply(SupplyManager smen)
        {
            ListAllBooks(smen);
            Console.WriteLine("Kérem válasszon melyik termék raktári darabszámát szeretné módosítani");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg mennyi darabbal szerené módosítani");
            int pcs = int.Parse(Console.ReadLine());
            smen.AddSupply(index, pcs);
        }

        /// <summary>
        /// Writes all books to console, and asks user to chose which item's supply change. Calls AddSupply function to change value of current supply.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void ChangeSupply(SupplyManager smen)
        {
            ListAllBooks(smen);
            Console.WriteLine("Kérem válasszon melyik termék raktári darabszámát szeretné módosítani");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg milyen értékre szeretné módosítani");
            int pcs = int.Parse(Console.ReadLine());
            smen.ChangeSupply(index, pcs);
        }

        /// <summary>
        /// Writes all authors and publishers and asks user values for a new book item. Calls AddBook function with the input values, and writes new item to console.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void AddBookSupplyManager(SupplyManager smen)
        {
            ListAllAuthors(smen);
            Console.WriteLine("Kérem adja meg az író nevét!");
            string author = Console.ReadLine();
            Console.Clear();
            ListAllPublishers(smen);
            Console.WriteLine("Kérem adja meg a kiadó nevét");
            string publisher = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Kérem adja meg a könyv nevét");
            string bookname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Kérem adja meg a könyv árát");
            int price = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Kérem adja meg a raktáron lévő darabszámot");
            int supply = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Kérem adja meg a kiadás évét");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(smen.AddBook(author, publisher, bookname, price, supply, year).ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// Asks user which table they wishes to modify items in. After calls UpdateBook, UpdateAuthor or UpdatePublisher function accordingly.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdateItem(AdminLogic admin)
        {
            Console.WriteLine("Kérem adja meg melyik táblán szeretne módosítást végezni");
            Console.WriteLine("1: Books  ||  2: Authors  ||  3: Publishers");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    UpdateBook(admin);
                    break;
                case 2:
                    UpdateAuthor(admin);
                    break;
                case 3:
                    UpdatePublisher(admin);
                    break;
            }
        }

        /// <summary>
        /// Writes all Book items to console, and asks which item to modify. Receaves input from user to what to modify book title and calls ChangeBookName function.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdateBook(AdminLogic admin)
        {
            ListAllBooks(admin);
            Console.WriteLine("Kerem valaszzon melyik könyv címén szeretne módosítani");
            int index = int.Parse(Console.ReadLine());
            if (admin.OneBook(index) != null)
            {
                Console.WriteLine("Kéram adja meg az új címet");
                admin.ChangeBookName(index, Console.ReadLine());
                Console.WriteLine("A kiválasztott elem:  " + admin.OneBook(index).ToString());
            }
            else
            {
                Console.WriteLine("Az elem nem létezik");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all Publisher items to console. User can choose which item to modify and which value. Asks user input for new value, then calls corresponding function accordingly.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdatePublisher(AdminLogic admin)
        {
            ListAllPublishers(admin);
            Console.WriteLine("Kerem valaszzon melyik elemet szeretne modositani!");
            int index = int.Parse(Console.ReadLine());
            if (admin.OnePublisher(index) != null)
            {
                Console.WriteLine("Melyik értéken szeretne módosítani?");
                Console.WriteLine("1: Név  ||  2: Kiadási nyelv  ||  3: Webcím  ||  4: Kiszállítási idő napokban  ||  5: Aktív-e még a kiadó");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Kérem adja meg az új nevet");
                        admin.ChangePublisherName(index, Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Kérem adja meg az új kiadási nyelvet");
                        admin.ChangePublisherLanguage(index, Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Kérem adja meg az új webcímet");
                        admin.ChangeWebsite(index, Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Kérem adja meg a kiszállítási időt napokban");
                        admin.ChangeDeliveryDays(index, int.Parse(Console.ReadLine()));
                        break;
                    case 5:
                        Console.WriteLine("Kérem adja meg az új értéket [igen-nem]");
                        string input2 = Console.ReadLine();
                        if (input2 == "igen")
                        {
                            admin.ChangePublisherIsActive(index, true);
                        }
                        else if (input2 == "nem")
                        {
                            admin.ChangePublisherIsActive(index, false);
                        }
                        else
                        {
                            Console.WriteLine("Hibás input");
                        }

                        break;
                }

                Console.WriteLine("Érték:  " + admin.OnePublisher(index).ToString());
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("A kiválasztott elem nem létezik");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all Author items to console. Asks user which item they wish to modify. Asks user which value they want to change. Then asks user the value to change to and then calls the corresponding logic function accortdingly.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdateAuthor(AdminLogic admin)
        {
            ListAllAuthors(admin);
            Console.WriteLine("Kérem válaszzon melyik elemte szeretné módosítani!");
            int index = int.Parse(Console.ReadLine());
            if (admin.OneAuthor(index) != null)
            {
                Console.WriteLine("Melyik értéken szeretne módosítani?");
                Console.WriteLine("1: Név  ||  2: Gyermekbarát tartalom  ||  3: Aktív-e még az író?");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Kérem adja meg a nevet, amire módosítani szeretne.");
                        admin.ChangeAuthorName(index, Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Kérem adja meg az új értéket [igen-nem]");
                        string input = Console.ReadLine();
                        if (input == "igen")
                        {
                            admin.ChangeForKidsAuthor(index, true);
                        }
                        else if (input == "nem")
                        {
                            admin.ChangeForKidsAuthor(index, false);
                        }
                        else
                        {
                            Console.WriteLine("Hibás input");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Kérem adja meg az új értéket [igen-nem]");
                        string input2 = Console.ReadLine();
                        if (input2 == "igen")
                        {
                            admin.ChangeIsActiveAuthor(index, true);
                        }
                        else if (input2 == "nem")
                        {
                            admin.ChangeIsActiveAuthor(index, false);
                        }
                        else
                        {
                            Console.WriteLine("Hibás input");
                        }

                        break;
                }

                Console.WriteLine("Érték:  " + admin.OneAuthor(index).ToString());
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("A kiválasztott elem nem létezik");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Asks user input to which to create from new author item. Calls AddAuthor function with given input.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void AddAuthor(AdminLogic admin)
        {
            Console.WriteLine("Kérem adja meg az író nevét!");
            string name = Console.ReadLine();
            Console.WriteLine("Kérem adja meg a születési évét");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg, az író anyanyelvét");
            string language = Console.ReadLine();
            Console.WriteLine("Kérem adja meg, hogy aktív-e az író [igen-nem]");
            string input = Console.ReadLine();
            bool isActive = false;
            if (input == "igen" || input == "nem")
            {
                if (input == "igen")
                {
                    isActive = true;
                }
                else if (input == "nem")
                {
                    isActive = false;
                }

                Console.WriteLine("Kérem adja meg, hogy gyermekbarát műveket ír-e az író [igen-nem]");
                input = Console.ReadLine();
                bool kidFriendly = false;
                if (input == "igen" || input == "nem")
                {
                    if (input == "igen")
                    {
                        isActive = true;
                    }
                    else if (input == "nem")
                    {
                        isActive = false;
                    }

                    admin.AddAuthor(name, year, isActive, language, kidFriendly);
                    Console.WriteLine("Író hozzáadva!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Writes all publisher items to console, then asks user which item to delete. Calls DeletePublisher funcion with chosen index, if item exists.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void DeletePublisher(AdminLogic admin)
        {
            Console.WriteLine("Kérem válasszon hányadik indexű elemet szeretné törölni");
            ListAllPublishers(admin);
            int index = int.Parse(Console.ReadLine());
            var p = admin.OnePublisher(index);
            if (p != null)
            {
                admin.DeletePublisher(index);
                Console.WriteLine(p.ToString() + "  " + "<---- elem törölve");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Elem nem létezik");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all author items to console, then asks user which item to delete. Calls DeleteAuthor funcion with chosen index, if item exists.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void DeleteAuthor(AdminLogic admin)
        {
            Console.WriteLine("Kérem válasszon hányadik indexű elemet szeretné törölni");
            ListAllAuthors(admin);
            int index = int.Parse(Console.ReadLine());
            var p = admin.OneAuthor(index);
            if (p != null)
            {
                admin.DeleteAuthor(index);
                Console.WriteLine(p.ToString() + "  " + "<---- elem törölve");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Elem nem létezik");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all book items to console, then asks user which item to delete. Calls DeleteBook funcion with chosen index, if item exists.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void DeleteBook(AdminLogic admin)
        {
            Console.WriteLine("Kérem válasszon hányadik indexű elemet szeretné törölni");
            ListAllBooks(admin);
            int index = int.Parse(Console.ReadLine());
            var p = admin.OneBook(index);
            if (p != null)
            {
                admin.DeleteBook(index);
                Console.WriteLine(p.ToString() + "  " + "<---- elem törölve");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Elem nem létezik");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all authors and publishers to console and asks user input for new book item. Calls AddBook function with given values.
        /// </summary>
        /// <param name="admin"> AdminLogic object.</param>
        public static void AddBook(AdminLogic admin)
        {
            ListAllAuthors(admin);
            Console.WriteLine("Kérem adja meg az író nevét!");
            string author = Console.ReadLine();
            Console.Clear();
            ListAllPublishers(admin);
            Console.WriteLine("Kérem adja meg a kiadó nevét");
            string publisher = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Kérem adja meg a könyv nevét");
            string bookname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Kérem adja meg a könyv árát");
            int price = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Kérem adja meg a raktáron lévő darabszámot");
            int supply = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Kérem adja meg a kiadás évét");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(admin.AddBook(author, publisher, bookname, price, supply, year).ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// Asks user input for new publisher item. Calls AddPublisher function with given values.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void AddPublisher(AdminLogic admin)
        {
            Console.WriteLine("Kérem adja meg a kiadó nevét!");
            string name = Console.ReadLine();
            Console.WriteLine("Kérem adja meg a kiadó nyelvét");
            string language = Console.ReadLine();
            Console.WriteLine("Kérem adja meg a kiadó webcímét");
            string web = Console.ReadLine();
            Console.WriteLine("Kérem adja meg hány nap alatt szállít ki a kiadó");
            int days = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem ajda meg, hogy aktív-e a kiadó [igen-nem]");
            string input = Console.ReadLine();
            bool isActive = false;
            if (input == "igen" || input == "nem")
            {
                if (input == "igen")
                {
                    isActive = true;
                }
                else if (input == "nem")
                {
                    isActive = false;
                }

                Console.WriteLine(admin.AddPublisher(name, language, web, days, isActive).ToString());
            }
            else
            {
                Console.WriteLine("Input rossz");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Writes all publisher items to console. Calls user.GetAllPublishers.
        /// </summary>
        /// <param name="user"> Userlogic object. </param>
        public static void ListAllPublishers(UserLogic user)
        {
            var p = user.GetAllPublishers();
            foreach (var item in p)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Writes all author items to console. Calls user.GetAllAuthors.
        /// </summary>
        /// <param name="user"> Userlogic object. </param>
        public static void ListAllAuthors(UserLogic user)
        {
            var a = user.GetAllAuthors();
            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Writes all book items to console. Calls user.GetAllBooks.
        /// </summary>
        /// <param name="user"> Userlogic object. </param>
        public static void ListAllBooks(UserLogic user)
        {
            var q = user.GetAllBooks();
            int aut;
            int pub;
            string[] book;
            string resoult = string.Empty;
            foreach (var a in q)
            {
                aut = 0;
                pub = 0;
                book = a.ToString();
                if (int.TryParse(book[1], out aut))
                {
                    if (user.OneAuthor(aut) != null)
                    {
                        book[1] = user.OneAuthor(aut).AuthorName;
                    }
                }

                if (int.TryParse(book[2], out pub))
                {
                    if (user.OnePublisher(pub) != null)
                    {
                        book[2] = user.OnePublisher(pub).PublisherName;
                    }
                }

                foreach (var item in book)
                {
                    resoult += item + " || ";
                }

                Console.WriteLine(resoult);
                resoult = string.Empty;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Runs Taks returned form Logic and outputs value.
        /// </summary>
        /// <param name="user"> UserLogic Object. </param>
        public static void ListEnglishBookForKidsAsync(UserLogic user)
        {
            var q = user.ListEnglishBookForKidsAsync().Result;
            int aut;
            int pub;
            string[] book;
            string resoult = string.Empty;
            foreach (var a in q)
            {
                aut = 0;
                pub = 0;
                book = a.ToString();
                if (int.TryParse(book[1], out aut))
                {
                    if (user.OneAuthor(aut) != null)
                    {
                        book[1] = user.OneAuthor(aut).AuthorName;
                    }
                }

                if (int.TryParse(book[2], out pub))
                {
                    if (user.OnePublisher(pub) != null)
                    {
                        book[2] = user.OnePublisher(pub).PublisherName;
                    }
                }

                foreach (var item in book)
                {
                    resoult += item + " || ";
                }

                Console.WriteLine(resoult);
                resoult = string.Empty;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Runs Taks returned form Logic and outputs value.
        /// </summary>
        /// <param name="user"> UserLogic Object. </param>
        public static void ListBooksWithLessThan10PcsWith10DayDeliveryAsync(UserLogic user)
        {
            var q = user.ListBooksWithLessThan10PcsWith10DayDeliveryAsync().Result;
            foreach (var item in q)
            {
                Console.WriteLine(item.Title + "  ||  " + item.Publisher + "  ||  " + item.Supply + "  ||  " + item.Days);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Runs Taks returned form Logic and outputs value.
        /// </summary>
        /// <param name="user"> UserLogic Object. </param>
        public static void ListAllAuthorsHowManyEditionsAsync(UserLogic user)
        {
            var q = user.ListAllAuthorsHowManyEditionsAsync().Result;
            foreach (var item in q)
            {
                Console.WriteLine(item.Name + "  ||  " + item.Editions);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Runs Taks returned form Logic and outputs value.
        /// </summary>
        /// <param name="user"> UserLogic Object. </param>
        public static void ListNewBooksWithOldEditionsAsync(UserLogic user)
        {
            var p = user.ListNewBooksWithOldEditionsAsync();
            var q = p.Result;
            int aut;
            int pub;
            string[] book;
            string resoult = string.Empty;
            foreach (var a in q)
            {
                aut = 0;
                pub = 0;
                book = a.ToString();
                if (int.TryParse(book[1], out aut))
                {
                    if (user.OneAuthor(aut) != null)
                    {
                        book[1] = user.OneAuthor(aut).AuthorName;
                    }
                }

                if (int.TryParse(book[2], out pub))
                {
                    if (user.OnePublisher(pub) != null)
                    {
                        book[2] = user.OnePublisher(pub).PublisherName;
                    }
                }

                foreach (var item in book)
                {
                    resoult += item + " || ";
                }

                Console.WriteLine(resoult);
                resoult = string.Empty;
            }

            Console.ReadLine();
        }
    }
}
