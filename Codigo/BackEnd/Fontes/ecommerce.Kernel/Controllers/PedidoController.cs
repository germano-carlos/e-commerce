//<#keep(imports)#>
using ecommerce.Kernel.DTO.PAuth;
using ecommerce.Kernel.DTO.PPedido;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PPedido;
using ecommerce.Kernel.Model.PProduto;
using System;
using System.Collections.Generic;
using System.Linq;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
    public class PedidoController
	{
		public PedidoController() 
		{

		}

		/*
		*/

		//<#keep(implementation)#>
		public List<PedidoProduto> ObterPedidosUsuario(UsuarioDTO user)
		{
			using (ecommerceContext c = ecommerceContext.Get("PedidoProduto.ObterPedidosUsuario"))
			{
				//<#keep(ListarProdutos)#>
				return PedidoProduto.ObterPedidosUsuario(user);
				//<#/keep(ListarProdutos)#> 
			}

		}

        public List<PedidoQuantidadeDTO> ObterPedidosPorMes()
        {

			using (ecommerceContext c = ecommerceContext.Get("PedidoProduto.ObterPedidosPorMes"))
			{
				var pedidos = c.PedidoSet;
				var query = from pedido in pedidos
							where pedido.dataInclusao.Year.Equals(DateTime.Now.Year) && pedido.StatusPedido.Equals(StatusPedido.Finalizado)
							group pedido by pedido.dataInclusao.Month into p
							select new PedidoQuantidadeDTO()
							{
								Mes = p.Key,
								Quantidade = p.Count()
							};

				return query.ToList();
			}
        }
        //<#/keep(implementation)#>
    }
}
