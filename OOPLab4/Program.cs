using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Console;
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector V1 = new Vector();
            Vector V2 = new Vector(2.7,4.9);
            Vector V3 = new Vector(V2);
            V3 *= 2;
            V1 = V3 - V2;
            V1.GetData();
        }
    }
    class Vector
    {
        double x;
        double y;
        public Vector()
        {
            x = y = 0.0;
        }
        public Vector(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector(Vector vec)
        {
            x = vec.x;
            y = vec.y;
        }
        public double Length() => Sqrt(x*x+y*y);
        public void GetData()
        {
            WriteLine($"The coordinates of the vector are ({x};{y})");
            WriteLine($"The length is {Length()}");
        }
        public static Vector operator *(Vector vec, float num) => new Vector(vec.x*num,vec.y*num);
        public static Vector operator *(float num,Vector vec) => new Vector(vec.x * num, vec.y * num);
        public static Vector operator -(Vector vec1,Vector vec2) => new Vector(vec1.x-vec2.x,vec1.y-vec2.y);
    }
}
