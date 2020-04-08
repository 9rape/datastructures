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
        { }

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
        { }

        public void AddValueAtIndex(int index, int value)
        {

        }

        public void ChangeValueAtIndex(int index, int value)
        {

        }

        public void DelValueEnd()
        {

        }

        public void DelValueEnd(int n)
        {

        }

        public void DelValueBegin()
        {

        }

        public void DelValueBegin(int n)
        {

        }

        public void DelValueAtIndex(int index)
        {

        }

        public void DelValueAtIndex(int index, int n)
        {

        }

        public void DelValueAtValue(int value)
        {

        }

        public string AccessAtIndex(int i)
        {
            return "";
        }

        public string IndexAtValue(int value)
        {
            string result = "";
            return result;
        }

        public void ReverseArray()
        {

        }

        public int GetLength()
        {
            int result = 0;
            return result;
        }

        public string SearchMaxValue()
        {
            return "";
        }

        public string SearchMinValue()
        {
            return "";
        }

        public string SearchMaxIndex()
        {
            return "";
        }

        public string SearchMinIndex()
        {
            return "";
        }

        public void SortAscending()
        {

        }

        public void SortDescending()
        {

        }
    }
}
