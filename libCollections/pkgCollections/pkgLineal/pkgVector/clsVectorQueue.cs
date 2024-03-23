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
        #region Attributes
        protected T[] attItems = new T[100]; 
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            return true;
        }
        public bool opPop(ref T prmItem)
        {
            return true;
        }
        public bool opPush(T prmItem)
        {
            return true;
        } 
	#endregion
    }
}
