
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
    [Route("api/v1/Subcategoria")]	
	[Produces("application/json")]
	public class SubcategoriaFacade : FacadeBase
	{
		public SubcategoriaFacade() 
		{
		}
		
		
		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
