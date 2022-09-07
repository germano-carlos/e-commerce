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
//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PTag
{
	[Table("TAGS")]
	public class Tags
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_tag", TypeName = "BIGINT")] public long TagId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nome { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Tags() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().TagsSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>

		internal static List<Tags> ListarTagsPorCaracter(string caracteres)
		{
			return (from t in ecommerceContext.Get().TagsSet
					where t.nome.ToUpper().Contains(caracteres.ToUpper())
					select t).OrderBy(x => x.nome).ToList();
		}
		//<#/keep(implements)#>
	}
}