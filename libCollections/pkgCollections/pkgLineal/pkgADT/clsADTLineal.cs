using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgADT
{
    class clsADTLineal<T>: iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLenght = 0;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        #endregion
        #region Getters
        public int opGetLenght()
        {
            return attLenght;
        }
        #endregion
        #region Serialize/DesSerialize
        public T[] opToArray()
        {
            throw new NotImplementedException();
        }

        public String opToString()
        {
            throw new NotImplementedException();
        }

        public bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUDs
        public bool opModify(int prmIdx, T prmItem)
        {
            if (prmIdx >= 0 && prmIdx < items.Count)
            {
                attItems[prmIdx] = prmItem;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool opRetrieve(int prmIdx, ref T prmItem)
        {
            if (prmIdx >= 0 && prmIdx < items.Count)
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
            attItems.Reverse();
            return true;
        }
        #endregion
    }
}
