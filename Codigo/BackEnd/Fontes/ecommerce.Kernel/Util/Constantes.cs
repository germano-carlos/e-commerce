//<#keep(import)#>
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
//<#/keep(import)#>

namespace ecommerce.Kernel.Util
{
	public class Constantes
	{
		//<#keep(conteudo)#>
        public static bool DebugSQL = true;
        public static string ConnectionString = "server=ecommerce.cdejcqhtgi0q.us-east-2.rds.amazonaws.com;port=3306;database=ecommerce;uid=app_ecommerce;password=app_ecommerce123;";
        public static string DBMS = "MySQL";
        public static bool DeleteDB = false;
        public const string JwtSecret = "19a1b1a4641fea6ceafb6e51ffd1d3a2f3927a2e22d6d9e1c7f8003377a860a3";
        public const string SendGridSecret = "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";
        //<#/keep(conteudo)#>
	}
}
