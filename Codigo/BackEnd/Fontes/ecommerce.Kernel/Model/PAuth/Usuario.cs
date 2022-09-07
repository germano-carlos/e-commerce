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
using ecommerce.Kernel.DTO.PAuth;
using ecommerce.Kernel.Util;
using System.Net;
using JWT;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.Model.PPedido;
using ecommerce.Kernel.Model.PLogradouro;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Model.PAuth
{
	[Table("USUARIO")]
	public class Usuario
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_usuario", TypeName = "BIGINT")] public long usuarioId { get; set; } 
		[Column("nome_usuario", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String nomeUsuario { get; set; } 
		[Column("data_validade", TypeName = "DATETIME"),   Required] public DateTime dataValidade { get; set; } 
		[Column("senha_usuario", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String senhaUsuario { get; set; } 
		[Column("email", TypeName = "VARCHAR(60)"),   MaxLength(60),   Required] public String email { get; set; } 
		[Column("data_nascimento", TypeName = "VARCHAR(20)"),   MaxLength(20),   Required] public String dataNascimento { get; set; }
		[Column("status_usuario", TypeName = "INT"), Required] public StatusUsuario StatusUsuario { get; set; }
		[Column("TIPOPERMISSAO", TypeName = "INT"), Required] public TipoPermissao TipoPermissao { get; set; }
		[Column("GENERO", TypeName = "INT"), Required] public Genero Genero { get; set; }
		[InverseProperty("Usuario")] public virtual List<Pedido> pedidos { get; set; }  // ICollection 
		[InverseProperty("Usuario")] public virtual List<Logradouro> enderecos { get; set; }  // ICollection 

		//[NotMapped] private ... // exemplo de campo que nao persistido

		public Usuario() { }
		//<#keep(constructor)#>

		public Usuario(UsuarioDTO usuario) 
		{
			if (ObterPorEmail(usuario.email, usuario.TipoPermissao) != null)
				throw new Exception("Usuário já existente em nosso sistema");

			this.nomeUsuario = usuario.nomeUsuario;
			this.dataValidade = DateTime.Now.AddDays(1);
			this.senhaUsuario = Seguranca.Hash(usuario.senhaUsuario);
			this.StatusUsuario = StatusUsuario.Ativo;
			this.TipoPermissao = usuario.TipoPermissao;
			this.email = usuario.email;

			ecommerceContext.Get().UsuarioSet.Add(this);
		}


		//<#/keep(constructor)#>
		internal void delete()
		{
			//<#keep(delete)#>
			ecommerceContext.Get().UsuarioSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static Usuario Obter(long usuarioId)
		{
			return (ecommerceContext.Get().UsuarioSet.Find(usuarioId));
		}


		internal void AtualizarStatus(StatusUsuario status)
        {
			this.StatusUsuario = status;
        }

		internal static List<Usuario> ListarUsuarios()
        {
			return (from u in ecommerceContext.Get().UsuarioSet
					where u.StatusUsuario != StatusUsuario.Inativo
					select u).ToList();
		}

		internal static Usuario Logar(string email, string senha, TipoPermissao TipoPermissao)
        {
			if (String.IsNullOrEmpty(senha))
				throw new Exception("Senha n�o pode ser nula");
			if (String.IsNullOrEmpty(email))
				throw new Exception("Email n�o pode ser nulo");

			email = email.ToLower();
			Usuario u = (from usuario in ecommerceContext.Get().UsuarioSet
							where usuario.email == email && usuario.senhaUsuario == Seguranca.Hash(senha) &&
							usuario.StatusUsuario == StatusUsuario.Ativo &&
							usuario.TipoPermissao == TipoPermissao
							select usuario).FirstOrDefault();
			if (u == null)
				return null;

			u.dataValidade = DateTime.Now.AddMinutes(15);
			return u;
		}
		internal static Usuario ObterPorEmail(string email, TipoPermissao TipoPermissao)
        {
			email = email.ToLower();
			return (from s in ecommerceContext.Get().UsuarioSet
					where s.email == email &&
					s.TipoPermissao == TipoPermissao &&
					s.StatusUsuario == StatusUsuario.Ativo
					select s).FirstOrDefault();
		}
		internal static Usuario EsqueciMinhaSenha(string email, string urlRecuperar, TipoPermissao TipoPermissao)
        {
			Usuario u = ObterPorEmail(email, TipoPermissao);
			if (u == null || u.StatusUsuario != StatusUsuario.Ativo)
				return null;

			string complemento = "";
			if (TipoPermissao == TipoPermissao.Comum)
				complemento = "Usu�rio";
			else
				complemento = "Administrador";

			byte[] bytes = Encoding.UTF8.GetBytes($"Redefini��o de senha - {complemento}");
			var titulo = Encoding.UTF8.GetString(bytes);
			int minutes = 15;

			var provider = new UtcDateTimeProvider().GetNow();
			var exp = provider.AddMinutes(minutes);

			var secondsSinceEpoch = UnixEpoch.GetSecondsSince(exp);

			Util.Mensagem.Email.SendGrid(email,
				titulo,
				$@"Ol�, {u.nomeUsuario}!<br><br>
				Voc� requisitou uma recupera��o de senha.<br><br>

				Clique no link abaixo para alterar sua senha:<br>

				<a href='{urlRecuperar}?email={WebUtility.UrlEncode(email)}&tokenTemp={secondsSinceEpoch}'>{urlRecuperar}</a><br><br>
				
				<p> Voc� ter� {minutes} minuto(s) para realizar a recupera��o da senha </p>

				Caso voc� n�o tenha feito essa solicita��o, ignore esse e-mail!<br><br><br>

				Atenciosamente,<br>",
				"E-Commerce");

			return u;
		}
		public void AlterarSenha(string email, string senha, string senhaAntiga)
        {
			if (!string.IsNullOrWhiteSpace(senha))
			{
				if (String.IsNullOrEmpty(senhaAntiga))
					this.senhaUsuario = Seguranca.Hash(senha);
				else if (Usuario.Logado() == this && this.senhaUsuario == Seguranca.Hash(senhaAntiga))
					this.senhaUsuario = Seguranca.Hash(senha);
				else if (Usuario.Logado() != this)
					throw new Exception("Somente o pr�prio usu�rio pode alterar sua senha");
				else if (this.senhaUsuario != Seguranca.Hash(senhaAntiga))
					throw new Exception("Senha antiga incorreta");
			}
		}
		public static Usuario Logado()
        {
			Usuario u = new Usuario();
			return u;
        }
		//<#/keep(implements)#>
	}
}