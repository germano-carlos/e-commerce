//<#keep(import)#>
using ecommerce.Console.Teste;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
//<#/keep(import)#>


namespace ecommerce.Console
{
    class Program
    {
        static void Main(string[] args)
        {
			Environment.SetEnvironmentVariable("AspNetEnvironment", "Development");
			//Config.Registry(new AppConfig());
			
			//<#keep(main)#>
			
			Run(Vazio.Run, "CaminhoFeliz");

			//<#/keep(main)#>

			System.Console.Read();
        }
		public delegate void F();
		public static void Run(F f, string mensagem)
		{
			try
			{
				f();
				System.Console.WriteLine("FIM: " + mensagem);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.ToString());
			}
		}
		//<#keep(end)#><#/keep(end)#>
    }
}
