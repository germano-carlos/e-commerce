
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
using ecommerce.Kernel.Model.PLogradouro;
using ecommerce.Kernel.DTO.PLogradouro;
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Logradouro")]	
	[Produces("application/json")]
	public class LogradouroFacade : FacadeBase
	{
		public LogradouroFacade() 
		{
		}
		
				/// <summary> 
		/// M�todo ListarLogradourosPorUserId 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ListarLogradourosPorUserId")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ListarLogradourosPorUserId(  [FromForm] int userId) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ListarLogradourosPorUserId)#> 
				Object ret = new ecommerce.Kernel.Controllers.LogradouroController().ListarLogradourosPorUserId(  userId); 
				return Json(ret); 
				//<#/keep(ListarLogradourosPorUserId)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Logradouro.ListarLogradourosPorUserId", e); 
			} 

		} 
		/// <summary> 
		/// M�todo AtualizarLogradouro 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("AtualizarLogradouro")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult AtualizarLogradouro(  [FromBody] LogradouroDTO logradouro) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(AtualizarLogradouro)#> 
				Object ret = new ecommerce.Kernel.Controllers.LogradouroController().AtualizarLogradouro(  logradouro); 
				return Json(ret); 
				//<#/keep(AtualizarLogradouro)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Logradouro.AtualizarLogradouro", e); 
			} 

		}

		[HttpPost, Route("DeletarLogradouro")]
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult DeletarLogradouro([FromQuery] int id)
		{
			try
			{
				//Seguranca.ValidaToken(Request.Headers["AuthToken"]);
				//<#keep(DeletarLogradouro)#> 
				Object ret = new ecommerce.Kernel.Controllers.LogradouroController().DeletarLogradouro(id);
				return Json(ret);
				//<#/keep(DeletarLogradouro)#> 
			}
			catch (Exception e)
			{
				return Erro("ecommerce.Logradouro.DeletarLogradouro", e);
			}

		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
