using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Kernel.Util.Paginação
{
    public class PaginacaoParametros
    {
        private int _tamanhoMaximoPagina = 2000;
        private int _tamanhoPagina = 1000;
        public int numeroPagina { get; set; } = 1;
        public int tamanhoPagina
        {
            get { return _tamanhoPagina; }

            set { _tamanhoPagina = value > _tamanhoMaximoPagina ? _tamanhoMaximoPagina : value; }
        }
        public bool metadata { get; set; } = false;

    }
}
