using System.Text.Json.Serialization;

namespace PaymentAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumStatusVenda
    {
        PagamentoAprovado,
        EnviadoParaTransportadora,
        Entregue,
        Cancelada
    }
}