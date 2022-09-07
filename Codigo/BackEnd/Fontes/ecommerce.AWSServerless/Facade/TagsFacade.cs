
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
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Tags")]	
	[Produces("application/json")]
	public class TagsFacade : FacadeBase
	{
		public TagsFacade() 
		{
		}
		
				/// <summary> 
		/// Método ListarTags 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ListarTags")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ListarTags(  [FromForm] String caracteres) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ListarTags)#> 
				Object ret = new ecommerce.Kernel.Controllers.TagsController().ListarTags(  caracteres); 
				return Json(ret); 
				//<#/keep(ListarTags)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Tags.ListarTags", e); 
			} 

		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
