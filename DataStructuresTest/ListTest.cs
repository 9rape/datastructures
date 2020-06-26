using NUnit.Framework;
using datastructures;
using datastructures.LinkedList;
using datastructures.DoubleLinkedList;

namespace datastructures.Tests
{
    [TestFixture(1)]
    [TestFixture(2)]
    [TestFixture(3)]
    public class ListTest
    {
        IList list;
        int q;

        public ListTest(int _q)
        {
            q = _q;
        }

        [SetUp]
        public void ListSelect()
        {
            switch (q)
            {
                case 1:
                    list = new ArrayList();
                    break;
                case 2:
                    list = new LinkedList.LinkedList();
                    break;
                case 3:
                    list = new DoubleLinkedList.DoubleLinkedList();
                    break;
            }
        }

        public void InitArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                list.AddToEnd(array[i]);
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 0 }, ExpectedResult = new int[] { 0 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public int[] ReturnArrayTest(int[] array)
        {
            InitArray(array);
            list.ReturnArray();
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 1, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { }, null, ExpectedResult = new int[] { 0 })]
        public int[] AddToEndTest(int[] array, int a)
        {
            InitArray(array);
            list.AddToEnd(a);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { 4, 5 }, ExpectedResult = new int[] { 4, 5 })]
        [TestCase(new int[] { -1 }, new int[] { }, ExpectedResult = new int[] { -1 })]
        public int[] AddToEndTest(int[] array, int[] a)
        {
            InitArray(array);
            list.AddToEnd(a);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, ExpectedResult = new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { }, 1, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 0 }, 1, ExpectedResult = new int[] { 1, 0 })]
        public int[] AddToBeginTest(int[] array, int a)
        {
            InitArray(array);
            list.AddToBegin(a);
            return list.ReturnArray();
        }

        [TestCase(new int[] { }, new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 4, 5 }, new int[] { }, ExpectedResult = new int[] { 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { }, ExpectedResult = new int[] { })]
        public int[] AddToBeginTest(int[] array, int[] a)
        {
            InitArray(array);
            list.AddToBegin(a);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, 9, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, 0, 0, ExpectedResult = new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 0, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 0, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 0, ExpectedResult = new int[] { 1, 2, 0, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 9, ExpectedResult = new int[] { 1, 2, 3, 9 })]
        public int[] AddValueAtIndexTest(int[] array, int i, int a)
        {
            InitArray(array);
            list.AddValueAtIndex(i, a);
            return list.ReturnArray();
        }

        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { -2, 5, 0 }, ExpectedResult = new int[] { -2, 5 })]
        [TestCase(new int[] { 1, -25, 3 }, ExpectedResult = new int[] { 1, -25 })]
        public int[] DelValueEndTest(int[] array)
        {
            InitArray(array);
            list.DelValueEnd();
            return list.ReturnArray();
        }

        [TestCase(new int[] { }, 2, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 1 }, 0, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, ExpectedResult = new int[] { 1 })]
        public int[] DelValueEndTest(int[] array, int n)
        {
            InitArray(array);
            list.DelValueEnd(n);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 3 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 17, 2, 32 }, ExpectedResult = new int[] { 2, 32 })]
        public int[] DelValueBeginTest(int[] array)
        {
            InitArray(array);
            list.DelValueBegin();
            return list.ReturnArray();
        }

        [TestCase(new int[] { }, 2, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = new int[] { 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 6, ExpectedResult = new int[] { })]
        public int[] DelValueBeginTest(int[] array, int n)
        {
            InitArray(array);
            list.DelValueBegin(n);
            return list.ReturnArray();
        }

        [TestCase(new int[] { }, 27, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 0, ExpectedResult = new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] DelValueAtIndexTest(int[] array, int i)
        {
            InitArray(array);
            list.DelValueAtIndex(i);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 3, ExpectedResult = new int[] { 1, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, 0, 6, ExpectedResult = new int[] { })]
        public int[] DelValueAtIndexTest(int[] array, int i, int n)
        {
            InitArray(array);
            list.DelValueAtIndex(i, n);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 2, 3}, 1, ExpectedResult = new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, ExpectedResult = new int[] { 2, 3, 4 })]
        [TestCase(new int[] { }, null, ExpectedResult = new int[] { })]
        public int[] DelValueAtValueTest(int[] array, int i)
        {
            InitArray(array);
            list.DelValueAtValue(i);
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, ExpectedResult = "Значение отсутствует")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, ExpectedResult = "1")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, ExpectedResult = "6")]
        public string AccessAtIndexTest(int[] array, int i)
        {
            InitArray(array);
            return list.AccessAtIndex(i);
        }

        [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 2, ExpectedResult = "1 3 ")]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 3, ExpectedResult = "2 ")]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 7, ExpectedResult = "Не найдено")]
        public string IndexAtValueTest(int[] array, int i)
        {
            InitArray(array);
            return list.IndexAtValue(i);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = new int[] { 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { -2, 4 }, ExpectedResult = new int[] { 4, -2 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public int[] ReverseArrayTest(int[] array)
        {
            InitArray(array);
            list.ReverseArray();
            return list.ReturnArray();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 47, ExpectedResult = new int[] { 1, 2, 47, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, -38, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        public int[] ChangeValueAtIndexTest(int[] array, int i, int a)
        {
            InitArray(array);
            list.ChangeValueAtIndex(i, a);
            return list.ReturnArray();
        }

        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 6)]
        public int GetLengthTest(int[] array)
        {
            InitArray(array);
            return list.GetLength();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 0 }, ExpectedResult = "5")]
        [TestCase(new int[] { }, ExpectedResult = "Список пуст")]
        [TestCase(new int[] { 1, 2, -37, 74, 0, 5 }, ExpectedResult = "74")]
        public string SearchMaxValueTest(int[] array)
        {
            InitArray(array);
            return list.SearchMaxValue();
        }

        [TestCase(new int[] { 1, 2, 3, -4, 5, 0 }, ExpectedResult = "-4")]
        [TestCase(new int[] { }, ExpectedResult = "Список пуст")]
        [TestCase(new int[] { 1, 2, -37, 4, 0, 5 }, ExpectedResult = "-37")]
        public string SearchMinValueTest(int[] array)
        {
            InitArray(array);
            return list.SearchMinValue();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 0 }, ExpectedResult = "4")]
        [TestCase(new int[] { }, ExpectedResult = "Список пуст")]
        [TestCase(new int[] { 1, 2, -37, 4, 0, 5 }, ExpectedResult = "5")]
        public string SearchMaxIndexTest(int[] array)
        {
            InitArray(array);
            return list.SearchMaxIndex();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 0 }, ExpectedResult = "5")]
        [TestCase(new int[] { }, ExpectedResult = "Список пуст")]
        [TestCase(new int[] { 1, 2, -37, 4, 5, 0 }, ExpectedResult = "2")]
        public string SearchMinIndexTest(int[] array)
        {
            InitArray(array);
            return list.SearchMinIndex();
        }

        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { -4 }, ExpectedResult = new int[] { -4 })]
        [TestCase(new int[] { -1, -3, -2, 4, 4, 0 }, ExpectedResult = new int[] { -3, -2, -1, 0, 4, 4 })]
        public int[] BubbleSortAscendingTest(int[] array)
        {
            InitArray(array);
            list.BubbleSortAscending();
            return list.ReturnArray();
        }
        
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { -4 }, ExpectedResult = new int[] { -4 })]
        [TestCase(new int[] { -1, -3, -2, 4, 4, 0 }, ExpectedResult = new int[] { -3, -2, -1, 0, 4, 4 })]
        public int[] InsertionSortAscendingTest(int[] array)
        {
            InitArray(array);
            list.InsertionSortAscending();
            return list.ReturnArray();
        }

        [TestCase(new int[] {  }, ExpectedResult = new int[] {  })]
        [TestCase(new int[] { -3 }, ExpectedResult = new int[] { -3 })]
        [TestCase(new int[] { -1, -3, -2, 4, 4, 0 }, ExpectedResult = new int[] { 4, 4, 0, -1, -2, -3 })]
        public int[] BubbleSortDescendingTest(int[] array)
        {
            InitArray(array);
            list.BubbleSortDescending();
            return list.ReturnArray();
        }
        
        [TestCase(new int[] {  }, ExpectedResult = new int[] {  })]
        [TestCase(new int[] { -3 }, ExpectedResult = new int[] { -3 })]
        [TestCase(new int[] { -1, -3, -2, 4, 4, 0 }, ExpectedResult = new int[] { 4, 4, 0, -1, -2, -3 })]
        public int[] InsertionSortDescendingTest(int[] array)
        {
            InitArray(array);
            list.InsertionSortDescending();
            return list.ReturnArray();
        }
    }
}