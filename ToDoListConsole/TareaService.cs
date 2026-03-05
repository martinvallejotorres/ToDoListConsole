using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListConsole
{
    internal class TareaService
    {
        public void Agregar(List<Tarea> tareas, int id, string descripcion)
        {
            var tarea = new Tarea(id, descripcion);
            tareas.Add(tarea);
            Console.WriteLine($"Tarea N° '{tarea.ID}' '{tarea.Descripcion}' agregada (Estado: {tarea.EstadoTarea}).");
        }

        public void ModificarEstado(List<Tarea> tareas, int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.ID == id);
            if (tarea == null)
            {
                Console.WriteLine("No se encontró la tarea.");
                return;
            }

            Console.WriteLine("=== Modificar Estado de la Tarea ===");
            Console.WriteLine("1- Pendiente");
            Console.WriteLine("2- Completada");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion) || (opcion != 1 && opcion != 2))
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            tarea.EstadoTarea = (Estado)opcion;
            Console.WriteLine($"Tarea N° '{tarea.ID}' '{tarea.Descripcion}' modificada a estado {tarea.EstadoTarea}.");
        }

        public void Eliminar(List<Tarea> tareas, int idEliminar)
        {
            var tarea = tareas.FirstOrDefault(t => t.ID == idEliminar);
            if (tarea == null)
            {
                Console.WriteLine("No se encontró la tarea.");
                return;
            }

            tareas.Remove(tarea);
            Console.WriteLine($"Tarea N° '{tarea.ID}' '{tarea.Descripcion}' eliminada de la lista.");
        }

        public void Mostrar(List<Tarea> tareas)
        {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas cargadas.");
                return;
            }

            Console.WriteLine("=== Tareas ===");
            foreach (var t in tareas)
            {
                Console.WriteLine($"Descripción: {t.Descripcion} | Estado: {t.EstadoTarea}");
            }
        }
    }
}