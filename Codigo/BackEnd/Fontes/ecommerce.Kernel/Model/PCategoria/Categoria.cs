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
using ecommerce.Kernel.Model.PCategoria;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.Model.PSubcategoria;
using ecommerce.Kernel.DTO.PCategoria;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PCategoria
{
	[Table("CATEGORIA")]
	public class Categoria
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_categoria", TypeName = "INT")] public int categoriaId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nome { get; set; } 
		[Column("data_inclusao", TypeName = "DATETIME"),   Required] public DateTime dataInclusao { get; set; } 
		[Column("data_alteracao", TypeName = "DATETIME"),   Required] public DateTime dataAlteracao { get; set; } 
		[Column("STATUSATIVIDADE", TypeName = "INT"), Required] public StatusAtividade StatusAtividade { get; set; }
		[InverseProperty("Categoria")] public virtual List<CategoriaSubCategoria> subcategorias { get; set; }  // ICollection 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Categoria() { }
		//<#keep(constructor)#>
		public Categoria(String nome, StatusAtividade StatusAtividade)
		{
			this.dataAlteracao = DateTime.Now;
			this.dataInclusao = DateTime.Now;
			this.atualizarCategoria(nome, StatusAtividade);

			ecommerceContext.Get().CategoriaSet.Add(this);
		}
		public Categoria(CategoriaDTO categoria)
		{
			this.atualizarCategoria(categoria.nome, categoria.StatusAtividade);
			this.dataInclusao = DateTime.Now;
			this.dataAlteracao = DateTime.Now;

			ecommerceContext.Get().CategoriaSet.Add(this);
		}

		//<#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().CategoriaSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>

		internal static Categoria obter(CategoriaDTO categoria)
		{
			return (from c in ecommerceContext.Get().CategoriaSet
					where c.categoriaId == categoria.categoriaId
					select c).FirstOrDefault();
		}

		internal void cancel()
		{
			if (this.StatusAtividade == StatusAtividade.Inativo)
				throw new Exception("Categoria já Inativa");

			this.StatusAtividade = StatusAtividade.Inativo;
		}

		internal Categoria atualizarCategoria(String nome, StatusAtividade StatusAtividade)
		{
			this.nome = nome;
			this.StatusAtividade = StatusAtividade;

			return this;
		}

		public static bool Exists(string nome)
		{
			var x = (from c in ecommerceContext.Get().CategoriaSet
					 where c.nome.Trim().ToUpper() == nome.Trim().ToUpper()
					 select c).FirstOrDefault();

			if (x != null)
				return true;

			return false;
		}
		public void VincularSCategoria(SubCategoria subcategoria)
		{
			new CategoriaSubCategoria(this, subcategoria);
		}

		internal static List<Categoria> ObterTodas()
		{
			return (from cat in ecommerceContext.Get()
					.CategoriaSet
					.Include(s => s.subcategorias)
					.ThenInclude(sc => sc.SubCategoria)
					.ThenInclude(c => c.classificacoes)
					.ThenInclude(cl => cl.ClassificacaoItem)
					select cat).ToList();
		}

		//<#/keep(implements)#>
	}
}