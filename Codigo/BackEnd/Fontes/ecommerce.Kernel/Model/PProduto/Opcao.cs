//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ecommerce.Kernel.Model.PEnums;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PProduto
{
	[Table("OPCAO")]
	public class Opcao
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_opcao", TypeName = "BIGINT")] public long opcaoId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(0)"),   MaxLength(0),   Required] public String nome { get; set; } 
		[Column("STATUSATIVIDADE", TypeName = "INT"), Required] public StatusAtividade StatusAtividade { get; set; }

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Opcao() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().OpcaoSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}