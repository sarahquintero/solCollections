using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgIterators;
using System;
using System.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T> : clsIterator<T>, iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attTotalCapacity = 100;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        protected static int attMaxCapacity = int.MaxValue / 32;//64
        protected T[] attItems = new T[100];
        #endregion
        #region Builders
        public clsADTLineal()
        {
        }
        public clsADTLineal(int attLength)
        {
            try
            {
                if (attLength < 0) attLength = 0;
                T[] attItems = new T[attLength];
            }
            catch
            {
                T[] attItems = new T[attLength];
                attLength = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
            }
        }
        #endregion
        #region Operations
        #region Query
        public bool opItsEmpty()
        {
            throw new NotImplementedException();
        }
        public int opFind(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opExists(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opItsOrderedAscending()
        {
            if (attItems == null) return false;
            return attItsOrderedAscending;

        }
        public bool opItsOrderedDescending()
        {
            if (attItems == null) return false;
            return attItsOrderedDescending;
        }
        #endregion
        #region Getters
        public int opGetLength()
        {
            return attLength;
        }
        public static int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }
        #endregion
        #region Serialize/Deserialize
        public virtual T[] opToArray()
        {
            if (attItems == null)
            {
                return null;
            }
            if (attLength == 0)
            {
                T[] prmArray = new T[100];
                for (int i = 0; i < 100; i++)
                {
                    prmArray[i] = attItems[i];
                }
                return prmArray;
            }
            if (attLength == attItems.Length / 2)
            {
                T[] prmarray = new T[attItems.Length];
                for (int i = 0; i < attItems.Length; i++)
                {
                    prmarray[i] = attItems[i];
                }
                return prmarray;
            }
            if (attLength != attItems.Length)
            {
                T[] array = new T[attLength + 1];
                for (int i = 0; i < attLength + 1; i++)
                {
                    array[i] = attItems[i];
                }
                return array;
            }
            T[] result = new T[attLength];
            for (int i = 0; i < attLength; i++)
            {
                result[i] = attItems[i];
            }
            return result;
        }
        public String opToString()
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray)
        {
            attItems = prmArray;
            return true;
        }
        public virtual bool opToItems(T[] prmArray, int prmItemsCount)
        {
            attLength = prmItemsCount;
            attItems = prmArray;
            return true;
        }
        #endregion
        #region CRUDs
        public virtual bool opModify(int prmIdx, T prmItem)
        {
            if (!opGo(prmIdx)) return false;
            return opSetCurrentItem(prmItem);
        }
        public virtual bool opRetrieve(int prmIdx, ref T prmItem)
        {
            if (attItems == null) return false;
            if (prmIdx >= 0 && prmIdx < attLength)
            {
                prmItem = attItems[prmIdx];
                return true;
            }
            else
            {
                prmItem = default(T);
                return false;
            }
        }
        public bool opReverse()
        {
            T[] prmArray = new T[attLength];
            prmArray.Reverse();
            return true;
        }
        public int opGetLength(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opItsValid(int prmIndex)
        {
            throw new NotImplementedException();
        }
        public bool opItsValid()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Sorting
        //tenemos el metodo opBubblesort que devuelve un valor booleano
        //El parametro prmBryAscending nos dice si el ordenamiento es ascendente  (true) o descendente  (false)
        public bool opBubbleSort(bool prmByAscending)
        {
            //Aqui tenemos un condicional que nos dice Si la longitud del array es 0, significa que la lista está vacía.
            if (attLength == 0)
            {
                //si attLengt es igual igual a cero entonces attItems se le asigna null
                attItems = null;
                //se retorna false diciendo que no se realizó ningún ordenamiento.
                return false;
            }
            //Se convierte la estructura de datos interna a un array utilizando el método opToArray().
            //Esto es necesario para realizar el ordenamiento utilizando Bubble Sort
            attItems = this.opToArray();
            //Se utiliza un doble bucle for para implementar el algoritmo de Bubble Sort.
            // El primer bucle for (con índice i) controla el número de pasadas por el array.
            for (int i = 0; i < attLength - 1; i++)
            {
                //El segundo bucle for (con índice j) compara los elementos adyacentes en cada paso y su posible intercambio
                for (int j = 0; j < attLength - i - 1; j++)
                {
                    //La variable comparison almacena el resultado de CompareTo entre dos elementos adyacentes
                    int comparison = attItems[j].CompareTo(attItems[j + 1]);
                    //La condición if comprueba si los elementos deben intercambiarse según el valor de prmByAscending
                    if ((prmByAscending && comparison > 0) || (!prmByAscending && comparison < 0))
                    {
                        //se declara una variable,almacena temporalmente el valor del elemento actual en la posición j del array attItems,attItems[j] es el valor del elemento en la posición j del array
                        T temp = attItems[j];
                        //Esta línea asigna el valor del elemento siguiente (attItems[j + 1]) a la posición actual (attItems[j]).
                        attItems[j] = attItems[j + 1];
                        //esta línea asigna el valor temporal (temp), que contiene el valor original de attItems[j], a la posición j + 1 del array.
                        attItems[j + 1] = temp;
                    }
                }
            }
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar el estado del ordenamiento.
            //Si prmByAscending es true, attItsOrderedAscending se establece en true, lo que indica que el ordenamiento es ascendente.
            //Si prmByAscending es false, attItsOrderedAscending se establece en false, lo que indica que el ordenamiento es descendente.
            attItsOrderedAscending = prmByAscending;
            //Si prmByAscending es true, attItsOrderedDescending se establece en false, lo que indica que el ordenamiento es desc
            //Si prmByAscending es false, attItsOrderedDescending se establece en true, lo que indica que el ordenamiento es ascend
            attItsOrderedDescending = !prmByAscending;
            //Se convierte el array ordenado de vuelta a la estructura de datos original utilizando el método opToItems().
            this.opToItems(attItems, attLength);
            //Se retorna true, indicando que se realizó un ordenamiento exitoso.
            return true;
        }



        //este metodo es para ordenar el array de forma ascendente o descendente, según el valor de prmByAscending.
        public bool opCocktailSort(bool prmByAscending)
        {
            //Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems como null y retorna false, indicando que no se realizó ninguna operación de ordenamiento.
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            //Se convierte la estructura de datos interna a un array utilizando el método opToArray().
            attItems = this.opToArray();
            //swapped es una bandera para verificar si se realizaron intercambios en una pasada. Se inicializa en true para entrar en el bucle while.
            bool swapped = true;
            //start y end indican los límites actuales del recorrido en el arreglo
            int start = 0, end = attLength - 1;
            //El bucle while se ejecuta mientras swapped sea true y start sea menor que end.
            while (swapped)
            {
                //swapped se establece en false para indicar que no se realizaron intercambios en esta
                swapped = false;
                //El bucle for recorre el arreglo desde start hasta end.
                for (int i = start; i < end; ++i)
                {
                    //La variable comparison almacena el resultado de CompareTo entre dos elementos adyacentes.
                    if ((prmByAscending && attItems[i].CompareTo(attItems[i + 1]) > 0) || (!prmByAscending && attItems[i].CompareTo(attItems[i + 1]) < 0))
                    {
                        //Se intercambian los elementos en las posiciones i y i + 1.
                        T temp = attItems[i];
                        //Se asigna el valor del elemento siguiente (attItems[i + 1]) a la posición actual
                        attItems[i] = attItems[i + 1];
                        //Se asigna el valor temporal (temp) a la posición i + 1
                        attItems[i + 1] = temp;
                        //Se establece swapped en true para indicar que se realizó un intercambio
                        swapped = true;
                    }
                }
                //Si swapped es false, significa que no se realizó ningún intercambio en esta pas
                if (!swapped)
                    break;
                //swapped se establece en false para indicar que no se realizaron intercambios en esta pasada
                swapped = false;
                //se ajusta end para reducir el rango de comparación.
                end--;
                //El bucle for recorre el arreglo desde end hasta start.
                for (int i = end - 1; i >= start; i--)
                {
                    //La variable comparison almacena el resultado de CompareTo entre dos elementos adyacentes.
                    if ((prmByAscending && attItems[i].CompareTo(attItems[i + 1]) > 0) || (!prmByAscending && attItems[i].CompareTo(attItems[i + 1]) < 0))
                    {
                        //Se intercambian los elementos en las posiciones i y i + 1.
                        T temp = attItems[i];
                        //Se asigna el valor del elemento siguiente (attItems[i + 1]) a la posición actual
                        attItems[i] = attItems[i + 1];
                        //Se asigna el valor temporal (temp) a la posición i + 1
                        attItems[i + 1] = temp;
                        //Se establece swapped en true para indicar que se realizó un intercambio
                        swapped = true;
                    }
                }
                //Se incrementa start para reducir el rango de comparación.
                start++;
            }
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar el estado del ordenamiento.
            this.opToItems(attItems, attLength);
            //Se establece el flag correspondiente (attItsOrderedAscending o attItsOrderedDescending) según el orden especificado por prmByAscending.
            if (prmByAscending) attItsOrderedAscending = true;

            else attItsOrderedDescending = true;
            //El método retorna true indicando que el arreglo ha sido ordenado correctamente.
            return true;
        }
        //este metodo es para ordenar el array de forma ascendente o descendente, según el valor de prmByAscending.
        public bool opInsertSort(bool prmByAscending)
        {
            //Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems
            if (attLength == 0)
            {
                //attItems se establece como null y se retorna false, indicando que no se realizó ning se retorna false, indicando que no se realizó ninguna operación de ordenamiento.
                attItems = null;
                return false;
            }
            //Se utiliza un bucle for que empieza en el segundo elemento (índice 1) y recorre todos los elementos hasta el final de la lista
            for (int i = 1; i < attLength; i++)
            {
                //key almacena el valor del elemento actual que se está ordenando
                T key = attItems[i];
                //j almacena el índice del elemento anterior al elemento actual
                int j = i - 1;
                //El bucle while se ejecuta mientras j sea mayor o igual a 0 y el valor del elemento en la posición j del arreglo sea mayor que el valor del elemento actual en la posición i.
                while (j >= 0 && ((prmByAscending && attItems[j].CompareTo(key) > 0) || (!prmByAscending && attItems[j].CompareTo(key) < 0)))
                {
                    //El elemento en la posición j del arreglo se mueve hacia adelante en el arreglo, desplazando el elemento actual hacia la derecha.
                    attItems[j + 1] = attItems[j];
                    //j se decrementa para continuar comparando con el elemento anterior.
                    j--;
                }
                //El elemento actual en la posición i del arreglo se coloca en la posición j + 1
                attItems[j + 1] = key;
            }
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar el
            this.opToItems(attItems, attLength);
            //Actualiza un indicador para reflejar que la lista está ordenada en orden ascendente si prmByAscending es true.
            attItsOrderedAscending = prmByAscending;
            // Actualiza un indicador para reflejar que la lista está ordenada en orden descendente si prmByAscending es false.
            attItsOrderedDescending = !prmByAscending;
            //El método retorna true indicando que el arreglo ha sido ordenado correctamente.
            return true;
        }

        //este metodo es para ordenar el array usando el algoritmo de ordenación por mezcla (Merge Sort),de forma ascendente o descendente, según el valor de prmByAscending.
        public bool opMergeSort(bool prmByAscending)
        {
            //Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems
            if (attLength == 0)
            {
                //attItems se establece como null y se retorna false, indicando que no se realizó ningun cambio
                attItems = null;
                return false;
            }
            //Llama a un método auxiliar opMergeSortHelper que realiza la ordenación por mezcla recursivamente, pasando el parametro que indica el orden de ordenacion, y ademas de eso psas el indice de inicio y el indice final del arreglo.
            opMergeSortHelper(prmByAscending, 0, attLength - 1);
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar que la lista está ordenada en orden ascendente.
            if (prmByAscending) attItsOrderedAscending = true;
            //Si prmByAscending es false, actualiza attItsOrderedDescending a true, indicando que la lista está ordenada en orden descendent
            else attItsOrderedDescending = true;
            //Retorna true para indicar que la ordenación se ha completado con éxito
            return true;
        }
        //este metodo es para ordenar el array usando el algoritmo de ordenación por mezcla de forma recursiva
        private void opMergeSortHelper(bool prmByAscending, int left, int right)
        {
            //Si left es menor que right, significa que hay al menos dos elementos en la parte izquierda del arreglo.
            if (left < right)
            {
                //Se calcula el índice del elemento medio del arreglo.
                int middle = (left + right) / 2;
                //Se llama recursivamente a opMergeSortHelper para ordenar la parte izquierda del arreglo
                opMergeSortHelper(prmByAscending, left, middle);
                //Se llama recursivamente a opMergeSortHelper para ordenar la parte derecha del arreglo
                opMergeSortHelper(prmByAscending, middle + 1, right);
                //Se llama a un método auxiliar opMerge que combina las dos partes ordenadas en uno solo.
                opMerge(prmByAscending, left, middle, right);
            }
        }
        // implementa la operación de fusión (merge) en el contexto del algoritmo de ordenamiento Merge Sort,el parametro prmBryAscebding determinando el orden de ordenacion, left el índice del último elemento del primer subarreglo, middle El índice del último elemento del segundo subarreglo,left,El índice del primer elemento del primer subarreglo
        private void opMerge(bool prmByAscending, int left, int middle, int right)
        {
            //calculamos el tamaño de los dos subarreglos. n1 es el número de elementos en el primer subarreglo que va desde left hasta middle. n2 es el número de elementos en el segundo subarreglo que va desde middle + 1 hasta right.
            int n1 = middle - left + 1;
            int n2 = right - middle;
            //Creamos dos arreglos temporales, uno para los elementos del primer subarreglo y otro  
            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];
            //Copiamos los elementos del primer subarreglo al arreglo leftArray,  y los elementos del subarreglo attItems[middle + 1...right] se copian a rightArray.
            for (int i = 0; i < n1; ++i)
                leftArray[i] = attItems[left + i];
            for (int j = 0; j < n2; ++j)
                rightArray[j] = attItems[middle + 1 + j];
            //Se utilizan tres índices, p para recorrer leftArray, q para recorrer rightArray y k para indicar la posición actual en attItems.
            int p = 0, q = 0, k = left;
            //El bucle while se ejecuta mientras p sea menor que n1 y q sea menor que n2
            while (p < n1 && q < n2)
            {
                //Se compara el elemento en la posición p del primer subarreglo con el elemento en la posicion q del segundo subarreglo.
                if ((prmByAscending && leftArray[p].CompareTo(rightArray[q]) <= 0) || (!prmByAscending && leftArray[p].CompareTo(rightArray[q]) >= 0))
                {
                    //Si el elemento en la posición p del primer subarreglo es menor o igual al elemento en la posición q del segundo subarreglo, se copia el elemento en la posición p del
                    attItems[k] = leftArray[p];
                    //Se incrementa p para pasar al siguiente elemento en leftArray.
                    p++;
                }
                else
                {
                    //Si el elemento en la posición p del primer subarreglo es mayor al elemento en la posicion Se copia el elemento en la posición q del segundo subarreglo en la posición k del
                    attItems[k] = rightArray[q];
                    //Se incrementa q para pasar al siguiente elemento en rightArray.
                    q++;
                }
                //Se incrementa k para pasar al siguiente elemento en attItems.
                k++;
            }
            //Si quedan elementos en rightArray después de que uno de los subarreglos se ha agotado, se copian al arreglo original:
            while (p < n1)
            {
                //Se copia el elemento en la posición p del primer subarreglo en la posición k del
                attItems[k] = leftArray[p];
                //Se incrementa p para pasar al siguiente elemento en leftArray.
                p++;
                //Se incrementa k para pasar al siguiente elemento en attItems.
                k++;
            }
            //Si quedan elementos en leftArray después de que uno de los subarreglos se ha agotado
            while (q < n2)
            {
                //Se copia el elemento en la posición q del segundo subarreglo en la posición k del
                attItems[k] = rightArray[q];
                //Se incrementa q para pasar al siguiente elemento en rightArray.
                q++;
                //Se incrementa k para pasar al siguiente elemento en attItems.
                k++;

            }
        }
        public bool opQuickSort(bool prmByAscending)
        {
            //Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems
            if (attLength == 0)
            {
                //attItems se establece como null y se retorna false, indicando que no se realizó ningun cambio
                attItems = null;
                return false;
            }
            //Llama a un método auxiliar opQuickSortHelper que realiza la ordenación por partes recursivamente,
            opQuickSortHelper(prmByAscending, 0, attLength - 1);
            //Si prmByAscending es true, actualiza attItsOrderedAscending a true, indicando que la lista está ordenada en orden ascendente, Si prmByAscending es false, actualiza attItsOrderedDescending a true, indicando que la lista está ordenada en orden descendente.
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            //Retorna true para indicar que la ordenación se ha completado con éxito
            return true;
        }
        // Este método es una versión recursiva del QuickSort y permite ordenar en orden ascendente o descendente según el valor del parámetro prmByAscending
        private void opQuickSortHelper(bool prmByAscending, int low, int high)
        {
            //son los índices iniciales que recorrerán la lista desde los extremos hacia el centro
            int i = low, j = high;
            //pivot es el elemento pivote, elegido como el valor medio del segmento actual de la lista. Este pivote se utiliza como referencia para dividir la lista en sublistas que serán ordenadas recursivamente
            T pivot = attItems[(low + high) / 2];
            //El bucle while se ejecuta mientras i sea menor que j
            do
            {
                //Si prmByAscending es true
                if (prmByAscending)
                {
                    //Incrementa i hasta encontrar un elemento que no es menor que el pivote.
                    while (attItems[i].CompareTo(pivot) < 0) i++;
                    //Decrementa j hasta encontrar un elemento que no es mayor que el pivote.
                    while (attItems[j].CompareTo(pivot) > 0) j--;
                }
                //Si prmByAscending es false
                else
                {
                    //Incrementa i hasta encontrar un elemento que no es mayor que el pivote.
                    while (attItems[i].CompareTo(pivot) > 0) i++;
                    //Decrementa j hasta encontrar un elemento que no es menor que el pivote.
                    while (attItems[j].CompareTo(pivot) < 0) j--;
                }
                //Si i es menor que j, se intercambian los elementos en las posiciones i y j
                if (i <= j)
                {
                    //Se crea una variable temporal temp de tipo T y se le asigna el valor del elemento en la posición i de la lista attItems, Esto es necesario para no perder el valor mientras se realiza el intercambio.
                    T temp = attItems[i];
                    //Se asigna el valor del elemento en la posición j de la lista attItems a la posición i
                    attItems[i] = attItems[j];
                    //Se asigna el valor de temp a la posición j de la lista attItems,esto es necesario para no perder el valor mientras se realiza el intercambio.
                    attItems[j] = temp;
                    //Se incrementa i y se decrementa j para continuar el proceso de partición.
                    i++;
                    j--;
                }
                //mientras i sea menor igual que j
            } while (i <= j);
            //Se llama recursivamente a opQuickSortHelper para ordenar el subsegmento izquierdo (desde low hasta j).
            if (low < j) opQuickSortHelper(prmByAscending, low, j);
            //if (i < high): Se llama recursivamente a opQuickSortHelper para ordenar el subsegmento derecho (desde i hasta high).
            if (i < high) opQuickSortHelper(prmByAscending, i, high);
        }
        #endregion
        #endregion
    }
}
