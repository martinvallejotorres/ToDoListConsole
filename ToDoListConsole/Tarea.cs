using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListConsole
{
    internal class Tarea
    {
        private int ID;
        private string Descripcion;
        private Estado EstadoTarea;
        private bool Eliminada;
       

        public int GetID() { return ID; }
        public string GetDescripcion() { return Descripcion; }
        public Estado GetEstado() { return EstadoTarea; }
        



        public Tarea(int id, string descripcion)
        {
            ID = id;
            Descripcion = descripcion;
            EstadoTarea= Estado.Pendiente;
            Eliminada = false;
        }

        public Tarea()
        {
        }

        public void AgregarTarea() 
        { 
            
            Console.WriteLine($"Tarea N°'{ID}''{Descripcion}' agregada a la lista.");
        
        }

        public void ModificarEStado(int buscarID, List<Tarea> tareas) 
        {
            
            foreach(Tarea tarea in tareas) 
            {
                if (tarea.GetID() == buscarID)
                {
                    int opcion = MenuModificarEstado();

                    try
                    {
                        if (opcion == 1)
                        {
                            tarea.EstadoTarea = Estado.Pendiente;
                            Console.WriteLine($"Tarea N°'{tarea.GetID()}''{tarea.GetDescripcion()}' modificada a estado Pendiente.");
                        }
                        else if (opcion == 2)
                        {
                            tarea.EstadoTarea = Estado.Completada;
                            Console.WriteLine($"Tarea N°'{tarea.GetID()}''{tarea.GetDescripcion()}' modificada a estado Completada.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    }
                    
                }
            }
        }

        public int MenuModificarEstado() 
        {
            int opcion = 0;
            Console.WriteLine("=== Modificar Estado de la Tarea ===");
            Console.WriteLine("1- Pendiente");
            Console.WriteLine("2- Completo");
            return opcion = int.Parse(Console.ReadLine());
            
        }


        public void Eliminar() 
        { 
        
        }

        public void MostrarTarea(List<Tarea>listaTareas)
        {
            foreach (var tarea in listaTareas)
            {
                Console.WriteLine($"ID: {tarea.ID}, Descripción: {tarea.Descripcion}, Estado: {tarea.EstadoTarea}");
            }

                
            
        }


    }
}
