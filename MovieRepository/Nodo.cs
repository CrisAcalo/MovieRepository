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
                            Console.WriteLine("\nLa pelicula del " + anio + " fue eliminada   ");
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
                            Console.WriteLine("\nLa pelicula del " + anio + " fue eliminada   ");
                            Console.ResetColor();
                            return;
                        }

                    }
                    anterior = puntero;
                    puntero = puntero.sig;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nLa pelicula del " + anio + " no esta dentro de la lista");
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
            int n = count();
            bool intercambio;
            Nodo temp;

            for (int i = 0; i < n - 1; i++)
            {
                intercambio = false;
                Nodo puntero = this;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (puntero.pelicula.anio > puntero.sig.pelicula.anio)
                    {
                        // Realizar el intercambio
                        temp = new Nodo(puntero.pelicula);
                        puntero.pelicula = puntero.sig.pelicula;
                        puntero.sig.pelicula = temp.pelicula;

                        intercambio = true;
                    }

                    puntero = puntero.sig;
                }

                if (!intercambio)
                {
                    break;
                }
            }
        }

        public void OrdenarAlfabeticamenteBurbuja()
        {
            int n = count();
            bool intercambio;
            Nodo temp;

            for (int i = 0; i < n - 1; i++)
            {
                intercambio = false;
                Nodo puntero = this;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(puntero.pelicula.nombre, puntero.sig.pelicula.nombre) > 0)
                    {
                        // Realizar el intercambio
                        temp = new Nodo(puntero.pelicula);
                        puntero.pelicula = puntero.sig.pelicula;
                        puntero.sig.pelicula = temp.pelicula;

                        intercambio = true;
                    }

                    puntero = puntero.sig;
                }

                if (!intercambio)
                {
                    break;
                }
            }
        }

        public void OrdenarShellSort()
        {
            int longitud = count();
            int gap = longitud / 2;

            while (gap > 0)
            {
                Nodo puntero1 = this;
                Nodo puntero2 = this;

                // Mover el puntero 2 a la posición gap en la lista
                for (int i = 0; i < gap; i++)
                    puntero2 = puntero2.sig;

                while (puntero2 != null)
                {
                    bool intercambio = false;

                    // Obtener las películas a comparar
                    Pelicula pelicula1 = puntero1.pelicula;
                    Pelicula pelicula2 = puntero2.pelicula;

                    if (pelicula1.anio > pelicula2.anio)
                    {
                        // Realizar el intercambio de películas
                        puntero1.pelicula = pelicula2;
                        puntero2.pelicula = pelicula1;
                        intercambio = true;
                    }

                    if (intercambio)
                    {
                        // Retroceder los punteros para verificar si hay más intercambios
                        puntero1 = this;
                        puntero2 = this;

                        for (int i = 0; i < gap; i++)
                            puntero2 = puntero2.sig;
                    }
                    else
                    {
                        // Avanzar los punteros
                        puntero1 = puntero1.sig;
                        puntero2 = puntero2.sig;
                    }
                }

                gap /= 2;
            }
        }

        public void OrdenarShellSortAlfabeticamente()
        {
            int longitud = count();
            int gap = longitud / 2;

            while (gap > 0)
            {
                for (int i = gap; i < longitud; i++)
                {
                    Nodo puntero1 = this;
                    Nodo puntero2 = this;
                    int j = i;

                    // Mover los punteros a las posiciones correspondientes en la lista
                    for (int k = 0; k < j; k++)
                        puntero1 = puntero1.sig;

                    for (int k = 0; k < j - gap; k++)
                        puntero2 = puntero2.sig;

                    // Obtener la película a comparar
                    Pelicula pelicula1 = puntero1.pelicula;
                    Pelicula pelicula2 = puntero2.pelicula;

                    while (j >= gap && string.Compare(pelicula2.nombre, pelicula1.nombre) < 0)
                    {
                        // Realizar el intercambio de películas
                        puntero1.pelicula = pelicula2;
                        puntero2.pelicula = pelicula1;

                        // Mover los punteros hacia atrás en la lista
                        j -= gap;
                        puntero1 = puntero2;
                        puntero2 = this;
                        for (int k = 0; k < j; k++)
                            puntero2 = puntero2.sig;

                        // Actualizar las películas a comparar
                        pelicula1 = puntero1.pelicula;
                        pelicula2 = puntero2.pelicula;
                    }
                }
                gap /= 2;
            }
        }

        public void OrdenarPorAnioQuick()
        {
            if (this == null || this.sig == null)
            {
                return; // La lista está vacía o solo tiene un elemento, no hay nada que ordenar
            }

            Nodo ultimo = ObtenerUltimoNodo();
            QuicksortPorAnio(this, ultimo);
        }

        public void OrdenarPorNombreQuick()
        {
            if (this == null || this.sig == null)
            {
                return; // La lista está vacía o solo tiene un elemento, no hay nada que ordenar
            }

            Nodo ultimo = ObtenerUltimoNodo();
            QuicksortPorNombre(this, ultimo);
        }

        public void QuicksortPorAnio(Nodo inicio, Nodo fin)
        {
            if (inicio != fin && inicio != null && fin != null)
            {
                Nodo pivote = UbicarPivoteAnio(inicio, fin);
                QuicksortPorAnio(inicio, pivote);
                QuicksortPorAnio(pivote.sig, fin);
            }
        }

        public void QuicksortPorNombre(Nodo inicio, Nodo fin)
        {
            if (inicio != fin && inicio != null && fin != null)
            {
                Nodo pivote = UbicarPivoteNombre(inicio, fin);
                QuicksortPorNombre(inicio, pivote);
                QuicksortPorNombre(pivote.sig, fin);
            }
        }

        public Nodo UbicarPivoteNombre(Nodo inicio, Nodo fin)
        {
            string pivote = inicio.pelicula.nombre;
            Nodo puntero1 = inicio.sig;
            Nodo puntero2 = inicio;

            while (puntero1 != fin.sig)
            {
                if (string.Compare(puntero1.pelicula.nombre, pivote) < 0)
                {
                    puntero2 = puntero2.sig;
                    IntercambiarNodos(puntero1, puntero2);
                }
                puntero1 = puntero1.sig;
            }

            IntercambiarNodos(inicio, puntero2);
            return puntero2;
        }

        public Nodo UbicarPivoteAnio(Nodo inicio, Nodo fin)
        {
            int pivote = inicio.pelicula.anio;
            Nodo puntero1 = inicio.sig;
            Nodo puntero2 = inicio;

            while (puntero1 != fin.sig)
            {
                if (puntero1.pelicula.anio < pivote)
                {
                    puntero2 = puntero2.sig;
                    IntercambiarNodos(puntero1, puntero2);
                }
                puntero1 = puntero1.sig;
            }

            IntercambiarNodos(inicio, puntero2);
            return puntero2;
        }

        private Nodo ObtenerUltimoNodo()
        {
            Nodo puntero = this;
            while (puntero.sig != null)
            {
                puntero = puntero.sig;
            }
            return puntero;
        }

        private void IntercambiarNodos(Nodo nodo1, Nodo nodo2)
        {
            Pelicula temp = nodo1.pelicula;
            nodo1.pelicula = nodo2.pelicula;
            nodo2.pelicula = temp;
        }

        public Pelicula BuscarSecuencialNombre(Nodo nodo, string elemento_buscado)
        {
            Pelicula encontrado = null;
            //bool bandera = false;
            int comparaciones = 1;
            Nodo puntero = this;

            while (puntero.sig != null)
            {
                if (puntero.pelicula.nombre == elemento_buscado)
                {
                    encontrado = puntero.pelicula;
                    //bandera = true;
                    break;
                }
                comparaciones++;
                puntero = puntero.sig;
            }

            if (encontrado != null)
            {
                CenterText("El elemento: \n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterText("══════════════════════════════════");
                Console.ResetColor();

                CenterText("Nombre: " + encontrado.nombre);
                CenterText("Año: " + encontrado.anio);

                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterText("══════════════════════════════════");
                Console.ResetColor();

                CenterText("Se ha encontrado en la posición: " + comparaciones);


                //Console.WriteLine("El elemento " + elemento_buscado + " se ha encontrado en la posicion: " + encontrado + ". Con " + comparaciones + " comparaciones.")
                return encontrado;
            }
            else
            {
                CenterText("La película llamada " + elemento_buscado + " no existe");
                return encontrado;
            }

        }

        public Pelicula BuscarSecuencialAnio(Nodo nodo, int elemento_buscado)
        {
            Pelicula encontrado = null;
            //bool bandera = false;
            int comparaciones = 1;
            Nodo puntero = this;

            while (puntero.sig != null)
            {
                if (puntero.pelicula.anio == elemento_buscado)
                {
                    encontrado = puntero.pelicula;
                    //bandera = true;
                    break;
                }
                comparaciones++;
                puntero = puntero.sig;
            }

            if (encontrado != null)
            {
                CenterText("El elemento: \n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterText("══════════════════════════════════");
                Console.ResetColor();

                CenterText("Nombre: " + encontrado.nombre);
                CenterText("Año: " + encontrado.anio);

                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterText("══════════════════════════════════");
                Console.ResetColor();

                CenterText("Se ha encontrado en la posición: " + comparaciones);


                //Console.WriteLine("El elemento " + elemento_buscado + " se ha encontrado en la posicion: " + encontrado + ". Con " + comparaciones + " comparaciones.")
                return encontrado;
            }
            else
            {
                CenterText("La película del año " + elemento_buscado + " no existe");
                return encontrado;
            }
<<<<<<< HEAD
        }

        public Pelicula BusquedaBinariaPorNombre(Nodo nodo,string nombreBuscado)
        {
            int inicio = 0;
            int fin = count() - 1;
            int comparaciones = 1;

            while (inicio <= fin)
            {
                int central = (inicio + fin) / 2;
                Nodo nodoMedio = ObtenerNodoEnPosicion(nodo, central);

                int comparacion = string.Compare(nodoMedio.pelicula.nombre, nombreBuscado);

                if (comparacion == 0)
                {
                    CenterText("Se ha encontrado con: " + comparaciones + " comparaciones");
                    return nodoMedio.pelicula;// Se encontró la película
                }
                else if (comparacion < 0)
                    inicio = central + 1;// La película está en la mitad derecha
                else
                    fin = central - 1;// La película está en la mitad izquierda
                comparaciones++;
            }
            return null;// No se encontró la película

        }

        public Pelicula BusquedaBinariaPorAnio(Nodo nodo,int anioBuscado)
        {
            int inicio = 0;
            int fin = count() - 1;
            int comparaciones = 1;

            while (inicio <= fin)
            {
                int central = (inicio + fin) / 2;
                Nodo nodoMedio = ObtenerNodoEnPosicion(nodo,central);

                if (nodoMedio.pelicula.anio == anioBuscado)
                {
                    CenterText("Se ha encontrado con: " + comparaciones + " comparaciones");
                    return nodoMedio.pelicula; // Se encontró la película
                }
                else if (nodoMedio.pelicula.anio < anioBuscado)
                {
                    inicio = central + 1; // La película está en la mitad derecha
                }
                else
                {
                    fin = central - 1; // La película está en la mitad izquierda
                }
                comparaciones++;
            }
            return null;// No se encontró la película
        }

        //Obtiene El nodo segun sea la posicion que se solicita
        public Nodo ObtenerNodoEnPosicion(Nodo puntero, int posicion)
        {
            int contador = 0;

            while(puntero != null)
            {
                if (contador == posicion)
                    break;
                contador++;
                puntero = puntero.sig;
            }
            return puntero;
        }

=======

        }

>>>>>>> 58f329737e6f8f71fef7d005d67b2acae3326408
    }
}