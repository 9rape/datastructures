using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures
{
    public class ArrayList : IList
    {
        private int[] array;
        private int length;

        public int this[int a]
        {
            get { return array[a]; }
            set { array[a] = value; }
        }

        public int[] ReturnArray()
        {
            int[] arrayToReturn = new int[length];
            for (int i = 0; i < length; i++)
            {
                arrayToReturn[i] = array[i];
            }

            return arrayToReturn;
        }

        public ArrayList()
        {
            array = new int[0];
            length = 0;
        }

        public ArrayList(int a)
        {
            array = new int[1] { a };
            length = 1;
        }

        public ArrayList(int[] a)
        {
            array = a;
            length = a.Length;
        }

        private void UpArraySize()
        {
            int newL = Convert.ToInt32(array.Length * 1.3d + 1);
            int[] newArray = new int[newL];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        private void DownArraySize()
        {
            int newL = Convert.ToInt32(array.Length - 1);
            int[] newArray = new int[newL];

            for (int i = 0; i < array.Length - 1; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        public void AddToEnd(int a)
        {
            if (length >= array.Length)
            {
                UpArraySize();
            }

            array[length] = a;
            length++;
        }

        public void AddToEnd(int[] a)
        {
            while (length + a.Length > array.Length)
            {
                UpArraySize();
            }

            for (int i = 0; i < a.Length; i++)
            {
                array[length + i] = a[i];
            }

            length += a.Length;
        }

        public void AddToBegin(int a)
        {
            if (length >= array.Length)
            {
                UpArraySize();
            }

            length++;
            int[] newArray = new int[length];
            for (int i = 0; i < length - 1; i++)
            {
                newArray[i + 1] = array[i];
            }
            array = newArray;
            array[0] = a;
        }

        public void AddToBegin(int[] a)
        {
            while (length + a.Length > array.Length)
            {
                UpArraySize();
            }

            length += a.Length;
            int[] newArray = new int[length];
            for (int i = 0; i < length - a.Length; i++)
            {
                newArray[i + a.Length] = array[i];
            }
            array = newArray;

            for (int i = 0; i < a.Length; i++)
            {
                array[i] = a[i];
            }
        }

        public void AddValueAtIndex(int index, int value)
        {
            if (index == length)
            {
                AddToEnd(value);
            }
            else if((length > 0) && (index < length) && (index >= 0))
            {
                if (length >= array.Length)
                {
                    UpArraySize();
                }
                int[] newArray = new int[length + 1];
                for (int i = 0; i < length; i++)
                {
                    newArray[i] = array[i];
                }
                for (int i = index; i < length; i++)
                {
                    newArray[i + 1] = array[i];
                }
                newArray[index] = value;
                array = newArray;
                length++;
            }
        }

        public void ChangeValueAtIndex(int index, int value)
        {
            if ((length > 0) && (index < length) && (index >= 0))
                array[index] = value;
        }

        public void DelValueEnd()
        {
            if (length > 0)
            {
                DownArraySize();
                length--;
            }
        }

        public void DelValueEnd(int n)
        {
            while (n != 0)
            {
                DelValueEnd();
                n--;
            }
        }

        public void DelValueBegin()
        {
            if (length > 0)
            {
                int[] newArray = new int[length];
                for (int i = 0; i < length - 1; i++)
                {
                    newArray[i] = array[i + 1];
                }
                array = newArray;

                DownArraySize();
                length--;
            }
        }

        public void DelValueBegin(int n)
        {
            while (n != 0)
            {
                DelValueBegin();
                n--;
            }
        }

        public void DelValueAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                int[] newArray = new int[length];
                newArray = array;
                for (int i = index; i < length - 1; i++)
                {
                    newArray[i] = array[i + 1];
                }
                array = newArray;

                DownArraySize();
                length--;
            }
        }

        public void DelValueAtIndex(int index, int n)
        {
            while (n != 0)
            {
                DelValueAtIndex(index);
                n--;
            }
        }

        public void DelValueAtValue(int value)
        {
            for (int i = 0; i < length; i++)
            {
                if (array[i] == value)
                {
                    DelValueAtIndex(i);
                    i--;
                }
            }
        }

        public string AccessAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                return array[index] + "";
            }
            else { return "Значение отсутствует"; }
        }

        public string IndexAtValue(int value)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                if (array[i] == value)
                { result += i + " "; }
            }
            if (result == "")
            { result = "Не найдено"; }
            return result;
        }

        public void ReverseArray()
        {
            for (int i = 0, j = array.Length - 1; i < j; i++, j--)
            {
                int tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
            }
        }

        public int GetLength()
        {
            int a = array.Length;
            return a;
        }

        public string SearchMaxValue()
        {
            if (length > 0)
            {
                int a = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (a < array[i])
                    {
                        a = array[i];
                    }
                }
                return a + "";
            }
            else return "Список пуст";
        }

        public string SearchMinValue()
        {
            if (length > 0)
            {
                int a = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (a > array[i])
                    {
                        a = array[i];
                    }
                }
                return a + "";
            }
            else return "Список пуст";
        }

        public string SearchMaxIndex()
        {
            if (length > 0)
            {
                int a = array[0];
                int b = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (a < array[i])
                    {
                        a = array[i];
                        b = i;
                    }
                }
                return b + "";
            }
            else return "Список пуст";
        }

        public string SearchMinIndex()
        {
            if (length > 0)
            {
                int a = array[0];
                int b = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (a > array[i])
                    {
                        a = array[i];
                        b = i;
                    }
                }
                return b + "";
            }
            else return "Список пуст";
        }

        public void SortAscending()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }

        public void SortDescending()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }
    }
}
