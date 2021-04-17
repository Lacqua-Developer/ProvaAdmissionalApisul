using System;

namespace ProvaAdmissionalCSharpApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            Elevadores el = new Elevadores();

             el.andarMenosUtilizado();
            Console.WriteLine("----------------------");
            el.elevadorMaisFrequentado();
            Console.WriteLine("----------------------");
            el.elevadorMenosFrequentado();
            Console.WriteLine("----------------------");
            el.percentualDeUsoElevadorA();
            Console.WriteLine("----------------------");
            el.percentualDeUsoElevadorB();
            Console.WriteLine("----------------------");
            el.percentualDeUsoElevadorC();
            Console.WriteLine("----------------------");
            el.percentualDeUsoElevadorD();
            Console.WriteLine("----------------------");
            el.percentualDeUsoElevadorE();

            Console.WriteLine("----------------------");
            el.periodoMaiorFluxoElevadorMaisFrequentado();
            Console.WriteLine("----------------------");
            el.periodoMenorFluxoElevadorMenosFrequentado();
            Console.WriteLine("----------------------");
            el.periodoMaiorUtilizacaoConjuntoElevadores();

            Console.ReadKey();
        }
    }
}
