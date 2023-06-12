namespace MovieRepository
{
    internal class Nodo
    {
        public string contenido;
        public Nodo sig;

        //constructor
        public Nodo(String dato = null)
        {
            this.contenido = dato;
            this.sig = null;
        }

        //Metodo vacío para comprobar si la lista tiene datos o está vacía
        public bool Vacio()
        {
            if (this.sig == null && this.contenido == null)
            {
                return true;
            }
            return false;
        }

        //Insertar un nodo al final de la lista
        public void InsertarFinal(String datoNuevo)
        {
            Nodo nuevo; //Nuevo nodo a insertar
            Nodo puntero = this;
            if (Vacio())
            {
                this.contenido = datoNuevo;
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
            Console.WriteLine("El nuevo dato " + datoNuevo + " fue ingresado de forma exitosa");
        }

        public void InsertarDatosAleatorios()
        {
            InsertarFinal("Andrea Lopez");
            InsertarFinal("Andrea Perez");
            InsertarFinal("Andrea Mancheno");
            Console.WriteLine("Se ingresaron 3 elementos");
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

        public void InertarInicio(String datoNuevo)
        {
            Nodo nuevo; //Nuevo nodo a insertar
            Nodo puntero = this;
            if (Vacio())
            {
                this.contenido = datoNuevo;
            }
            else
            {
                nuevo = new Nodo(datoNuevo);
                this.sig = puntero;
                this.contenido = nuevo.contenido;
            }
            Console.WriteLine("El nuevo dato " + datoNuevo + " fue ingresado al inicio de forma exitosa");
        }

        public void validacionPrimerElemento()
        {
            Nodo nodonuevo = this;
            Console.WriteLine("El primer elemento es " + nodonuevo.contenido);
        }
    }

}