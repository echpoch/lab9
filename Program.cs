using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab8
{
    internal class LinkList<T> : Interface<T> where T : class
    {
        internal class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

        }
        public void Push(T value)
        {
            Size++;
            var node = new Node() { Value = value };
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Current.Next = node;
            }
            Current = node;

        }




        public void ListNodes()
        {
            Node tempNode = Head;

            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Next;
            }
        }

        public T this[int position]
        {
            get
            {
                Node tempNode = Head;
                for (int i = 0; i < position; ++i)
                    // переходим к следующему узлу списка
                    tempNode = tempNode.Next;
                return tempNode.Value;
            }
        }
        private Node Head { get; set; }
        private Node Tails { get; set; }
        private Node Current { get; set; }
        private Node Current1 { get; set; }
        public int Size { get; set; }

        public static LinkList<T> operator +(LinkList<T> list1, LinkList<T> list2)
        {

            var list = new LinkList<T>();
            var size = list1.Size + list2.Size;
            list.Size = size;
            for (int i = 0; i < size; i++)
            {
                if (i < list1.Size)
                {
                    list.Push(list1[i]);
                }
                else
                {

                    list.Push(list2[i - list1.Size]);
                }

            }
            return list;

        }


        public void DeleteNode(int number)
        {

            if ((Head != null) && (number < Size) && (number >= 0))
            {
                Node tempNode = Head;
                Node prevNode = null;
                for (int i = 0; i < number; i++)
                {
                    prevNode = tempNode;
                    tempNode = tempNode.Next;

                }


                if (tempNode == Head)
                {

                    prevNode = tempNode;
                    tempNode = tempNode.Next;
                    Head = tempNode;
                    Size--;
                }
                else
                {


                    prevNode = tempNode.Next;
                    Size--;

                }

            }


        }

        //public static LinkList<T> operator !(LinkList<T> list)
        //{


        //    LinkList<T> link = new LinkList<T>();

        //    for (int i = 0; i < list.Size; i++)
        //    {


        //        link.Push(list[list.Size - i - 1]);

        //    }

        //    return link;
        //}

        //public static LinkList<T> operator <(LinkList<T> list1, LinkList<T> list2)
        //{

        //    for (int i = 0; i < list2.Size; i++)
        //    {
        //        list1.Push(list2[i]);

        //    }
        //    return list1;

        //}


        //public static LinkList<T> operator >(LinkList<T> list1, LinkList<T> list2)
        //{
        //    for (int i = 0; i < list1.Size; i++)
        //    {
        //        list2.Push(list1[i]);

        //    }
        //    return list2;

        //}




        public static bool operator ==(LinkList<T> list1, LinkList<T> list2)
        {
            if (list1.Size == list2.Size && list1.Equals(list2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator !=(LinkList<T> list1, LinkList<T> list2)
        {


            if (list1.Size != list2.Size && !list1.Equals(list2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public class Owner
        {
            public int iD { get; set; }
            public string Name { get; set; }
            public string Organization { get; set; }

        }

        public class Date
        {
            public string date { get; set; }
        }

        //public static LinkList<T> operator ++(LinkList<T> obj)
        //{
        //    obj.Push(5);
        //    return obj;
        //}


    }
    public interface Interface<T> //п1

    {
        void Push(T value);
        void ListNodes();
        void DeleteNode(int number);
    }



    class Bench
    {
        public int length { get; set; }      //длина

        public int width { get; set; }       //ширина

        //стоимость 

        public override string ToString()
        {

            Console.WriteLine("Данные об объекте : ");



            Console.WriteLine($"Длина : {length}");

            Console.WriteLine($"Ширина : {width}");




            return $" {length} {width} ";
        }
    }


    class BenchException : Exception
    {


        public BenchException() : base("Неверное значение ! ")
        {

        }
        public BenchException(string message) : base(message)
        { }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Bench b1 = new Bench() { length = 10, width = 20 };
            Bench b2 = new Bench() { length = 19, width = 22 };
            
            try
            {
                if (b1.length <= 0)
                    throw new BenchException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string writePath = @"D:\oop\laba8\a.txt";
            using (var file = new StreamWriter(writePath, true))
            {

                file.WriteLine($"Длина : { b1.length}");
                file.WriteLine($"Ширина : { b1.width}");
               

            }
           
            using (var file = new StreamReader(writePath))
            {
                var read = file.ReadToEnd();
                Console.WriteLine($"Чтение из файла : {read}");
            }
            Console.WriteLine("___________________");
            LinkList<Bench> obj = new LinkList<Bench>();
            obj.Push(b1);
            obj.ListNodes();
            
            LinkList<string> obj1 = new LinkList<string>();
            obj1.Push("Ilya");
           obj1.ListNodes();
            Console.ReadKey();
        }
    }

}


