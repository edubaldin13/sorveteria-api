using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sorveteria.DTO
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public int QuantidadeBolas { get; set; }
        public int Sabor1Id { get; set; }
        public Sabor Sabor1 { get; set; }
        public int? Sabor2Id { get; set; }
        public Sabor? Sabor2 { get; set; }
        public decimal Valor { get; set; }
        public Boolean Ativo { get; set; }
    }
}
