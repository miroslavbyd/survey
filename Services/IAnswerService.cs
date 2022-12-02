using ankiety.Models;

namespace ankiety.Services
{
    public interface IAnswerService
    {
        IEnumerable<AnswerModel> GetAll();
        IEnumerable<AnswerModel> GetAllId(int id);
        AnswerModel? Edit(int? id);
        void Edit(AnswerModel answerModel);
        void Add(AnswerModel answer);
        void Delete(int? id);
    }
}
