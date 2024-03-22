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
        bool opInsert(ref int ldx, T prmItem);
        bool opRemove(ref int ldx, T prmItem);
        #endregion
    }
}
