using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Lab6cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            Expression[] exps = new Expression[4];
            for(int i = 0; i < 4; i++)
            {
                exps[i] = new Expression(rand.Next(1, 5), rand.Next(1, 100), rand.Next(1, 100));
                try
                {
                    Write($"Значение {i + 1}-го выражения:");
                    WriteLine(exps[i].Value);
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }
    }
    sealed class Expression
    {
        public double a { get; set; }
        public double c { get; set; }
        public double d { get; set; }
        public double Value{get=>Calculate();}
        public Expression(double _a,double _c,double _d)
        {
            a = _a;
            c = _c;
            d = _d;
        }
        private double Calculate()
        {
                if (a >= 4 || a == 0) throw new Exception("Недопустимый операнд 'a' в выражении");
                return (2 * c - d / 23) / (Math.Log(1 - a / 4));
        } 
    }

}
