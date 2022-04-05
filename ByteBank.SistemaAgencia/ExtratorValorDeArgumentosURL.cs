using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;  
        public string URL { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {

            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url nao pode ser nulo ou vazia.", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;
        }
    }
}
