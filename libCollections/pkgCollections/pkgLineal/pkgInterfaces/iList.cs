using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    interface iList<T> where T : IComparable<T>
    {
        bool Add(ref T prmItem);
        bool Insert(ref int ldx, T prmItem);
        bool Remove(ref int ldx, T prmItem);
    }
}
