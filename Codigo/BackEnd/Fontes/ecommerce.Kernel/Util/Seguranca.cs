using ecommerce.Kernel.Model.PAuth;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ecommerce.Kernel.Util
{
    public class Seguranca
    {
        public static String Hash(string message)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(message)));
        }
        public static String GerarTokenJWT(long id, StatusUsuario status, string email)
        {
            var provider = new UtcDateTimeProvider();
            var now = provider.GetNow();
            var exp = now.AddMinutes(60);

            var secondsSinceEpoch = UnixEpoch.GetSecondsSince(now);
            var secondsSinceExp = UnixEpoch.GetSecondsSince(exp);

            var payload = new Dictionary<string, object>
            {
                { "id", id },
                { "iat", secondsSinceEpoch },
                { "role", status },
                { "email", email },
                { "exp", secondsSinceExp }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, Constantes.JwtSecret);
            return token;
        }
        public static JObject DescriptografarTokenJWT(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var json = JObject.Parse(decoder.Decode(token, Constantes.JwtSecret, verify: true));
                return json;
            }
            catch (TokenExpiredException)
            {
                throw new Exception("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("Token has invalid signature");
            }
        }
        public static void ValidaToken(string token)
        {
            if(token == null)
                throw new Exception("Token Inválido");
            JObject values = DescriptografarTokenJWT(token);
            if (values == null)
                throw new Exception("Token Inválido");
            Object usuario = new ecommerce.Kernel.Controllers.AuthController().ObterUsuarioPorId((long)values["id"]);
            if(usuario == null)
                throw new Exception("Token Inválido");
        }
    }
}
