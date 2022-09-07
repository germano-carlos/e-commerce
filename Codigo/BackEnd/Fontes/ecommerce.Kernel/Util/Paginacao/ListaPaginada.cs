using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecommerce.Kernel.Util.Paginação
{
    public class ListaPaginada<T> : List<T>
    {
        public int paginaAtual { get; private set; }
        public int totalPaginas { get; private set; }
        public int tamanhoPagina { get; private set; }
        public int totalRegistros { get; private set; }

        public bool possuiAntes => paginaAtual > 1;
        public bool possuiDepois => paginaAtual < totalPaginas;

        public ListaPaginada(List<T> registros, int contador, int numeroPagina, int tamanhoPagina)
        {
            this.totalRegistros = contador;
            this.tamanhoPagina = tamanhoPagina;
            this.paginaAtual = numeroPagina;
            this.totalPaginas = (int)Math.Ceiling(contador / (double)tamanhoPagina);

            AddRange(registros);
        }

        public static ListaPaginada<T> ToListaPaginada(IQueryable<T> fonte, int numeroPagina, int tamanhoPagina)
        {
            int contador = fonte.Count();
            var registros = fonte.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

            return new ListaPaginada<T>(registros, contador, numeroPagina, tamanhoPagina);
        }

        public static Object ListaPaginadaComMetaData(ListaPaginada<T> lista)
        {
            return new
            {
                _metadata = new
                {
                    paginaAtual = lista.paginaAtual,
                    totalPaginas = lista.totalPaginas,
                    tamanhoPagina = lista.tamanhoPagina,
                    totalRegistros = lista.totalRegistros,
                    possuiAntes = lista.possuiAntes,
                    possuiDepois = lista.possuiDepois
                },
                registros = lista
            };
        }
    }
}
