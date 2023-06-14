using MovieRepository;
using System.Diagnostics;

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

        Pelicula nuevaPelicula1 = new Pelicula("A", 2010);
        Pelicula nuevaPelicula2 = new Pelicula("D", 2011);
        Pelicula nuevaPelicula3 = new Pelicula("C", 2012);
        Pelicula nuevaPelicula4 = new Pelicula("B", 2013);
        Pelicula nuevaPelicula5 = new Pelicula("E", 2014);
        nodo.InsertarFinal(nuevaPelicula5);
        nodo.InsertarFinal(nuevaPelicula4);
        nodo.InsertarFinal(nuevaPelicula3);
        nodo.InsertarFinal(nuevaPelicula1);
        nodo.InsertarFinal(nuevaPelicula2);

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
                        return;
                    }
                    else if (menuOptions[selectedOptionIndex] == "Ingresar película       ")
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║        Nueva Pelicula        ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();
                        AñadirPelicula(nodo);

                    }
                    else if (menuOptions[selectedOptionIndex] == "Ver películas ingresadas")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║      Peliculas Actuales      ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();
                        nodo.ver();
                    }
                    else if (menuOptions[selectedOptionIndex] == "Eliminar película(s)    ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║     Eliminar Película(s)     ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();

                        EliminarAtributoSubmenu(nodo);

                    }
                    else if (menuOptions[selectedOptionIndex] == "Ordenar                 ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║       Ordenar Películas      ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();

                        OrdenarAtributoSubmenu(nodo);
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void AñadirPelicula(Nodo nodo)
    {
        string nombre;
        string año;
        int añoInteger = 0;
        bool isValidInput = false;

        CenterText("Inserte los datos de la película ");

        Console.ForegroundColor = ConsoleColor.Cyan;
        CenterText("Nombre: ");
        Console.ResetColor();

        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
        nombre = Console.ReadLine();
        while (nombre == "" || nombre == null || nombre == " ")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CenterText("..:: Debe tener un nombre :) ::..");
            Console.ResetColor();
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

    private static void OrdenarAtributoSubmenu(Nodo nodo)
    {
        Console.Clear();

        string[] menuOptions = {
            "Ordenar por nombre      ",
            "Ordenar por año         ",
            "Atrás                   "
        };

        int selectedOptionIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterText("╔════════════════════════════╗");
            CenterText("║                            ║");
            CenterText("║          Ordenar           ║");
            CenterText("║                            ║");
            CenterText("╚════════════════════════════╝");
            Console.ResetColor();
            CenterText("");
            CenterText("Seleccione el atributo a ordenar:");
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
                        return;
                    }
                    else if (menuOptions[selectedOptionIndex] == "Ordenar por nombre      ")
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║      Ordenar Por Nombre      ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();
                        ordenarMetodoSubmenu(nodo, "nombre");
                    }
                    else if (menuOptions[selectedOptionIndex] == "Ordenar por año         ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║        Ordenar por año       ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();
                        ordenarMetodoSubmenu(nodo, "anio");
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ordenarMetodoSubmenu(Nodo nodo, string atributo)
    {
        Console.Clear();

        string[] menuOptions = {
            "Burbuja                 ",
            "Shell                   ",
            "Quick                   ",
            "Atrás                   "
        };

        int selectedOptionIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterText("╔════════════════════════════╗");
            CenterText("║                            ║");
            CenterText("║    Metodo de Ordenación    ║");
            CenterText("║                            ║");
            CenterText("╚════════════════════════════╝");
            Console.ResetColor();
            CenterText("");
            CenterText("Seleccione el algoritmo a usar:");
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
                        return;
                    }
                    else if (menuOptions[selectedOptionIndex] == "Burbuja                 ")
                    {
                        try
                        {
                            if (atributo == "nombre")
                            {
                                nodo.OrdenarAlfabeticamenteBurbuja();
                                Console.ForegroundColor = ConsoleColor.Green;
                                CenterText("El ordenamiento alfabetico por Burbuja se ha ejecutado con exito");
                                Console.ResetColor();
                            }
                            else if (atributo == "anio")
                            {
                                nodo.OrdenarBurbuja();
                                Console.ForegroundColor = ConsoleColor.Green;
                                CenterText("El ordenamiento por año por Burbuja se ha ejecutado con exito");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            CenterText("Ha ocurrido un problema con el algoritmo de la Burbuja...");
                            Console.ResetColor();
                            throw;
                        }
                    }
                    else if (menuOptions[selectedOptionIndex] == "Shell                   ")
                    {
                        try
                        {
                            if (atributo == "nombre")
                            {
                                nodo.OrdenarAlfabeticamenteBurbuja();
                                Console.ForegroundColor = ConsoleColor.Green;
                                CenterText("El ordenamiento alfabetico por SellSort se ha ejecutado con exito");
                                Console.ResetColor();
                            }
                            else if (atributo == "anio")
                            {
                                nodo.OrdenarShellSort();

                                Console.ForegroundColor = ConsoleColor.Green;
                                CenterText("El ordenamiento por año por SellSort se ha ejecutado con exito");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            CenterText("Ha ocurrido un problema con el algoritmo Shell...");
                            Console.ResetColor();
                            throw;
                        }
                    }
                    else if (menuOptions[selectedOptionIndex] == "Quick                   ")
                    {
                        try
                        {
                            if (atributo == "nombre")
                            {
                                nodo.OrdenarPorNombreQuick();
                                Console.ForegroundColor = ConsoleColor.Green;
                                CenterText("El ordenamiento alfabetico por Quick se ha ejecutado con exito");
                                Console.ResetColor();
                            }
                            else if (atributo == "anio")
                            {
                                nodo.OrdenarPorAnioQuick();
                                Console.ForegroundColor = ConsoleColor.Green;
                                CenterText("El ordenamiento por año por Quick se ha ejecutado con exito");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            CenterText("Ha ocurrido un problema con el algoritmo de Quick...");
                            Console.ResetColor();
                            throw;
                        }
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void EliminarAtributoSubmenu(Nodo nodo)
    {
        Console.Clear();

        string[] menuOptions = {
            "Eliminar por nombre      ",
            "Eliminar por año         ",
            "Atrás                   "
        };

        int selectedOptionIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterText("╔════════════════════════════╗");
            CenterText("║                            ║");
            CenterText("║          Eliminar          ║");
            CenterText("║                            ║");
            CenterText("╚════════════════════════════╝");
            Console.ResetColor();
            CenterText("");
            CenterText("Seleccione el atributo a eliminar:");
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
                        return;
                    }
                    else if (menuOptions[selectedOptionIndex] == "Eliminar por nombre      ")
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║      Eliminar Por Nombre     ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();

                        CenterText("Inserte el nombre de la pelicula a eliminar ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("Nombre: ");
                        Console.ResetColor();

                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                        string nombreEliminado = Console.ReadLine();
                        nodo.EliminarPorNombre(nombreEliminado);
                    }
                    else if (menuOptions[selectedOptionIndex] == "Eliminar por año         ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("╔══════════════════════════════╗");
                        CenterText("║                              ║");
                        CenterText("║        Eliminar por año      ║");
                        CenterText("║                              ║");
                        CenterText("╚══════════════════════════════╝");
                        Console.ResetColor();

                        CenterText("Inserte el anio de la pelicula a eliminar ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("Anio: ");
                        Console.ResetColor();

                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                        int anioEliminado = int.Parse(Console.ReadLine());
                        nodo.EliminarPorAnio(anioEliminado);
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }
}