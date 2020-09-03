using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Petrovskaya_90311.Controllers;
using Petrovskaya_90311.DAL.Entities;
using Xunit;

namespace Petrovskaya_90311.Tests
{
    public class AnimalControllerTests
    {
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            var controller = new AnimalController();
            controller._animals = TestData.GetDishesList();
            // Act
            var result = controller.Index(page) as ViewResult;
            var model = result?.Model as List<Animal>;
            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].AnimalId);
        }
    }
}
