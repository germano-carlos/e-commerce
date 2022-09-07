//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PCategoria; 
using ecommerce.Kernel.DTO.PProduto; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PProduto
{
	public class ProdutoCategoriaDTO
	{
		public long id;
		public CategoriaDTO Categoria;
		public ProdutoDTO Produto;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}