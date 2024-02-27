using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    interface iADTLineal<T> where T : IComparable<T>
    {
        bool opModify(int prmIdx, T prmItem);
        bool opRetrieve(int prmIdx, ref T prmItem);
        int opFind(T prmItem);
        bool opExists(T prmItem);
        int opGetLength(T prmItem);
        T[] opToArray();
        string opToString();
    }
}
