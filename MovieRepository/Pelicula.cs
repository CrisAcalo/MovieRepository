namespace MovieRepository
{
    internal class Pelicula
    {
        private string nombre { get; set; }
        private int anio { get; set; }

        public Pelicula(string nombre, int anio)
        {
            this.nombre = nombre;
            this.anio = anio;
        }
    }
}
