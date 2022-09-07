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

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PLogradouro
{
	[Table("LOGRADOURO")]
	public class Logradouro
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_logradouro", TypeName = "INT")] public int logradouroId { get; set; } 
		[Column("rua", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String rua { get; set; } 
		[Column("bairro", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String bairro { get; set; } 
		[Column("numero", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String numero { get; set; } 
		[Column("cep", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String cep { get; set; } 
		[Column("cidade", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String cidade { get; set; } 
		[Column("estado", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String estado { get; set; } 
		[Column("complemento", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String complemento { get; set; } 
		[Column("uf", TypeName = "VARCHAR(2)"),   MaxLength(2),   Required] public String uf { get; set; } 
		[Column("apelido", TypeName = "VARCHAR(0)"),   MaxLength(0)] public String apelido { get; set; } 
		[Column("id_usuario", TypeName = "BIGINT"), ForeignKey("Usuario")] public long? id_usuario { get; set; } 
		public virtual Usuario Usuario { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Logradouro() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().LogradouroSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		internal static List<Logradouro> ObterPorUserId(int userId)
		{
			return ecommerceContext.Get().LogradouroSet.Where(l => l.id_usuario == userId).ToList();
		}
		//<#/keep(implements)#>
	}
}