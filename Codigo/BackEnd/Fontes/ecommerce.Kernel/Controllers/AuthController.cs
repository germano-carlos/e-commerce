//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ecommerce.Kernel;
using ecommerce.Kernel.DTO.PAuth;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PAuth;
using ecommerce.Kernel.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
	public class AuthController
	{
		public AuthController() 
		{
		}

		public BlacklistResponse AdicionarClientesBlacklist(  List<UsuarioDTO> Usuarios) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.AdicionarClientesBlacklist")) 
			{ 
				//<#keep(AdicionarClientesBlacklist)#> 
				foreach (var usuario in Usuarios)
					Usuario.Obter(usuario.usuarioId).AtualizarStatus(StatusUsuario.Blacklist);

				c.SaveChanges();
				return null;
				//<#/keep(AdicionarClientesBlacklist)#> 
			} 
		} 
		/* 
		 
		*/ 
		public object [] ListarUsuarios() 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.ListarUsuarios")) 
			{ 
				//<#keep(ListarUsuarios)#> 
				return Limpar(Usuario.ListarUsuarios().ToArray());
				//<#/keep(ListarUsuarios)#> 
			} 
		} 
		/* 
		 
		*/ 
		public UsuarioDTO Logar(  string email, string senha, TipoPermissao TipoPermissao) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.Logar")) 
			{ 
				//<#keep(Logar)#> 
				Usuario usuario = Usuario.Logar(email, senha, TipoPermissao);
				c.SaveChanges();
				return Limpar(usuario);
				//<#/keep(Logar)#> 
			} 
		} 
		/* 
		 
		*/ 
		public UsuarioDTO ObterUsuarioLogado(string token) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.ObterUsuarioLogado")) 
			{ 
				//<#keep(ObterUsuarioLogado)#> 
				JObject informacoes = Seguranca.DescriptografarTokenJWT(token);
				if (informacoes == null)
					return null;

				Usuario usuario = Usuario.Obter((long)informacoes["id"]);
				c.SaveChanges();
				return Limpar(usuario);
				//<#/keep(ObterUsuarioLogado)#> 
			} 

		} 
		/* 
		 
		*/ 
		public UsuarioDTO EsqueciMinhaSenha(  String email, String urlRecuperar, TipoPermissao TipoPermissao) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.EsqueciMinhaSenha")) 
			{ 
				//<#keep(EsqueciMinhaSenha)#> 
				Usuario usuario = Usuario.EsqueciMinhaSenha(email, urlRecuperar, TipoPermissao);
				c.SaveChanges();
				return Limpar(usuario);
				//<#/keep(EsqueciMinhaSenha)#> 
			} 

		} 
		/* 
		 
		*/ 
		public UsuarioDTO AlterarSenha(  String email, String senha, String senhaAntiga, TipoPermissao TipoPermissao) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.AlterarSenha")) 
			{ 
				//<#keep(AlterarSenha)#> 
				Usuario usuario = Usuario.ObterPorEmail(email, TipoPermissao);
				if (usuario == null)
					throw new Exception("Usu�rio n�o encontrado");

				usuario.AlterarSenha(email, senha, senhaAntiga);
				c.SaveChanges();
				return Limpar(usuario);
				//<#/keep(AlterarSenha)#> 
			} 

		} 
		/* 
		 
		*/ 
		public UsuarioDTO ObterUsuarioPorId(  long id) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.ObterUsuarioPorId")) 
			{ 
				//<#keep(ObterUsuarioPorId)#> 
				Usuario usuario = Usuario.Obter(id);
				c.SaveChanges();
				return Limpar(usuario);
				//<#/keep(ObterUsuarioPorId)#> 
			} 
		} 
		/* 
		 
		*/ 
		public UsuarioDTO CriarUsuario(  UsuarioDTO usuario) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Auth.CriarUsuario")) 
			{ 
				//<#keep(CriarUsuario)#> 
				Usuario u = new Usuario(usuario);
				c.SaveChanges(); 
				return Limpar(u); 
				//<#/keep(CriarUsuario)#> 
			} 

		} 

		//<#keep(implementation)#>
		private UsuarioDTO Limpar(Usuario usuario)
		{
			if (usuario != null)
			{
				return new UsuarioDTO
				{
					usuarioId = usuario.usuarioId,
					nomeUsuario = usuario.nomeUsuario,
					senhaUsuario = null,
					token = Seguranca.GerarTokenJWT(usuario.usuarioId, usuario.StatusUsuario, usuario.email),
					dataValidade = usuario.dataValidade,
					email = usuario.email,
					StatusUsuario = usuario.StatusUsuario,
					TipoPermissao = usuario.TipoPermissao
				};
			}

			return null;
		}
		private UsuarioDTO[] Limpar(Usuario[] usuarios)
		{
			List<UsuarioDTO> retorno = new List<UsuarioDTO>();
			foreach (Usuario u in usuarios)
				retorno.Add(Limpar(u));
			return retorno.ToArray();
		}

		public bool AtualizarUsuario(UsuarioDTO usuario)
		{
			using (ecommerceContext c = ecommerceContext.Get("Auth.AtualizarUsuario"))
			{
				var entity = c.UsuarioSet.FirstOrDefault(u => u.usuarioId.Equals(usuario.usuarioId));
				entity.nomeUsuario = isNull(usuario.nomeUsuario, entity.nomeUsuario).ToString();
				entity.email = isNull(usuario.email, entity.email).ToString();
				entity.dataNascimento = isNull(usuario.dataNascimento, entity.dataNascimento).ToString();
				entity.Genero = (Genero) isNull(usuario.Genero, entity.Genero);
				var state = c.Entry(entity).State;
				c.SaveChanges();

				return state.Equals(EntityState.Modified);
			}
		}

		private object isNull(object a, object b)
        {
			return a is null ? b : a;
        }
		//<#/keep(implementation)#>
	}
}
