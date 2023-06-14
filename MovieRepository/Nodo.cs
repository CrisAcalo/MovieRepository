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
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterText("══════════════════════════════════");
                Console.ResetColor();
                for (int i = 0; i < numElementos; i++)//for que sirve para imprimir el contenido de la lista
                {
                    CenterText("Nombre: " + puntero.pelicula.nombre);
                    CenterText("Año: " + puntero.pelicula.anio);
                    if (i != (numElementos - 1))
                    {
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


        public void eliminarPrimero()
        {
            Nodo puntero;//Apuntador que se ubicara en el 2do nodo

            if (!Vacio())//Solo se puede eliminar si la lista contiene dato
            {
                if (this.sig == null)
                {
                    this.pelicula = null;
                }
                else//hay almenos 2 elementos en la Lista
                {
                    puntero = this.sig;
                    //Se copia el contenido del 2do nodo en el 1ro
                    this.pelicula.nombre = puntero.pelicula.nombre;
                    this.pelicula.anio = puntero.pelicula.anio;
                    //Se hace apuntar el primer nodo al 3er nodo
                    this.sig = puntero.sig;
                    puntero.sig = null;
                }
            }
        }


        public void EliminarPorNombre(string nombre)
        {
            Nodo puntero = this;
            Nodo anterior = null;

            if (!Vacio())
            {
                while (puntero != null)
                {
                    if (puntero.pelicula.nombre == nombre)
                    {
                        if (puntero == this)
                        {
                            eliminarPrimero();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nLa pelicula " + nombre + " fue eliminada   ");
                            Console.ResetColor();
                            return;
                        }
                        else
                        {
                            if (anterior == null)
                                puntero = puntero.sig;
                            else
                                anterior.sig = puntero.sig;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nLa pelicula " + nombre + " fue eliminada   ");
                            Console.ResetColor();
                            return;
                        }

                    }
                    anterior = puntero;
                    puntero = puntero.sig;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nLa pelicula " + nombre + " no esta dentro de la lista");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("La lista esta vacia");
                Console.ResetColor();
            }
        }

        public void EliminarPorAnio(int anio)
        {
            Nodo puntero = this;
            Nodo anterior = null;

            if (!Vacio())
            {
                while (puntero != null)
                {
                    if (puntero.pelicula.anio == anio)
                    {
                        if (puntero == this)
                        {
                            eliminarPrimero();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nLa pelicula " + anio + " fue eliminada   ");
                            Console.ResetColor();
                            return;
                        }
                        else
                        {
                            if (anterior == null)
                                puntero = puntero.sig;
                            else
                                anterior.sig = puntero.sig;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nLa pelicula " + anio + " fue eliminada   ");
                            Console.ResetColor();
                            return;
                        }

                    }
                    anterior = puntero;
                    puntero = puntero.sig;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nLa pelicula " + anio + " no esta dentro de la lista");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("La lista esta vacia");
                Console.ResetColor();
            }
        }

        public void OrdenarBurbuja()
        {
            Nodo puntero1, puntero2;
            Pelicula temp;
            int longitud = count();

            for (int i = 0; i < longitud - 1; i++)
            {
                puntero1 = this;
                puntero2 = this.sig;

                for (int j = 0; j < longitud - i - 1; j++)
                {
                    if (puntero1.pelicula.anio > puntero2.pelicula.anio)
                    {
                        // Realizar el intercambio de películas
                        temp = puntero1.pelicula;
                        puntero1.pelicula = puntero2.pelicula;
                        puntero2.pelicula = temp;
                    }

                    puntero1 = puntero1.sig;
                    puntero2 = puntero2.sig;
                }
            }
        }


        public void OrdenarAlfabeticamenteBurbuja()
        {
            Nodo puntero1, puntero2;
            string temp;
            int longitud = count();

            for (int i = 0; i < longitud - 1; i++)
            {
                puntero1 = this;
                puntero2 = this.sig;

                for (int j = 0; j < longitud - i - 1; j++)
                {
                    if (string.Compare(puntero1.pelicula.nombre, puntero2.pelicula.nombre) > 0)
                    {
                        // Realizar el intercambio de nombres de películas
                        temp = puntero1.pelicula.nombre;
                        puntero1.pelicula.nombre = puntero2.pelicula.nombre;
                        puntero2.pelicula.nombre = temp;
                    }

                    puntero1 = puntero1.sig;
                    puntero2 = puntero2.sig;
                }
            }
        }
    }
}