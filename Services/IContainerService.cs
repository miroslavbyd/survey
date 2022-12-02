using ankiety.Models;

namespace ankiety.Services
{
    public interface IContainerService
    {
        IEnumerable<ContainerModel> GetAll();
        IEnumerable<ContainerModel> GetAllId(int? id);
        ContainerModel? Edit(int? id);
        void Edit(ContainerModel containerModel);
        void Add(ContainerModel container);
        void Delete(int? id);
    }
}
