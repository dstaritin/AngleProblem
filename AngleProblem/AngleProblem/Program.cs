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

        public bool this[bool poz] => Pozitive;

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 1:
                        return Degrees;
                    case 2:
                        return Minutes;
                    case 3:
                        return Seconds;
                    default:
                        return i;
                }
            }
        }
        public override string ToString()
        {
            var ch = Pozitive ? '+' : '-';
            return $"{ch}{Degrees}° {Minutes}\' {Seconds}\"";
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
            bool poz = a1.Pozitive;
            int deg, min, sec;

            if (a1.Pozitive != a2.Pozitive)
                a2.Inverse();

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
        public static Angle operator *(Angle a, int i)
        {
            bool poz = a.Pozitive;
            int deg = a.Degrees*i;
            int min = a.Minutes*i;
            int sec = a.Seconds*i;
            return new Angle(poz, deg, min, sec);
        }

        public static bool operator ==(Angle a1, Angle a2)
        {
            if(a1.Pozitive != a2.Pozitive)
                a2.Inverse();

            if (a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes && a1.Seconds == a2.Seconds)
                return true;
            return false;
        }

        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1 == a2);
        }
        public static bool operator <(Angle a1, Angle a2)
        {
            if (a1.Pozitive != a2.Pozitive)
                a2.Inverse();

            if (a1[1] < a2[1])
                return true;
            if (a1[1] == a2[1] && a1[2] < a2[2])
                return true;
            if (a1[2] == a2[2] && a1[3] < a2[3])
                return true;
            return false;

        }

        public static bool operator >(Angle a1, Angle a2)
        {
            if (a1.Pozitive != a2.Pozitive)
                a2.Inverse();

            if (a1[1] > a2[1])
                return true;
            if (a1[1] == a2[1] && a1[2] > a2[2])
                return true;
            if (a1[2] == a2[2] && a1[3] > a2[3])
                return true;
            return false;
        }

        public static bool operator <=(Angle a1, Angle a2)
        {
            return !(a1 > a2);
        }

        public static bool operator >=(Angle a1, Angle a2)
        {
            return !(a1 < a2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Angle(true, 60, 48, 1);
            var b = new Angle(true, 60, 48, 1);

            Console.WriteLine("a = {0}\nb = {1}\n".PadRight(34, '_'), a, b);
            Console.WriteLine();

            Console.WriteLine("a == b - {0}", a == b);
            Console.WriteLine("a != b - {0}", a != b);
            Console.WriteLine("a < b - {0}", a < b);
            Console.WriteLine("a > b - {0}", a > b);
            Console.WriteLine("a <= b - {0}", a <= b);
            Console.WriteLine("a >= b - {0}", a >= b);
            Console.WriteLine();

        }
    }
}
