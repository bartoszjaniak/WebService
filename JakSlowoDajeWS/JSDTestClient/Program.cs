using JSDTestClient.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JSDTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var macierz = new double[][] { new[] { 2.2, 3.4 }, new[] { 5.4, 6.7 } };
            int mnoznik = 2;
            var ws = new MathService();
            ws.UserAuthValue = new UserAuth() { UserName = "Kuba112", Password = "Tajne#haslo!" };
            var wynik = ws.MacierzRazyLiczba(macierz, mnoznik);
            wynik.SelectMany(x => x.ToList()).ToList().ForEach(Console.WriteLine);
            Console.ReadLine();

        }
    }
}
