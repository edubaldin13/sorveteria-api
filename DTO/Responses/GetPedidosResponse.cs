namespace Sorveteria.DTO.Responses
{
    public class GetPedidosResponse
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public int QuantidadeBolas { get; set; }
        public string NomeSabor1{ get; set; }
        public string? NomeSabor2 { get; set; }
        public decimal Valor { get; set; }
    }
}
