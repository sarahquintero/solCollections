﻿using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgLinked
{
    public class clsLinkedQueue<T> : clsADTLinked<T>, iQueue<T> where T : IComparable<T>
    {
        public clsLinkedQueue()
        {
            attLength = 0;
            attItems = null;
        }
        public clsLinkedQueue(int prmCapacity)
        {
            try
            {
                if (prmCapacity < 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;
                attItems = new T[100];
            }
        }

        public bool opPeek(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opPop(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opPush(T prmItem)
        {
            clsLinkedNode<T> newNode = new clsLinkedNode<T>(prmItem);
            if (attFirst == null)
            {
                attLength++;
                T[] array = new T[attLength];
                array[0] = newNode.opGetItem();
                attItems = array;
                attFirst = newNode;
                attFirstQuarter = newNode;
                attMiddle = newNode;
                attLastQuarter = newNode;
                attLast = newNode;
                return true;
            }
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[attLength-1] = newNode.opGetItem();
            for (int i = 0; i < attLength-2; i++)
            {
                prmArray[i] = attItems[i];
            }
            attItems = prmArray;
            attFirst = newNode;
            return true;
        }
    }
}
