using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedList<T> : clsADTDoubleLinked<T>, iList<T> where T : IComparable<T>
    {
        public clsDoubleLinkedList()
        {
            attLength = 0;
            attItems = null;
        }
        public bool opAdd(T prmItem)
        {
            clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
            newNode.opSetItem(prmItem);
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[attLength - 1] = prmItem;
            for (int i = 0; i < attLength - 1; i++)
            {
                prmArray[i] = attItems[i];
            }
            attItems = prmArray;
            return true;
        }
        public bool opInsert(int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(int Idx, ref T prmItem)
        {
            throw new NotImplementedException();
        }
    }
}
