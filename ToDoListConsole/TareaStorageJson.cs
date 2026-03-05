using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoListConsole
{
    internal class TareaStorageJson
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public TareaStorageJson(string path = "tareas.json")
        {
            _path = path;
        }

        public List<Tarea> Cargar()
        {
            try
            {
                if (!File.Exists(_path))
                    return new List<Tarea>();

                string json = File.ReadAllText(_path);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<Tarea>();

                return JsonSerializer.Deserialize<List<Tarea>>(json, _jsonOptions) ?? new List<Tarea>();
            }
            catch
            {
                Console.WriteLine("No se pudo cargar el archivo JSON. Se iniciará con una lista vacía.");
                return new List<Tarea>();
            }
        }

        public void Guardar(List<Tarea> tareas)
        {
            try
            {
                string json = JsonSerializer.Serialize(tareas, _jsonOptions);
                File.WriteAllText(_path, json);
            }
            catch
            {
                Console.WriteLine("No se pudo guardar el archivo JSON.");
            }
        }
    }
}