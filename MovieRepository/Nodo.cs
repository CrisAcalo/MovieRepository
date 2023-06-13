namespace MovieRepository
{
    internal class Nodo
    {
        public Pelicula pelicula;
        public Nodo sig;

        //constructor
        public Nodo(Pelicula peli = null)
        {
            this.pelicula = peli;
            this.sig = null;
        }

        //Metodo vacío para comprobar si la lista tiene datos o está vacía
        public bool Vacio()
        {
            if (this.sig == null && this.pelicula == null)
            {
                return true;
            }
            return false;
        }

        //Insertar un nodo al final de la lista
        public void InsertarFinal(Pelicula datoNuevo)
        {
            Nodo nuevo; //Nuevo nodo a insertar
            Nodo puntero = this;
            if (Vacio())
            {
                this.pelicula = datoNuevo;
            }
            else
            {
                while (puntero.sig != null)
                {
                    puntero = puntero.sig;
                }
                nuevo = new Nodo(datoNuevo);
                puntero.sig = nuevo;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            CenterText("");
            CenterText(">> La película " + puntero.pelicula.nombre + " del año " + puntero.pelicula.anio + " fue ingresada con éxito <<");
            Console.ResetColor();
        }

        public int count()
        {
            int i = 0;
            Nodo puntero = this;

            while (puntero.sig != null)
            {
                i++;
                puntero = puntero.sig;
            }
            return i + 1;
        }

        public void InertarInicio(Pelicula datoNuevo)
        {
            Nodo nuevo; //Nuevo nodo a insertar
            Nodo puntero = this;
            if (Vacio())
            {
                this.pelicula = datoNuevo;
            }
            else
            {
                nuevo = new Nodo(datoNuevo);
                this.sig = puntero;
                this.pelicula = nuevo.pelicula;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nEl nuevo dato " + datoNuevo + " fue ingresado al inicio de forma exitosa");
            Console.ResetColor();
        }

        public void validacionPrimerElemento()
        {
            Nodo nodonuevo = this;
            Console.WriteLine("El primer elemento es " + nodonuevo.pelicula);
        }
        public void ver()//mediante un for recorre los espacios y muestra el elemento de las lista
        {
            if (!Vacio())
            {
                Nodo puntero = this;
                int numElementos = 0;
                numElementos = puntero.count();

                CenterText("══════════════════════════════════");
                Console.ResetColor();
                for (int i = 0; i < numElementos; i++)//for que sirve para imprimir el contenido de la lista
                {
                    CenterText("Nombre: " + puntero.pelicula.nombre);
                    CenterText("Año: " + puntero.pelicula.anio);
                    if (i != (numElementos - 1))
                    {
                        //Console.Write("->");//Write imprime sin el salto de linea
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        CenterText("══════════════════════════════════");
                        Console.ResetColor();
                    }

                    puntero = puntero.sig;//salta cada puntero 
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterText("══════════════════════════════════");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("La lista esta vacia");
            }
        }


        static void CenterText(string text)
        {
            int windowWidth = Console.WindowWidth;
            int leftPadding = (windowWidth - text.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}