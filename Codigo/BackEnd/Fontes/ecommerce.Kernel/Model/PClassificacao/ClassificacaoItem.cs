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
using ecommerce.Kernel.Model.PEnums;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PClassificacao
{
	[Table("CLASSIFICACAO_ITEM")]
	public class ClassificacaoItem
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_classificacao", TypeName = "INT")] public int classificacaoId { get; set; } 
		[Column("nome", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nome { get; set; } 
		[Column("data_inclusao", TypeName = "DATETIME"),   Required] public DateTime dataInclusao { get; set; } 
		[Column("data_alteracao", TypeName = "DATETIME"),   Required] public DateTime dataAlteracao { get; set; } 
		[Column("STATUSATIVIDADE", TypeName = "INT"), Required] public StatusAtividade StatusAtividade { get; set; }

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public ClassificacaoItem() { }
		//<#keep(constructor)#>
		public ClassificacaoItem(String nome, StatusAtividade StatusAtividade)
		{
			this.dataInclusao = DateTime.Now;
			this.dataAlteracao = DateTime.Now;
			this.atualizarClassificacao(nome, StatusAtividade);

			ecommerceContext.Get().ClassificacaoItemSet.Add(this);
		}
		public ClassificacaoItem(string nome)
		{
			this.nome = nome;

			ecommerceContext.Get().ClassificacaoItemSet.Add(this);
		}
		//<#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().ClassificacaoItemSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static bool Exists(string nome)
		{
			var x = (from c in ecommerceContext.Get().ClassificacaoItemSet
					 where c.nome == nome
					 select c).FirstOrDefault();

			if (x != null)
				return true;

			return false;
		}

		public static ClassificacaoItem obter(string nome)
		{
			return (from c in ecommerceContext.Get().ClassificacaoItemSet
					where c.nome == nome
					select c).FirstOrDefault();
		}

		internal void atualizarClassificacao(String nome, StatusAtividade StatusAtividade)
		{
			this.nome = nome;
			this.StatusAtividade = StatusAtividade;
		}

		//<#/keep(implements)#>
	}
}