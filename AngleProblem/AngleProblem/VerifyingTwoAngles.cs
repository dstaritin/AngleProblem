using System;

namespace AngleProblem
{
    public static class VerifyingTwoAngles
    {
        public static void Anglecw(Angle a, Angle b)
        {
            Console.WriteLine("a = {0}\nb = {1}\n".PadRight(34, '_'), a, b);
            Console.WriteLine();

            Console.WriteLine("a == b - {0}", a == b);
            Console.WriteLine("a != b - {0}", a != b);
            Console.WriteLine("a < b - {0}", a < b);
            Console.WriteLine("a > b - {0}", a > b);
            Console.WriteLine("a <= b - {0}", a <= b);
            Console.WriteLine("a >= b - {0}", a >= b);
        }
    }
}