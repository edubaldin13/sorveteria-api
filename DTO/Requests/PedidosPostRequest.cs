namespace Sorveteria.DTO.Requests
{
    public class PedidosPostRequest
    {
        public string NomeCliente { get; set; }
        public int QuantidadeBolas { get; set; }
        public decimal ValorBola { get; set; }
        public int Sabor1Id { get; set; }
        public int? Sabor2Id { get; set; }
        public decimal? Valor { get; set; }
        public Boolean Ativo { get; set; }
    }
}
