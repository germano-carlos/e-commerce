//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ecommerce.Kernel.Model.PMarca; 
using ecommerce.Kernel.Model.PProduto;
using ecommerce.Kernel.Model.PTag;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.DTO.PProduto;
using ecommerce.Kernel.Model.PPedido;
using ecommerce.Kernel.Util.Paginação;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PProduto
{
	[Table("PRODUTO")]
	public class Produto
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_produto", TypeName = "BIGINT")] public long produtoId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nome { get; set; } 
		[Column("descricao", TypeName = "TEXT"),   Required] public String descricao { get; set; } 
		[Column("data_insercao", TypeName = "DATETIME"),   Required] public DateTime dataInsercao { get; set; } 
		[Column("data_atualizacao", TypeName = "DATETIME"),   Required] public DateTime dataAtualizacao { get; set; } 
		[Column("rating", TypeName = "decimal(0, 2)")] public decimal? rating { get; set; } 
		[Column("STATUSATIVIDADE", TypeName = "INT"), Required] public StatusAtividade StatusAtividade { get; set; }
		[Column("id_marca", TypeName = "BIGINT"), ForeignKey("Marca")] public long id_marca { get; set; } 
		public virtual Marca Marca { get; set; } 
		[InverseProperty("Produto")] public virtual List<ProdutoCategoria> categorias { get; set; }  // ICollection 
		[InverseProperty("Produto")] public virtual List<PedidoProduto> pedidos { get; set; }  // ICollection 
		[InverseProperty("Produto")] public virtual List<ProdutoOpcao> opcoes { get; set; }  // ICollection 
		[InverseProperty("Produto")] public virtual List<TagsProduto> tags { get; set; }  // ICollection 
		[InverseProperty("Produto")] public virtual List<AnexoImagem> AnexoImagemList { get; set; }  // ICollection 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Produto() { }
		//<#keep(constructor)#><#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().ProdutoSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>


		public static ListaPaginada<Produto> ObterProdutos(PaginacaoParametros queryParams, FiltroProduto filtros)
		{
			IQueryable<Produto> query = ecommerceContext.Get().ProdutoSet
																.Include(c => c.categorias).ThenInclude(cc => cc.Categoria)
																.Include(anexo => anexo.AnexoImagemList)
																.Include(op => op.opcoes).ThenInclude(op => op.Opcao)
																.Include(m => m.Marca);

			//Inicia a aplicação dos filtros
			query = AplicaFiltros(query, filtros);

			return ListaPaginada<Produto>.ToListaPaginada(query, queryParams.numeroPagina, queryParams.tamanhoPagina);
		}

		public static Produto ObterProdutoPorId(long id)
		{
			return (from p in ecommerceContext.Get().ProdutoSet
									.Include(c => c.categorias).ThenInclude(cc => cc.Categoria)
									.ThenInclude(s => s.subcategorias)
									.ThenInclude(ss => ss.SubCategoria)
									.ThenInclude(cl => cl.classificacoes)
									.ThenInclude(classif => classif.ClassificacaoItem)
									.Include(m => m.Marca)
									.Include(t => t.tags)
									.Include(o => o.opcoes).ThenInclude(oo => oo.Opcao)
									.Include(a => a.AnexoImagemList)
					where p.produtoId == id
					select p).FirstOrDefault();
		}

		public static List<Produto> ObterUltimosProdutos(int limite = 5)
        {
			return (from p in ecommerceContext.Get().ProdutoSet
									.Include(img => img.AnexoImagemList)
									.Include(o => o.opcoes).ThenInclude(oo => oo.Opcao)
					select p).OrderByDescending(p => p.produtoId)
									.Take(limite)
									.ToList();
        }

		// Busca os produtos comprados por diferentes usu�rios
		public static List<Produto> ObterProdutosPopulares(int limite = 5)
        {
			IQueryable<Produto> query = ecommerceContext.Get().ProdutoSet;

			// Realiza os vinculos entre as tabelas necessarias
			query = query.Include(p => p.AnexoImagemList);
			query = query.Include(p => p.opcoes).ThenInclude(p => p.Opcao);

			// Realiza os filtros necess�rios
			query = query.Where(p => (p.StatusAtividade == StatusAtividade.Ativo) &&
										(p.opcoes.Count == 0 || p.opcoes.Any(p => p.Opcao.StatusAtividade == StatusAtividade.Ativo)) &&
										(p.categorias.Any(p => p.Categoria.StatusAtividade == StatusAtividade.Ativo &&
																					p.Categoria.subcategorias.Any(s => s.SubCategoria.StatusAtividade == StatusAtividade.Ativo &&
																													s.SubCategoria.classificacoes.Any(c => c.ClassificacaoItem.StatusAtividade == StatusAtividade.Ativo &&
																																						c.ClassificacaoItem.StatusAtividade == StatusAtividade.Ativo)))));

			return query.Select(p => p)
							.Distinct()
							.ToList();
		}

		// Busca os produtos comprados em maior quantidade
		public static List<Produto> ObterProdutosVendidos(bool detalhado = false)
		{
			IQueryable<Produto> query = ecommerceContext.Get().ProdutoSet;

			// Realiza os vinculos entre as tabelas necessarias
			query = query.Include(p => p.AnexoImagemList);
			query = query.Include(p => p.opcoes).ThenInclude(p => p.Opcao);

			if (detalhado)
				query = query.Include(p => p.pedidos).ThenInclude(p => p.Pedido).ThenInclude(p => p.Usuario);
			else
				query = query.Include(p => p.pedidos);

			// Realiza os filtros necess�rios
			query = query.Where(p => (p.StatusAtividade == StatusAtividade.Ativo) &&
										(p.pedidos.Any(p => p.Pedido.StatusPedido == StatusPedido.Finalizado &&
															(p.Pedido.dataInclusao <= DateTime.Now && p.Pedido.dataInclusao >= DateTime.Now.AddMonths(-1)))) &&
										(p.opcoes.Count == 0 || p.opcoes.Any(p => p.Opcao.StatusAtividade == StatusAtividade.Ativo)) &&
										(p.categorias.Any(p => p.Categoria.StatusAtividade == StatusAtividade.Ativo &&
																					p.Categoria.subcategorias.Any(s => s.SubCategoria.StatusAtividade == StatusAtividade.Ativo &&
																													s.SubCategoria.classificacoes.Any(c => c.ClassificacaoItem.StatusAtividade == StatusAtividade.Ativo &&
																																						c.ClassificacaoItem.StatusAtividade == StatusAtividade.Ativo)))));
			return query.Select(p => p)
						.Distinct()
						.ToList();
		}

		public static IQueryable<Produto> AplicaFiltros(IQueryable<Produto> query, FiltroProduto filtro)
        {
			if (filtro.CategoriasIds.Count > 0)
				query = query.Where(p => p.categorias.Any(p=> filtro.CategoriasIds.Contains(p.Categoria.categoriaId)));
			if (filtro.MarcasIds.Count > 0)
				query = query.Where(p => filtro.MarcasIds.Contains(p.Marca.marcaId));
			if (filtro.Tamanhos.Count > 0)
				query = query.Where(p => p.opcoes.Any(p=> filtro.Tamanhos.Contains(p.tamanho)));
			if (filtro.StatusAtividade.HasValue)
				query = query.Where(p => p.StatusAtividade == filtro.StatusAtividade.Value);
			return query;
        }
		//<#/keep(implements)#>
	}
}