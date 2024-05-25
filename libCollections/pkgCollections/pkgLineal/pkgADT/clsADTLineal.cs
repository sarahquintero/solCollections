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
        public bool opBubbleSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            attItems = this.opToArray();
            for (int i = 0; i < attLength - 1; i++)
            {
                for (int j = 0; j < attLength - i - 1; j++)
                {
                    if ((prmByAscending && attItems[j].CompareTo(attItems[j + 1]) > 0) || (!prmByAscending && attItems[j].CompareTo(attItems[j + 1]) < 0))
                    {
                        T temp = attItems[j];
                        attItems[j] = attItems[j + 1];
                        attItems[j + 1] = temp;
                    }
                }
            }
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            this.opToItems(attItems, attLength);
            return true;
        }
        public bool opCocktailSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            attItems = this.opToArray();
            bool swapped = true;
            int start = 0;
            int end = attLength - 1;

            while (swapped)
            {
                swapped = false;

                for (int i = start; i < end; ++i)
                {
                    if ((prmByAscending && attItems[i].CompareTo(attItems[i + 1]) > 0) || (!prmByAscending && attItems[i].CompareTo(attItems[i + 1]) < 0))
                    {
                        T temp = attItems[i];
                        attItems[i] = attItems[i + 1];
                        attItems[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;
                end--;

                for (int i = end - 1; i >= start; i--)
                {
                    if ((prmByAscending && attItems[i].CompareTo(attItems[i + 1]) > 0) || (!prmByAscending && attItems[i].CompareTo(attItems[i + 1]) < 0))
                    {
                        T temp = attItems[i];
                        attItems[i] = attItems[i + 1];
                        attItems[i + 1] = temp;
                        swapped = true;
                    }
                }

                start++;
            }
            this.opToItems(attItems, attLength);
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            return true;
        }
        public bool opInsertSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            for (int i = 1; i < attLength; i++)
            {
                T key = attItems[i];
                int j = i - 1;
                while (j >= 0 && ((prmByAscending && attItems[j].CompareTo(key) > 0) || (!prmByAscending && attItems[j].CompareTo(key) < 0)))
                {
                    while (j >= 0 && ((prmByAscending && attItems[j].CompareTo(key) > 0) || (!prmByAscending && attItems[j].CompareTo(key) < 0)))
                    {
                        attItems[j + 1] = attItems[j];
                        j--;
                    }
                }
                attItems[j + 1] = key;
            }
            this.opToItems(attItems, attLength);
            attItsOrderedAscending = prmByAscending;
            attItsOrderedDescending = !prmByAscending;
            return true;
        }
        public bool opMergeSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            opMergeSortHelper(prmByAscending, 0, attLength - 1);
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            return true;
        }
        private void opMergeSortHelper(bool prmByAscending, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                opMergeSortHelper(prmByAscending, left, middle);
                opMergeSortHelper(prmByAscending, middle + 1, right);
                opMerge(prmByAscending, left, middle, right);
            }
        }
        private void opMerge(bool prmByAscending, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];

            for (int i = 0; i < n1; ++i)
                leftArray[i] = attItems[left + i];
            for (int j = 0; j < n2; ++j)
                rightArray[j] = attItems[middle + 1 + j];

            int p = 0;
            int q = 0;
            int k = left;

            while (p < n1 && q < n2)
            {
                if ((prmByAscending && leftArray[p].CompareTo(rightArray[q]) <= 0) || (!prmByAscending && leftArray[p].CompareTo(rightArray[q]) >= 0))
                {
                    attItems[k] = leftArray[p];
                    p++;
                }
                else
                {
                    attItems[k] = rightArray[q];
                    q++;
                }
                k++;
            }
            while (p < n1)
            {
                attItems[k] = leftArray[p];
                p++;
                k++;
            }
            while (q < n2)
            {
                attItems[k] = rightArray[q];
                q++;
                k++;
            }
        }
        public bool opQuickSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            opQuickSortHelper(prmByAscending, 0, attLength - 1);
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            return true;
        }
        private void opQuickSortHelper(bool prmByAscending, int low, int high)
        {
            int i = low;
            int j = high;
            T pivot = attItems[(low + high) / 2];
            do
            {
                if (prmByAscending)
                {
                    while (attItems[i].CompareTo(pivot) < 0) i++;
                    while (attItems[j].CompareTo(pivot) > 0) j--;
                }
                else
                {
                    while (attItems[i].CompareTo(pivot) > 0) i++;
                    while (attItems[j].CompareTo(pivot) < 0) j--;
                }
                if (i <= j)
                {
                    T temp = attItems[i];
                    attItems[i] = attItems[j];
                    attItems[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (low < j) opQuickSortHelper(prmByAscending, low, j);
            if (i < high) opQuickSortHelper(prmByAscending, i, high);
        }
        #endregion
        #endregion
    }
}
