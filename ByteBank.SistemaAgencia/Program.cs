using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaCorrente conta1 = new ContaCorrente(2121, 5534);

            Console.WriteLine(conta1.Numero);

            Console.ReadLine();
            
        }
    }
}
