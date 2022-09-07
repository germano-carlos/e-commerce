using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ecommerce.Kernel.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ecommerce.AWSServerless.Facade
{
	public class FacadeBase : Controller
	{
		[HttpGet]
		public ObjectResult Erro(string mensagem, Exception e, HttpStatusCode StatusCode = HttpStatusCode.InternalServerError)
		{
			return base.StatusCode((int)StatusCode, e.Message);
		}		
		public override JsonResult Json(object data)
		{
			return base.Json(data, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
		}
	}
}
