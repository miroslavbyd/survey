using ankiety.Models;

namespace ankiety.Services
{
    public interface IAnswerCompletedService
    {
        IEnumerable<AnswerCompletedModel> GetAll();
        IEnumerable<AnswerCompletedModel> GetAllId(int? id);
        AnswerCompletedModel? Edit(int? id);
        void Edit(AnswerCompletedModel answerCompletedModel);
        void Add(AnswerCompletedModel answerCompleted);
        void Delete(int? id);
    }
}
