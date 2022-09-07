//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using ecommerce.Kernel.DTO.PProduto;

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PProduto
{
	public class ProdutoOpcaoDTO
	{
		public long id;
		public String tamanho;
		public String cor;
		public decimal preco;
		public int quantidade;
		public ProdutoDTO Produto;
		public OpcaoDTO Opcao;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}