using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Pedido
    {
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

        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
            " separadas por um espaço em branco")]
        [StringLength(50)]
        public string NomeEmpresaDestinataria { get; set; }

        [Required(ErrorMessage = "Adicione um país")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string PaisDestino { get; set; }

        [Required(ErrorMessage = "Adicione uma cidade")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string CidadeDestino { get; set; }

        [Required(ErrorMessage = "Adicione uma rua")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string RuaDestino { get; set; }

        [Required(ErrorMessage = "Adicione um código postal")]
        [StringLength(8)]
        public string CodigoPostalDestino { get; set; }

        [Required(ErrorMessage = "Adicione um número de porta")]
        [StringLength(4)]
        public string NumPortaDestino { get; set; }

        [Required(ErrorMessage = "Adicione um contacto")]
        [RegularExpression("[0-9]{9,9}", ErrorMessage = "Insira um número de 9 dígitos")]
        public string ContactoDestinatario { get; set; }

        [Required(ErrorMessage = "Adicione um email")]
        public string EmailDestinatario { get; set; }

        [Required(ErrorMessage = "Adicione um peso")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "Adicione um comprimento")]
        public decimal Comprimento { get; set; }

        [Required(ErrorMessage = "Adicione um largura")]
        public decimal Largura { get; set; }

        [Required(ErrorMessage = "Adicione uma altura")]
        public decimal Altura { get; set; }

        [Required(ErrorMessage = "Adicione uma data de entrega pretendida")]
        public DateTime DataEntregaPretendida { get; set; }

    }
}