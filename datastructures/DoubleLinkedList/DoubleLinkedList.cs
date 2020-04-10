using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.DoubleLinkedList
{
    public class DoubleLinkedList : IList
    {
        private Node root;
        private Node end;
        public int length { get; private set; }

        public DoubleLinkedList()
        {
            root = null;
            end = null;
            length = 0;
        }

        public DoubleLinkedList(int a)
        {
            root = new Node(a);
            end = root;
            length = 1;
        }

        private void ShiftNodes(Node a, Node b)
        {
            if (a == root && b != end)
            {
                a.Next = b.Next;
                b.Next.Prev = a;
                a.Prev = b;
                b.Next = a;
                b.Prev = null;
                root = b;

            }
            else if (a == root && b == end)
            {
                a.Next = null;
                b.Next = a;
                a.Prev = b;
                b.Prev = null;
                root = b;
                end = a;
            }
            else if (a != root && b == end)
            {
                a.Next = null;
                b.Prev = a.Prev;
                a.Prev.Next = b;
                b.Next = a;
                a.Prev = b;
                end = a;
            }
            else
            {
                a.Prev.Next = b;
                b.Next.Prev = a;
                a.Next = b.Next;
                b.Next = a;
                b.Prev = a.Prev;
                a.Prev = b;
            }
        }

        private void ResetArray()
        {
            root = null;
            end = null;
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
            if (length == 0)
            {
                root = new Node(a);
                end = root;
                length = 1;
            }
            else
            {
                end.Next = new Node(a);
                end.Next.Prev = end;
                end = end.Next;
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
            if (length == 0)
            {
                root = new Node(a);
                end = root;
                length = 1;
            }
            else
            {
                root.Prev = new Node(a);
                root.Prev.Next = root;
                root = root.Prev;
                length++;
            }
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
            else if (index == 0)
            {
                AddToBegin(value);
            }
            else if ((length > 0) && (index < length) && (index > 0))
            {
                if (index <= (length / 2))
                {
                    Node tmp = root;
                    int i = 0;
                    while (i <= length / 2)
                    {
                        if (i == index)
                        {
                            Node tmp2 = tmp.Prev;
                            tmp2.Next = new Node(value);
                            tmp2.Next.Next = tmp;
                            tmp2.Next.Prev = tmp2;
                            tmp.Prev = tmp2.Next;
                            length++;
                            break;
                        }
                        tmp = tmp.Next;
                        i++;
                    }
                }
                else if (index >= (length / 2))
                {
                    Node tmp = end;
                    int i = length - 1;
                    while (i >= length / 2)
                    {
                        if (i == index)
                        {
                            Node tmp2 = tmp.Prev;
                            tmp2.Next = new Node(value);
                            tmp2.Next.Next = tmp;
                            tmp2.Next.Prev = tmp2;
                            tmp.Prev = tmp2.Next;
                            length++;
                            break;
                        }
                        tmp = tmp.Prev;
                        i--;
                    }
                }
            }
        }

        public void ChangeValueAtIndex(int index, int value)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                if (index <= (length / 2))
                {
                    Node tmp = root;
                    for (int i = 0; i < length / 2; i++)
                    {
                        if (i == index)
                        {
                            tmp.Value = value;
                        }
                        tmp = tmp.Next;
                    }
                }
                else if (index >= (length / 2))
                {
                    Node tmp = end;
                    for (int i = length - 1; i >= length / 2; i--)
                    {
                        if (i == index)
                        {
                            tmp.Value = value;
                        }
                        tmp = tmp.Prev;
                    }
                }
            }
        }

        public void DelValueEnd()
        {
            if (length > 0)
            {
                end = end.Prev;
                end.Next = null;
                length--;
            }
        }

        public void DelValueEnd(int n)
        {
            if (n >= length)
            {
                ResetArray();
            }
            else if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    DelValueEnd();
                }
            }
        }

        public void DelValueBegin()
        {
            if (length <= 1)
            {
                ResetArray();
            }
            else if (length > 1)
            {
                root = root.Next;
                root.Prev = null;
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
                for (int i = 0; i < n; i++)
                {
                    DelValueBegin();
                }
            }
        }

        public void DelValueAtIndex(int index)
        {
            if (length <= 1)
            {
                ResetArray();
            }
            else if (index >= 0)
            {
                if (index == 0)
                {
                    DelValueBegin();
                }
                else if (index == length - 1)
                {
                    DelValueEnd();
                }
                else
                {
                    if (index <= (length / 2))
                    {
                        Node tmp = root;
                        int i = 0;
                        while (i <= length / 2)
                        {
                            if (i == index)
                            {
                                tmp.Next.Prev = tmp.Prev;
                                tmp.Prev.Next = tmp.Next;
                                length--;
                                break;
                            }
                            tmp = tmp.Next;
                            i++;
                        }
                    }
                    else if (index >= (length / 2))
                    {
                        Node tmp = end;
                        int i = length - 1;
                        while (i >= length / 2)
                        {
                            if (i == index)
                            {
                                tmp.Next.Prev = tmp.Prev;
                                tmp.Prev.Next = tmp.Next;
                                length--;
                                break;
                            }
                            tmp = tmp.Prev;
                            i--;
                        }
                    }
                }
            }
        }

        public void DelValueAtIndex(int index, int n)
        {
            while (n > 0)
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
                if (index <= (length / 2))
                {
                    Node tmp = root;
                    int i = 0;
                    while (i <= length / 2)
                    {
                        if (i == index)
                        {
                            value = tmp.Value;
                            break;
                        }
                        tmp = tmp.Next;
                        i++;
                    }
                }
                else if (index >= (length / 2))
                {
                    Node tmp = end;
                    int i = length - 1;
                    while (i >= length / 2)
                    {
                        if (i == index)
                        {
                            value = tmp.Value;
                            break;
                        }
                        tmp = tmp.Prev;
                        i--;
                    }
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
                Node tmp = root;
                Node tmp2 = root;
                tmp.Prev = tmp.Next;
                tmp.Next = null;
                tmp = tmp.Prev;
                while (tmp != end)
                {
                    tmp2 = tmp.Next;
                    tmp.Next = tmp.Prev;
                    tmp.Prev = tmp2;
                    tmp = tmp.Prev;
                }
                tmp.Next = tmp.Prev;
                tmp.Prev = null;
                tmp2 = end;
                end = root;
                root = tmp2;
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
            if (length > 0)
            {
                Node current = root;
                Node prev = root;
                Node next = current.Next;
                Node last = root;
                bool x = false;
                while (x != true)
                {
                    next = current.Next;
                    x = true;
                    for (int i = length - 2; i >= 0; i--)
                    {
                        current = root;
                        prev = root;
                        for (int j = 0; j < i; j++)
                        {
                            current = current.Next;
                        }
                        if (current.Value > current.Next.Value)
                        {
                            next = current.Next;
                            ShiftNodes(current, next);
                            x = false;
                        }

                    }

                }
                last = current;
                end = last;
            }
        }

        public void SortDescending()
        {
            for (var i = 1; i < length; i++)
            {
                Node current = root;
                for (int j = 0; j < i; j++)
                {
                    current = current.Next;
                }
                Node prev = current.Prev;
                while (prev.Value < current.Value)
                {
                    ShiftNodes(prev, current);
                    if (current == root)
                    {
                        break;
                    }
                    prev = current.Prev;
                }
            }
        }
    }
}
