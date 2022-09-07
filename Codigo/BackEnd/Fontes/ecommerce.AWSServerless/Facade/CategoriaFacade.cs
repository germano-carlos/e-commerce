
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
using ecommerce.Kernel.DTO.POperacao;
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Categoria")]	
	[Produces("application/json")]
	public class CategoriaFacade : FacadeBase
	{
		public CategoriaFacade() 
		{
		}
		
				/// <summary> 
		/// Método SalvarConfiguracoesProduto 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("SalvarConfiguracoesProduto")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult SalvarConfiguracoesProduto(   ConfiguracoesDTO parametros) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(SalvarConfiguracoesProduto)#> 
				Object ret = new ecommerce.Kernel.Controllers.CategoriaController().SalvarConfiguracoesProduto(  parametros); 
				return Json(ret); 
				//<#/keep(SalvarConfiguracoesProduto)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Categoria.SalvarConfiguracoesProduto", e); 
			} 

		} 
		/// <summary> 
		/// Método ListarConfiguracoesProduto 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ListarConfiguracoesProduto")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ListarConfiguracoesProduto() 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ListarConfiguracoesProduto)#> 
				Object ret = new ecommerce.Kernel.Controllers.CategoriaController().ListarConfiguracoesProduto(); 
				return Json(ret); 
				//<#/keep(ListarConfiguracoesProduto)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Categoria.ListarConfiguracoesProduto", e); 
			} 

		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
