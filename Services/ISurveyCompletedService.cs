using ankiety.Models;

namespace ankiety.Services
{
    public interface ISurveyCompletedService
    {
        IEnumerable<SurveyCompletedModel> GetAll();
        IEnumerable<SurveyCompletedModel> GetAllId(int? id);
        SurveyCompletedModel? Edit(int? id);
        void Edit(SurveyCompletedModel surveyCompletedModel);
        void Add(SurveyCompletedModel surveyCompleted);
        void Delete(int? id);
    }
}
