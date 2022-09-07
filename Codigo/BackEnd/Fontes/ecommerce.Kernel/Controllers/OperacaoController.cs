//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ecommerce.Kernel;
using ecommerce.Kernel.Util;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PCategoria;
using ecommerce.Kernel.DTO.PCategoria;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.DTO.POperacao;
using ecommerce.Kernel.Model.PSubcategoria;
using ecommerce.Kernel.Model.PClassificacao;
using ecommerce.Kernel.Model.PLogradouro;
using ecommerce.Kernel.Model.PTag;
using ecommerce.Kernel.Model.PProduto;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
	public class OperacaoController
	{
		public OperacaoController() 
		{
		}
		
				/* 
		 
		*/ 
		public Categoria SalvarConfiguracoesProduto(  ConfiguracoesDTO parametros) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Operacao.SalvarConfiguracoesProduto")) 
			{ 
				//<#keep(SalvarConfiguracoesProduto)#> 

				// Adicionar tratativa na lista parametros (remover duplicatas)
				//parametros = TratarDados(parametros);

				// Realiza a cria��o da categoria
				if (Categoria.Exists(parametros.nome))
					throw new Exception("Categoria j� existente no sistema");

				Categoria categoria = new Categoria(parametros.nome, StatusAtividade.Ativo);

				if (parametros.subcategorias.Count > 0)
				{
					// Realiza a grava��o das subcategorias
					foreach (var subcategoria in parametros.subcategorias)
					{
						SubCategoria sub = SubCategoria.obter(subcategoria.text);
						if (sub == null)
							sub = new SubCategoria(subcategoria.text, StatusAtividade.Ativo);

						categoria.VincularSCategoria(sub);

						// Realiza a grava��o das classifica��es
						if (subcategoria.classificacoes.Count > 0)
						{
							foreach (var classificacao in subcategoria.classificacoes)
							{
								ClassificacaoItem classif = ClassificacaoItem.obter(classificacao.ClassificacaoItem.nome);
								if (classif == null)
									classif = new ClassificacaoItem(classificacao.ClassificacaoItem.nome, StatusAtividade.Ativo);

								sub.VincularClassificacao(classif);
							}
						}
					}
				}

				c.SaveChanges();
				return categoria;
				//<#/keep(SalvarConfiguracoesProduto)#> 
			} 

		} 
		/* 
		 
		*/ 
		public List<Categoria> ListarConfiguracoesProduto() 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Operacao.ListarConfiguracoesProduto")) 
			{ 
				//<#keep(ListarConfiguracoesProduto)#> 
				return Categoria.ObterTodas();
				//<#/keep(ListarConfiguracoesProduto)#> 
			} 

		} 
		/* 
		 
		*/ 
		public List<Logradouro> ListarLogradourosPorUserId(  int userId) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Operacao.ListarLogradourosPorUserId")) 
			{ 
				//<#keep(ListarLogradourosPorUserId)#> 
				List<Logradouro> enderecos = Logradouro.ObterPorUserId(userId);
				c.SaveChanges();
				return enderecos;
				//<#/keep(ListarLogradourosPorUserId)#> 
			} 

		} 
		/* 
		 
		*/ 
		public List<Tags> ListarTags(  String caracteres) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Operacao.ListarTags")) 
			{ 
				//<#keep(ListarTags)#> 
				List<Tags> tags = Tags.ListarTagsPorCaracter(caracteres);
				return tags;
				//<#/keep(ListarTags)#> 
			} 

		} 
		/* 
		 
		*/ 
		public List<Produto> ListarProdutos() 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Operacao.ListarProdutos")) 
			{ 
				//<#keep(ListarProdutos)#> 
				List<Produto> list = Produto.ObterProdutos(null, null);
				return list;
				//<#/keep(ListarProdutos)#> 
			} 

		} 
		/* 
		 
		*/ 
		public Produto ObterProdutoPorId(  int id) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Operacao.ObterProdutoPorId")) 
			{ 
				//<#keep(ObterProdutoPorId)#> 
				Produto produto = Produto.ObterProdutoPorId(id);
				return produto;
				//<#/keep(ObterProdutoPorId)#> 
			} 

		} 

		//<#keep(implementation)#>
		
		//OLHAR FUNÇÕES FALTANTES !

		//<#/keep(implementation)#>
	}
}
