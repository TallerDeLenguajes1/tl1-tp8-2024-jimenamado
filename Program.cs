using RutinaTareas;
using System.Collections.Generic;
using System.Reflection.Metadata;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Tarea> ListadoDeTareasPendientes = new List<Tarea>();    // declaro una lista con objetos de tipo tarea
        List<Tarea> ListadoDeTareasRealizadas = new List<Tarea>();

        string salida = " ";
        int num = 0;
        do
        {
            System.Console.WriteLine("Ingrese la descripcion de la tarea:");
            string descTarea = Console.ReadLine();

            Tarea nuevaTareaPendiente = new Tarea();
            nuevaTareaPendiente.TareaID = num;
            nuevaTareaPendiente.Descripcion = descTarea;

            //num aleatorio entre rango    
            Random randon = new Random();   
            int min = 10, max = 100;
            nuevaTareaPendiente.Duracion = randon.Next(min, max);

            ListadoDeTareasPendientes.Add(nuevaTareaPendiente);     //agrego la nueva tarea a lista
            num++;

            System.Console.WriteLine("Desea ingresar una nueva tarea:(si/no)");
            salida = Console.ReadLine();

        } while (salida != "no");

        System.Console.WriteLine("Listado de tareas pendientes");
        MostrarLista(ListadoDeTareasPendientes);

        System.Console.WriteLine("Marcar tarea a realizado: Ingrese el ID");
        string cad = Console.ReadLine();
        int id = 0;
        bool result = int.TryParse(cad, out id);

        MoverTareaPorId(ListadoDeTareasPendientes, ListadoDeTareasRealizadas, id);

        System.Console.WriteLine("Listado de tareas Realizadas");
        MostrarLista(ListadoDeTareasRealizadas);

        System.Console.WriteLine("Buscar tarea pendiente por descripcion:");
        System.Console.WriteLine("Ingrese la descripcion:");
        string desc = Console.ReadLine();
        System.Console.WriteLine("Tarea Buscada:");
        BuscarTareaPorDescripcion(ListadoDeTareasPendientes, desc);

    }

    //Metodo para mover y eliminar una tarea de la lista pendiente a la lista realizada a traves del ID
    private static void MoverTareaPorId(List<Tarea> ListadoDeTareasPendientes, List<Tarea> ListadoDeTareasRealizadas, int id)
    {
        bool tarea_encontrada = false;
        var tarea = new Tarea();

        foreach (var tarea_buscada in ListadoDeTareasPendientes)
        {
            if (tarea_buscada.TareaID == id)
            {
                tarea = tarea_buscada;
                ListadoDeTareasRealizadas.Add(tarea);
                tarea_encontrada = true;
            }
        }

        if (tarea_encontrada)
        {
            ListadoDeTareasPendientes.Remove(tarea);
        }
        
    }

    //Metodo para buscar tareas pendientes por descripción
    public static void BuscarTareaPorDescripcion(List<Tarea> TareasPendientes, string descripcion)
    {
        //Tarea aux = TareasPendientes.FirstOrDefault( t => t.Descripcion == descripcion);
        
        foreach (var tarea_buscada in TareasPendientes)
        {
            if (tarea_buscada.Descripcion == descripcion)
            {
                System.Console.WriteLine("ID:" + tarea_buscada.TareaID + " - Descripcion: " + tarea_buscada.Descripcion + " - Duracion en min:" + tarea_buscada.Duracion);
            }
        }

    }

    //Metodo para mostrar lista completa
    public static void MostrarLista(List<Tarea> ListadoTareas)
    {
        foreach (Tarea tareaX in ListadoTareas)
        {
            System.Console.WriteLine("ID:" + tareaX.TareaID + " - Descripcion: " + tareaX.Descripcion + " - Duracion en min:" + tareaX.Duracion);
        }   
    }


}