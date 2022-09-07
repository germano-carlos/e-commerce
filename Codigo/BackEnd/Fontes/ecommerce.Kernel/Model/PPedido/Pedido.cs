//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;using ecommerce.Kernel.Model.PAuth;
using ecommerce.Kernel.DTO.PPedido;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PPedido
{
	[Table("PEDIDO")]
	public class Pedido
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_pedido", TypeName = "BIGINT")] public long pedidoId { get; set; } 
		[Column("data_inclusao", TypeName = "DATETIME"),   Required] public DateTime dataInclusao { get; set; } 
		[Column("data_alteracao", TypeName = "DATETIME"),   Required] public DateTime dataAlteracao { get; set; } 
		[Column("STATUSPEDIDO", TypeName = "INT"), Required] public StatusPedido StatusPedido { get; set; }
		[Column("id_usuario", TypeName = "BIGINT"), ForeignKey("Usuario")] public long id_usuario { get; set; } 
		public virtual Usuario Usuario { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Pedido() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().PedidoSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static Pedido ObterPedidosPorId(long id)
        {
			return ecommerceContext.Get().PedidoSet.Find(id);
        }
		public static List<Pedido> ObterPedidosPorId(HashSet<long> ids)
        {
			return (from p in ecommerceContext.Get().PedidoSet
					where ids.Contains(p.pedidoId)
					select p).ToList();
		}

		//<#/keep(implements)#>
	}
}