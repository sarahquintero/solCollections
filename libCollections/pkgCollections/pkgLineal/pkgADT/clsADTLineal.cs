using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T>: iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLength = 0;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        protected static int attMaxCapacity = int.MaxValue / 16;
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
                T[]attItems = new T[attLength];
            }
            catch (Exception e)
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
            if (attItems.All(item => item.Equals(default(T))))
            {
                // Si todos los elementos son nulos o el valor predeterminado de T, no hay orden definido
                return false;
            }

            HashSet<T> uniqueElements = new HashSet<T>();
            for (int i = 0; i < attLength; i++)
            {
                if (EqualityComparer<T>.Default.Equals(attItems[i], default(T)))
                {
                    return false;
                }
                if (!uniqueElements.Add(attItems[i]))
                {
                    // Si se encuentra un elemento repetido, no está ordenado en forma ascendente
                    return false;
                }
            }
            for (int i = 1; i < attLength; i++)
            {
                if (Comparer<T>.Default.Compare(attItems[i], attItems[i - 1]) <= 0)
                {
                    // Si encuentra dos elementos consecutivos que no están en orden ascendente, retorna falso
                    return false;
                }
            }
            // Si no se encontró ningún par de elementos consecutivos en orden descendente, retorna verdadero
            return false;
        }
        public bool opItsOrderedDescending()
        {
            if (attItems.All(item => item.Equals(default(T))))
            {
                // Si todos los elementos son nulos o el valor predeterminado de T, no hay orden definido
                return false;
            }

            HashSet<T> uniqueElements = new HashSet<T>();
            for (int i = 0; i < attLength; i++)
            {
                if (EqualityComparer<T>.Default.Equals(attItems[i], default(T)))
                {
                    return false;
                }
                if (!uniqueElements.Add(attItems[i]))
                {
                    // Si se encuentra un elemento repetido, no está ordenado en forma descendente
                    return false;
                }
            }

            for (int i = 1; i < attLength; i++)
            {
                if (Comparer<T>.Default.Compare(attItems[i], attItems[i - 1]) >= 0)
                {
                    // Si encuentra dos elementos consecutivos que no están en orden descendente, retorna falso
                    return false;
                }
            }
            // Si no se encontró ningún par de elementos consecutivos en orden ascendente, retorna verdadero
            return false;
        }
        #endregion
        #region Getters
        public int opGetLength()
        {
            return attLength;
        }
        #endregion
        #region Serialize/Deserialize
        public virtual T[] opToArray()
        {
            throw new NotImplementedException();
        }
        public String opToString()
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray, int prmItemsCount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUDs
        public bool opModify(int prmIdx, T prmItem)
        {
            int prmItemsCount = 0;
            T[] prmArray = new T[attLength];
            if (prmIdx >= 0 && prmIdx < prmItemsCount)
            {
                prmArray[prmIdx] = prmItem;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool opRetrieve(int prmIdx, ref T prmItem)
        {
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
        #endregion
    }
}
