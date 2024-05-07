using System;
using pkgServices.pkgCollections.pkgNodes.pkgInterfaces;

namespace pkgServices.pkgCollections.pkgNodes
{
    public class clsNode<T> : iNode<T> where T : IComparable<T>
    {
        #region Attributes
        protected T attItem = default;
        #endregion
        #region Operations
        #region Builders
        protected clsNode()
        {
        }
        public clsNode(T attItem)
        {
        }
        #endregion
        #region Getter
        public T opGetItem()
        {
            return attItem;
        }
        #endregion
        #region Setter
        public bool opSetItem(T prmContent)
        {
            return false;
        }
        #endregion 
        #endregion
    }
}
