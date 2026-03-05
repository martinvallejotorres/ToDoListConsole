using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListConsole
{
    internal class Program
    {
        static int idCounter = 0;

        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                var storage = new TareaStorageJson("tareas.json");
                List<Tarea> tareas = storage.Cargar();

                // Setear el idCounter para no repetir IDs
                idCounter = (tareas.Count == 0) ? 0 : tareas.Max(t => t.ID) + 1;

                var service = new TareaService();
                bool salir = false;

                while (!salir)
                {
                    Console.Clear();
                    MenuPrincipal();

                    string opcion = Console.ReadLine();
                    Console.Clear();

                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Descripción de la tarea: ");
                            string descripcion = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(descripcion))
                            {
                                Console.WriteLine("La descripción no puede estar vacía.");
                                Console.ReadKey();
                                break;
                            }

                            service.Agregar(tareas, idCounter, descripcion.Trim());
                            idCounter++;
                            storage.Guardar(tareas);
                            Console.ReadKey();
                            break;

                        case "2":
                            Console.Write("ID de la tarea que quieres modificar el estado: ");
                            if (!int.TryParse(Console.ReadLine(), out int idModificar))
                            {
                                Console.WriteLine("ID inválido.");
                                Console.ReadKey();
                                break;
                            }

                            service.ModificarEstado(tareas, idModificar);
                            storage.Guardar(tareas);
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Write("ID de la tarea que quieres eliminar: ");
                            if (!int.TryParse(Console.ReadLine(), out int idEliminar))
                            {
                                Console.WriteLine("ID inválido.");
                                Console.ReadKey();
                                break;
                            }

                            service.Eliminar(tareas, idEliminar);
                            storage.Guardar(tareas);
                            Console.ReadKey();
                            break;

                        case "4":
                            service.Mostrar(tareas);
                            Console.ReadKey();
                            break;

                        case "5":
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            Console.ReadKey();
                            break;
                    }
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