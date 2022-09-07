//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PProduto; 

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PMarca
{
	public class MarcaDTO
	{
		public long marcaId;
		public String nome;
		public String logo;
		public List<ProdutoDTO> produtos = new List<ProdutoDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}