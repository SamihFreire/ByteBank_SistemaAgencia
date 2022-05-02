using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Lista<T> //Criando uma lista com tipo generico, com isso no program quando instanciada essa lista em tempo de compilação será fixada a lista o tipo o qual foi criado a lista, fazendo com que o compilador so permitar o tipo referente a lista criada
    {
        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public Lista(int capacidadeInicial = 5) //Adicionando um valor padrão ao construtor caso nao seja informado
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }
        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            Console.WriteLine($"Adiconando item na posição {_proximaPosicao}.");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void AdicionarVarios(params T[] itens) //Params possibilita passar varios intens por parametro
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        public void Remover(T item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;

            //_itens[_proximaPosicao] = null;
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            Console.WriteLine("Aumentando Capacidade da lista");

            T[] novoArray = new T[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];

                Console.WriteLine(".");
            }

            _itens = novoArray;
        }

        public T this[int indice]  //Definindo Indexadores - criando a mesma sintaxe do array
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}
