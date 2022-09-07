using Newtonsoft.Json;

namespace ecommerce.Kernel.DTO.PMarca
{
    public class MarcaQuantidade
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }
    }
}
