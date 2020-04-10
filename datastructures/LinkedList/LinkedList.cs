using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.LinkedList
{
    public class LinkedList : IList
    {
        private Node root;

        public int length { get; private set; }

        public LinkedList()
        {
            root = null;
            length = 0;
        }

        public LinkedList(int a)
        {
            root = new Node(a);
            length = 1;
        }

        private void ResetArray()
        {
            root = null;
            length = 0;
        }

        public int[] ReturnArray()
        {
            int[] array = new int[length];
            if (length != 0)
            {
                int i = 0;
                Node tmp = root;
                do
                {
                    array[i] = tmp.Value;
                    i++;
                    tmp = tmp.Next;
                } while (tmp != null);
            }
            return array;
        }

        public void AddToEnd(int a)
        {
            if (length == 0)//(root==null)
            {
                root = new Node(a);
                length = 1;
            }
            else if (length == 1)//(root!=null&&root.Next==null)
            {
                root.Next = new Node(a);
                length++;
            }
            else
            {
                Node tmp = root;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node(a);
                length++;
            }
        }

        public void AddToEnd(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                AddToEnd(a[i]);
            }
        }

        public void AddToBegin(int a)
        {
            Node tmp = new Node(a);
            tmp.Next = root;
            root = tmp;
            length++;
        }

        public void AddToBegin(int[] a)
        {
            int i = a.Length - 1;
            while (i != -1)
            {
                AddToBegin(a[i]);
                i--;
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
                Node tmp = root;
                if (index == 0)
                {
                    tmp = new Node(value);
                    tmp.Next = root;
                    root = tmp;
                }
                else
                if (index > 0)
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        tmp = tmp.Next;
                    }
                    Node c = new Node(value);
                    c.Next = tmp.Next;
                    tmp.Next = c;
                }
                length++;
            }
        }

        public void ChangeValueAtIndex(int index, int value)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                Node tmp = root;
                for (int i = 0; i < length; i++)
                {
                    if (i == index)
                    {
                        tmp.Value = value;
                    }
                    tmp = tmp.Next;
                }
            }
        }

        public void DelValueEnd()
        {
            if (length > 0)
            {
                Node tmp = root;
                for (int i = 0; i < length - 2; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                length--;
            }
        }

        public void DelValueEnd(int n)
        {
            if (n >= length)
            {
                ResetArray();
            }
            else if (n <= length)
            {
                Node tmp = root;
                for (int i = 0; i < length - 1 - n; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                length = length - n;
            }
        }

        public void DelValueBegin()
        {
            if (length > 0)
            {
                Node tmp = root;
                tmp = tmp.Next;
                root = tmp;
                length--;
            }
        }

        public void DelValueBegin(int n)
        {
            if (n >= length)
            {
                ResetArray();
            }
            else if (n >= 0)
            {
                Node tmp = root;
                for (int i = 0; i < n; i++)
                {
                    tmp = tmp.Next;
                }
                root = tmp;
                length = length - n;
            }
        }

        public void DelValueAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                if (index == 0)
                {
                    Node tmp = root;
                    tmp = tmp.Next;
                    root = tmp;
                    length--;
                }

                if (index > 0)
                {
                    Node tmp = root;
                    for (int i = 2; i <= index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    Node c = tmp.Next;
                    c = c.Next;
                    tmp.Next = c;
                    length--;
                }
            }
        }

        public void DelValueAtIndex(int index, int n)
        {
            while (n>0)
            {
                DelValueAtIndex(index);
                n--;
            }
        }

        public void DelValueAtValue(int value)
        {
            Node tmp = root;
            for (int i = 0; i < length; i++)
            {
                if (tmp.Value == value) 
                {
                    DelValueAtIndex(i);
                    i--;
                }
                tmp = tmp.Next;
            }
        }

        public string AccessAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                int value = 0;
                Node tmp = root;
                for (int i = 0; i < length; i++)
                {
                    if (i == index)
                    {
                        value = tmp.Value;
                    }
                    tmp = tmp.Next;
                }
                return value + "";
            }
            else { return "Значение отсутствует"; }
        }

        public string IndexAtValue(int value)
        {
            Node tmp = root;
            string b = "";
            for (int i = 0; i < length; i++)
            {
                if (tmp.Value == value) { b += i + " "; };
                tmp = tmp.Next;
            }
            if (b == "")
            { b = "Не найдено"; }
            return b;
        }

        public void ReverseArray()
        {
            if (length > 0)
            {
                Node current = root;
                Node prev = null;
                Node next;
                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }
                current.Next = prev;
                root = current;
            }
        }

        public int GetLength()
        {
            return length;
        }

        public string SearchMaxValue()
        {
            if (length > 0)
            {
                Node tmp = root;
                int b = tmp.Value;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value >= b) { b = tmp.Value; };
                    tmp = tmp.Next;
                }
                return b + "";
            }
            else return "Список пуст";
        }

        public string SearchMinValue()
        {
            if (length > 0)
            {
                Node tmp = root;
                int b = tmp.Value;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value <= b) { b = tmp.Value; };
                    tmp = tmp.Next;
                }
                return b + "";
            }
            else return "Список пуст";
        }

        public string SearchMaxIndex()
        {
            if (length > 0)
            {
                Node tmp = root;
                int b = tmp.Value;
                int a = 0;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value > b) { b = tmp.Value; a = i; };
                    tmp = tmp.Next;
                }
                return a + "";
            }
            else return "Список пуст";
        }

        public string SearchMinIndex()
        {
            if (length > 0)
            {
                Node tmp = root;
                int b = tmp.Value;
                int a = 0;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value < b) { b = tmp.Value; a = i; };
                    tmp = tmp.Next;
                }
                return a + "";
            }
            else return "Список пуст";
        }

        public void SortAscending()
        {
            Node prev = null;
            Node minPrev = null;
            Node min = root;
            Node tmp = root;

            while (tmp != null)
            {
                if (min.Value > tmp.Value)
                {
                    min = tmp;
                    minPrev = prev;
                }
                prev = tmp;
                tmp = tmp.Next;
            }
            if (minPrev != null)
            {
                minPrev.Next = minPrev.Next.Next;
                min.Next = root;
                root = min;
            }

            Node place = root;

            for (int i = 1; i < length; i++)
            {
                prev = place;
                minPrev = place;
                min = place.Next;
                tmp = place.Next;

                while (tmp != null)
                {
                    if (min.Value > tmp.Value)
                    {
                        min = tmp;
                        minPrev = prev;
                    }
                    prev = tmp;
                    tmp = tmp.Next;
                }

                minPrev.Next = minPrev.Next.Next;
                min.Next = place.Next;
                place.Next = min;
                place = place.Next;
            }
        }

        public void SortDescending()
        {
            Node prev = null;
            Node minPrev = null;
            Node min = root;
            Node tmp = root;

            while (tmp != null)
            {
                if (min.Value < tmp.Value)
                {
                    min = tmp;
                    minPrev = prev;
                }
                prev = tmp;
                tmp = tmp.Next;
            }
            if (minPrev != null)
            {
                minPrev.Next = minPrev.Next.Next;
                min.Next = root;
                root = min;
            }

            Node place = root;

            for (int i = 1; i < length; i++)
            {
                prev = place;
                minPrev = place;
                min = place.Next;
                tmp = place.Next;

                while (tmp != null)
                {
                    if (min.Value < tmp.Value)
                    {
                        min = tmp;
                        minPrev = prev;
                    }
                    prev = tmp;
                    tmp = tmp.Next;
                }

                minPrev.Next = minPrev.Next.Next;
                min.Next = place.Next;
                place.Next = min;
                place = place.Next;
            }
        }

    }
}
