using Tarea02_c.Models;

namespace Tarea02_c.Infraestructure
{
    public class BookRepositoryImpl : IBookRepository
    {

        private IDictionary<int, Book> _books;

        public BookRepositoryImpl()
        {
            _books = new Dictionary<int, Book>();

            //isbn, titulo, autor, fecha creacion
            Book book1 = new Book(0, "Voces anonimas - Inframundo", "Guillermo Lockhart", new DateOnly(2023, 7, 21));
            Book book2 = new Book(1, "Misterio en el Cabo Polonio", "Helen Velando", new DateOnly(2021, 5, 17));
            Book book3 = new Book(2, "Felipe", "Susana Olaondo", new DateOnly(2019, 1, 23));
            Book book4 = new Book(3, "El poder de seis", "Pitacus Lore", new DateOnly(2016, 6, 12));
            Book book5 = new Book(4, "Soy el numero cuatro", "Pitacus Lore", new DateOnly(2014, 5, 1));
            Book book6 = new Book(5, "Voces anonima - Juegos Prohibidos", "Guillermo Lockhart", new DateOnly(2015, 11, 30));


            this._books.Add(book1.Isbn, book1);
            this._books.Add(book2.Isbn, book2);
            this._books.Add(book3.Isbn, book3);
            this._books.Add(book4.Isbn, book4);
            this._books.Add(book5.Isbn, book5);
            this._books.Add(book6.Isbn, book6);
        }

        public void Add(Book book)
        {
            this._books.Add(book.Isbn, book);
        }

        public IList<Book> GetAllBooks(){

            return _books.Values.ToList();

        }

        public void Update(Book book)
        {

            this._books[book.Isbn] = book; //si la clave existe actualiza, si no la crea, puede funcionar como una funcion de save para ambos casos, solo si estoy seguro que nunca me llegaran datos repetidos,
                                            //ya que podria ser util enviar un mensaje de error por datos que ya existe, en lugar de actualizar.

        }

        public void Delete(int Isbn)
        {
            this._books.Remove(Isbn);
        }

        public Book GetById(int id)
        {
            if (this._books != null)
            {
                Book book = this._books[id];
                return book;
            }
            return null;
        }
    }
}
