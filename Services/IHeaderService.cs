using ankiety.Models;

namespace ankiety.Services
{
    public interface IHeaderService
    {
        IEnumerable<HeaderModel> GetAll();
        IEnumerable<HeaderModel> GetAllId(int? id);
        HeaderModel? Edit(int? id);
        void Edit(HeaderModel headerModel);
        void Add(HeaderModel header);
        void Delete(int? id);
    }
}
