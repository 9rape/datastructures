using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures
{
    public interface IList
    {
        int[] ReturnArray();

        void AddToEnd(int a);

        void AddToEnd(int[] a);

        void AddToBegin(int a);

        void AddToBegin(int[] a);

        void AddValueAtIndex(int index, int value);

        void ChangeValueAtIndex(int index, int value);

        void DelValueEnd();

        void DelValueEnd(int value);

        void DelValueBegin();

        void DelValueBegin(int value);

        void DelValueAtIndex(int index);

        void DelValueAtIndex(int index, int value);

        void DelValueAtValue(int value);

        string AccessAtIndex(int index);

        string IndexAtValue(int value);

        void ReverseArray();

        int GetLength();

        string SearchMaxValue();

        string SearchMinValue();

        string SearchMaxIndex();

        string SearchMinIndex();

        void BubbleSortAscending();
        
        void InsertionSortAscending();

        void BubbleSortDescending();
        
        void InsertionSortDescending();
    }
}
