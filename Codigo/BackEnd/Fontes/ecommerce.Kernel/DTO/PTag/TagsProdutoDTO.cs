//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PProduto; 
using ecommerce.Kernel.DTO.PTag; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PTag
{
	public class TagsProdutoDTO
	{
		public long TagProdutoId;
		public long TagId;
		public long ProdutoId;
		public ProdutoDTO Produto;
		public TagsDTO Tags;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}