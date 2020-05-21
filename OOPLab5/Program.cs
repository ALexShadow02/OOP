using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Console;
using System.Collections;
using static System.Threading.Thread;
using static System.Convert;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    struct Coord
    {
        public double x { get; set; }
        public double y;
        public Coord(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Line
    {
        public Coord beg { get; protected set; }
        public Coord end { get; protected set; }
        public Line(Coord beg, Coord end)
        {
            this.beg = beg;
            this.end = end;
        }
        public double GetLength() => Sqrt(Pow(end.x-beg.x,2)+Pow(end.y-beg.y,2));
    }
    class LineSeg: Line {
        public LineSeg(Coord beg,Coord end):base(beg,end)
        {
        }
        public double GetAngle() => Atan2(Abs(end.y-beg.y),end.x-beg.x);
        public double angle { get => GetAngle(); }
        public void GetData()
        {
            WriteLine($"The coordinates are:({beg.x};{beg.y}) and ({end.x};{end.y})");
            WriteLine($"The length is {GetLength()}");
            WriteLine($"The angle is {angle}");
        }
    }
    class Ustring
    {
        protected Stack str;
        public Ustring()
        {
            str = new Stack();
        }
        public Ustring(string istr)
        {
            str = new Stack(istr.Length);
            for (int i = 0; i < istr.Length; i++) str.Push(istr[i]);
        }
        public virtual void AddSym(char s) => str.Push(s);
        public int GetLength() => str.Count;
        public override string ToString(){
            if (str == null) return "";
            string rest = "";
            int len = str.Count;
            for(int i = 0; i < len; i++)
            {
                Stack cop = str;
                rest += cop.Peek();
                cop.Pop();
            }
            string res = "";
            for (int i = rest.Length - 1; i >= 0; i--) res += rest[i];
            return res;
        }
    }
    class UpperString: Ustring
    {
        public UpperString() :base()
        {
        }
        public UpperString(string wor)
        {
            for (int i = 0; i < wor.Length; i++) str.Push(Char.ToUpper(wor[i]));
        }
        public override void AddSym(char sym)
        {
            str.Push(Char.ToUpper(sym));
        }
    }
    class LowerString : Ustring
    {
        public LowerString() : base()
        {
        }
        public LowerString(string wor)
        {
            for (int i = 0; i < wor.Length; i++) str.Push(Char.ToLower(wor[i]));
        }
        public override void AddSym(char sym)
        {
            str.Push(Char.ToLower(sym));
        }
    }
}


