namespace TareaSpace;

public class Tarea
{
    private int id;
    public int Id { get => id; set => id = value; }

    private string descripcion;
    public string Descripcion
    { get => descripcion; set => descripcion = value; }

    private int duracion;
    public int Duracion { get => duracion; set => duracion = value; }

    public Tarea(int idT, int durac, string desc)
    {
        id = idT;
        duracion = durac;
        descripcion = desc;
    }
}
