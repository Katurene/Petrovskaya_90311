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
        [InlineData(1, 3, 1)] // 1-я страница, кол. объектов 3, id первого объекта 1
        [InlineData(2, 2, 4)] // 2-я страница, кол. объектов 2, id первого объекта 4
        
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            var controller = new AnimalController();
            controller._animals = new List<Animal>
            {
                new Animal{ AnimalId=1},
                new Animal{ AnimalId=2},
                new Animal{ AnimalId=3},
                new Animal{ AnimalId=4},
                new Animal{ AnimalId=5}
            };
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
