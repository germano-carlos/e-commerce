using ecommerce.Kernel.Model.PEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Kernel.DTO.PProduto
{
    public class FiltroProduto
    {
        public List<long> MarcasIds = new List<long>();
        public List<long> CategoriasIds = new List<long>();
        public List<string> Tamanhos = new List<string>();
        public List<decimal> Preco = new List<decimal>();
        public List<string> Cores = new List<string>();
        public StatusAtividade? StatusAtividade { get; set; }
    }
}
