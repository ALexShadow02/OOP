using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Lab8cs
{
    delegate void SortDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            /*char[] keys = { 'f','a','c','p','z','w','b'};
            WriteLine("The original array:");
            for (int i = 0; i < keys.Length; i++) Write(keys[i] + " ");
            WriteLine();
            CASort sort = new CASort(keys);
            SortDelegate del = sort.SortDesc;
            del();//виклик делегату
            WriteLine("The sorted array:");
            for (int i = 0; i < keys.Length; i++) Write(keys[i]+" ");
            WriteLine();*/
            UQueue amazon = new UQueue(5);
            for (int i = 2; i <= 32; i *= 2) amazon.Enqueue(i);
            WriteLine(amazon);
            WriteLine("Trying to add another element to the queue...");
            amazon.Enqueue(10);
        }
    }
    class CASort {
        public char[] array;
        public CASort(char[] arr)
        {
            array = arr;
        }
        public void SortDesc()
        {
            Array.Sort(array);
            for (int i = 0; i < array.Length / 2 + 1; i++)
            {
                char temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
        }
        public static void SortDesc(char[] arr)
        {
            Array.Sort(arr);
            for(int i = 0; i < arr.Length/2+1; i++)
            {
                char temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }
        }
    }

    class UQueue {
        private int front, rear, capacity;
        private int[] queue;
        public delegate void EventHandler();
        event EventHandler Notify;
        public UQueue(int n)
        {
            front = rear = 0;
            capacity = n;
            queue = new int[capacity];
        }
        public void Enqueue(int data)
        {
            if (capacity == rear)
            {
                Notify += DisplayError;
                Notify();
                return;
            }
            else
            {
                queue[rear] = data;
                rear++;
            }
            return;
        }
        public void Dequeue()
        {
            if (front == rear)
            {
                WriteLine("Queue is empty!!!");
                return;
            }
            else
            {
                for(int i = 0; i < rear - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }
                if (rear < capacity) queue[rear] = 0;
                rear--;
            }
            return;
        }
        public void Display()
        {
            if (front == rear)
            {
                WriteLine("Queue is empty");
                return;
            }
            int i;
            for(i=front; i < rear; i++)
            {
                Write("{0} <-- ",queue[i]);
            }
            WriteLine();
            return;
        }
        public void Front()
        {
         if(front==rear)
            {
                WriteLine("Queue is empty!!!");
                return;
            }
            Write($"\n Front element is {queue[front]}");
        }
        public override string ToString()
        {
            if (front == rear) return "Queue is empty";
            string res="";
            for(int i = front; i < rear; i++)
            {
                res += queue[i].ToString() + " <-- ";
            }
            return res;
        }
        public void DisplayError() => WriteLine("The queue is full!!!");
    }

}
