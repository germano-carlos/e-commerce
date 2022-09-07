//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ecommerce.Kernel;
using ecommerce.Kernel.DTO.PAuth;
using ecommerce.Kernel.DTO.PMarca;
using ecommerce.Kernel.DTO.PProduto;
using ecommerce.Kernel.DTO.PTag;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PPedido;
using ecommerce.Kernel.Model.PProduto;
using ecommerce.Kernel.Util;
using ecommerce.Kernel.Util.Paginação;
using Newtonsoft.Json.Linq;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
	public class ProdutoController
	{
		public ProdutoController()
		{
		}

		/* 

*/
		public ListaPaginada<ProdutoDTO> ListarProdutos(PaginacaoParametros queryParams, FiltroProduto filtros)
		{
			using (ecommerceContext c = ecommerceContext.Get("Produto.ListarProdutos"))
			{
				//<#keep(ListarProdutos)#>
				var relatorio = Produto.ObterProdutos(queryParams, filtros);

				ListaPaginada<ProdutoDTO> retorno = new ListaPaginada<ProdutoDTO>(new List<ProdutoDTO>(), relatorio.totalRegistros, relatorio.paginaAtual, relatorio.tamanhoPagina);

				foreach (var m in relatorio)
				{
					// Cria o objeto DTO de Marca
					MarcaDTO mDTO = new MarcaDTO
					{
						marcaId = m.Marca.marcaId,
						nome = m.Marca.nome,
						logo = m.Marca.logo
					};

					// Cria o objeto DTO de ProdutoCategoria
					List<ProdutoCategoriaDTO> categoriaDTO = new List<ProdutoCategoriaDTO>();
					if(m.categorias != null)
                    {
						foreach (var cat in m.categorias)
						{
							categoriaDTO.Add(new ProdutoCategoriaDTO
							{
								id = cat.id,
								Categoria = new DTO.PCategoria.CategoriaDTO
								{
									categoriaId = cat.Categoria.categoriaId,
									nome = cat.Categoria.nome,
									StatusAtividade = cat.Categoria.StatusAtividade
								}
							});
						}
					}

					// Cria o objeto DTO de Op��o
					List<ProdutoOpcaoDTO> opcaoDTO = new List<ProdutoOpcaoDTO>();
					if (m.opcoes != null)
                    {
						foreach (var op in m.opcoes)
						{
							opcaoDTO.Add(new ProdutoOpcaoDTO
							{
								id = op.id,
								tamanho = op.tamanho,
								cor = op.cor,
								preco = op.preco,
								quantidade = op.quantidade,
								Opcao = new OpcaoDTO
								{
									opcaoId = op.Opcao.opcaoId,
									nome = op.Opcao.nome,
									StatusAtividade = op.Opcao.StatusAtividade
								}

							});
						}
					}

					// Cria o objeto DTO de Anexos
					List<AnexoImagemDTO> anexoDTO = new List<AnexoImagemDTO>();
					if (m.AnexoImagemList != null)
					{
						foreach (var anex in m.AnexoImagemList)
						{
							anexoDTO.Add(new AnexoImagemDTO
							{
								anexoId = anex.anexoId,
								descricao = anex.descricao
							});
						}
					}

					retorno.Add(new ProdutoDTO
					{
						produtoId = m.produtoId,
						nome = m.nome,
						descricao = m.descricao,
						dataInsercao = m.dataInsercao,
						dataAtualizacao = m.dataAtualizacao,
						rating = m.rating,
						StatusAtividade = m.StatusAtividade,
						Marca = mDTO,
						categorias = categoriaDTO,
						opcoes = opcaoDTO,
						tags = new List<TagsProdutoDTO>(),
						AnexoImagemList = anexoDTO
					});
				}

				return retorno;
				//<#/keep(ListarProdutos)#> 
			} 

		} 
		/* 
		 
		*/ 
		public Produto ObterProdutoPorId(  long id) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Produto.ObterProdutoPorId")) 
			{ 
				//<#keep(ObterProdutoPorId)#> 
				return Produto.ObterProdutoPorId(id); 
				//<#/keep(ObterProdutoPorId)#> 
			} 

		} 
		/* 
		 
		*/ 
		public List<Produto> ObterUltimosProdutos() 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Produto.ObterUltimosProdutos")) 
			{ 
				//<#keep(ObterUltimosProdutos)#> 
				return Produto.ObterUltimosProdutos(); 
				//<#/keep(ObterUltimosProdutos)#> 
			} 

		} 
		/* 
		 
		*/ 
		public List<ProdutoDTO> ObterProdutosPopulares() 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Produto.ObterProdutosPopulares")) 
			{
				//<#keep(ObterProdutosPopulares)#> 
				List<Produto> produtosVendidos = Produto.ObterProdutosVendidos(true);
				List<ProdutoDTO> retorno = new List<ProdutoDTO>();
				Dictionary<long, HashSet<long>> agrupador = new Dictionary<long, HashSet<long>>();

				foreach (Produto produto in produtosVendidos)
				{
					long key = produto.produtoId;
					foreach (PedidoProduto pedido in produto.pedidos)
                    {
						if (!agrupador.ContainsKey(key))
							agrupador.Add(key, new HashSet<long>());
						agrupador[key].Add(pedido.Pedido.Usuario.usuarioId);
                    }

					retorno.Add(new ProdutoDTO()
					{
						produtoId = produto.produtoId,
						nome = produto.nome,
						descricao = produto.descricao,
						dataInsercao = produto.dataInsercao,
						dataAtualizacao = produto.dataAtualizacao,
						rating = produto.rating,
						StatusAtividade = produto.StatusAtividade,
						AnexoImagemList = Util.Helper.JsonToObject<List<AnexoImagemDTO>>(Util.Helper.ObjectToJson(produto.AnexoImagemList)),
						opcoes = Util.Helper.JsonToObject<List<ProdutoOpcaoDTO>>(Util.Helper.ObjectToJson(produto.opcoes)),
						latest = false,
						trending = true,
						bestSellers = false,
						totalRegistro = agrupador[key].Count
					});
				}

				retorno.Sort((o1, o2) => o2.totalRegistro.CompareTo(o1.totalRegistro));
				return retorno;
				//<#/keep(ObterProdutosPopulares)#> 
			}
		} 
		/* 
		 
		*/ 
		public List<ProdutoDTO> ObterProdutosMaisVendidos() 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Produto.ObterProdutosMaisVendidos")) 
			{ 
				//<#keep(ObterProdutosMaisVendidos)#>
				List<Produto> produtosVendidos = Produto.ObterProdutosVendidos();
				List<ProdutoDTO> retorno = new List<ProdutoDTO>();

				foreach (Produto produto in produtosVendidos)
				{
					int quantidadeVendas = produto.pedidos.Count;
					retorno.Add(new ProdutoDTO()
					{
						produtoId = produto.produtoId,
						nome = produto.nome,
						descricao = produto.descricao,
						dataInsercao = produto.dataInsercao,
						dataAtualizacao = produto.dataAtualizacao,
						rating = produto.rating,
						StatusAtividade = produto.StatusAtividade,
						AnexoImagemList = Util.Helper.JsonToObject<List<AnexoImagemDTO>>(Util.Helper.ObjectToJson(produto.AnexoImagemList)),
						opcoes = Util.Helper.JsonToObject<List<ProdutoOpcaoDTO>>(Util.Helper.ObjectToJson(produto.opcoes)),
						latest = false,
						trending = false,
						bestSellers = true,
						totalRegistro = quantidadeVendas
					});
				}

				retorno.Sort((o1, o2) => o2.totalRegistro.CompareTo(o1.totalRegistro));
				return retorno;

				//<#/keep(ObterProdutosMaisVendidos)#> 
			}

		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
