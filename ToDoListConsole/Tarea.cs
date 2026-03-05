namespace ToDoListConsole
{
    internal class Tarea
    {
        public int ID { get; set; }
        public string Descripcion { get; set; } = "";
        public Estado EstadoTarea { get; set; } = Estado.Pendiente;

        // Constructor vacío para JSON
        public Tarea() { }

        public Tarea(int id, string descripcion)
        {
            ID = id;
            Descripcion = descripcion;
            EstadoTarea = Estado.Pendiente;
        }
    }
}