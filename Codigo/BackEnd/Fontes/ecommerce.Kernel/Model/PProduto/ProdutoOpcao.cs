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
using ecommerce.Kernel.Model.PProduto;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PProduto
{
	[Table("PRODUTO_OPCAO")]
	public class ProdutoOpcao
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "BIGINT")] public long id { get; set; } 
		[Column("cor", TypeName = "VARCHAR(20)"),   MaxLength(20),   Required] public String cor { get; set; } 
		[Column("preco", TypeName = "decimal(0, 2)"),   Required] public decimal preco { get; set; } 
		[Column("quantidade", TypeName = "INT"),   Required] public int quantidade { get; set; } 
		[Column("tamanho", TypeName = "VARCHAR(20)")] public String tamanho { get; set; } 
		[Column("id_produto", TypeName = "BIGINT"), ForeignKey("Produto")] public long? id_produto { get; set; } 
		public virtual Produto Produto { get; set; } 
		[Column("id_opcao", TypeName = "BIGINT"), ForeignKey("Opcao")] public long id_opcao { get; set; } 
		public virtual Opcao Opcao { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public ProdutoOpcao() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().ProdutoOpcaoSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}