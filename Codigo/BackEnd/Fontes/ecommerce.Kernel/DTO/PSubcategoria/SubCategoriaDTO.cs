//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using ecommerce.Kernel.DTO.PSubcategoria;
using ecommerce.Kernel.Model.PEnums;

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PSubcategoria
{
	public class SubCategoriaDTO
	{
		public int subcategoriaId;
		public String nome;
		public DateTime dataInclusao;
		public DateTime dataAlteracao;
		public StatusAtividade StatusAtividade;
		public List<SubCategoriaClassificacaoDTO> classificacoes = new List<SubCategoriaClassificacaoDTO>();

		//<#keep(implements)#>
		public String text;
		//<#/keep(implements)#>
	}
}