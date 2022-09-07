//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;using ecommerce.Kernel.Model.PCategoria; 
using ecommerce.Kernel.Model.PProduto; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PProduto
{
	[Table("PRODUTO_CATEGORIA")]
	public class ProdutoCategoria
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "BIGINT")] public long id { get; set; } 
		[Column("id_categoria", TypeName = "INT"), ForeignKey("Categoria")] public int id_categoria { get; set; } 
		public virtual Categoria Categoria { get; set; } 
		[Column("id_produto", TypeName = "BIGINT"), ForeignKey("Produto")] public long id_produto { get; set; } 
		public virtual Produto Produto { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public ProdutoCategoria() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().ProdutoCategoriaSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}