using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgNodes.pkgInterfaces
{
    public interface iDoubleLinkedNode<T> where T : IComparable<T>
    {
        clsDoubleLinkedNode<T> opGetPrevious();
        clsDoubleLinkedNode<T> opGetNext();
        bool opSetPrevious(clsDoubleLinkedNode<T> prmNode);
        bool opSetNext(clsDoubleLinkedNode<T> prmNode);
    }
}
