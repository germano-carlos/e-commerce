//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using ecommerce.Kernel.DTO.PMarca; 
using ecommerce.Kernel.DTO.PProduto;
using ecommerce.Kernel.DTO.PTag;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.Model.PProduto;

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PProduto
{
	public class ProdutoDTO
	{
		public long produtoId;
		public String nome;
		public String descricao;
		public DateTime dataInsercao;
		public DateTime dataAtualizacao;
		public decimal? rating;
		public StatusAtividade StatusAtividade;
		public MarcaDTO Marca;
		public List<ProdutoCategoriaDTO> categorias = new List<ProdutoCategoriaDTO>();
		public List<PedidoProdutoDTO> pedidos = new List<PedidoProdutoDTO>();
		public List<ProdutoOpcaoDTO> opcoes = new List<ProdutoOpcaoDTO>();
		public List<TagsProdutoDTO> tags = new List<TagsProdutoDTO>();
		public List<AnexoImagemDTO> AnexoImagemList = new List<AnexoImagemDTO>();

		//<#keep(implements)#>
		public bool latest;
		public bool trending;
		public bool bestSellers;
		public int totalRegistro;
		//<#/keep(implements)#>
	}
}