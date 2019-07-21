using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Cliente : Utilizadores
    {
        public Cliente()
        {
            // criar o objeto 'ListaDeMultas'
            ListaDePedidos = new HashSet<Cliente>();
        }
        //[RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
        //  " separadas por um espaço em branco")]
        [StringLength(50)]
        public string NomeEmpresa { get; set; }

        //[RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,3}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
        //   " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Pais { get; set; }


        //[RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
        //   " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Cidade { get; set; }


        //[RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
        //   " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Rua { get; set; }


        [StringLength(8)]
        public string CodigoPostal { get; set; }

        [StringLength(4)]
        public string NumPorta { get; set; }

        //[RegularExpression("[0-9]{9,9}", ErrorMessage = "Insira um número de 9 dígitos")]
        public string NIF { get; set; }

        //[RegularExpression("[0-9]{14,14}", ErrorMessage = "Insira um número de 14 dígitos. Inclusive o indicativo do seu país")]
        public string Contacto { get; set; }

        //[Required(ErrorMessage = "Adicione um email")]
        public string Email { get; set; }

        public virtual ICollection<Cliente> ListaDePedidos { get; set; }

        // FK para a tabela dos Utilizadores
        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }
    }
}