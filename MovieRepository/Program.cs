using MovieRepository;
class Program
{
    static void CenterText(string text)
    {
        int windowWidth = Console.WindowWidth;
        int leftPadding = (windowWidth - text.Length) / 2;
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        Console.WriteLine(text);
    }
    static void Main(string[] args)
    {
        Console.Clear();

        string[] menuOptions = {
            "Ingresar película       ",
            "Ver películas ingresadas",
            "Eliminar película(s)    ",
            "Ordenar                 ",
            "Salir                   " };
        int selectedOptionIndex = 0;

        Nodo nodo = new Nodo();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterText("╔════════════════════════════╗");
            CenterText("║                            ║");
            CenterText("║      Movie Repository      ║");
            CenterText("║                            ║");
            CenterText("╚════════════════════════════╝");
            Console.ResetColor();
            CenterText("");
            CenterText("Seleccione una opción:");
            CenterText("");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedOptionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    CenterText("> " + menuOptions[i]);
                }
                else
                {
                    CenterText("  " + menuOptions[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOptionIndex = selectedOptionIndex > 0 ? selectedOptionIndex - 1 : menuOptions.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOptionIndex = (selectedOptionIndex + 1) % menuOptions.Length;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    
                    CenterText("Presione cualquier tecla para continuar...");

                    if (selectedOptionIndex == menuOptions.Length - 1)
                    {
                        return; // Salir del programa
                    }
                    else if (menuOptions[selectedOptionIndex] == "Ingresar película       ")
                    {
                        string nombre;
                        string año;
                        int añoInteger = 0;
                        bool isValidInput = false;

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║        Nueva Pelicula        ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();

                        CenterText("Inserte los datos de la película ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("Nombre: ");
                        Console.ResetColor();

                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                        nombre = Console.ReadLine();
                        while (nombre == "" || nombre == null || nombre == " ")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            CenterText("Nombre: ");
                            Console.ResetColor();
                            Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                            nombre = Console.ReadLine();
                        }

                        do
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                CenterText("Año: ");
                                Console.ResetColor();
                                Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                                año = Console.ReadLine();

                                añoInteger = int.Parse(año);

                                while (añoInteger == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    CenterText("Año: ");
                                    Console.ResetColor();
                                    Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                                    nombre = Console.ReadLine();
                                }

                                Pelicula nuevaPelicula = new Pelicula(nombre, añoInteger);

                                nodo.InsertarFinal(nuevaPelicula);
                                isValidInput = true;
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                CenterText("..:: Tipo de dato no válido. Ingresar de nuevo por favor ::..");
                                Console.ResetColor();
                            }
                            catch (OverflowException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                CenterText("Ha ingresado un valor fuera del rango de un número entero ;-;");
                                Console.ResetColor();
                            }
                        } while (isValidInput != true);

                    }
                    else if (menuOptions[selectedOptionIndex] == "Ver películas ingresadas")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║      Peliculas Actuales      ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");

                        nodo.ver();
                    }
                    else if (menuOptions[selectedOptionIndex] == "Eliminar película(s)    ")
                    {
                        //CenterText("Inserte el nombre de la pelicula a eliminar ");

                        //Console.ForegroundColor = ConsoleColor.Cyan;
                        //CenterText("Nombre: ");
                        //Console.ResetColor();

                        //Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                        //string nombreEliminado = Console.ReadLine();
                        //nodo.EliminarPorNombre(nombreEliminado);

                        CenterText("Inserte el anio de la pelicula a eliminar ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("Anio: ");
                        Console.ResetColor();

                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                        int anioEliminado = int.Parse(Console.ReadLine());
                        nodo.EliminarPorAnio(anioEliminado);
                        CenterText("EN EL AIRE WEON");
                    }
                    else if (menuOptions[selectedOptionIndex] == "Ordenar                 ")
                    {
                        CenterText("EN EL AIRE WEON");
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }
}