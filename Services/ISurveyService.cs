using ankiety.Models;

namespace ankiety.Services
{
    public interface ISurveyService
    {
        IEnumerable<SurveyModel> GetAll();
        SurveyModel? Edit(int? id);
        void Edit(SurveyModel surveyModel);
        void Add(SurveyModel survey);
        void Delete(int? id);
    }
}
