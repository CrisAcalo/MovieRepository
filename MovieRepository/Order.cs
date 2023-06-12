namespace MovieRepository
{
    internal class Order
    {
        public Order()
        {
            //
        }
        static void OrdenarIntercambio(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        //Realizar el intercambio
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
                Ver(arr);
            }
        }

        static void Ver(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void OrdenarBurbuja(int[] arr)
        {
            int n = arr.Length;
            bool intercambio;
            int temp;
            for (int i = 0; i < n - 1; i++)
            {
                intercambio = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        //Realizar el intercambio
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        intercambio = true;
                    }

                    Console.WriteLine("Iteración: " + j);
                    Ver(arr);
                }
                //Si no hubo intercambios en esta pasada, la lista está ordenada
                if (!intercambio) //+1 de eficiencia
                {
                    Console.WriteLine("EN EL AIRE WEON!?");
                    break;
                }
            }
        }

        static void OrdenarAlfabeticamente(string[] palabras)
        {
            int intercambios = 0;
            bool intercambio;
            for (int i = 0; i < palabras.Length - 1; i++)
            {
                intercambio = false;
                for (int j = 0; j < palabras.Length - i - 1; j++)
                {
                    if (string.Compare(palabras[j], palabras[j + 1]) > 0)
                    {
                        string temp = palabras[j];
                        palabras[j] = palabras[j + 1];
                        palabras[j + 1] = temp;
                        intercambios++;
                        intercambio = true;
                    }
                }
                if (!intercambio) //+1 de eficiencia
                {
                    Console.WriteLine("EN EL AIRE WEON!?");
                    break;
                }
            }

            Console.WriteLine("El numero de intercambios realizados son: " + intercambios);
        }

        static void ImprimirElementos(string[] palabras)
        {
            int i = 0;
            foreach (string palabra in palabras)
            {
                Console.Write(palabra);
                if (i != palabras.Length - 1)
                {
                    Console.Write(", ");
                }
                i++;
            }
            Console.WriteLine();
        }


        static void ordenar_insertar(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            { //recorrer el arreglo desde el segundo elemento
                int valorActual = arr[i]; //guardar el valor actual
                int j = i - 1; //guardar el indice anterior
                while (j >= 0 && arr[j] > valorActual)
                { //mientras el indice anterior sea mayor o igual a 0 y el valor en el indice anterior sea mayor al valor actual
                    arr[j + 1] = arr[j]; //mover el valor en el indice anterior al siguiente indice
                    j--; //disminuir el indice anterior
                }
                arr[j + 1] = valorActual; //insertar el valor actual en el indice anterior
            }
        }

        static int ubicar_pivote(int[] lista, int ini, int fin)
        {
            int pivote = lista[ini];

            while (ini < fin)
            {
                while (ini < fin && lista[fin] >= pivote)
                {
                    fin--;
                }
                lista[ini] = lista[fin];
                while (ini < fin && lista[ini] <= pivote)
                {
                    ini++;
                }
                lista[fin] = lista[ini];
            }
            lista[ini] = pivote;

            return ini;
        }

        static void ordenar_quicksort(int[] lista, int ini, int fin)
        {
            if (ini < fin)
            {
                int pivote = ubicar_pivote(lista, ini, fin);
                ordenar_quicksort(lista, ini, pivote - 1);
                ordenar_quicksort(lista, pivote + 1, fin);
            }
        }

        static void ordenar_shellsort(int[] arr)
        {
            int n = arr.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
                gap /= 2;
            }
        }

        static void imprimir_arreglo_char(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void imprimir_arreglo(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}