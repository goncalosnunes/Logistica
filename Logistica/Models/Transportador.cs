using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Transportador : Utilizadores
    {
        // FK para a tabela dos Utilizadores
        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }

        // FK para a tabela dos Transportadores
        [ForeignKey("Transportadora")]
        public int TransportadoresFK { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}