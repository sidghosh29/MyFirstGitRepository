using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        static List<Book> bookList = new List<Book>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        
        static int bookAdded = 0;

        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Library Management System");
            bool close = true;
            while (close)
            {


                Console.WriteLine("\nMenu\n" +
                "1)Add\n" +
                "2)Delete\n" +
                "3)Search\n" +
                "4)Issue\n" +
                "5)Submit\n" +
                "6)Exit\n\n");
                Console.Write("Choose your option from menu :");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        GetBook();
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    case 3:
                        SearchBook();
                        break;
                    case 4:
                        Borrow();
                        break;
                    case 5:
                        ReturnBook();
                        break;
                    case 6:
                        Console.WriteLine("Exit");
                        close = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option\nRetry !!!");
                        break;

                }
            }
        }

        //To add book details to the Library database
        public static void GetBook()
        {
            Book book = new Book();
            Console.WriteLine("Book Id:{0}", book.bookId = (bookAdded++) + 1);
            Console.Write("Book Name:");
            book.bookName = Console.ReadLine();
            Console.Write("Book Price:");
            book.bookPrice = int.Parse(Console.ReadLine());
            Console.Write("Number of Books:");
            book.tot = book.bookCount = int.Parse(Console.ReadLine());
            bookList.Add(book);
        }

        //To delete book details from the Library database 
        public static void RemoveBook()
        {
            bool flag = false;
            Console.Write("Enter Book id to be deleted : ");

            int Del = int.Parse(Console.ReadLine());
            foreach (Book removeBook in bookList)
            {
                if (removeBook.bookId == Del)
                {  flag = true;
                    bookList.RemoveAt(Del - 1);
                    Console.WriteLine("Book id - {0} has been deleted", Del);
                    break;
                }
            }
                if (!flag)
                {
                    Console.WriteLine("Invalid Book id");
                }
            

        }

        //To search book details from the Library database using Book id 
        public static void SearchBook()
        {
            bool flag=false;
            Console.Write("Search by BOOK id :");
            int find = int.Parse(Console.ReadLine());
            foreach (Book searchId in bookList)
            {
                if (searchId.bookId == find)
                {
                    flag = true;
                    Console.WriteLine("Book id :{0}\n" +
                    "Book name :{1}\n" +
                    "Book price :{2}\n" +
                    "Book Count :{3}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount);
                }
            }

            if (!flag)
            {
                Console.WriteLine("Book id {0} not found", find);
            }
        }

        //To borrow book details from the Library
        public static void Borrow()
        {
            bool flag= false;
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            Console.WriteLine("User id : {0}", (borrow.userId = borrowList.Count + 1));
            Console.Write("Name :");

            borrow.userName = Console.ReadLine();

            Console.Write("Book id :");
            borrow.borrowBookId = int.Parse(Console.ReadLine());
            Console.Write("Number of Books : ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            Console.Write("Address :");
            borrow.userAddress = Console.ReadLine();
            borrow.borrowDate = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());


            foreach (Book searchId in bookList)
            {
                if (searchId.bookCount != 0)
                {
                    if (searchId.bookId == borrow.borrowBookId)
                    {
                        flag = true;
                        if (searchId.bookCount > searchId.bookCount - borrow.borrowCount && searchId.bookCount - borrow.borrowCount >= 0)
                        {

                            searchId.bookCount = searchId.bookCount - borrow.borrowCount;
                            break;

                        }
                        else
                        {

                            Console.WriteLine("Only {0} books are found", searchId.bookCount);
                            break;

                        }
                    }
                }
                else
                {
                    Console.WriteLine("All the books have been issued currently");


                }
            }

            if (!flag)
            {
                Console.WriteLine("Book id {0} not found", borrow.borrowBookId);
                borrowList.Add(borrow);
            }

        }



        //To return borrowed book to the library 
        public static void ReturnBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter following details :");

            Console.Write("Book id : ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            int returnCount = int.Parse(Console.ReadLine());
            int flag = 0;


            foreach (Book addReturnBookCount in bookList)
            {
                if (addReturnBookCount.bookId == returnId)
                {
                    flag = 1;
                    if (addReturnBookCount.tot >= returnCount + addReturnBookCount.bookCount)
                    {

                        addReturnBookCount.bookCount = addReturnBookCount.bookCount + returnCount;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Count exceeds the actual count");
                        break;
                    }
                }

            }
            if (flag != 1)
                Console.WriteLine("Book id {0} not found", returnId);
        }
    }
}