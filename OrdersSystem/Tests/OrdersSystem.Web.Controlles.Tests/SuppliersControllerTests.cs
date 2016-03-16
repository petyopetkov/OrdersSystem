namespace OrdersSystem.Web.Controlles.Tests
{
    using Models;
    using Moq;
    using NUnit.Framework;
    using OrdersSystem.Web.Areas.Admin.Controllers;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Services.Contracts;
    using TestStack.FluentMVCTesting;
    [TestFixture]
    public class SuppliersControllerTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(DevicesController).Assembly);
        }

        [Test]
        public void SuppliersControllerAddActionShouldRenderProperView()
        {
            var suppliersServicesMock = new Mock<ISuppliersServices>();
            suppliersServicesMock.Setup(x => x.Add(new Supplier { Name = "Delete me" }));
            var controller = new SuppliersController(suppliersServicesMock.Object);

            controller.WithCallTo(x => x.Add()).ShouldRenderView("Add");
        }

        [Test]
        public void SuppliersControllerEditActionShouldRenderProperView()
        {
            var suppliersServicesMock = new Mock<ISuppliersServices>();
            var supplier = new Supplier { Name = "Delete me" };
            suppliersServicesMock.Setup(x => x.Update(It.IsAny<int>(), supplier));

            var controller = new SuppliersController(suppliersServicesMock.Object);

            controller.WithCallTo(x => x.Edit(123)).ShouldRenderView("Edit");
        }
    }
}
