using Microsoft.AspNetCore.Mvc;
using Tarea02_c.Models;

namespace Tarea02_c.Controllers

{

    [Route("Book")]
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;

        private readonly IBookRepository _bookRepository;

        private readonly IWebHostEnvironment _webRootPath; //en caso de necesitar acceder a archivos en wwwroot

        public BookController(ILogger<BookController> logger,
          IBookRepository repo,
          IWebHostEnvironment path)
        {
            _logger = logger;
            _bookRepository = repo;
            _webRootPath = path;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("Devolviendo lista de libros del sistema.");
            return View("ViewAllBooks", this._bookRepository.GetAllBooks());
        }

        [HttpGet]
        [Route("ViewBook/{Isbn}")]
        public IActionResult GetBook(int Isbn)
        {
            _logger.LogInformation("Estoy devolviendo un libro con id: " + Isbn);

            return View("ViewBook", this._bookRepository.GetById(Isbn));

        }

        [HttpGet]
        [Route("CreateBook")]
        public IActionResult CreateBook()
        {
            return View(); //cuando devuelvo esto el controllador asume que quiero devolver una vista del mismo nombre, en este caso busca el archivo CreateBook.cshtml
        }

        [HttpPost]
        [Route("CreateBook")] //puedo tener dos endpoints con mismo nombre siempre y cuando uno reciba parametros distintos.
        public IActionResult CreateBook([Bind("Isbn,Title,Author,CreationDate")] Book book) //    <!-- isbn, title, author, creationDate-->
        {

            _logger.LogInformation("Creando libro");
            this._bookRepository.Add(book);
            return RedirectToAction("GetAllBooks", "Book");
        }

        [HttpGet]
        [Route("Delete/{Isbn}")]
        public IActionResult Delete(int Isbn)
        {
            if (Isbn != null)
            {
                _logger.LogInformation("Estoy mostrando libro a eliminar Isbn: " + Isbn);

                Book book = _bookRepository.GetById(Isbn);

                return View("DeleteBook", book);
            }

            return null;
            
        }

        [HttpPost]
        [Route("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int Isbn)
        {
            _logger.LogInformation("Eliminando libro ....");
            this._bookRepository.Delete(Isbn);

            return RedirectToAction("GetAllBooks", "Book");

        }

        [HttpGet]
        [Route("EditBook/{Isbn}")]
        public IActionResult Edit (int Isbn)
        {

            _logger.LogInformation("Estoy mostrando libro a editar Isbn: " + Isbn);

            Book book = this._bookRepository.GetById(Isbn);

            return View("EditBook", book);
        }

        [HttpPost]
        [Route("EditConfirmed")]
        public IActionResult EditConfirmed([Bind("Isbn,Title,Author,CreationDate")] Book book)
        {
            _logger.LogInformation("Editando libro ....");
            this._bookRepository.Update(book);

            return RedirectToAction("GetAllBooks", "Book");

        }
    }
}
