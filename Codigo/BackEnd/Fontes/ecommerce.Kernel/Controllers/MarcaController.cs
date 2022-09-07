//<#keep(imports)#>
using ecommerce.Kernel.DTO.PMarca;
using ecommerce.Kernel.Model;
using System.Collections.Generic;
using System.Linq;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
    public class MarcaController
    {
        public MarcaController()
        {

        }

        public List<MarcaQuantidade> ObterMarcasMaisVendidas()
        {
            using (ecommerceContext c = ecommerceContext.Get("Marca.ObterMarcasMaisVendidas"))
            {
                //<#keep(ListarLogradourosPorUserId)#> 
                var pedidosProdutos = c.PedidoProdutoSet;
                var produtos = c.ProdutoSet;
                var marcas = c.MarcaSet;

                var query = (from marca in marcas
                            join produto in produtos
                            on marca.marcaId equals produto.id_marca
                            join pedidoProduto in pedidosProdutos
                            on produto.produtoId equals pedidoProduto.id_produto
                            group marca by marca.nome into m
                            select new MarcaQuantidade(){ Nome = m.Key, Quantidade = m.Count()});

                var marcasQuantidadeList = query.OrderByDescending(m => m.Quantidade).Take(5).ToList();

                //<#/keep(ListarLogradourosPorUserId)#> 
                return marcasQuantidadeList;
            }

        }


        //<#keep(implementation)#><#/keep(implementation)#>
    }
}
