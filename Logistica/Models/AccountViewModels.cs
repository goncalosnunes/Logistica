using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logistica.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        [StringLength(30)]
        [RegularExpression("([A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,2}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
            " separadas por um espaço em branco")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O apelido é de preenchimento obrigatório")]
        [StringLength(30)]
        [RegularExpression("([A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,2}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
            " separadas por um espaço em branco")]
        public string Apelido { get; set; }

        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòù]+( [A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,6}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Adicione um país")]
        [RegularExpression("([A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,2}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
           " separadas por um espaço em branco")]
        [StringLength(50)]
        public string Pais { get; set; }


        [RegularExpression("([A-ZÁÉÍÓÚ][a-záéíóúàèìòù]*){1,2}", ErrorMessage = "só são aceites palavras, começadas por maiúsculas," +
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
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}