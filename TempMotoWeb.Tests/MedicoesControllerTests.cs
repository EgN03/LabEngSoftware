using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TempMotoWeb.Controllers;
using TempMotoWeb.Data;
using TempMotoWeb.Models;
using Xunit;


namespace TempMotoWeb.Tests
{
    public class MedicoesControllerTests
    {
        private readonly Mock<AquaContext> _mockContext;

        public MedicoesControllerTests()
        {
            _mockContext = new Mock<AquaContext>();
        }

        [Fact]
        public async void Index_ReturnsAViewResult_WithAListOfMedicoes()
        {
            // Arrange
            var medicoes = new List<Medicao>
            {
                new Medicao { Id = 1, Temperatura = 25.5f, Ph = 7.0f },
                new Medicao { Id = 2, Temperatura = 26.0f, Ph = 7.2f }
            };
            _mockContext.Setup(c => c.Medicao).ReturnsDbSet(medicoes);

            var controller = new MedicaoController(_mockContext.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Medicao>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async void Index_ReturnsProblemResult_WhenMedicoesIsNull()
        {
            // Arrange
            _mockContext.Setup(c => c.Medicao).Returns(() => null);

            var controller = new MedicaoController(_mockContext.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var problemResult = Assert.IsType<ProblemObjectResult>(result);
            Assert.Equal("Entity set 'TempMotoWebContext.Medicao'  is null.", problemResult.Value);
        }

        // Add other test methods as needed
    }
}
