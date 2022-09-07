//<#keep(imports)#>
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Microsoft.Extensions.Logging;
using ecommerce.Kernel.Util;
using System.Diagnostics;
using ecommerce.Kernel.Model.PAuth;
using ecommerce.Kernel.Model.PCategoria;
using ecommerce.Kernel.Model.PClassificacao;
using ecommerce.Kernel.Model.PProduto;
using ecommerce.Kernel.Model.PPedido;
using ecommerce.Kernel.Model.PLogradouro;
using ecommerce.Kernel.Model.PMarca;
using ecommerce.Kernel.Model.PSubcategoria;
using ecommerce.Kernel.Model.PTag;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Model
{
    public class ecommerceContext : DbContext
	{
		private static ThreadLocal<ecommerceContext> instance = new ThreadLocal<ecommerceContext>();
		internal static ecommerceContext Get()
		{
			if (!instance.IsValueCreated || instance.Value == null)
				throw new Exception("Uma transação não pode ser iniciada sem título.");
			return instance.Value;
		}
		internal static ecommerceContext Get(string titulo)
		{
			if (instance.IsValueCreated && instance.Value != null)
				throw new Exception($"Uma transação só pode ter um título {titulo}.");
			return instance.Value = new ecommerceContext(titulo);
		}
		internal static ecommerceContext Get(string titulo, string detalhes)
		{
			if (instance.IsValueCreated && instance.Value != null)
				throw new Exception($"Uma transação só pode ter um título {titulo}.");
			return instance.Value = new ecommerceContext(titulo, detalhes);
		}
		
		public DbSet<Usuario> UsuarioSet { get; set; }
		public DbSet<Categoria> CategoriaSet { get; set; }
		public DbSet<ClassificacaoItem> ClassificacaoItemSet { get; set; }
		public DbSet<Produto> ProdutoSet { get; set; }
		public DbSet<Pedido> PedidoSet { get; set; }
		public DbSet<AnexoImagem> AnexoImagemSet { get; set; }
		public DbSet<Marca> MarcaSet { get; set; }
		public DbSet<ProdutoOpcao> ProdutoOpcaoSet { get; set; }
		public DbSet<Opcao> OpcaoSet { get; set; }
		public DbSet<Logradouro> LogradouroSet { get; set; }
		public DbSet<ProdutoCategoria> ProdutoCategoriaSet { get; set; }
		public DbSet<SubCategoria> SubCategoriaSet { get; set; }
		public DbSet<CategoriaSubCategoria> CategoriaSubCategoriaSet { get; set; }
		public DbSet<SubCategoriaClassificacao> SubCategoriaClassificacaoSet { get; set; }
		public DbSet<PedidoProduto> PedidoProdutoSet { get; set; }
		public DbSet<Tags> TagsSet { get; set; }
		public DbSet<TagsProduto> TagsProdutoSet { get; set; }
		
		private ecommerceContext(string titulo) 
		{ 
			//<#keep(criacao)#><#/keep(criacao)#>
		}
		private ecommerceContext(string titulo, string detalhes)
		{
			//<#keep(criacao2)#><#/keep(criacao2)#>
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				if (Constantes.DBMS == "MySQL")
					optionsBuilder.UseMySql(Constantes.ConnectionString);
				else if (Constantes.DBMS == "MSSQL")
					optionsBuilder.UseSqlServer(Constantes.ConnectionString);
				else if (Constantes.DBMS == "InMemory")
					optionsBuilder.UseInMemoryDatabase(Constantes.ConnectionString);
				else
					try
					{
						optionsBuilder.UseInMemoryDatabase(Constantes.ConnectionString);
					}
					catch (Exception e)
					{
						optionsBuilder.UseInMemoryDatabase(databaseName: "ecommerce");
					}				
				//optionsBuilder.UseLazyLoadingProxies();
			}
		}
		//<#keep(generico)#><#/keep(generico)#>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// para fazer uma propriedade transiente
			// modelBuilder.Entity<Usuario>().Ignore(b => b.nome);
			// ou colocar [NotMapped] na propriedade

			//<#keep(index)#>
			
			// para chave composta
			//modelBuilder.Entity<Order>().HasKey(o => new { o.CustomerAbbreviation, o.OrderNumber });
			
			//modelBuilder.Entity<Solicitacao>()
			//	.HasOne(c => c.IFDestino)
			//	.WithOne

			/*
			modelBuilder.Entity<Solicitacao>().HasIndex(s => new {
				s.CPFCliente,
				s.CNPJEmpregador,
				s.IdIFFolha
			});
			modelBuilder.Entity<InstituicaoFinanceira>().HasIndex(s => s.CNPJ).IsUnique();
			*/
			
			//<#/keep(index)#>
		}
		public override int SaveChanges()
		{
			int ret = base.SaveChanges();
			return ret;
		}
		public override void Dispose()
		{
			base.Dispose();
			instance.Value = null;
			//<#keep(dispose)#><#/keep(dispose)#>
		}
		//<#keep(end)#><#/keep(end)#>
	}
}
