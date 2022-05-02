using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens) //Definindo nesse metodo static qual list por meio do This. Com isso posso chamar a lista e o método, Ex.: listaDeinteiros.AdicionarVarios();
        {                                       // Indica que estamos extendendo o tipo List por meio do This;
            foreach(int item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }

    }
}
