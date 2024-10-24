using System.ComponentModel.DataAnnotations;

namespace SistemaTesteSoftware.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        [StrongPassword(ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
        public string Password { get; set; }
    }

    // Validação customizada para senha forte
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;
            if (password != null)
            {
                // Verifica se a senha contém pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial
                bool hasUpperChar = false, hasLowerChar = false, hasDigit = false, hasSpecialChar = false;

                foreach (var c in password)
                {
                    if (char.IsUpper(c)) hasUpperChar = true;
                    if (char.IsLower(c)) hasLowerChar = true;
                    if (char.IsDigit(c)) hasDigit = true;
                    if (!char.IsLetterOrDigit(c)) hasSpecialChar = true;
                }

                if (hasUpperChar && hasLowerChar && hasDigit && hasSpecialChar)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
