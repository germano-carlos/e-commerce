//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;using ecommerce.Kernel.Model.PSubcategoria;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.Model.PClassificacao;

//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PSubcategoria
{
	[Table("SUBCATEGORIA")]
	public class SubCategoria
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_subcategoria", TypeName = "INT")] public int subcategoriaId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nome { get; set; } 
		[Column("data_inclusao", TypeName = "DATETIME"),   Required] public DateTime dataInclusao { get; set; } 
		[Column("data_alteracao", TypeName = "DATETIME"),   Required] public DateTime dataAlteracao { get; set; } 
		[Column("STATUSATIVIDADE", TypeName = "INT"), Required] public StatusAtividade StatusAtividade { get; set; }
		[InverseProperty("SubCategoria")] public virtual List<SubCategoriaClassificacao> classificacoes { get; set; }  // ICollection 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public SubCategoria() { }
		//<#keep(constructor)#>

		public SubCategoria(String nome, StatusAtividade StatusAtividade)
		{
			this.dataInclusao = DateTime.Now;
			this.dataAlteracao = DateTime.Now;
			this.atualizarSubCategoria(nome, StatusAtividade);

			ecommerceContext.Get().SubCategoriaSet.Add(this);
		}
		//<#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().SubCategoriaSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static bool Exists(string nome)
		{
			var x = (from c in ecommerceContext.Get().SubCategoriaSet
					 where c.nome == nome
					 select c).FirstOrDefault();

			if (x != null)
				return true;

			return false;
		}

		internal void atualizarSubCategoria(String nome, StatusAtividade StatusAtividade)
		{
			this.nome = nome;
			this.StatusAtividade = StatusAtividade;
		}

		public static SubCategoria obter(string nome)
		{
			return (from c in ecommerceContext.Get().SubCategoriaSet
					where c.nome == nome
					select c).FirstOrDefault();
		}
		public void VincularClassificacao(ClassificacaoItem classificacao)
		{
			new SubCategoriaClassificacao(this, classificacao);
		}

		//<#/keep(implements)#>
	}
}