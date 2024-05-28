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
        // We have the opBubbleSort method which returns a boolean value
        // The prmByAscending parameter tells us if the sorting is ascending (true) or descending (false)
        //tenemos el metodo opBubblesort que devuelve un valor booleano
        //El parametro prmBryAscending nos dice si el ordenamiento es ascendente  (true) o descendente  (false)
        public bool opBubbleSort(bool prmByAscending)
        {
            // Here we have a conditional that tells us if the length of the array is 0, meaning the list is empty.
            //Aqui tenemos un condicional que nos dice Si la longitud del array es 0, significa que la lista está vacía.
            if (attLength == 0)
            {
                // If attLength is equal to zero then attItems is assigned null
                //si attLengt es igual igual a cero entonces attItems se le asigna null
                attItems = null;
                // False is returned indicating that no sorting was performed.
                // se retorna false diciendo que no se realizó ningún ordenamiento
                return false;
            }
            // The internal data structure is converted to an array using the method opToArray().
            // This is necessary to perform the sorting using Bubble Sort.
            //Se convierte la estructura de datos interna a un array utilizando el método opToArray().
            //Esto es necesario para realizar el ordenamiento utilizando Bubble Sort
            attItems = this.opToArray();
            // A double for loop is used to implement the Bubble Sort algorithm.
            // The first for loop (with index i) controls the number of passes through the array
            //Se utiliza un doble bucle for para implementar el algoritmo de Bubble Sort.
            // El primer bucle for (con índice i) controla el número de pasadas por el array.
            for (int i = 0; i < attLength - 1; i++)
            {
                // The second for loop (with index j) compares adjacent elements in each pass and their possible swap
                // El segundo bucle for (con índice j) compara los elementos adyacentes en cada paso y su posible intercambio
                for (int j = 0; j < attLength - i - 1; j++)
                {
                    // The comparison variable stores the result of CompareTo between two adjacent elements
                    // La variable comparison almacena el resultado de CompareTo entre dos elementos adyacentes
                    int comparison = attItems[j].CompareTo(attItems[j + 1]);
                    // The if condition checks if the elements should be swapped based on the value of prmByAscending
                    // La condición if comprueba si los elementos deben intercambiarse según el valor de prmByAscending
                    if ((prmByAscending && comparison > 0) || (!prmByAscending && comparison < 0))
                    {
                        // A variable is declared to temporarily store the value of the current element at position j of the array attItems, attItems[j] is the value of the element at position j of the array
                        // se declara una variable,almacena temporalmente el valor del elemento actual en la posición j del array attItems, attItems[j] es el valor del elemento en la posición j del array
                        T temp = attItems[j];
                        // This line assigns the value of the next element (attItems[j + 1]) to the current position (attItems[j]).
                        // Esta línea asigna el valor del elemento siguiente (attItems[j + 1]) a la posición actual (attItems[j]).
                        attItems[j] = attItems[j + 1];
                        // This line assigns the temporary value (temp), which contains the original value of attItems[j], to the j + 1 position of the array.
                        // esta línea asigna el valor temporal (temp), que contiene el valor original de attItems[j], a la posición j + 1 del array.
                        attItems[j + 1] = temp;
                    }
                }
            }
            // The attItsOrderedAscending and attItsOrderedDescending flags are updated to reflect the sorting state.
            // Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar el estado del ordenamiento.
            // If prmByAscending is true, attItsOrderedAscending is set to true, indicating that the sorting is ascending.
            // Si prmByAscending es true, attItsOrderedAscending se establece en true, lo que indica que el ordenamiento es ascendente.
            // If prmByAscending is false, attItsOrderedAscending is set to false, indicating that the sorting is descending.
            // Si prmByAscending es false, attItsOrderedAscending se establece en false, lo que indica que el ordenamiento es descendente.
            attItsOrderedAscending = prmByAscending;
            // If prmByAscending is true, attItsOrderedDescending is set to false, indicating that the sorting is descending.
            // Si prmByAscending es true, attItsOrderedDescending se establece en false, lo que indica que el ordenamiento es descendente.
            // If prmByAscending is false, attItsOrderedDescending is set to true, indicating that the sorting is ascending.
            // Si prmByAscending es false, attItsOrderedDescending se establece en true, lo que indica que el ordenamiento es ascendente.
            attItsOrderedDescending = !prmByAscending;
            // The sorted array is converted back to the original data structure using the opToItems() method.
            // Se convierte el array ordenado de vuelta a la estructura de datos original utilizando el método opToItems().
            this.opToItems(attItems, attLength);
            // True is returned, indicating that a successful sort was performed.
            // Se retorna true, indicando que se realizó un ordenamiento exitoso.
            return true;
        }



        // This method is to sort the array in ascending or descending order, according to the value of prmByAscending.
        // este metodo es para ordenar el array de forma ascendente o descendente, según el valor de prmByAscending
        public bool opCocktailSort(bool prmByAscending)
        {
            // If attLength is 0 (i.e., if the array is empty), set attItems to null and return false, indicating that no sorting operation was performed.
            // Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems como null y retorna false, indicando que no se realizó ninguna operación de ordenamiento.
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            // The internal data structure is converted to an array using the opToArray() method.
            // Se convierte la estructura de datos interna a un array utilizando el método opToArray().
            attItems = this.opToArray();
            // swapped is a flag to check if swaps were made in a pass. It is initialized to true to enter the while loop.
            // swapped es una bandera para verificar si se realizaron intercambios en una pasada. Se inicializa en true para entrar en el bucle while.
            bool swapped = true;
            // start and end indicate the current limits of the array traversal.
            // start y end indican los límites actuales del recorrido en el arreglo
            int start = 0, end = attLength - 1;
            // The while loop runs while swapped is true and start is less than end.
            // El bucle while se ejecuta mientras swapped sea true y start sea menor que end
            while (swapped)
            {
                // swapped is set to false to indicate that no swaps were made in this pass.
                // swapped se establece en false para indicar que no se realizaron intercambios en esta pasada.
                swapped = false;
                // The for loop traverses the array from start to end.
                // El bucle for recorre el arreglo desde start hasta end.
                for (int i = start; i < end; ++i)
                {
                    // The comparison variable stores the result of CompareTo between two adjacent elements.
                    // La variable comparison almacena el resultado de CompareTo entre dos elementos adyacentes.
                    if ((prmByAscending && attItems[i].CompareTo(attItems[i + 1]) > 0) || (!prmByAscending && attItems[i].CompareTo(attItems[i + 1]) < 0))
                    {
                        // The elements at positions i and i + 1 are swapped.
                        // Se intercambian los elementos en las posiciones i y i + 1.
                        T temp = attItems[i];
                        // The value of the next element (attItems[i + 1]) is assigned to the current position.
                        // Se asigna el valor del elemento siguiente (attItems[i + 1]) a la posición actual.
                        attItems[i] = attItems[i + 1];
                        // The temporary value (temp) is assigned to position i + 1.
                        // Se asigna el valor temporal (temp) a la posición i + 1.
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
                        // swapped is set to true to indicate that a swap was made.
                        // Se establece swapped en true para indicar que se realizó un intercambio.
                        swapped = true;
                    }
                }
                // Increments start to reduce the comparison range.
                //Se incrementa start para reducir el rango de comparación.
                start++;
            }
            // Updates the flags attItsOrderedAscending and attItsOrderedDescending to reflect the sorting state.
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar el estado del ordenamiento.
            this.opToItems(attItems, attLength);
            // Sets the corresponding flag (attItsOrderedAscending or attItsOrderedDescending) according to the specified order by prmByAscending.
            //Se establece el flag correspondiente (attItsOrderedAscending o attItsOrderedDescending) según el orden especificado por prmByAscending.
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            // The method returns true indicating that the array has been correctly sorted.
            //El método retorna true indicando que el arreglo ha sido ordenado correctamente.
            return true;
        }
        // This method is for sorting the array in ascending or descending order, according to the value of prmByAscending.
        //este metodo es para ordenar el array de forma ascendente o descendente, según el valor de prmByAscending.
        public bool opInsertSort(bool prmByAscending)
        {
            // If attLength is 0 (i.e., if the array is empty), sets attItems
            //Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems
            if (attLength == 0)
            {
                // attItems is set to null and false is returned, indicating that no sorting operation was performed.
                //attItems se establece como null y se retorna false, indicando que no se realizó ning se retorna false, indicando que no se realizó ninguna operación de ordenamiento.
                attItems = null;
                return false;
            }
            // A for loop is used that starts at the second element (index 1) and iterates over all elements to the end of the list
            //Se utiliza un bucle for que empieza en el segundo elemento (índice 1) y recorre todos los elementos hasta el final de la lista
            for (int i = 1; i < attLength; i++)
            {
                // key stores the value of the current element being sorted
                //key almacena el valor del elemento actual que se está ordenando
                T key = attItems[i];
                // j stores the index of the element before the current element
                //j almacena el índice del elemento anterior al elemento actual
                int j = i - 1;
                // The while loop runs while j is greater than or equal to 0 and the value of the element at position j in the array is greater than the value of the current element at position i.
                //El bucle while se ejecuta mientras j sea mayor o igual a 0 y el valor del elemento en la posición j del arreglo sea mayor que el valor del elemento actual en la posición i.
                while (j >= 0 && ((prmByAscending && attItems[j].CompareTo(key) > 0) || (!prmByAscending && attItems[j].CompareTo(key) < 0)))
                {// The element at position j of the array is moved forward in the array, shifting the current element to the right.
                 //El elemento en la posición j del arreglo se mueve hacia adelante en el arreglo, desplazando el elemento actual hacia la derecha.
                    attItems[j + 1] = attItems[j];
                    // j is decremented to continue comparing with the previous element.
                    //j se decrementa para continuar comparando con el elemento anterior.
                    j--;
                }
                // The current element at position i of the array is placed in position j + 1
                //El elemento actual en la posición i del arreglo se coloca en la posición j + 1
                attItems[j + 1] = key;
            }
            // The flags attItsOrderedAscending and attItsOrderedDescending are updated to reflect the state
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar el
            this.opToItems(attItems, attLength);
            // Updates a flag to reflect that the list is ordered in ascending order if prmByAscending is true.
            //Actualiza un indicador para reflejar que la lista está ordenada en orden ascendente si prmByAscending es true.
            attItsOrderedAscending = prmByAscending;
            // Updates a flag to reflect that the list is ordered in descending order if prmByAscending is false.
            // Actualiza un indicador para reflejar que la lista está ordenada en orden descendente si prmByAscending es false.
            attItsOrderedDescending = !prmByAscending;
            // The method returns true indicating that the array has been correctly sorted.
            //El método retorna true indicando que el arreglo ha sido ordenado correctamente.
            return true;
        }

        // This method is for sorting the array using the merge sort algorithm in ascending or descending order, according to the value of prmByAscending.
        //este metodo es para ordenar el array usando el algoritmo de ordenación por mezcla (Merge Sort),de forma ascendente o descendente, según el valor de prmByAscending.
        public bool opMergeSort(bool prmByAscending)
        {
            // If attLength is 0 (i.e., if the array is empty), sets attItems
            //Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems
            if (attLength == 0)
            {
                // attItems is set to null and false is returned, indicating that no change was made
                //attItems se establece como null y se retorna false, indicando que no se realizó ningun cambio
                attItems = null;
                return false;
            }
            // Calls a helper method opMergeSortHelper that performs the merge sort recursively, passing the sorting order parameter, and also the start and end indices of the array.
            //Llama a un método auxiliar opMergeSortHelper que realiza la ordenación por mezcla recursivamente, pasando el parametro que indica el orden de ordenacion, y ademas de eso psas el indice de inicio y el indice final del arreglo.
            opMergeSortHelper(prmByAscending, 0, attLength - 1);
            // Updates the flags attItsOrderedAscending and attItsOrderedDescending to reflect that the list is ordered in ascending order.
            //Se actualizan las banderas attItsOrderedAscending y attItsOrderedDescending para reflejar que la lista está ordenada en orden ascendente.
            if (prmByAscending) attItsOrderedAscending = true;
            // If prmByAscending is false, updates attItsOrderedDescending to true, indicating that the list is ordered in descending order.
            //Si prmByAscending es false, actualiza attItsOrderedDescending a true, indicando que la lista está ordenada en orden descendent
            else attItsOrderedDescending = true;
            // Returns true to indicate that the sorting has been successfully completed.
            //Retorna true para indicar que la ordenación se ha completado con éxito
            return true;
        }
        // This method is for sorting the array using the merge sort algorithm recursively.
        //este metodo es para ordenar el array usando el algoritmo de ordenación por mezcla de forma recursiva
        private void opMergeSortHelper(bool prmByAscending, int left, int right)
        {
            // If left is less than right, it means there are at least two elements in the left part of the array.
            //Si left es menor que right, significa que hay al menos dos elementos en la parte izquierda del arreglo.
            if (left < right)
            {
                // The index of the middle element of the array is calculated.
                //Se calcula el índice del elemento medio del arreglo.
                int middle = (left + right) / 2;
                // Recursively calls opMergeSortHelper to sort the left part of the array.
                //Se llama recursivamente a opMergeSortHelper para ordenar la parte izquierda del arreglo
                opMergeSortHelper(prmByAscending, left, middle);
                // Recursively calls opMergeSortHelper to sort the right part of the array.
                //Se llama recursivamente a opMergeSortHelper para ordenar la parte derecha del arreglo
                opMergeSortHelper(prmByAscending, middle + 1, right);
                // Calls a helper method opMerge that combines the two sorted parts into one.
                //Se llama a un método auxiliar opMerge que combina las dos partes ordenadas en uno solo.
                opMerge(prmByAscending, left, middle, right);
            }
        }
        // Implement the merge operation in the context of the Merge Sort algorithm, with prmByAscending determining the sorting order, left as the index of the first element of the first subarray, middle as the index of the last element of the first subarray, and right as the index of the last element of the second subarray.
        // implementa la operación de fusión (merge) en el contexto del algoritmo de ordenamiento Merge Sort,el parametro prmBryAscebding determinando el orden de ordenacion, left el índice del último elemento del primer subarreglo, middle El índice del último elemento del segundo subarreglo,left,El índice del primer elemento del primer subarreglo
        private void opMerge(bool prmByAscending, int left, int middle, int right)
        {
            // Calculate the sizes of the two subarrays. n1 is the number of elements in the first subarray from left to middle. n2 is the number of elements in the second subarray from middle + 1 to right.
            //calculamos el tamaño de los dos subarreglos. n1 es el número de elementos en el primer subarreglo que va desde left hasta middle. n2 es el número de elementos en el segundo subarreglo que va desde middle + 1 hasta right.
            int n1 = middle - left + 1;
            int n2 = right - middle;
            // Create two temporary arrays, one for the elements of the first subarray and the other for the elements of the second subarray.
            //Creamos dos arreglos temporales, uno para los elementos del primer subarreglo y otro  
            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];
            // Copy the elements from the first subarray to leftArray, and copy the elements from the subarray attItems[middle + 1...right] to rightArray.
            //Copiamos los elementos del primer subarreglo al arreglo leftArray,  y los elementos del subarreglo attItems[middle + 1...right] se copian a rightArray.
            for (int i = 0; i < n1; ++i)
                leftArray[i] = attItems[left + i];
            for (int j = 0; j < n2; ++j)
                rightArray[j] = attItems[middle + 1 + j];
            // Use three indices, p to traverse leftArray, q to traverse rightArray, and k to indicate the current position in attItems.
            //Se utilizan tres índices, p para recorrer leftArray, q para recorrer rightArray y k para indicar la posición actual en attItems.
            int p = 0, q = 0, k = left;
            // The while loop runs while p is less than n1 and q is less than n2.
            //El bucle while se ejecuta mientras p sea menor que n1 y q sea menor que n2
            while (p < n1 && q < n2)
            {
                // Compare the element at position p of the first subarray with the element at position q of the second subarray.
                //Se compara el elemento en la posición p del primer subarreglo con el elemento en la posicion q del segundo subarreglo.
                if ((prmByAscending && leftArray[p].CompareTo(rightArray[q]) <= 0) || (!prmByAscending && leftArray[p].CompareTo(rightArray[q]) >= 0))
                {
                    // If the element at position p of the first subarray is less than or equal to the element at position q of the second subarray, copy the element at position p of the first subarray to position k of attItems.
                    //Si el elemento en la posición p del primer subarreglo es menor o igual al elemento en la posición q del segundo subarreglo, se copia el elemento en la posición p del
                    attItems[k] = leftArray[p];
                    // Increment p to move to the next element in leftArray.
                    //Se incrementa p para pasar al siguiente elemento en leftArray.
                    p++;
                }
                else
                {
                    // If the element at position p of the first subarray is greater than the element at position q of the second subarray, copy the element at position q of the second subarray to position k of attItems.
                    //Si el elemento en la posición p del primer subarreglo es mayor al elemento en la posicion Se copia el elemento en la posición q del segundo subarreglo en la posición k del
                    attItems[k] = rightArray[q];
                    // Increment q to move to the next element in rightArray.
                    //Se incrementa q para pasar al siguiente elemento en rightArray.
                    q++;
                }
                // Increment k to move to the next element in attItems.
                //Se incrementa k para pasar al siguiente elemento en attItems.
                k++;
            }
            // If there are elements remaining in rightArray after one of the subarrays has been exhausted, copy them to the original array:
            //Si quedan elementos en rightArray después de que uno de los subarreglos se ha agotado, se copian al arreglo original:
            while (p < n1)
            {
                // Copy the element at position p of the first subarray to position k of attItems.
                //Se copia el elemento en la posición p del primer subarreglo en la posición k del
                attItems[k] = leftArray[p];
                // Increment p to move to the next element in leftArray.
                //Se incrementa p para pasar al siguiente elemento en leftArray.
                p++;
                // Increment k to move to the next element in attItems.
                //Se incrementa k para pasar al siguiente elemento en attItems.
                k++;
            }
            // If there are elements remaining in leftArray after one of the subarrays has been exhausted:
            //Si quedan elementos en leftArray después de que uno de los subarreglos se ha agotado
            while (q < n2)
            {
                // Copy the element at position q of the second subarray to position k of attItems.
                //Se copia el elemento en la posición q del segundo subarreglo en la posición k del
                attItems[k] = rightArray[q];
                // Increment q to move to the next element in rightArray.
                //Se incrementa q para pasar al siguiente elemento en rightArray.
                q++;
                // Increment k to move to the next element in attItems.
                //Se incrementa k para pasar al siguiente elemento en attItems.
                k++;

            }
        }
        // Este método es para ordenar el array usando el algoritmo de Quick Sort, de forma ascendente o descendente, según el valor de prmByAscending.
        // This method is for sorting the array using the Quick Sort algorithm, either in ascending or descending order based on prmByAscending.
        public bool opQuickSort(bool prmByAscending)
        {
            // Si attLength es 0 (es decir, si el arreglo está vacío), establece attItems a null y retorna false, indicando que no se realizó ningún cambio.
            // If attLength is 0 (i.e., if the array is empty), set attItems to null and return false, indicating that no changes were made.
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            // Llama a un método auxiliar opQuickSortHelper que realiza la ordenación por partes recursivamente.
            // Call an auxiliary method opQuickSortHelper that performs recursive sorting in parts.
            opQuickSortHelper(prmByAscending, 0, attLength - 1);
            // Si prmByAscending es true, actualiza attItsOrderedAscending a true, indicando que la lista está ordenada en orden ascendente. Si prmByAscending es false, actualiza attItsOrderedDescending a true, indicando que la lista está ordenada en orden descendente.
            // If prmByAscending is true, update attItsOrderedAscending to true, indicating that the list is sorted in ascending order. If prmByAscending is false, update attItsOrderedDescending to true, indicating that the list is sorted in descending order.
            if (prmByAscending)
                attItsOrderedAscending = true;
            else
                attItsOrderedDescending = true;
            // Retorna true para indicar que la ordenación se ha completado con éxito.
            // Return true to indicate that the sorting has been successfully completed.
            return true;
        }
        // This method is a recursive version of QuickSort and allows sorting in ascending or descending order based on the prmByAscending parameter.
        // Este método es una versión recursiva del QuickSort y permite ordenar en orden ascendente o descendente según el valor del parámetro prmByAscending.
        private void opQuickSortHelper(bool prmByAscending, int low, int high)
        {
            // These are the initial indices that will traverse the list from the edges towards the center.
            // Son los índices iniciales que recorrerán la lista desde los extremos hacia el centro.
            int i = low, j = high;
            // Pivot is the pivot element, chosen as the middle value of the current segment of the list. This pivot is used as a reference to divide the list into sublists that will be sorted recursively.
            // Pivot es el elemento pivote, elegido como el valor medio del segmento actual de la lista. Este pivote se utiliza como referencia para dividir la lista en sublistas que serán ordenadas recursivamente.
            T pivot = attItems[(low + high) / 2];
            // The while loop runs while i is less than j.
            // El bucle while se ejecuta mientras i sea menor que j.
            do
            {
                // If prmByAscending is true.
                // Si prmByAscending es true.
                if (prmByAscending)
                {
                    // Increment i until an element that is not less than the pivot is found.
                    // Incrementa i hasta encontrar un elemento que no es menor que el pivote.
                    while (attItems[i].CompareTo(pivot) < 0) i++;
                    // Decrement j until an element that is not greater than the pivot is found.
                    // Decrementa j hasta encontrar un elemento que no es mayor que el pivote.
                    while (attItems[j].CompareTo(pivot) > 0) j--;
                }
                // If prmByAscending is false.
                // Si prmByAscending es false.
                else
                {
                    // Increment i until an element that is not greater than the pivot is found.
                    // Incrementa i hasta encontrar un elemento que no es mayor que el pivote.
                    while (attItems[i].CompareTo(pivot) > 0) i++;
                    // Decrement j until an element that is not less than the pivot is found.
                    // Decrementa j hasta encontrar un elemento que no es menor que el pivote.
                    while (attItems[j].CompareTo(pivot) < 0) j--;
                }
                // If i is less than j, the elements at positions i and j are swapped.
                // Si i es menor que j, se intercambian los elementos en las posiciones i y j.
                if (i <= j)
                {
                    // A temporary variable temp of type T is created and assigned the value of the element at position i in the attItems list. This is necessary to not lose the value while performing the swap.
                    // Se crea una variable temporal temp de tipo T y se le asigna el valor del elemento en la posición i de la lista attItems. Esto es necesario para no perder el valor mientras se realiza el intercambio.
                    T temp = attItems[i];
                    // The value of the element at position j in the attItems list is assigned to position i.
                    // Se asigna el valor del elemento en la posición j de la lista attItems a la posición i.
                    attItems[i] = attItems[j];
                    // The value of temp is assigned to position j in the attItems list. This is necessary to not lose the value while performing the swap.
                    // Se asigna el valor de temp a la posición j de la lista attItems. Esto es necesario para no perder el valor mientras se realiza el intercambio.
                    attItems[j] = temp;
                    // Increment i and decrement j to continue the partitioning process.
                    // Se incrementa i y se decrementa j para continuar el proceso de partición.
                    i++;
                    j--;
                }
                // while i is less than or equal to j.
                // mientras i sea menor igual que j.
            } while (i <= j);
            // Recursively call opQuickSortHelper to sort the left subsegment (from low to j).
            // Se llama recursivamente a opQuickSortHelper para ordenar el subsegmento izquierdo (desde low hasta j).
            if (low < j) opQuickSortHelper(prmByAscending, low, j);
            // if (i < high): Recursively call opQuickSortHelper to sort the right subsegment (from i to high).
            // if (i < high): Se llama recursivamente a opQuickSortHelper para ordenar el subsegmento derecho (desde i hasta high).
            if (i < high) opQuickSortHelper(prmByAscending, i, high);
        }
        #endregion
        #endregion
    }
}
