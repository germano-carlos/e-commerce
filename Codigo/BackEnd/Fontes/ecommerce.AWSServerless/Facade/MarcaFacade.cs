
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
using ecommerce.Kernel.Model.PMarca;
using ecommerce.Kernel.DTO.PMarca;
//<#/keep(imports)#>

namespace ecommerce.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Marca")]	
	[Produces("application/json")]
	public class MarcaFacade : FacadeBase
	{
		public MarcaFacade() 
		{

		}

		[HttpGet,Route("ObterMaisVendidas")]
		public IActionResult ObterMarcasMaisVendidas()
        {
			try
			{
				Seguranca.ValidaToken(Request.Headers["AuthToken"]);
				//<#keep(SalvarConfiguracoesProduto)#> 
				Object ret = new ecommerce.Kernel.Controllers.MarcaController().ObterMarcasMaisVendidas();
				return Json(ret);
				//<#/keep(SalvarConfiguracoesProduto)#> 
			}
			catch (Exception e)
			{
				return Erro("ecommerce.Marcas.ObterMaisVendidas", e);
			}

		}
		
		
		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
