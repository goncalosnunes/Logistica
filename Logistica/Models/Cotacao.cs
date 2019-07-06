using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Cotacao
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Adicione um valor à cotação")]
        public decimal valorCotacao { get; set; }

        [ForeignKey("Pedidofk")]
        public Pedido Pedido { get; set; }
        public int Pedidofk { get; set; }

        [ForeignKey("Transportadorafk")]
        public Transportadora Transportadora { get; set; }
        public int Transportadorafk { get; set; }
    }
}