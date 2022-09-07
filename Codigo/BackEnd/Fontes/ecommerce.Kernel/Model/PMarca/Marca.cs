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

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PMarca
{
	[Table("MARCA")]
	public class Marca
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_marca", TypeName = "BIGINT")] public long marcaId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nome { get; set; } 
		[Column("logo", TypeName = "TEXT")] public String logo { get; set; } 
		[InverseProperty("Marca")] public virtual List<Produto> produtos { get; set; }  // ICollection 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Marca() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().MarcaSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}