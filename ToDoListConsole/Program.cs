namespace ToDoListConsole
{
    internal class Program
    {
        
        static int idCounter = 1;
        static void Main(string[] args)
        {
            List<Tarea> tareas = new List<Tarea>();


            string descripcion = "Empty";
            int buscarID = 0;
            bool salir = false;

            while (!salir)
            {
                MenuPrincipal();
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Descripcion de la tarea:");
                        descripcion = Console.ReadLine();
                        tareas.Add(new Tarea(idCounter, descripcion));
                        idCounter++;

                        break;
                    case "2":
                        Tarea buscar = new Tarea();
                            
                        Console.WriteLine("ID de la tarea que quieres modificar el estado:");
                        buscarID = int.Parse(Console.ReadLine());

                        buscar.ModificarEStado(buscarID, tareas);

                        break;

                    case "3":


                       


                        break;
                    case "4":

                        Tarea verTarea = new Tarea();

                        verTarea.MostrarTarea(tareas);

                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }



        }

        private static void MenuPrincipal()
        {
            Console.WriteLine("=== Lista de Tareas ===");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Modificar Estado");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Mostrar Tareas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }



    }
}