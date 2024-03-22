using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTLineal<T> where T : IComparable<T>
    {
        #region Getters
        int opGetLength(T prmItem);
	#endregion
        #region Query
		int opFind(T prmItem);
        bool opExists(T prmItem);
        bool opItsEmpty();
        bool opItsValid();
        bool opItsOrderedAscending();
        bool opItsOrderedDescending(); 
	#endregion
        #region Serialize/Deserialize
		T[] opToArray();
        string opToString();
        bool opToItems(T[] prmArray);
        bool opToItems(T[] prmArray, int prmItemsCount);
        #endregion
        #region CRUDs
		bool opModify(int prmIdx, T prmItem);
        bool opRetrieve(int prmIdx, ref T prmItem);
        bool opSetCapacity(int prmValue);
        #endregion
    }
}
