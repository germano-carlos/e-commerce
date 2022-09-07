//<#keep(imports)#>
using ecommerce.Kernel.DTO.PAuth;
using Newtonsoft.Json;
using System;

//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PLogradouro
{
	public class LogradouroDTO
	{
		public int logradouroId;
		public String rua;
		public String bairro;
		public String numero;
		public String cep;
		public String cidade;
		public String estado;
		public String complemento;
		public String uf;
		public String apelido;
		public UsuarioDTO Usuario;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}