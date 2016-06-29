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

        public Angle(bool _poz, int _deg, int _min, int _sec)
        {
            _pozitive = _poz;
            _degrees = _deg;
            _minutes = _min;
            _seconds = _sec;
            Adduction();
        }
        public override string ToString()
        {
            char ch;
            if (_pozitive)
                ch = '+';
            else
                ch = '-';
            return $"{ch} {_degrees}° {_minutes}\' {_seconds}\"";
        }

        public void Adduction()
        {
            while (_seconds > 60)
            {
                _seconds -= 60;
                _minutes++;
            }
            while ( _minutes > 60 )
            {
                _minutes -= 60;
                _degrees++;
            }
            while ( _degrees > 360 )
            {
                _degrees -= 360;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Angle(true, 369, 45, 74);
            Console.WriteLine(a);
        }
    }
}
