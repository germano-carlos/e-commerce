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
using ecommerce.Kernel.Model.PSubcategoria; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PCategoria
{
	[Table("CATEGORIA_SUBCATEGORIA")]
	public class CategoriaSubCategoria
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "BIGINT")] public long id { get; set; } 
		[Column("id_categoria", TypeName = "INT"), ForeignKey("Categoria")] public int id_categoria { get; set; } 
		public virtual Categoria Categoria { get; set; } 
		[Column("id_subcategoria", TypeName = "INT"), ForeignKey("SubCategoria")] public int id_subcategoria { get; set; } 
		public virtual SubCategoria SubCategoria { get; set; } 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public CategoriaSubCategoria() { }
		//<#keep(constructor)#>
		public CategoriaSubCategoria(Categoria cat, SubCategoria sub)
		{
			this.SubCategoria = sub;
			this.Categoria = cat;

			ecommerceContext.Get().CategoriaSubCategoriaSet.Add(this);
		}

		//<#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().CategoriaSubCategoriaSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#><#/keep(implements)#>
	}
}