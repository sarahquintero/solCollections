using System;
using pkgServicies.pkgCollections.pkgNodes.pkgInterfaces;

namespace pkgServicies.pkgCollections.pkgNodes
{
    public class clsNode<T> : iNode<T> where T : IComparable<T>
    {
        protected T attItem = default;
        protected clsNode() 
        {
        }
        public clsNode(T attItem)
        {
        }
        public T opGetItem() 
        {
            return attItem;
        }
        public bool opSetItem(T prmContent) 
        {
            return false;
        }
    }
}
