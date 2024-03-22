using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorQueue<T> : iQueue<T> where T : IComparable<T>
    {
        protected T[] attItems = new T[100];
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (attItems.Count == 0)
            {
                prmItem = default(T);
                return false;
            }
            prmItem = attItems[attItems.Count - 1];
            return true;
        }
        public bool opPop(ref T prmItem)
        {
            if (attItems.Count == 0)
            {
                prmItem = default(T);
                return false;
            }
            prmItem = attItems[attItems.Count - 1];
            attItems.RemoveAt(attItems.Count - 1);
            return true;
        }
        public bool opPush(T prmItem)
        {
            attItems.Add(prmItem);
            return true;
        } 
	#endregion
    }
}
