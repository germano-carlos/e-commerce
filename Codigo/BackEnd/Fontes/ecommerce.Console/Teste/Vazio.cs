using Microsoft.Extensions.Configuration;
using ecommerce.Kernel.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using ecommerce.Kernel.Util;

namespace ecommerce.Console.Teste
{
    class Vazio
    {
        public static Random r = new Random();
		public static void Run()
		{
            AdmController admC = new AdmController();

            admC.criarDB();
			admC.Init();
		}
	}
}
