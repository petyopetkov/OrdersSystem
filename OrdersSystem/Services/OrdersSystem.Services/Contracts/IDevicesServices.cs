namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;

    public interface IDevicesServices
    {
        IQueryable<Device> GetAll();

        Device Add(Device device);

        Device Update(int id, Device device);

        void Delete(int id);
    }
}
