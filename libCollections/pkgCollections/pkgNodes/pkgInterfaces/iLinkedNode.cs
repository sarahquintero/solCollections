using System;

namespace pkgServicies.pkgCollections.pkgNodes.pkgInterfaces
{
    public interface iLinkedNode<T> where T : IComparable<T>
    {
        clsLinkedNode<T> opGetNext();
        bool opSetNext(clsLinkedNode<T> prmNode);
    }
}
