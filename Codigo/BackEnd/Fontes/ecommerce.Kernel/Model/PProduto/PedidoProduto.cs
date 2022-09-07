//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;using ecommerce.Kernel.Model.PProduto; 
using ecommerce.Kernel.Model.PPedido;
using ecommerce.Kernel.Model.PAuth;
using ecommerce.Kernel.DTO.PAuth;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PProduto
{
	[Table("PEDIDO_PRODUTO")]
	public class PedidoProduto
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "BIGINT")] public long id { get; set; } 
		[Column("id_produto", TypeName = "BIGINT"), ForeignKey("Produto")] public long id_produto { get; set; } 
		public virtual Produto Produto { get; set; } 
		[Column("id_pedido", TypeName = "BIGINT"), ForeignKey("Pedido")] public long id_pedido { get; set; } 
		public virtual Pedido Pedido { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public PedidoProduto() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().PedidoProdutoSet.Remove(this);
			//<#/keep(delete)#>
		}

		public static List<PedidoProduto> ObterPedidosUsuario(UsuarioDTO user)
		{
			return (from p in ecommerceContext.Get().PedidoProdutoSet
					where p.Pedido.id_usuario == user.usuarioId
					select p).Include(p => p.Pedido).ToList();
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}