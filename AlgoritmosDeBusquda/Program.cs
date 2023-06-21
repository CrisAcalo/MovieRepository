namespace AlgoritmosDeBusquda
{

    internal class Program
    {

        public static int ubicar_pivote(int[] lista, int ini, int fin)
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

        public static void ordenar_quicksort(int[] lista, int ini, int fin)
        {
            if (ini < fin)
            {
                int pivote = ubicar_pivote(lista, ini, fin);
                ordenar_quicksort(lista, ini, pivote - 1);
                ordenar_quicksort(lista, pivote + 1, fin);
            }
        }

        public static void ordenar_shellsort(int[] arr)
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
        public static int BusquedaBinaria_Menor(int[] arr)
        {
            int menor = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < menor)
                {
                    menor = arr[i];
                }
            }
            return menor;
        }

        public static int BusquedaBinaria_Mayor(int[] arr)
        {
            int mayor = arr[arr.Length - 1];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > mayor)
                {
                    mayor = arr[i];
                }
            }
            return mayor;
        }

        public static int BusquedaBinaria_Elemento(int[] arr, int elemento_buscado)
        {
            int encontrado = -1;
            bool bandera = false;
            int comparaciones = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == elemento_buscado)
                {
                    encontrado = i;
                    bandera = true;
                    break;
                }
                comparaciones++;
            }
            if (bandera)
            {
                Console.WriteLine("El elemento " + elemento_buscado + " se ha encontrado en la posicion: " + encontrado + ". Con " + comparaciones + " comparaciones.");
                return encontrado;
            }
            else
            {
                Console.WriteLine("El elemento " + elemento_buscado + " no existe");
                return encontrado;
            }

        }

        public static int busquedaBinaria(int[] arr, int elemento_buscado)
        {
            int inf = 0;
            int sup = arr.Length - 1; 
            int central = 0;

            while (inf <= sup)
            {
                central = (inf + sup) / 2;
                if (arr[central] == elemento_buscado)
                {
                    return central;
                }
                else if (elemento_buscado < arr[central])
                {
                    sup = central - 1;
                }
                else
                {
                    inf = central + 1;
                }   

            }

            return -1;
        }
        static void Ver(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int aBuscar = 48;
            int[] array = { 22, 6, 25, 48, 32, 5, 12, 20, 31, 35 };
            Ver(array);
            int menor = BusquedaBinaria_Menor(array);
            Console.WriteLine("El elemento menor es: " + menor);
            int mayor = BusquedaBinaria_Mayor(array);

            Console.WriteLine("El elemento mayor es: " + mayor);
            //int buscados = BusquedaBinaria_Elemento(array,20);

            //ordenar_shellsort(array);
            ordenar_quicksort(array, 0, array.Length - 1);
            
            Ver(array);
            int buscado = busquedaBinaria(array, aBuscar);
            Console.WriteLine("El elemento " + aBuscar + " fue encontrado en la posicion " + buscado);



        }
    }
}