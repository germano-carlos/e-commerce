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
using ecommerce.Kernel.Model.PTag; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PTag
{
	[Table("TAGS_PRODUTO")]
	public class TagsProduto
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_tag_produto", TypeName = "BIGINT")] public long TagProdutoId { get; set; } 
		[Column("id_tag", TypeName = "BIGINT"),   Required] public long TagId { get; set; } 
		[Column("id_produto", TypeName = "BIGINT"),   Required] public long ProdutoId { get; set; } 
		[Column("id_produto", TypeName = "BIGINT"), ForeignKey("Produto")] public long id_produto { get; set; } 
		public virtual Produto Produto { get; set; } 
		[Column("id_tag", TypeName = "BIGINT"), ForeignKey("Tags")] public long id_tag { get; set; } 
		public virtual Tags Tags { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public TagsProduto() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().TagsProdutoSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}