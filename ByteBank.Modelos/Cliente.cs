using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            Cliente outroCliente = obj as Cliente; // Fazendo cast do obj em Cliente com a palavra reservada AS, caso nao consiga, passa null para outroCliente

            if(outroCliente == null)
            {
                return false; 
            }

            return CPF == outroCliente.CPF;
        }
    }
}
