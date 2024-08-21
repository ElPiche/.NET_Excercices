namespace Taller.NET_Tarea02_a.Models
{
    public class TaskClass
    {

        //TaskClass en lugar de Task, debido a similitud con el nombre de otra clase de System.Threading.Task

        //atributo
        private int _id;

        public int Id {  //propiedad que define setter y getter para mi atributo
            get { return _id; } 
            set { _id = value; }
        }

        //Propiedades
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }

        public string? Responsible { get; set; }

        public DateOnly? creationDate { get; set; }

        public TaskClass() { 
        
        }

        public TaskClass(int id, string name, string description, int duration, string responsible, DateOnly creationDate)
        {
            this._id = id;
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.Responsible = responsible;
            this.creationDate = creationDate;

        }



    }
}
