//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ecommerce.Kernel;
using ecommerce.Kernel.DTO.POperacao;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PCategoria;
using ecommerce.Kernel.Model.PClassificacao;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.Model.PSubcategoria;
using ecommerce.Kernel.Util;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
	public class CategoriaController
	{
		public CategoriaController() 
		{
		}
		
				/* 
		 
		*/ 
		public Categoria SalvarConfiguracoesProduto(  ConfiguracoesDTO parametros) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Categoria.SalvarConfiguracoesProduto")) 
			{ 
				//<#keep(SalvarConfiguracoesProduto)#>

				// Realiza a cria��o da categoria
				if (Categoria.Exists(parametros.nome))
					throw new Exception("Categoria ja existente no sistema");

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
			using (ecommerceContext c = ecommerceContext.Get("Categoria.ListarConfiguracoesProduto")) 
			{ 
				//<#keep(ListarConfiguracoesProduto)#> 
				return Categoria.ObterTodas();
				//<#/keep(ListarConfiguracoesProduto)#> 
			} 

		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
