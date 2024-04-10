using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iList<T> where T : IComparable<T>
    {
        #region CRUDs
		bool opAdd(ref T prmItem);
        bool opInsert(ref int Idx, T prmItem);
        bool opRemove(ref int Idx, T prmItem);
        //bool opModify(ref int Idx, T prmItem);
        #endregion
        #region Query
        int opFind(T Item);
        bool opExists(T Item); 
        #endregion
    }
}
