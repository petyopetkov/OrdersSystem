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
    public class CustomersControllerTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(CustomersController).Assembly);
        }

        [Test]
        public void CategoriesControllerAddActionShouldRenderProperView()
        {
            var customersServicesMock = new Mock<ICustomersServices>();
            customersServicesMock.Setup(x => x.Add(new Customer { Name = "Delete me", Address = "Some address" }));
            var controller = new CustomersController(customersServicesMock.Object);

            controller.WithCallTo(x => x.Add()).ShouldRenderView("Add");
        }

        [Test]
        public void CategoriesControllerEditActionShouldRenderProperView()
        {
            var customersServicesMock = new Mock<ICustomersServices>();
            var newCustomer = new Customer { Name = "Delete me", Address = "Some address" };

            customersServicesMock.Setup(x => x.Update(It.IsAny<int>(), newCustomer))
                .Returns(newCustomer);
            var controller = new CustomersController(customersServicesMock.Object);

            controller.WithCallTo(x => x.Edit(123))
                .ShouldRenderView("Edit");
        }
    }
}
