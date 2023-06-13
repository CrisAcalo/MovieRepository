using System;

public class Pelicula
{
    public string nombre { get; set; }
    public int anio { get; set; }

    public Pelicula(string nombre, int anio)
    {
        this.nombre = nombre;
        this.anio = anio;
    }
    public Pelicula()
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is Pelicula pelicula &&
               nombre == pelicula.nombre &&
               anio == pelicula.anio;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(nombre, anio);
    }

}
