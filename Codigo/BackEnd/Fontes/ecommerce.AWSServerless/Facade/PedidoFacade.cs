
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
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Pedido")]	
	[Produces("application/json")]
	public class PedidoFacade : FacadeBase
	{
		public PedidoFacade() 
		{
		}

		/// <summary> 
		/// Método ListarProdutos 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("GetUsuarioPedidos")]
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult GetUsuarioPedidos()
		{
			try
			{
				//<#keep(ListarProdutos)#> 
				string token = Request.Headers["AuthToken"];
				Seguranca.ValidaToken(token);
				UsuarioDTO usuario =  new ecommerce.Kernel.Controllers.AuthController().ObterUsuarioLogado(token);

				Object ret = new ecommerce.Kernel.Controllers.PedidoController().ObterPedidosUsuario(usuario);
				return Json(ret);
				//<#/keep(ListarProdutos)#> 
			}
			catch (Exception e)
			{
				return Erro("ecommerce.PedidoProduto.GetUsuarioPedidos", e);
			}

		}

		[HttpGet, Route("ObterPedidosPorMes")]
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public IActionResult ObterPedidosPorMes()
		{
			try
			{
				//<#keep(ListarProdutos)#> 
				string token = Request.Headers["AuthToken"];
				Seguranca.ValidaToken(token);

				Object ret = new ecommerce.Kernel.Controllers.PedidoController().ObterPedidosPorMes();
				return Json(ret);
				//<#/keep(ListarProdutos)#> 
			}
			catch (Exception e)
			{
				return Erro("ecommerce.PedidoProduto.ObterPedidosPorMes", e);
			}

		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
