using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Kernel.Util.Mensagem
{
    public class Retorno
    {
        public bool erro = false;
        public bool erroPlataforma = false;
        public Exception e;
        public string mensagem;
    }
}
