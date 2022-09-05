using ankiety.Controllers;
using ankiety.Domain;

namespace ankiety.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _surveyDbContext;
        public SurveyRepository(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }

        public Survey Get(int id)
        {
            return _surveyDbContext.surveys.SingleOrDefault(x => x.Id == id);
        }

        public void Add(Survey survey)
        {
            _surveyDbContext.surveys.Add(survey);
            _surveyDbContext.SaveChanges();
        }
        public IQueryable<Survey> GetAll()
        {
            return _surveyDbContext.surveys.AsQueryable();
        }
        public void Update(int id, Survey survey)
        {
            var result = _surveyDbContext.surveys.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
                result.Id = survey.Id;
                result.Name = survey.Name;
                result.DateCreation = survey.DateCreation;
                result.DateFrom = survey.DateFrom;
                result.DateTo = survey.DateTo;

                _surveyDbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var result = _surveyDbContext.surveys.SingleOrDefault(x => x.Id == id);
            if(null != result)
            {
                _surveyDbContext.surveys.Remove(result);
                _surveyDbContext.SaveChanges();
            }
        }
    }
}
