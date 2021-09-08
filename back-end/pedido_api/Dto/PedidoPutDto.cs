using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace pedido_api.Dto
{
    public class PedidoPutDto
    {
        [Required]
        public string NomeProduto { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }
    }
}
