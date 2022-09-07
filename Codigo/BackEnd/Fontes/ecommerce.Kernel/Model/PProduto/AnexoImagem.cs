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
using System.Runtime.Serialization;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PProduto
{
	[Table("ANEXO_IMAGEM")]
	public class AnexoImagem
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_anexo", TypeName = "INT")] public int anexoId { get; set; } 
		[Column("descricao", TypeName = "TEXT"),   Required] public String descricao { get; set; } 
		[Column("id_produto", TypeName = "BIGINT"), ForeignKey("Produto")] public long id_produto { get; set; } 
		public virtual Produto Produto { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public AnexoImagem() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().AnexoImagemSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}