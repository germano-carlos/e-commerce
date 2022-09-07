//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PClassificacao; 
using ecommerce.Kernel.DTO.PSubcategoria; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PSubcategoria
{
	public class SubCategoriaClassificacaoDTO
	{
		public long id;
		public ClassificacaoItemDTO ClassificacaoItem;
		public SubCategoriaDTO SubCategoria;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}