namespace Sorveteria.DTO.Responses
{
    public class GetPedidosResponse
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public int QuantidadeBolas { get; set; }
        public Sabor Sabor1 { get; set;}
        public Sabor? Sabor2 { get; set;}
        public decimal Valor { get; set; }
    }
}
