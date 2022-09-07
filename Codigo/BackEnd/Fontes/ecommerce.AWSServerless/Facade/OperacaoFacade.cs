
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
using ecommerce.Kernel.DTO.PCategoria;
using ecommerce.Kernel.Model.PEnums;
using ecommerce.Kernel.DTO.POperacao;
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Operacao")]	
	[Produces("application/json")]
	public class OperacaoFacade : FacadeBase
	{
		public OperacaoFacade() 
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
				Object ret = new ecommerce.Kernel.Controllers.OperacaoController().SalvarConfiguracoesProduto(  parametros); 
				return Json(ret); 
				//<#/keep(SalvarConfiguracoesProduto)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Operacao.SalvarConfiguracoesProduto", e); 
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
				Object ret = new ecommerce.Kernel.Controllers.OperacaoController().ListarConfiguracoesProduto();
				return Json(ret);
				//<#/keep(ListarConfiguracoesProduto)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Operacao.ListarConfiguracoesProduto", e); 
			} 

		} 
		/// <summary> 
		/// Método ListarLogradourosPorUserId 
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
				Object ret = new ecommerce.Kernel.Controllers.OperacaoController().ListarLogradourosPorUserId(  userId); 
				return Json(ret); 
				//<#/keep(ListarLogradourosPorUserId)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Operacao.ListarLogradourosPorUserId", e); 
			} 

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
				Object ret = new ecommerce.Kernel.Controllers.OperacaoController().ListarTags(caracteres);
				return Json(ret);
				//<#/keep(ListarTags)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Operacao.ListarTags", e); 
			} 

		} 
		/// <summary> 
		/// Método ListarProdutos 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ListarProdutos")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ListarProdutos() 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ListarProdutos)#> 
				Object ret = new ecommerce.Kernel.Controllers.OperacaoController().ListarProdutos();
				return Json(ret);
				//<#/keep(ListarProdutos)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Operacao.ListarProdutos", e); 
			} 

		} 
		/// <summary> 
		/// Método ObterProdutoPorId 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ObterProdutoPorId")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ObterProdutoPorId(  [FromForm] int id) 
		{ 
			try 
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ObterProdutoPorId)#> 
				Object ret = new ecommerce.Kernel.Controllers.OperacaoController().ObterProdutoPorId(id);
				return Json(ret);
				//<#/keep(ObterProdutoPorId)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Operacao.ObterProdutoPorId", e); 
			} 

		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
