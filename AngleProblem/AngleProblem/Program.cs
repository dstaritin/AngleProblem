using System;
using static AngleProblem.VerifyingTwoAngles;

/*

 Possible operations:
 For one Angle: !(Invers);
 Between two Angles: +, -, <, >, ==, !=, <=, >= ();
 Between Angle and int: *;

*/
namespace AngleProblem
{
    public struct Angle
    {
        #region ReSharper asked me to write it
        public bool Equals(Angle other)
        {
            return _pozitive == other._pozitive && _degrees == other._degrees && _minutes == other._minutes && _seconds == other._seconds;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Angle && Equals((Angle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _pozitive.GetHashCode();
                hashCode = (hashCode*397) ^ _degrees;
                hashCode = (hashCode*397) ^ _minutes;
                hashCode = (hashCode*397) ^ _seconds;
                return hashCode;
            }
        }
        #endregion

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

        public static Angle operator *(int i, Angle a)
        {
            return a*i;
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
        static void Main()
        {
            var angle = new Angle(true, 541, 845, 6);
            Console.WriteLine("a = {0}", angle);
            Console.WriteLine("!a = {0}", !angle);
            var angle2 = new Angle(false, 76, 87, 36);
            Console.WriteLine("b = {0}", angle2);
            Console.WriteLine("a + b = {0}", angle + angle2);
            Console.WriteLine("a - b = {0}", angle - angle2);
            Console.WriteLine("b - a = {0}", angle2 - angle);
            Console.WriteLine("a * 5 = {0}", angle * 5);
            Console.WriteLine("35 * b = {0}", 35 * angle2);
            Console.WriteLine("\nPress any key to move to the next step . . .");
            Console.ReadKey();
            Console.WriteLine();

            var a1 = new Angle(true, 60, 48, 1);
            var a2 = new Angle(true, 60, 48, 1);
            Anglecw(a1, a2);
            Console.WriteLine("\nPress any key to move to the next step . . .");
            Console.ReadKey();
            Console.WriteLine();

            var a3 = new Angle(true, 43, 46, 8);
            var a4 = new Angle(true, 43, 47, 8);
            Anglecw(a3, a4);
            Console.WriteLine("\nPress any key to move to the next step . . .");
            Console.ReadKey();
            Console.WriteLine();

            var a5 = new Angle(false, 123, 41, 48);
            var a6 = new Angle(true, 84, 27, 2);
            Anglecw(a5, a6);
            Console.WriteLine("\nFINISH!");
        }
    }
}
