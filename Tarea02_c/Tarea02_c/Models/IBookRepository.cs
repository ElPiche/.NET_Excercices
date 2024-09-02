namespace Tarea02_c.Models
{
    public interface IBookRepository
    {

        public void Add(Book book);

        public void Update(Book book);

        public void Delete(int Isbn);

        public Book GetById(int Isbn);

        public IList<Book> GetAllBooks();

    }
}
