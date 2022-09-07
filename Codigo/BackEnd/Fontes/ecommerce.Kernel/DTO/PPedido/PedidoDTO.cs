//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using ecommerce.Kernel.DTO.PAuth;
using ecommerce.Kernel.Model.PPedido;

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PPedido
{
	public class PedidoDTO
	{
		public long pedidoId;
		public DateTime dataInclusao;
		public DateTime dataAlteracao;
		public StatusPedido StatusPedido;
		public UsuarioDTO Usuario;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}