//<#keep(imports)#>
using ecommerce.Kernel.DTO.PLogradouro;
using ecommerce.Kernel.DTO.POperacao;
using ecommerce.Kernel.DTO.PPedido;
using ecommerce.Kernel.Model.PAuth;
using ecommerce.Kernel.Model.PEnums;
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace ecommerce.Kernel.DTO.PAuth
{
	public class UsuarioDTO
	{
		public long usuarioId;
		public String nomeUsuario;
		public DateTime dataValidade;
		public String senhaUsuario;
		public String email;
		public String dataNascimento;
		public StatusUsuario StatusUsuario;
		public TipoPermissao TipoPermissao;
		public Genero Genero;
		public List<PedidoDTO> pedidos = new List<PedidoDTO>();
		public List<LogradouroDTO> enderecos = new List<LogradouroDTO>();

		//<#keep(implements)#>
		public String token;
		//<#/keep(implements)#>
	}
}