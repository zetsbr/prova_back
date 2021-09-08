using System;
namespace pedido_api.Entities
{
    public class PedidoGetDto
    {
        public PedidoGetDto(int id, string nomeProduto, decimal valor, DateTime dataVencimento, string condicao)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Valor = valor;
            DataVencimento = dataVencimento;
            Condicao = condicao;
        }

        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Condicao { get; set; }
    }
}
