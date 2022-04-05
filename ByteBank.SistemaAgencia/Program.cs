using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime dataFimPagamento = new DateTime(2022, 1, 20);
            //DateTime dataCorrente = DateTime.Now;

            //TimeSpan diferenca = dataCorrente - dataFimPagamento;
            //TimeSpan diferenca = TimeSpan.FromMinutes(40);
            //string msg = "vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);


            //Console.WriteLine(dataCorrente);
            //Console.WriteLine(dataFimPagamento);

            //Console.WriteLine(msg);

            //ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(null);

            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "kjdskldjsl";

            Console.WriteLine(String.IsNullOrEmpty(textoVazio));
            Console.WriteLine(String.IsNullOrEmpty(textoNulo));
            Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
            

            Console.ReadLine();

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf('?') + 1;

            Console.WriteLine(url);

            string argumentos = url.Substring(indiceInterrogacao);

            Console.WriteLine(argumentos);


            Console.ReadLine();
            
        }

    }
}
