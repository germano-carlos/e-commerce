//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ecommerce.Kernel;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PTag;
using ecommerce.Kernel.Util;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
	public class TagsController
	{
		public TagsController() 
		{
		}
		
				/* 
		 
		*/ 
		public List<Tags> ListarTags(  String caracteres) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Tags.ListarTags")) 
			{ 
				//<#keep(ListarTags)#> 
				return Tags.ListarTagsPorCaracter(caracteres); ; 
				//<#/keep(ListarTags)#> 
			} 

		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
