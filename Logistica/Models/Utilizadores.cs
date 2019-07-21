using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Logistica.Models
{
    public class Utilizadores
    {
        [Key]
        public int ID { get; set; }

        //[Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        [StringLength(30)]
        //[RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | da | das | do | dos |-|'|d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]*){1,3}",
                     //    ErrorMessage = "só são aceites palavras, começadas por Maiúscula, " +
                          //             "separadas por um espeço em branco.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O apelido é de preenchimento obrigatório")]
        [StringLength(30)]
        //[RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | da | das | do | dos |-|'|d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]*){1,3}",
                      //   ErrorMessage = "só são aceites palavras, começadas por Maiúscula, " +
                         //              "separadas por um espeço em branco.")]
        public string Apelido { get; set; }

        //[Required(ErrorMessage = "A fotografia é de preenchimento obrigatório")]
        public string Fotografia { get; set; }



    }
}