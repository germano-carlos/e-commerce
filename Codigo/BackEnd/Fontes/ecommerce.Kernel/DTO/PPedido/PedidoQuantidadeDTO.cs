using Newtonsoft.Json;

namespace ecommerce.Kernel.DTO.PPedido
{
    public class PedidoQuantidadeDTO
    {
        [JsonProperty("mes")]
        public int Mes { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }
    }
}
