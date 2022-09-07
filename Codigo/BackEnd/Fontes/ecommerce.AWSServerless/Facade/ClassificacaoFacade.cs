
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
    [Route("api/v1/Classificacao")]	
	[Produces("application/json")]
	public class ClassificacaoFacade : FacadeBase
	{
		public ClassificacaoFacade() 
		{
		}
		
		
		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
