using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ecommerce.Kernel.Util.Mensagem
{
    public class Email
    {
		public static Retorno SendGrid(string endereco, string titulo, string conteudo, string nomeFrom)
		{
			try
			{
				SendGridClient client = new SendGridClient(Constantes.SendGridSecret);
				EmailAddress from = new EmailAddress("germano.carlos2712@gmail.com", nomeFrom);
				var to = new EmailAddress(endereco);
				SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, titulo, conteudo, conteudo);
				Task<Response> retTask = client.SendEmailAsync(msg);
				retTask.Wait();
				SendGrid.Response o = retTask.Result;
				if (o.StatusCode != HttpStatusCode.Accepted)
					return new Retorno { erro = true, erroPlataforma = true };

				return new Retorno();
			}
			catch (Exception e)
			{
				return new Retorno
				{
					erro = true,
					erroPlataforma = false,
					e = e,
					mensagem = $"Erro no envio do email SendGrid para endereco = {endereco}"
				};
			}
		}
	}
}
