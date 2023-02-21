using ankiety.Models;

namespace ankiety.Services
{
    public interface IQuestionService
    {
        IEnumerable<QuestionModel> GetAll();
        IEnumerable<QuestionModel> GetAllId(int? id);
        QuestionModel? Edit(int? id);
        void Edit(QuestionModel questionModel);
        void Add(QuestionModel question);
        void Delete(int? id);
        public int? QuestionIdToContainerId(int? QuestionId);
        public int? ContainerIdToSurveyId(int? ContainerId);
    }
}
