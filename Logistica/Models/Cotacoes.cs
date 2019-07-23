using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica.Models
{
    public class Cotacoes
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Adicione um valor à cotação")]
        public string valorCotacao { get; set; }

        [ForeignKey("Pedidofk")]
        public  Pedidos Pedido { get; set; }
        public  int Pedidofk { get; set; }

        [ForeignKey("Transportadorafk")]
        public virtual Transportadora Transportadora { get; set; }
        public virtual int Transportadorafk { get; set; }

        public bool Aceite { get; set; }
    }
}