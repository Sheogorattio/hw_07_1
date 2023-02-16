using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;

namespace hw_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] a = new Book[5];
            a[0] = new Book();
            a[0].Author = "Margaret Cavendish";
            a[0].Title = "The blazing world";
            a[1] = new Book();
            a[1].Author = "Mary Shelley";
            a[1].Title = "Frankenstein";
            a[2] = new Book();
            a[2].Author = "Isaac Azimov";
            a[2].Title = "Foundation";
            a[3] = new Book();
            a[3].Author = "Frank Herbert";
            a[3].Title = "Duna";
            a[4] = new Book();
            a[4].Author = "Naomi Alderman";
            a[4].Title = "The power";

            Array.Sort(a,new Book.SortByTitle());
            foreach (Book b in a)
            {
                Console.WriteLine("{0}\n-------------------------", b.ToString());
            }

            Library lib = new Library(a);
            foreach(Book temp in lib)
            {
                Console.WriteLine(temp.ToString());
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
