using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {   new ContaCorrente(341, 25666),
                null,
                new ContaCorrente(123, 32323),
                new ContaCorrente(432, 34245),
                null,
                new ContaCorrente(432, 1)
            };

            // contas.Sort(); ~~> Chama a implementação dada em IComparable

            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero); 

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadLine();   
        }

        static void TestandoVar()
        {
            var idade = 12; // declarando uma variavel com VAR é necessário atribuir na criação, pois dessa forma o var identifica o tipo daquela variavel
            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();
            var gerenciador2 = new GerenciadorBonificacao(); // o gerenciador2 funciona do mesmo jeito que o gerenciador

        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar(9);

            listaDeIdades.AdicionarVarios(1, 2, 3, 4, 5);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];

                Console.WriteLine($"Idade {idade} no indice {i}");
            }
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(111111111, 222222222);


            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(654654, 654646),
                new ContaCorrente(654654, 654333),
                new ContaCorrente(654654, 654333)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(contaDoGui, new ContaCorrente(654654, 654646), new ContaCorrente(654654, 654333)); //Se utilizando do Params 

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero} / {itemAtual.Agencia}");
            }
        }

        static int SomaVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach(int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(242, 23423),
                new ContaCorrente(565, 87654),
                new ContaCorrente(846, 57474)
            };


            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];
                Console.WriteLine($"Conta {i} - A:{contaAtual.Agencia} - N: {contaAtual.Numero}");
            }

        }

        static void TestaArrayInt()
        {
            int[] idades = new int[5];
            int acumulador = 0;

            idades[0] = 20;
            idades[1] = 15;
            idades[2] = 28;
            idades[3] = 35;
            idades[4] = 50;

            for (int i = 0; i < idades.Length; i++)
            {
                int idade = idades[i];

                Console.WriteLine($"Acessando o array idades no índice {i}");
                Console.WriteLine($"Valor de idades[{i}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;

            Console.WriteLine($"Média de idades = {media}");

        }


        static void teste()
        {
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            Console.ReadLine();



            //Classe REGEX para Expressões Regulares

            string padrao = "[0-9]{4,5}-?[0-9]{4}"; //{4, 5} Afirmando que aceita 4 ate 5 digitos na primeira parte / [-]{0,1} aceita sem [-] ou com [-], posso usar ? tbm para isso
            string textoDeTeste = "Meu nome é guilherme, me ligue em 98784-4546";

            Match match = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine("Existe o numero: " + Regex.IsMatch(textoDeTeste, padrao));
            if (Regex.IsMatch(textoDeTeste, padrao))
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

        }

    }
}
