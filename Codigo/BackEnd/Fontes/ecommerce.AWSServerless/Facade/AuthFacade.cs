
//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Kernel;
using ecommerce.Kernel.Util;
using ecommerce.Kernel.DTO.PAuth;
using ecommerce.Kernel.Model.PAuth;
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Auth")]	
	[Produces("application/json")]
	public class AuthFacade : FacadeBase
	{
		public AuthFacade() 
		{
		}
		
		/// <summary> 
		/// M�todo AdicionarClientesBlacklist 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("AdicionarClientesBlacklist")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult AdicionarClientesBlacklist(  [FromBody] List<UsuarioDTO> Usuarios) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(AdicionarClientesBlacklist)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().AdicionarClientesBlacklist(  Usuarios); 
				return Json(ret); 
				//<#/keep(AdicionarClientesBlacklist)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.AdicionarClientesBlacklist", e); 
			} 

		} 
		/// <summary> 
		/// M�todo ListarUsuarios 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ListarUsuarios")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ListarUsuarios() 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ListarUsuarios)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().ListarUsuarios(); 
				return Json(ret); 
				//<#/keep(ListarUsuarios)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.ListarUsuarios", e); 
			} 

		} 
		/// <summary> 
		/// M�todo Logar 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("Logar")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult Logar(  [FromForm] string email, [FromForm] string senha, [FromForm] TipoPermissao TipoPermissao) 
		{ 
			try 
			{
				//<#keep(Logar)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().Logar(  email, senha, TipoPermissao); 
				return Json(ret); 
				//<#/keep(Logar)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.Logar", e); 
			} 

		} 
		/// <summary> 
		/// M�todo ObterUsuarioLogado 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ObterUsuarioLogado")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ObterUsuarioLogado() 
		{ 
			try 
			{
				//<#keep(ObterUsuarioLogado)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().ObterUsuarioLogado(Request.Headers["TokenAuth"]); 
				return Json(ret); 
				//<#/keep(ObterUsuarioLogado)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.ObterUsuarioLogado", e); 
			} 

		} 
		/// <summary> 
		/// M�todo EsqueciMinhaSenha 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("EsqueciMinhaSenha")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult EsqueciMinhaSenha(  [FromForm] String email, [FromForm] String urlRecuperar, [FromForm] TipoPermissao TipoPermissao) 
		{ 
			try 
			{
				//<#keep(EsqueciMinhaSenha)#>
				Object ret = new ecommerce.Kernel.Controllers.AuthController().EsqueciMinhaSenha(  email, urlRecuperar, TipoPermissao); 
				return Json(ret); 
				//<#/keep(EsqueciMinhaSenha)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.EsqueciMinhaSenha", e); 
			} 

		} 
		/// <summary> 
		/// M�todo AlterarSenha 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("AlterarSenha")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult AlterarSenha(  [FromForm] String email, [FromForm] String senha, [FromForm] String senhaAntiga, [FromForm] TipoPermissao TipoPermissao) 
		{ 
			try 
			{
				//<#keep(AlterarSenha)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().AlterarSenha(  email, senha, senhaAntiga, TipoPermissao); 
				return Json(ret); 
				//<#/keep(AlterarSenha)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.AlterarSenha", e); 
			} 

		} 
		/// <summary> 
		/// M�todo ObterUsuarioPorId 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ObterUsuarioPorId")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ObterUsuarioPorId(  [FromForm] long id) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ObterUsuarioPorId)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().ObterUsuarioPorId(  id); 
				return Json(ret); 
				//<#/keep(ObterUsuarioPorId)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.ObterUsuarioPorId", e); 
			} 

		} 
		/// <summary> 
		/// M�todo CriarUsuario 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("CriarUsuario")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult CriarUsuario(  [FromBody] UsuarioDTO usuario) 
		{ 
			try 
			{
				//<#keep(CriarUsuario)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().CriarUsuario(  usuario); 
				return Json(ret); 
				//<#/keep(CriarUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Auth.CriarUsuario", e); 
			} 

		}

		/// <summary> 
		/// M�todo CriarUsuario 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("AtualizarUsuario")]
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult AtualizarUsuario([FromBody] UsuarioDTO usuario)
		{
			try
			{
				//<#keep(CriarUsuario)#> 
				Object ret = new ecommerce.Kernel.Controllers.AuthController().AtualizarUsuario(usuario);
				return Json(ret);
				//<#/keep(CriarUsuario)#> 
			}
			catch (Exception e)
			{
				return Erro("ecommerce.Auth.CriarUsuario", e);
			}

		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
