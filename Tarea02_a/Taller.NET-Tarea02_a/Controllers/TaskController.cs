using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.NET_Tarea02_a.Models;


namespace Taller.NET_Tarea02_a.Controllers
{

    [ApiController]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        //TaskClass en lugar de Task, debido a similitud con el nombre de otra clase de System.Threading.Task

        //atributos
        private readonly ILogger<TaskController> _logger;
        private IList<TaskClass> _taskList; //lista de tareas a manipular en memoria.

        
        public TaskController(ILogger<TaskController> logger)
        {
            this._logger = logger; //inyeccion instancia logger mediante el constructor.

            this._taskList = new List<TaskClass>(); //inicializo lista

            //cargo datos de prueba en lista.
            //id, nombre, descripcion, duracion, responsable.

           this._taskList.Add(new TaskClass(0, "Tarea 1", "Mirar correos", 2, "Pepe", new DateOnly(2023, 7, 21)));
           this._taskList.Add(new TaskClass(1, "Tarea 2", "Hacer reporte", 2, "Milagros", new DateOnly(2023, 6, 19)));
           this._taskList.Add(new TaskClass(2, "Tarea 3", "Terminar maqueta", 2, "Felipe", new DateOnly(2025, 6, 1)));
           this._taskList.Add(new TaskClass(3, "Tarea 4", "Actualizar perfil", 2, "José", new DateOnly(2023, 4, 2)));
           this._taskList.Add(new TaskClass(4, "Tarea 5", "Chequear actualizaciones", 2, "`Nicolás", new DateOnly(2024, 12, 31)));
           
        }

        /// <summary>
        /// Obtiene todas las tareas del sistema
        /// </summary>
        /// <returns> Devuelve una lista de tareas </returns>
        /// <response code="200"> Retorna una lista de todas las tareas</response>
        /// <response code="404"> Si la lista de tareas esta vacía </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IList<TaskClass>> GetAllTasks()
        {
            _logger.LogInformation("Devolviendo lista de tareas");

            if (_taskList != null)
            {
                return Ok(_taskList.ToList());
            }

            return NotFound("No hay usuarios en el sistema");


        }

        /// <summary>
        /// Buscar tarea por id
        /// </summary>
        /// <param name="id"> Utiliza el identificador para buscar la tarea</param>
        /// <returns>Devuelve una lista en particular </returns>
        /// <response code="200"> Retorna una tarea </response>
        /// <response code="404"> Si no se pudo encontrar la tarea </response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskClass> GetTaskById(int id)
        {
            _logger.LogInformation("Devolviendo " + $"tarea con id: {id}");

            if (_taskList != null)
            {
                return Ok(_taskList[id]);
            }

            return NotFound("No se encontró una tarea con el id: " + id);
           

        }

        /// <summary>
        /// Crear tarea
        /// </summary>
        /// <param name="task"> Utiliza los parametros del body para crear el objeto </param>
        /// <returns>Una lista de tareas con la tarea agregada</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "id": 5,
        ///        "name": "Revisar Tarea",
        ///        "description": "Tareas de API's en .NET",
        ///        "duration": 2,
        ///        "responsible": "Gabriel",
        ///        "creationDate": "2024-04-30"
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> Retorna una lista de tarea, con la nueva tarea</response>
        /// <response code="500"> Si no se pudo crear la tarea </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult newTask([FromBody] TaskClass task) //Obtengo la data del body. No es necesario FromBody en caso de tener: [ApiController]
        {
            try
            {
                _taskList.Add(task);
                _logger.LogInformation("Añadiendo nueva tarea: " + task.Name + " a la lista de Tareas");

                return Ok(_taskList.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al añadir la tarea: " + ex.Message);
                return StatusCode(500, "Se produjo un error al añadir la tarea.");
            }
        }

        /// <summary>
        /// Eliminar Tarea
        /// </summary>
        /// <param name="id">  Utiliza el identificador para buscar y eliminar la tarea </param>
        /// <returns> Devuleve una lista de tareas, sin la tarea eliminada </returns>
        /// <response code="200"> Retorna una lista de tareas con la tarea eliminada</response>
        /// <response code="404"> Si no se pudo eliminar la tarea </response>
        [HttpDelete ("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteTaskById(int id) {

            _logger.LogInformation("Eliminando tarea con id: " + id);

            if (_taskList != null) {
                this._taskList.RemoveAt(id);
                return Ok(_taskList.ToList());
            }
            
            return NotFound("No se encontró una tarea con el id: " + id);

            
        }

       
    }
}
