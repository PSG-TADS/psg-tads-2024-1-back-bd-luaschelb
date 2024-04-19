using System;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CPFAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success; // Permitir valores nulos ou vazios
            }

            string cpf = value.ToString().Replace(".", "").Replace("-", "");

            if (!IsValidCPF(cpf))
            {
                return new ValidationResult("O CPF informado é inválido.");
            }

            return ValidationResult.Success;
        }

        private bool IsValidCPF(string cpf)
        {
            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
            {
                return false;
            }

            var numbers = new int[11];
            for (int i = 0; i < 11; i++)
            {
                numbers[i] = int.Parse(cpf[i].ToString());
            }

            int sum1 = 0;
            for (int i = 0; i < 9; i++)
            {
                sum1 += numbers[i] * (10 - i);
            }

            int remainder1 = sum1 % 11;
            int digit1 = remainder1 < 2 ? 0 : 11 - remainder1;

            if (numbers[9] != digit1)
            {
                return false;
            }

            int sum2 = 0;
            for (int i = 0; i < 10; i++)
            {
                sum2 += numbers[i] * (11 - i);
            }

            int remainder2 = sum2 % 11;
            int digit2 = remainder2 < 2 ? 0 : 11 - remainder2;

            return numbers[10] == digit2;
        }
    }
}
