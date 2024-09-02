using System.Runtime.CompilerServices;

namespace Tarea02_c.Models
{
    public class Book
    {
        private int _Isbn;

        public int Isbn
        {  //propiedad que define setter y getter para mi atributo
            get { return _Isbn; }
            set { _Isbn = value; }
        }


        public string? Title { get; set;}

        public string? Author { get; set;}

        public DateOnly CreationDate {  get; set;}

        public Book()
        {

        }

        public Book(int isbn, string title, string author, DateOnly creationDate)
        {
            this._Isbn = isbn;
            this.Title = title;
            this.Author = author;
            this.CreationDate = creationDate;
        }
    }
}
