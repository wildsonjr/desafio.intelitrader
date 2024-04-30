using System;

namespace desafio.intelitrader.distancia
{
    internal class Program
    {
        private static readonly int[] _array1 = new int[] { -7, -19, -96, -1, 55, -27, 36, -8, -82, 17, 16, 47, 68, -38, -81, 30 };
        private static readonly int[] _array2 = new int[] { 28, -15, 87, -46, 9, 23, 70, -59, -33, 90, -61, 13, 72, -11, 99, -51 };

        static void Main(string[] args)
        {
            var numero1 = default(int);
            var numero2 = default(int);
            var menorDistancia = int.MaxValue;

            foreach (var a1 in _array1)
            {
                foreach (var a2 in _array2)
                {
                    var distancia = Math.Abs(a1 - a2);

                    if (distancia < menorDistancia)
                    {
                        numero1 = a1;
                        numero2 = a2;
                        menorDistancia = distancia;
                    }
                }
            }

            Console.WriteLine("{0} - {1} = {2}", numero1, numero2, menorDistancia);
        }
    }
}
