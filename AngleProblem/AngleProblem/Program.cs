using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleProblem
{
    public struct Angle
    {
        private bool _pozitive;
        private int _degrees, _minutes, _seconds;

        public bool Pozitive => _pozitive;

        public int Degrees => _degrees;

        public int Minutes => _minutes;

        public int Seconds => _seconds;


        public Angle(bool poz, int deg, int min, int sec)
        {
            _pozitive = poz;
            _degrees = deg;
            _minutes = min;
            _seconds = sec;
            Adduction();
        }

        public Angle(Angle an)
        {
            _pozitive = an._pozitive;
            _degrees = an._degrees;
            _minutes = an._minutes;
            _seconds = an._seconds;
            Adduction();
        }

        public override string ToString()
        {
            var ch = Pozitive ? '+' : '-';
            return $"{ch} {Degrees}° {Minutes}\' {Seconds}\"";
        }

        public void Adduction()
        {
            while (_seconds >= 60)
            {
                _seconds -= 60;
                _minutes++;
            }
            while (_minutes >= 60)
            {
                _minutes -= 60;
                _degrees++;
            }
            while (_degrees >= 360)
                _degrees -= 360;
        }
        //public void Inverse()
        //{
        //    _pozitive = !_pozitive;
        //    _
        //}
        public static Angle operator +(Angle a1, Angle a2)
        {
            bool poz = a1.Pozitive;
            int deg, min, sec;

            if (a1.Pozitive != a2.Pozitive)
                /*a2.Inverse()*/;
            deg = a1.Degrees + a2.Degrees;
            min = a1.Minutes + a2.Minutes;
            sec = a1.Seconds + a2.Seconds;
            return new Angle(poz, deg, min, sec);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Angle(true, 59, 48, 2);
            var b = new Angle(true, 95, 57, 1);
            Console.WriteLine("{0}\n{1}\n", a, b);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}
