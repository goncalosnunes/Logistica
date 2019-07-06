using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Utilizadores
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        [StringLength(30)]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
            " separadas por um espaço em branco")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O apelido é de preenchimento obrigatório")]
        [StringLength(30)]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
            " separadas por um espaço em branco")]
        public string Apelido { get; set; }

        public string Fotografia { get; set; }

        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Adicione um país")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Pais { get; set; }

        
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Cidade { get; set; }


        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Rua { get; set; }

 
        [StringLength(8)]
        public string CodigoPostal { get; set; }

        [StringLength(4)]
        public string NumPorta { get; set; }

        [RegularExpression("[0-9]{9,9}", ErrorMessage = "Insira um número de 9 dígitos")]
        public string NIF { get; set; }

        [RegularExpression("[0-9]{9,9}", ErrorMessage = "Insira um número de 9 dígitos")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Adicione um email")]
        public string Email { get; set; }

    }
}