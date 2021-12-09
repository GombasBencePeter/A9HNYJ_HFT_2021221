using System;
using ConsoleTools;
using System.Collections.Generic;
using System.Reflection;
using A9HNYJ_HFT_2021221.Models;
using System.Linq;

namespace A9HNYJ_HFT_2021221.Client
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
            RestService rest = new RestService("http://localhost:37921");
            var supplymanagermenu = new ConsoleMenu()
                .Add("Add Book", () => AddBookSupplyManager(rest))
                .Add("Add Supply", () => AddSupply(rest))
                .Add("Change Supply", () => ChangeSupply(rest))
                .Add("Change Price", () => ChangePrice(rest))
                .Add("Back", ConsoleMenu.Close);
            var adminmenu = new ConsoleMenu()
                .Add("Modify item", () => UpdateItem(rest))
                .Add("Add Book", () => AddBook(rest))
                .Add("Add Publisher", () => AddPublisher(rest))
                .Add("Add Author", () => AddAuthor(rest))
                .Add("Delete Publisher", () => DeletePublisher(rest))
                .Add("Delete Author", () => DeleteAuthor(rest))
                .Add("Delete Book", () => DeleteBook(rest))
                .Add("Back", ConsoleMenu.Close);
            var menu = new ConsoleMenu()
                .Add("List all english books from 1990, where the author wrote kidfriendly books", () => EnglishBooksByEnglishAuthorsForKids(rest))
                .Add("List all items that hase less than 10 supply, and can be resupplied within 10 days.", () => ListBooksWithLessThan10PcsWith10DayDelivery(rest))
                .Add("List all authors and how many publications they have in our system.", () => ListAllAuthorsNumberOfEditions(rest))
                .Add("List all books, which has both old and new editions avaiable.", () => ListNewBooksWithOldEditions(rest))
                .Add("List all Publishers", () => ListAllPublishers(rest))
                .Add("List all Authors", () => ListAllAuthors(rest))
                .Add("List all  Books", () => ListAllBooks(rest))
                .Add("Admin functionalities", () => adminmenu.Show())
                .Add("Supply manager functionalioties", () => supplymanagermenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Calls query "ListNewBooksWithOldEditions" and outputs results to console.
        /// </summary>
        /// <param name="user"> UserLogic object. </param>
        public static void ListNewBooksWithOldEditions(RestService rest)
        {
            var q = rest.Get<Book>("user/book/withneweditions");
            foreach (var item in q)
            {
                Console.WriteLine(item.ToString()) ;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Calls query "ListAllAuthorsHowManyEditions" and outputs results to console.
        /// </summary>
        /// <param name="user"> UserLogic object. </param>
        public static void ListAllAuthorsNumberOfEditions(RestService rest)
        {
            var q = rest.Get<ListAllAuthorsEditionsReturnValue>("user/listauthorseditions");
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
        public static void ListBooksWithLessThan10PcsWith10DayDelivery(RestService rest)
        {
            var q = rest.Get<ListBooksWithLessThan10PcsReturnValue>("admin/book/booksWithLessThanTen");
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
        public static void EnglishBooksByEnglishAuthorsForKids(RestService rest)
        {
            var q = rest.Get<Book>("user/book/forkids");
            
            foreach (var a in q)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Writes all books to console, and asks user to chose which item's price they whish to modify. Calls ChangePrice function whith chosen index and new price.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void ChangePrice(RestService rest)
        {
            ListAllBooks(rest);
            Console.WriteLine("Please chose which item's price you want to modify");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Please give new price");
            int price = int.Parse(Console.ReadLine());
            Book q = rest.GetOne<Book>($"user/book/{index}");
            q.Price = price;
            rest.Put<Book>(q, "admin/book");
        }

        /// <summary>
        /// Writes all books to console, and asks user to chose which item's supply to add to. Calls AddSupply function to add value to current supply.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void AddSupply(RestService rest)
        {
            ListAllBooks(rest);
            Console.WriteLine("Please chose which item's supply count you want to modify");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Please add how many new pices you want to add to the supply");
            int pcs = int.Parse(Console.ReadLine());
            Book q = rest.GetOne<Book>($"user/book/{index}");
            q.Supply = q.Supply+pcs;
            rest.Put<Book>(q, "admin/book");
        }

        /// <summary>
        /// Writes all books to console, and asks user to chose which item's supply change. Calls AddSupply function to change value of current supply.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void ChangeSupply(RestService rest)
        {
            ListAllBooks(rest);
            Console.WriteLine("Please chose which item's supply count you want to modify");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Please add new supply count");
            int pcs = int.Parse(Console.ReadLine());
            Book q = rest.GetOne<Book>($"user/book/{index}");
            q.Supply = pcs;
            rest.Put<Book>(q, "admin/book");
        }

        /// <summary>
        /// Writes all authors and publishers and asks user values for a new book item. Calls AddBook function with the input values, and writes new item to console.
        /// </summary>
        /// <param name="smen"> SupplyManager object. </param>
        public static void AddBookSupplyManager(RestService rest)
        {
            ListAllAuthors(rest);
            Console.WriteLine("Please give the index of the author");
            int author = int.Parse(Console.ReadLine());
            author = rest.GetOne<Author>($"user/author/{author}").AuthorKey;
            Console.Clear();
            ListAllPublishers(rest);
            Console.WriteLine("Please give the index of the publisher");
            int publisher = int.Parse(Console.ReadLine());
            publisher = rest.GetOne<Publisher>($"user/publisher/{publisher}").PublisherID;
            Console.Clear();
            Console.WriteLine("Please give the name of the book");
            string bookname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please give the price of the book");
            int price = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("PLease give how many pieces there are in supply");
            int supply = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("PLease give year of release");
            int year = int.Parse(Console.ReadLine());
            rest.Post<Book>(new Book {
                AuthorID = author, 
                PublisherID = publisher, 
                Bookname = bookname, 
                Price = price, 
                Supply = supply, 
                Year = year 
            },"admin/book");
            Console.ReadLine();
        }

        /// <summary>
        /// Asks user which table they wishes to modify items in. After calls UpdateBook, UpdateAuthor or UpdatePublisher function accordingly.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdateItem(RestService rest)
        {
            Console.WriteLine("Please add which table you want to modify");
            Console.WriteLine("1: Books  ||  2: Authors  ||  3: Publishers");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    UpdateBook(rest);
                    break;
                case 2:
                    UpdateAuthor(rest);
                    break;
                case 3:
                    UpdatePublisher(rest);
                    break;
            }
        }

        /// <summary>
        /// Writes all Book items to console, and asks which item to modify. Receaves input from user to what to modify book title and calls ChangeBookName function.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdateBook(RestService rest)
        {
            ListAllBooks(rest);
            Console.WriteLine("Please chose which book you want to modify");
            int index = int.Parse(Console.ReadLine());
            var q = rest.GetOne<Book>($"user/book/{index}");
            if (q != null)
            {
                Console.WriteLine("Please chose which value to change");
                Console.WriteLine("1: Author || 2: Publisher || 3: Title || 4: Year");
                int inp = int.Parse(Console.ReadLine());
                switch (inp)
                {
                    case 1: 
                        ListAllAuthors(rest);
                        Console.WriteLine("Input number for new author");
                        int na = int.Parse(Console.ReadLine());
                        q.AuthorID = na;
                        rest.Put<Book>(q, "admin/book");
                        break;
                    case 2:
                        ListAllPublishers(rest);
                        Console.WriteLine("Input number for new publisher");
                        int np = int.Parse(Console.ReadLine());
                        q.PublisherID = np;
                        rest.Put<Book>(q, "admin/book");
                        break;
                    case 3:
                        Console.WriteLine("Input ne title");
                        string nt = Console.ReadLine();
                        q.Bookname = nt;
                        rest.Put<Book>(q, "admin/book");
                        break;
                    case 4:
                        Console.WriteLine("Input new release year");
                        int ny = int.Parse(Console.ReadLine());
                        q.Year = ny;
                        rest.Put<Book>(q, "admin/book");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No book with such id");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all Publisher items to console. User can choose which item to modify and which value. Asks user input for new value, then calls corresponding function accordingly.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdatePublisher(RestService rest)
        {
            ListAllPublishers(rest);
            Console.WriteLine("Chose which item you want to modify!");
            int index = int.Parse(Console.ReadLine());
            var q = rest.Get<Publisher>($"user/publisher/{index}").FirstOrDefault();
            if (q!= null)
            {
                Console.WriteLine("CHose wich value you want to modify");
                Console.WriteLine("1: Name  ||  2: Language  ||  3: Webpage  ||  4: Delivery days  ||  5: Aktive status");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please give new name");
                        q.PublisherName = Console.ReadLine();
                        rest.Put<Publisher>(q, "admin/publisher");
                        break;
                    case 2:
                        Console.WriteLine("Please give new language");
                        q.Language = Console.ReadLine();
                        rest.Put<Publisher>(q, "admin/publisher");
                        break;
                    case 3:
                        Console.WriteLine("Please give new Web address");
                        q.Webpage = Console.ReadLine();
                        rest.Put<Publisher>(q, "admin/publisher");
                        break;
                    case 4:
                        Console.WriteLine("Please give new delivery days value");
                        q.DelivareDays = int.Parse(Console.ReadLine());
                        rest.Put<Publisher>(q, "admin/publisher");
                        break;
                    case 5:
                        Console.WriteLine("PLease give new active status [true-false]");
                        string input2 = Console.ReadLine();
                        if (input2 == "true")
                        {
                            q.IsActive = true;
                        }
                        else if (input2 == "false")
                        {
                            q.IsActive = false;
                        }
                        else
                        {
                            Console.WriteLine("wrong input");
                        }
                        rest.Put<Publisher>(q, "admin/publisher");
                        break;
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Chosen item doesn't exist");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all Author items to console. Asks user which item they wish to modify. Asks user which value they want to change. Then asks user the value to change to and then calls the corresponding logic function accortdingly.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void UpdateAuthor(RestService rest)
        {
            ListAllAuthors(rest);
            Console.WriteLine("Chose which item you want to modify!");
            int index = int.Parse(Console.ReadLine());
            var q = rest.GetOne<Author>($"user/author/{index}");
            if (q != null)
            {
                Console.WriteLine("Chose wich value you want to modify?");
                Console.WriteLine("1: Name  ||  2: KidFriendly  ||  3: Aktive status");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please give new name");
                        q.AuthorName = Console.ReadLine();
                        rest.Put<Author>(q, "admin/author");
                        break;
                    case 2:
                        Console.WriteLine("Please give new value [true-false]");
                        string input = Console.ReadLine();
                        if (input == "true")
                        {
                            q.ForKids = true;
                            rest.Put<Author>(q, "admin/author");
                        }
                        else if (input == "false")
                        {
                            q.ForKids = false;
                            rest.Put<Author>(q, "admin/author");
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Please give new value [true-false]");
                        string input2 = Console.ReadLine();
                        if (input2 == "false")
                        {
                            q.IsActive = true;
                            rest.Put<Author>(q, "admin/author");
                        }
                        else if (input2 == "true")
                        {
                            q.IsActive = false;
                            rest.Put<Author>(q, "admin/author");
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        break;
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Chosen item doesn't exist");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Asks user input to which to create from new author item. Calls AddAuthor function with given input.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void AddAuthor(RestService rest)
        {
            Console.WriteLine("Please give name of author!");
            string name = Console.ReadLine();
            Console.WriteLine("Please give the year he/she was born");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Please give authors language");
            string language = Console.ReadLine();
            Console.WriteLine("PLease give authors active status [true-false]");
            string input = Console.ReadLine();
            bool isActive = false;
            if (input == "true" || input == "false")
            {
                if (input == "true")
                {
                    isActive = true;
                }
                else if (input == "false")
                {
                    isActive = false;
                }

                Console.WriteLine("Please give wether author wrote kid friendly books");
                input = Console.ReadLine();
                bool kidFriendly = false;
                if (input == "true" || input == "false")
                {
                    if (input == "true")
                    {
                        kidFriendly = true;
                    }
                    else if (input == "false")
                    {
                        kidFriendly = false;
                    }

                    rest.Post<Author>(
                        new Author
                        {
                            AuthorName = name,
                            YearBorn = year,
                            OriginalLanguage = language,
                            IsActive = isActive,
                            ForKids = kidFriendly
                        }, "admin/author"
                        );
                    Console.WriteLine("Success!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong input format");
                }
            }
            else
            {
                Console.WriteLine("Wring input format");
            }
        }

        /// <summary>
        /// Writes all publisher items to console, then asks user which item to delete. Calls DeletePublisher funcion with chosen index, if item exists.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void DeletePublisher(RestService rest)
        {
            ListAllPublishers(rest);
            Console.WriteLine("PLease input index of item to delete");
            int index = int.Parse(Console.ReadLine());
            var p = rest.GetOne<Publisher>($"user/publisher/{index}");
            if (p != null)
            {
                rest.Delete(index, "admin/publisher");
                Console.WriteLine(p.ToString() + "  " + "<---- item deleted");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Item doesn't exist");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all author items to console, then asks user which item to delete. Calls DeleteAuthor funcion with chosen index, if item exists.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void DeleteAuthor(RestService rest)
        {
            ListAllAuthors(rest);
            Console.WriteLine("PLease input index of item to delete");
            int index = int.Parse(Console.ReadLine());
            var p = rest.GetOne<Author>($"user/author/{index}");
            if (p != null)
            {
                rest.Delete(index, "admin/author");
                Console.WriteLine(p.ToString() + "  " + "<---- item deleted");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Item doesn't exist");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all book items to console, then asks user which item to delete. Calls DeleteBook funcion with chosen index, if item exists.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void DeleteBook(RestService rest)
        {
            ListAllBooks(rest);
            Console.WriteLine("Please input index of item to delete");
            int index = int.Parse(Console.ReadLine());
            var p = rest.GetOne<Book>($"user/book/{index}");
            if (p != null)
            {
                rest.Delete(index, "admin/book");
                Console.WriteLine(p.ToString() + "  " + "<---- item deleted");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Item doesn't exist");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes all authors and publishers to console and asks user input for new book item. Calls AddBook function with given values.
        /// </summary>
        /// <param name="admin"> AdminLogic object.</param>
        public static void AddBook(RestService rest)
        {
            ListAllAuthors(rest);
            Console.WriteLine("Please give index of author");
            int author = int.Parse(Console.ReadLine());
            Console.Clear();
            ListAllPublishers(rest);
            Console.WriteLine("PLease give index of publisher");
            int publisher = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please give title of book");
            string bookname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please give price of book");
            int price = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please give amount on stock");
            int supply = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("PLease give release year");
            int year = int.Parse(Console.ReadLine());
            rest.Post<Book>(
                new Book
                {
                    Bookname = bookname,
                    AuthorID = author,
                    PublisherID = publisher,
                    Year = year,
                    Price = price,
                    Supply = supply
                }, "admin/book");
            Console.WriteLine("Item added");
            Console.ReadLine();
        }

        /// <summary>
        /// Asks user input for new publisher item. Calls AddPublisher function with given values.
        /// </summary>
        /// <param name="admin"> AdminLogic object. </param>
        public static void AddPublisher(RestService rest)
        {
            Console.WriteLine("Please give name of publisher");
            string name = Console.ReadLine();
            Console.WriteLine("Please give language of publisher");
            string language = Console.ReadLine();
            Console.WriteLine("Please give webaddress of publisher");
            string web = Console.ReadLine();
            Console.WriteLine("PLease give number of delivery days");
            int days = int.Parse(Console.ReadLine());
            Console.WriteLine("PLease give publisher active status [true-false]");
            string input = Console.ReadLine();
            bool isActive = false;
            if (input == "true" || input == "false")
            {
                if (input == "true")
                {
                    isActive = true;
                }
                else if (input == "false")
                {
                    isActive = false;
                }

                rest.Post<Publisher>(
                    new Publisher
                    {
                        PublisherName = name,
                        Language = language,
                        Webpage = web,
                        DelivareDays = days,
                        IsActive = isActive
                    }, "admin/publisher");
            }
            else
            {
                Console.WriteLine("Wrong input");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Writes all publisher items to console. Calls user.GetAllPublishers.
        /// </summary>
        /// <param name="user"> Userlogic object. </param>
        public static void ListAllPublishers(RestService rest)
        {
            var p = rest.Get<Publisher>("user/publisher/all");
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
        public static void ListAllAuthors(RestService rest)
        {
            var a = rest.Get<Author>("user/author/all");
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
        public static void ListAllBooks(RestService rest)
        {
            var q = rest.Get<Book>("user/book/all");
            foreach (var a in q)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadLine();
        }
    }
}
