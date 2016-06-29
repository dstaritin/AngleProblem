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
        public void Inverse()
        {
            _pozitive = !_pozitive;
            _degrees = 360 - _degrees;
            _minutes = -_minutes;
            _seconds = -_seconds;

            while (_seconds < 0)
            {
                _seconds += 60;
                _minutes--;
            }
            while (_minutes < 0)
            {
                _minutes += 60;
                _degrees--;
            }
        }
        public static Angle operator +(Angle a1, Angle a2)
        {
            bool poz = a2.Pozitive;
            int deg, min, sec;

            if (a1.Pozitive != a2.Pozitive)
                a1.Inverse();
            deg = a1.Degrees + a2.Degrees;
            min = a1.Minutes + a2.Minutes;
            sec = a1.Seconds + a2.Seconds;
            return new Angle(poz, deg, min, sec);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            a2._pozitive = !a2._pozitive;
            a2.Inverse();
            return a1 + a2;
        }

        public static Angle operator !(Angle a)
        {
            a.Inverse();
            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Angle(true, 60, 48, 1);
            var b = a;

            Console.WriteLine(a - b);
            
        }
    }
}
