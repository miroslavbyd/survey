using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class SurveyCompletedService : ISurveyCompletedService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public SurveyCompletedService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(SurveyCompletedModel surveyCompletedModel)
        {
            SurveyCompleted page = new SurveyCompleted();
            if (page != null)
            {
                //page.Id = surveyCompletedModel.Id;
                page.DateAnswer = surveyCompletedModel.DateAnswer;
                page.Status = surveyCompletedModel.Status;
                page.surveyId = surveyCompletedModel.surveyId;
                page.UserId = surveyCompletedModel.UserId;

            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var page = _surveyDbContext.surveyCompleteds.Find(id);
            //var page = _surveyDbContext.surveyCompleteds.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }

        public SurveyCompletedModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.surveyCompleteds.Find(id);

            if (page == null)
            {
                return null;
            }
            var surveyCompletedModel = new SurveyCompletedModel()
            {
                Id = page.Id,
                DateAnswer = page.DateAnswer,
                Status = page.Status,
                surveyId = page.surveyId,
                UserId = page.UserId,
            };
            return surveyCompletedModel;
        }

        public void Edit(SurveyCompletedModel surveyCompletedModel)
        {
            var page = _surveyDbContext.surveyCompleteds.Find(surveyCompletedModel.Id);
            if (page != null)
            {
                //page.Id = surveyCompletedModel.Id;
                page.DateAnswer = surveyCompletedModel.DateAnswer;
                page.Status = surveyCompletedModel.Status;
                page.surveyId = surveyCompletedModel.surveyId;
                page.UserId = surveyCompletedModel.UserId;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<SurveyCompletedModel> GetAll()
        {
            var surveyCompleteds = _surveyDbContext
                .surveyCompleteds.ToList();
            IEnumerable<SurveyCompletedModel> surveyCompletedsModel = surveyCompleteds.Select(s => new SurveyCompletedModel()
            {
                Id = s.Id,
                DateAnswer = s.DateAnswer,
                Status = s.Status,
                surveyId = s.surveyId,
                UserId = s.UserId,
            });
            var result = surveyCompletedsModel;
            return result;
        }

        public IEnumerable<SurveyCompletedModel> GetAllId(int? id)
        {
            var surveyCompleteds = _surveyDbContext
                .surveyCompleteds.ToList();
            IEnumerable<SurveyCompletedModel> surveyCompletedsModel = surveyCompleteds.Select(s => new SurveyCompletedModel()
            {
                Id = s.Id,
                DateAnswer = s.DateAnswer,
                Status = s.Status,
                surveyId = s.surveyId,
                UserId = s.UserId,
            }).Where(s => s.surveyId == id);
            var result = surveyCompletedsModel;
            return result;
        }

    }
}
