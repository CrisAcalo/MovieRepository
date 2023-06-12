namespace MovieRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            Console.WriteLine("Hello, World!");

            List<string> opciones = new List<string>()
        {
            "..:: Ingresar pelicula",
            "..:: Ver peliculas ingresadas",
            "..:: Eliminar pelicula/s",
            "..:: Ordenar",
            "..:: Salir"
        };

            int opcionSeleccionada = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción:");

                for (int i = 0; i < opciones.Count; i++)
                {
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(opciones[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        opcionSeleccionada = (opcionSeleccionada == 0) ? opciones.Count - 1 : opcionSeleccionada - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        //opcionSeleccionada = (opcionSeleccionada == opciones.Count - 1) ? 0 : opcionSeleccionada + 1;
                        opcionSeleccionada = (opcionSeleccionada + 1) % opciones.Count;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("..:: Opción seleccionada: " + opciones[opcionSeleccionada]);

                        // Aquí puedes agregar la lógica correspondiente a cada opción seleccionada

                        if (opciones[opcionSeleccionada] == "..:: Ingresar pelicula")
                        {
                            Console.WriteLine("A continuación se va a ingresar una pelicula");
                        }
                        else if (opciones[opcionSeleccionada] == "..:: Ver peliculas ingresadas")
                        {

                        }
                        else if (opciones[opcionSeleccionada] == "..:: Eliminar pelicula/s")
                        {

                        }
                        else if (opciones[opcionSeleccionada] == "..:: Salir")
                        {
                            return;
                        }

                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}