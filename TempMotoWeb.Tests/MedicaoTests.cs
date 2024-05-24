using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace TempMotoWeb.Tests
{
    public class MedicaoTests
    {
        [Fact]
        public void TestMedicaoValidation()
        {
            // Arrange
            var medicaoValida = new Medicao { Temperatura = 25.0f, Ph = 7.0f }; // Valores dentro dos limites esperados
            var medicaoInvalida = new Medicao { Temperatura = 100.0f, Ph = 8.0f }; // Valores fora dos limites esperados

            // Act
            var resultadoValido = ValidateModel(medicaoValida);
            var resultadoInvalido = ValidateModel(medicaoInvalida);

            // Assert
            Assert.Empty(resultadoValido); // Nenhum erro deve ser retornado para uma instância válida
            Assert.NotEmpty(resultadoInvalido); // Erros devem ser retornados para uma instância inválida
        }

        private static ValidationResult[] ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            Validator.TryValidateObject(model, validationContext, validationResults, true);

            return validationResults.ToArray();
        }
    }

    public class Medicao
    {
        [Range(0, 50, ErrorMessage = "A temperatura deve estar entre 0 e 50 graus.")]
        public float Temperatura { get; set; }

        [Range(0, 14, ErrorMessage = "O pH deve estar entre 0 e 14.")]
        public float Ph { get; set; }
    }
}
