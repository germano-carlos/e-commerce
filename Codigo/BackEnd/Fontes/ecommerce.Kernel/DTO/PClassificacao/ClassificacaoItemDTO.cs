//<#keep(imports)#>
using ecommerce.Kernel.Model.PEnums;
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PClassificacao
{
	public class ClassificacaoItemDTO
	{
		public int classificacaoId;
		public String nome;
		public DateTime dataInclusao;
		public DateTime dataAlteracao;
		public StatusAtividade StatusAtividade;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}