using ankiety.Domain;

namespace ankiety.Repositories
{
    public interface ISurveyRepository
    {
        Survey Get(int id);
        IQueryable<Survey> GetAll();
        void Add(Survey survey);
        void Update(int id, Survey survey);
        void Delete(int id);

    }
}
