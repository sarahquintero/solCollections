using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    interface iADTLineal<T> where T : IComparable<T>
    {
        #region Getters
		int opGetLength(T prmItem); 
	#endregion
        #region Query
		int opFind(T prmItem);
        bool opExists(T prmItem);
        bool opItsEmpty();
        bool opIsValid();
        bool opItsOrderedAscending();
        bool opItsOrderedDescending(); 
	#endregion
        #region Serialize
		T[] opToArray();
        string opToString(); 
	#endregion
        #region Deserialize
		bool opToItems(T[] Array); 
	#endregion
        #region CRUDs
		bool opModify(int prmIdx, T prmItem);
        bool opRetrieve(int prmIdx, ref T prmItem); 
	#endregion 
    }
}
