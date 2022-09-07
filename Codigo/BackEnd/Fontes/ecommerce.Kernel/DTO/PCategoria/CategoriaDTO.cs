//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using ecommerce.Kernel.DTO.PCategoria;
using ecommerce.Kernel.Model.PEnums;

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PCategoria
{
	public class CategoriaDTO
	{
		public int categoriaId;
		public String nome;
		public DateTime dataInclusao;
		public DateTime dataAlteracao;
		public StatusAtividade StatusAtividade;
		public List<CategoriaSubCategoriaDTO> subcategorias = new List<CategoriaSubCategoriaDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}