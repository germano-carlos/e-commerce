//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;using ecommerce.Kernel.Model.PClassificacao; 
using ecommerce.Kernel.Model.PSubcategoria; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PSubcategoria
{
	[Table("SUBCATEGORIA_CLASSIFICACAO")]
	public class SubCategoriaClassificacao
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "BIGINT")] public long id { get; set; } 
		[Column("id_classificacao", TypeName = "INT"), ForeignKey("ClassificacaoItem")] public int id_classificacao { get; set; } 
		public virtual ClassificacaoItem ClassificacaoItem { get; set; } 
		[Column("id_subcategoria", TypeName = "INT"), ForeignKey("SubCategoria")] public int id_subcategoria { get; set; } 
		public virtual SubCategoria SubCategoria { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public SubCategoriaClassificacao() { }
		//<#keep(constructor)#>
		public SubCategoriaClassificacao(SubCategoria subcategoria, ClassificacaoItem classificacao)
		{
			this.SubCategoria = subcategoria;
			this.ClassificacaoItem = classificacao;

			ecommerceContext.Get().SubCategoriaClassificacaoSet.Add(this);
		}
		//<#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().SubCategoriaClassificacaoSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}