//<#keep(import)#>
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
//<#/keep(import)#>

namespace ecommerce.Kernel.Controllers
{
    public class AdmController
    {
		public void criarDB()
		{
			bool deveApagar = (Constantes.DeleteDB && Constantes.ConnectionString.Contains("Memory"));
				
			using (ecommerceContext c = ecommerceContext.Get("AdmController.criarDB"))
			{
                if (deveApagar)
					c.Database.EnsureDeleted();
				c.Database.EnsureCreated();
			}
		}
		public void Init()
		{
			//<#keep(init)#><#/keep(init)#>
		}
		//<#keep(end)#><#/keep(end)#>
	}
}
