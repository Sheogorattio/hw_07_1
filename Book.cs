using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    public class Book : IComparable, ICloneable
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public Book() { }
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
        public class SortByTitle : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Book || y is Book) return (x as Book).Title.CompareTo((y as Book).Title);
                throw new ArgumentException();
            }
        }

        public class SortByAuthor : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Book || y is Book) return (x as Book).Author.CompareTo((y as Book).Author);
                throw new ArgumentException();
            }
        }
        public int CompareTo(object obj)
        {
           if(obj is Book) return Title.CompareTo((Book)obj);
           throw new ArgumentException();
        }

        public override string ToString()
        {
            return "Author: " + Author + "\nTitle: " + Title;
        }

        public object Clone()
        {
            return new Book(Title, Author);
        }
    }


    public class Library : IEnumerable, IEnumerator
    {
        private Book[] book;
        private int size;
        private int curpos = -1;
        public int Size
        {
            get { return size; }
        }

        public object Current
        {
            get { return book[curpos]; }
        }

        public Library(Book[] lib)
        {
            size = lib.Length;
            book = new Book[size];
            for(int i=0; i < size; i++)
            {
                book[i] = new Book(lib[i].Title, lib[i].Author);
            }
        }
        public Library(int size)
        {
            book = new Book[size];
            for(int i=0; i < size; i++) book[i] = new Book();
            this.size = size;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (curpos < book.Length - 1)
            {
                curpos++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            curpos = -1;
        }
    }
}
