namespace OrdersSystem.Web.Controlles.Tests
{
    using Moq;
    using NUnit.Framework;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Areas.Admin.Controllers;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class CategoriesControllerTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(CategoriesController).Assembly);
        }

        [Test]
        public void CategoriesControllerAddActionShouldRenderProperView()
        {
            var categoriesServicesMock = new Mock<ICategoriesServices>();
            categoriesServicesMock.Setup(x => x.Add(new Category { Name = "Delete me" }));
            var controller = new CategoriesController(categoriesServicesMock.Object);

            controller.WithCallTo(x => x.Add()).ShouldRenderView("Add");
        }

        [Test]
        public void CategoriesControllerEditActionShouldRenderProperView()
        {
            var categoriesServicesMock = new Mock<ICategoriesServices>();
            var newCategory = new Category { Name = "Delete me" };

            categoriesServicesMock.Setup(x => x.Update(It.IsAny<int>(), newCategory))
                .Returns(newCategory);
            var controller = new CategoriesController(categoriesServicesMock.Object);

            controller.WithCallTo(x => x.Edit(123))
                .ShouldRenderView("Edit");
        }        
    }
}
