//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PProduto; 
using ecommerce.Kernel.DTO.PPedido; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PProduto
{
	public class PedidoProdutoDTO
	{
		public long id;
		public ProdutoDTO Produto;
		public PedidoDTO Pedido;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}