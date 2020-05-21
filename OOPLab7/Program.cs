using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Lab7cs
{
    class Program
    {
        static void Main(string[] args)
        {
            IntList nums = new IntList();
            nums.Add(34);
            nums.Add(75);
            nums.Add(67);
            nums.Add(19);
            nums.Add(40);
            nums.Add(12);
            nums.Add(85);
            nums.Add(11);
            nums.Add(30);
            nums.Add(23);
            int counter = 0;
            for (int i = 0; i < nums.Length; i++) if (nums[i] % 5 == 0) counter++;
            WriteLine("Початковий список:");
            WriteLine(nums+"\n");
            WriteLine($"Кiлькiсть елементiв кратних п'яти: {counter}"+"\n");
            nums = RemoveAfterMax(nums);
            WriteLine("Список с видаленими елементами, що йдуть пiсля максимального:");
            WriteLine(nums+"\n");
        }
        public static IntList RemoveAfterMax(IntList list)
        {
            int max_index = 0;
            for(int i=0; i < list.Length; i++)
            {
                if (list[i] > list[max_index]) max_index = i;
            }
            for (int i = 0; i < list.Length; i++)
            {
                if (i > max_index)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }
    }
    sealed class IntList{
        int[] arr;
        public int Length { get; private set; }
        public IntList()
        {
            arr = null;
        }
        public IntList(int[] array)
        {
            Length = array.Length;
            arr = array;
        }
        public IntList(IntList list)
        {
            arr = list.arr;
            Length = list.Length;
        }
        public IntList(int n)
        {
            Length = n;
            arr = new int[n];
        }
        public void Add(int num)
        {
            Length += 1;
            if (arr == null)
            {
                int[] tempi = { num };
                arr = tempi;
                return;
            }
            int[] temp = new int[Length];
            temp[0] = arr[0];
            temp[1] = num;
            for (int i = 2; i <= arr.Length; i++) temp[i] = arr[i-1];
            arr = temp;
        }
        public void RemoveAt(int index)
        {
            if (arr == null) return;
            if (!(index > -1 && index < Length)) throw new Exception("Index is out of range");
            if (Length == 1)
            {
                arr = null;
                Length = 0;
                return;
            }
            Length -= 1;
            int[] temp = new int[Length];
            if(index==0)
            {
                for (int i = 1, j = 0; i < Length + 1; i++,j++) temp[j] = arr[i];
            }
            else if (index == Length)
            {
                for (int i = 0, j = 0;i<Length;i++,j++) temp[j] = arr[i];
            }
            else 
            {
                int c = 0;
                for(int i = 0; i < Length; i++,c++)
                {
                    if (i < index || i > index) temp[i] = arr[c];
                    else
                    {
                        c++;
                        temp[i] = arr[c];
                    }
                }
            }
            arr = temp;
        }
        public int this[int index] {
            get
            {
                    if (!(index > -1 && index < Length)) throw new Exception("Index is out of range");
                    else return arr[index];
            }
            set
            {
                if (!(index > -1 && index < Length)) throw new Exception("Index is out of range");
                else arr[index]=value;
            }
        }
        public IntList GetRange(int start,int count)
        {
            if (!(start > -1 && start < Length)) throw new Exception("Start is out of range");
            if (start + count > Length) throw new Exception("Too long range");
            IntList temp = new IntList(count);
            for (int i = start, j = 0; i < start + count; i++,j++) temp[j] = arr[i];
            return temp;
        }
        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < Length; i++)
            {
                temp += arr[i];
                if (i != Length - 1) temp += " ";
            }
            return temp;
        }
    }
}