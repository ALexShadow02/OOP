using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace OOPLaba3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] nums = new int[,] { {2,4,8 },{ 3,9,27},{4,16,64,} };
            TwoDimArr mass = new TwoDimArr(nums);
            WriteLine(mass.size_dim1);
        }
    }
    class TwoDimArr
    {
        private int[,] arr;
        private int _1dim_size;
        private int _2dim_size;
        public int size_dim1 {
           get => _1dim_size;
        }
        public int size_dim2
        {
            get => _2dim_size;
        }
        public TwoDimArr(int[,] ar)
        {
            arr = ar;
            _1dim_size = arr.GetLength(0);
            _2dim_size = arr.GetLength(1);
        }
        public int this[int a, int b] {
            get
            {
                if ((a >= 0 && a <= arr.Length - 1) && (b >= 0 && b <= arr.GetLength(1))) return arr[a, b];
                else return 0;
            }
            set
            {
                try
                {
                    arr[a, b] = value;
                }
                catch
                {
                    WriteLine("Возникла ошибка присваивания");
                }
                
            }
        }
    }
}
