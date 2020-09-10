using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Petrovskaya_90311.Controllers;
using Petrovskaya_90311.DAL.Entities;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Petrovskaya_90311.DAL.Data;

namespace Petrovskaya_90311.Tests
{
    public class AnimalControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;

        public AnimalControllerTests()
        {
            _options =
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "testDb")
            .Options;
        }

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new AnimalController(context)
                { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(group: null, pageNo:page) as ViewResult;
                var model = result?.Model as List<Animal>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].AnimalId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new AnimalController(context)
                { ControllerContext = controllerContext };
                var comparer = Comparer<Animal>.GetComparer((d1, d2) =>
                d1.AnimalId.Equals(d2.AnimalId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Animal>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Animals
                .ToArrayAsync()
                .GetAwaiter()
                .GetResult()[2], model[0], comparer);
            }
        }
    }
}
        //[Theory]
        //[MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        //public void ControllerGetsProperPage(int page, int qty, int id)
        //{
        //    // Arrange
        //    var controller = new AnimalController();
        //    controller._animals = TestData.GetDishesList();
        //    // Act
        //    //var result = controller.Index(page) as ViewResult;
        //    var result = controller.Index(pageNo: page, group: null) as ViewResult;
        //    var model = result?.Model as List<Animal>;
        //    // Assert
        //    Assert.NotNull(model);
        //    Assert.Equal(qty, model.Count);
        //    Assert.Equal(id, model[0].AnimalId);
        //}

        //[Fact]
        //public void ControllerSelectsGroup()
        //{
        //    // Контекст контроллера
        //    var controllerContext = new ControllerContext();
        //    // Макет HttpContext
        //    var moqHttpContext = new Mock<HttpContext>();
        //    moqHttpContext.Setup(c => c.Request.Headers)
        //    .Returns(new HeaderDictionary());
        //    controllerContext.HttpContext = moqHttpContext.Object;
        //    var controller = new AnimalController()
        //    { ControllerContext = controllerContext };

            // arrange
            //var controller = new AnimalController();
            //var data = TestData.GetDishesList();
            //controller._animals = data;
            //var comparer = Comparer<Animal>
            //.GetComparer((d1, d2) => d1.AnimalId.Equals(d2.AnimalId));
            //// act
            //var result = controller.Index(2) as ViewResult;
            //var model = result.Model as List<Animal>;
            //// assert
            //Assert.Equal(2, model.Count);
            //Assert.Equal(data[2], model[0], comparer);
    
