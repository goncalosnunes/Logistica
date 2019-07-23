using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logistica.Models
{
    public class Transportadora
    {
        public Transportadora()
        {
            // criar o objeto 'ListaDeMultas'
            ListaDeCotacoes = new HashSet<Cotacoes>();
        }

        public int ID { get; set; }

        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
            " separadas por um espaço em branco")]
        [StringLength(50)]
        public string NomeTransportadora { get; set; }

        [Required(ErrorMessage = "Adicione um país")]
        [RegularExpression("([A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,2}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Adicione uma cidade")]
        [RegularExpression("([A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,2}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Adicione uma rua")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Adicione um código postal")]
        [StringLength(8)]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Adicione um número de porta")]
        [StringLength(4)]
        public string NumPorta { get; set; }

        [RegularExpression("[0-9]{9,9}", ErrorMessage = "Insira um número de 9 dígitos")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Adicione um contacto")]
        [RegularExpression("[0-9]{9,9}", ErrorMessage = "Insira um número de 9 dígitos")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Adicione um email")]
        public string Email { get; set; }


        public virtual ICollection<Cotacoes> ListaDeCotacoes { get; set; }
    }
}