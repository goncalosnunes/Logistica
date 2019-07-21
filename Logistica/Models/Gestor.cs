using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Gestor : Utilizadores
    {
        // FK para a tabela dos Utilizadores
        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }
    }
}