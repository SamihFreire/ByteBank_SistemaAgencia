using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //Classe REGEX para Expressões Regulares

            string padrao = "[0-9]{4,5}-?[0-9]{4}"; //{4, 5} Afirmando que aceita 4 ate 5 digitos na primeira parte / [-]{0,1} aceita sem [-] ou com [-], posso usar ? tbm para isso
            string textoDeTeste = "Meu nome é guilherme, me ligue em 98784-4546";

            Match match = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine("Existe o numero: " + Regex.IsMatch(textoDeTeste, padrao));
            if(Regex.IsMatch(textoDeTeste, padrao)) 
                Console.WriteLine("numero: " + match.Value);
            Console.ReadLine();






            string urlParametros = "https://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            string urlTesteInicio = "https://www.bytebank.com";
            string urlTesteFim = "valor=1500";

            Console.WriteLine("verificação url bytebank: " + urlParametros.StartsWith(urlTesteInicio));//os 3 casos são case sensitive
            Console.WriteLine("verificaçãp url bytebank: " + urlParametros.EndsWith(urlTesteFim));     //os 3 casos são case sensitive
            Console.WriteLine("verificação url bytebank: " + urlParametros.Contains(urlTesteInicio));  //os 3 casos são case sensitive
                                                                                                       
            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(urlParametros);

            Console.WriteLine("Valor de moeda origem: " + extrator.GetValor("moedaOrigEm"));
            Console.WriteLine("Valor de moeda destino: " + extrator.GetValor("moedaDEStinO"));
            Console.WriteLine("Valor: " + extrator.GetValor("VAlor"));

            //string testeRemocao = "primeiraParte&parteParaRemover";
            //int indiceEComercial = testeRemocao.IndexOf('&');
            //Console.WriteLine(testeRemocao.Remove(indiceEComercial));



            Console.ReadLine();
            
        }

    }
}
