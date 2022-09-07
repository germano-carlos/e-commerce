//<#keep(imports)#>
using ecommerce.Kernel.DTO.PLogradouro;
using ecommerce.Kernel.Model;
using ecommerce.Kernel.Model.PLogradouro;
using System.Collections.Generic;
using System.Linq;
//<#/keep(imports)#>

namespace ecommerce.Kernel.Controllers
{
    public class LogradouroController
	{
		public LogradouroController() 
		{
		}
		
				/* 
		 
		*/ 
		public List<Logradouro> ListarLogradourosPorUserId(int userId) 
		{ 
			using (ecommerceContext c = ecommerceContext.Get("Logradouro.ListarLogradourosPorUserId")) 
			{ 
				//<#keep(ListarLogradourosPorUserId)#> 
				return Logradouro.ObterPorUserId(userId);
				//<#/keep(ListarLogradourosPorUserId)#> 
			} 

		} 

		public Logradouro AtualizarLogradouro(LogradouroDTO logradouro)
        {
			using (ecommerceContext c = ecommerceContext.Get("Logradouro.AtualizarLogradouro"))
			{
				//<#keep(AtualizarLogradouroAsync)#> 
				var entity = c.LogradouroSet.SingleOrDefault(l => l.logradouroId.Equals(logradouro.logradouroId));
				entity.rua = logradouro.rua;
				entity.bairro = logradouro.bairro;
				entity.numero = logradouro.numero;
				entity.cep = logradouro.cep;
				entity.cidade = logradouro.cidade;
				entity.estado = logradouro.estado;
				entity.complemento = logradouro.complemento;
				entity.uf = logradouro.uf;
				entity.apelido = logradouro.apelido;

				c.SaveChanges();
				return entity;
				//<#/keep(AtualizarLogradouroAsync)#> 
			}
		}

		
		public Logradouro DeletarLogradouro(int id)
        {
			using (ecommerceContext c = ecommerceContext.Get("Logradouro.DeletarLogradouro"))
            {
				var entity = c.LogradouroSet.SingleOrDefault(l => l.logradouroId.Equals(id));
				c.LogradouroSet.Remove(entity);
				c.SaveChanges();
				return entity;
			}

		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
