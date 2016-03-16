namespace OrdersSystem.Services
{
    using System.Linq;

    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    
    public class DevicesServices : IDevicesServices
    {
        private IRepository<Device> devices;

        public DevicesServices(IRepository<Device> devices)
        {
            this.devices = devices;
        }

        public IQueryable<Device> GetAll()
        {
            return this.devices.All().OrderBy(x => x.Name);
        }

        public Device Add(Device device)
        {
            this.devices.Add(device);
            this.devices.SaveChanges();

            return device;
        }

        public Device Update(int id, Device device)
        {
            var deviceToUpdate = this.devices.GetById(id);
            deviceToUpdate.Name = device.Name;
            deviceToUpdate.CategoryId = device.CategoryId;
            this.devices.SaveChanges();

            return deviceToUpdate;
        }

        public void Delete(int id)
        {
            this.devices.Delete(id);
            this.devices.SaveChanges();
        }
    }
}
