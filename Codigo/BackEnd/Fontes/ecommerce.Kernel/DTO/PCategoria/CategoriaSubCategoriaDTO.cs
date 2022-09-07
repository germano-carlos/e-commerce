//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PCategoria; 
using ecommerce.Kernel.DTO.PSubcategoria; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PCategoria
{
	public class CategoriaSubCategoriaDTO
	{
		public long id;
		public CategoriaDTO Categoria;
		public SubCategoriaDTO SubCategoria;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}