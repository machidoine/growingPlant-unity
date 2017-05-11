using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Merger
{
    public static void Merge<T>(List<T> from, List<T> with, IEqualityComparer<T> comparator, Action<T> addF, Action<T> removeF)
    {
        HashSet<T> fromSet = new HashSet<T>(from, comparator);
        HashSet<T> addedElements = new HashSet<T>(with, comparator);
        addedElements.ExceptWith(fromSet);

        HashSet<T> removedElements = new HashSet<T>(fromSet, comparator);
        removedElements.ExceptWith(with);

        foreach (var addedElement in addedElements)
        {
            addF(addedElement);
        }

        foreach (var removedElement in removedElements)
        {
            removeF(removedElement);
        }
    }
}
