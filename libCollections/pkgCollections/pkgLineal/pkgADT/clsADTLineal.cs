﻿using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
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
            if (prmByAscending)
            {
                if (attLength == 0)
                {
                    attItems = null;
                    return false;
                }
                int lenght = attLength;
                attItems = this.opToArray();
                for (int i = 0; i < lenght - 1; i++)
                {
                    for (int j = 0; j < lenght - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) > 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                        }
                    }
                }
                this.opToItems(attItems, attLength);
                attItsOrderedAscending = true;
                return true;
            }
            else
            {
                if (attLength == 0)
                {
                    attItems = null;
                    return false;
                }
                int lenght = attLength;
                attItems = this.opToArray();
                for (int i = 0; i < lenght - 1; i++)
                {
                    for (int j = 0; j < lenght - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) < 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                        }
                    }
                }
                this.opToItems(attItems, attLength);
                attItsOrderedDescending = true;
                return true;
            }
        }
        public bool opCocktailSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            attItems = this.opToArray();
            int length = attLength;
            if (prmByAscending)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = i; j < length - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) > 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;

                    swapped = false;
                    for (int j = length - i - 2; j > i; j--)
                    {
                        if (attItems[j].CompareTo(attItems[j - 1]) < 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j - 1];
                            attItems[j - 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
                this.opToItems(attItems, attLength);
                attItsOrderedAscending = true;
                return true;
            }
            else
            {
                for (int i = 0; i < length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = i; j < length - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) < 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;

                    swapped = false;
                    for (int j = length - i - 2; j > i; j--)
                    {
                        if (attItems[j].CompareTo(attItems[j - 1]) > 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j - 1];
                            attItems[j - 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
                this.opToItems(attItems, attLength);
                attItsOrderedDescending = true;
                return true;
            }
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
                    attItems[j + 1] = attItems[j];
                    j--;
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
            this.opToItems(attItems, attLength);
            attItsOrderedAscending = prmByAscending;
            attItsOrderedDescending = !prmByAscending;

            MergeSort(attItems, 0, attLength - 1, prmByAscending);
            return true;
        }
        private void MergeSort(T[] attItems, int left, int right, bool attItsOrderedAscending)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(attItems, left, middle, attItsOrderedAscending);
                MergeSort(attItems, middle + 1, right, attItsOrderedAscending);

                Merge(attItems, left, middle, right, attItsOrderedAscending);
            }
        }
        private void Merge(T[] attItems, int left, int middle, int right, bool ascending)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;
            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];
            Array.Copy(attItems, left, leftArray, 0, n1);
            Array.Copy(attItems, middle + 1, rightArray, 0, n2);
            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if ((ascending && leftArray[i].CompareTo(rightArray[j]) <= 0) || (!ascending && leftArray[i].CompareTo(rightArray[j]) >= 0))
                {
                    attItems[k] = leftArray[i];
                    i++;
                }
                else
                {
                    attItems[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                attItems[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                attItems[k] = rightArray[j];
                j++;
                k++;
            }
        }
        private void Swap(T[] attItems, int i, int j)
        {
            T temp = attItems[i];
            attItems[i] = attItems[j];
            attItems[j] = temp;
        }

        private int Partition(T[] attItems, int low, int high, bool ascending)
        {
            T pivot = attItems[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if ((ascending && attItems[j].CompareTo(pivot) < 0) || (!ascending && attItems[j].CompareTo(pivot) > 0))
                {
                    i++;
                    Swap(attItems, i, j);
                }
            }
            Swap(attItems, i + 1, high);
            return i + 1;
        }
        private void QuickSort(T[] attItems, int low, int high, bool ascending)
        {
            if (low < high)
            {
                int partition = Partition(attItems, low, high, ascending);
                QuickSort(attItems, low, partition - 1, ascending);
                QuickSort(attItems, partition + 1, high, ascending);
            }
        }
        public bool opQuickSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }

            QuickSort(attItems, 0, attLength - 1, prmByAscending);
            this.opToItems(attItems, attLength);
            attItsOrderedAscending = prmByAscending;
            attItsOrderedDescending = !prmByAscending;
            return true;
        }
        #endregion
        #endregion
    }
}
