﻿using TareaSpace;

// Instancia de random para generar descripciones, cantidad y duracion de tareas pseudo-aleatorias
Random rnd = new Random();

// Lista de descripciones para tarea default
string[] ListaTareasDescDefault = { "Terminar este tp", "Hacer otro tp", "Empezar aquel tp", "Desarrollar una respuesta a nada" };

// Rango de cantidad de tareas
int amount = rnd.Next(1, 10);
Console.WriteLine($"Cantidad de Tareas autogeneradas: {amount}");

// Listas de tareas pendientes y terminadas 
var listaTareasPendientes = new List<Tarea>();
var listaTareasTerminadas = new List<Tarea>();

// Lista que guardara los id de las tareas a eliminar de lista de pendientes
var idToDeleteFromPendiente = new List<int>();

// Genero N cantidad de tareas. N igual a la cantidad pseudo-aleatoria generada.
for (int i = 0; i < amount; i++)
{
    var randDur = rnd.Next(10, 100);
    var randDesc = rnd.Next(1, ListaTareasDescDefault.Length);
    var tarea = new Tarea(i + 1, randDur, ListaTareasDescDefault[randDesc]);
    listaTareasPendientes.Add(tarea);
}

Console.WriteLine("================");
Console.WriteLine("     TAREAS     ");
Console.WriteLine("================");


// Pregunta si la tarea ha sido realizada. En caso positivo añadirla a la lista de
// terminadas, en caso contrario no hacer nada. A la vez que se guarda el id de la tarea
// a tranferir para luego ser quitada de la lista de pendientes 

for (var x = 0; x < amount; x++)
{
    Console.WriteLine($"id: {listaTareasPendientes[x].Id}");
    Console.WriteLine($"duracion: {listaTareasPendientes[x].Duracion}");
    Console.WriteLine($"descripcion: {listaTareasPendientes[x].Descripcion}");
    Console.WriteLine("---------------");
    Console.Write(@"¿La tarea ha sido realizada?(y/n): ");
    string? preRes = Console.ReadLine();
    char response = preRes!.ToLower().ToCharArray()[0];
    if (response == 'y' || response == 'n')
    {
        if (response == 'y')
        {
            listaTareasTerminadas.Add(listaTareasPendientes[x]);
            // Solucion a problemas generados por eliminar elemento 
            // de la list durante el proceso de recorrido de la misma (Cambian indices)
            idToDeleteFromPendiente.Add(listaTareasPendientes[x].Id);
        }
    }
    else
    {
        Console.WriteLine("Debe ingresar un valor valido. (y/n)");
    }
}
// Quitar tarea terminada de pendiente en base al id antes conseguido.
idToDeleteFromPendiente.ForEach(idTarea =>
{
    listaTareasPendientes.Remove(listaTareasTerminadas.Find(tarea => tarea.Id == idTarea)!);
});


// Muestreo de Lista de tareas Terminadas
Console.WriteLine("-----------------------");
Console.WriteLine("       TERMINADAS      ");
Console.WriteLine("-----------------------");
listaTareasTerminadas.ForEach(tarea =>
{
    Console.WriteLine($"{tarea.Id}");
    Console.WriteLine($"{tarea.Duracion}");
    Console.WriteLine($"{tarea.Descripcion}");
});

// Muestreo de Lista de tareas Pendientes (Luego de sufrir, o no, cambios)
Console.WriteLine("-----------------------");
Console.WriteLine("       PENDIENTES      ");
Console.WriteLine("-----------------------");
listaTareasPendientes.ForEach(tarea =>
{
    Console.WriteLine($"{tarea.Id}");
    Console.WriteLine($"{tarea.Duracion}");
    Console.WriteLine($"{tarea.Descripcion}");
});
