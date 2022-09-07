
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
using ecommerce.Kernel.Util.Paginação;
using ecommerce.Kernel.DTO.PProduto;
using ecommerce.Kernel.Model.PProduto;
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Produto")]	
	[Produces("application/json")]
	public class ProdutoFacade : FacadeBase
	{
		public ProdutoFacade() 
		{
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
		public ActionResult ListarProdutos([FromQuery] PaginacaoParametros queryParams, [FromBody] FiltroProduto filtros) 
		{ 
			try 
			{
				//Seguranca.ValidaToken(Request.Headers["AuthToken"]);
				//<#keep(ListarProdutos)#> 
				ListaPaginada<ProdutoDTO> ret = new ecommerce.Kernel.Controllers.ProdutoController().ListarProdutos(queryParams, filtros);

				if (queryParams.metadata)
					return Json(ListaPaginada<ProdutoDTO>.ListaPaginadaComMetaData(ret));
				return Json(ret);
				//<#/keep(ListarProdutos)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Produto.ListarProdutos", e); 
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
		public ActionResult ObterProdutoPorId(  [FromForm] long id) 
		{ 
			try 
			{
				//Seguranca.ValidaToken(Request.Headers["AuthToken"]); 
				//<#keep(ObterProdutoPorId)#> 
				Object ret = new ecommerce.Kernel.Controllers.ProdutoController().ObterProdutoPorId(  id); 
				return Json(ret); 
				//<#/keep(ObterProdutoPorId)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Produto.ObterProdutoPorId", e); 
			} 

		} 
		/// <summary> 
		/// Método ObterUltimosProdutos 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ObterUltimosProdutos")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ObterUltimosProdutos() 
		{ 
			try 
			{
				//<#keep(ObterUltimosProdutos)#> 
				Object ret = new ecommerce.Kernel.Controllers.ProdutoController().ObterUltimosProdutos(); 
				return Json(ret); 
				//<#/keep(ObterUltimosProdutos)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Produto.ObterUltimosProdutos", e); 
			} 

		} 
		/// <summary> 
		/// Método ObterProdutosPopulares 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ObterProdutosPopulares")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ObterProdutosPopulares() 
		{ 
			try 
			{
				//<#keep(ObterProdutosPopulares)#> 
				Object ret = new ecommerce.Kernel.Controllers.ProdutoController().ObterProdutosPopulares(); 
				return Json(ret); 
				//<#/keep(ObterProdutosPopulares)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Produto.ObterProdutosPopulares", e); 
			} 

		} 
		/// <summary> 
		/// Método ObterProdutosMaisVendidos 
		/// </summary> 
		/// <returns> 
		///  
		/// </returns> 
		[HttpPost, Route("ObterProdutosMaisVendidos")] 
		//[SwaggerResponse(HttpStatusCode.OK, Type = typeof(DeliveryOptionsModel), Description = "")] 
		//[SwaggerResponseExample(tHttpStatusCode.OK, typeof(DeliveryOptionsModelExample))] 
		public ActionResult ObterProdutosMaisVendidos() 
		{ 
			try 
			{
				//<#keep(ObterProdutosMaisVendidos)#> 
				Object ret = new ecommerce.Kernel.Controllers.ProdutoController().ObterProdutosMaisVendidos(); 
				return Json(ret); 
				//<#/keep(ObterProdutosMaisVendidos)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("ecommerce.Produto.ObterProdutosMaisVendidos", e); 
			} 

		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
