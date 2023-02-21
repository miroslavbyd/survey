using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyDbContext _surveyDbContext;
        private readonly IHeaderService _headerService;
        public SurveyService(SurveyDbContext surveyDbContext, IHeaderService headerService)
        {
            _surveyDbContext = surveyDbContext;
            _headerService = headerService;
        }
        public IEnumerable<SurveyModel> GetAll()
        {
            var surveys = _surveyDbContext
                .surveys.ToList();
            IEnumerable<SurveyModel> surveysModel = surveys.Select(s => new SurveyModel()
            {
                Id = s.Id,
                Name = s.Name,
                DateCreation = s.DateCreation,
                DateFrom = s.DateFrom,
                DateTo = s.DateTo,
                //HeadersModel = (Task<HeaderModel>)_headerService.GetAllId(s.Id)
            });
            var result = surveysModel;
            return result;
        }
        public SurveyModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.surveys.Find(id);
            //var page = _surveyDbContext.surveys.SingleOrDefault(x => x.Id == id);
            if(page == null)
            {
                return null;
            }
            var surveyModel = new SurveyModel()
            {
                Id = page.Id,
                Name = page.Name,
                DateCreation = page.DateCreation,
                DateFrom = page.DateFrom,
                DateTo = page.DateTo
            };
            return surveyModel;
        }
        public void Edit(SurveyModel? surveyModel)
        {
            var page = _surveyDbContext.surveys.Find(surveyModel.Id);
            if(page != null)
            {
                //page.Id = surveyModel.Id;
                page.Name = surveyModel.Name;
                page.DateCreation = surveyModel.DateCreation;
                page.DateFrom = surveyModel.DateFrom;
                page.DateTo = surveyModel.DateTo;
            }
            _surveyDbContext.SaveChanges();
        }
        public void Add(SurveyModel surveyModel)
        {
            Survey page = new Survey();
            if (page != null)
            {
                //page.Id = surveyModel.Id;
                page.Name = surveyModel.Name;
                page.DateCreation = surveyModel.DateCreation;
                page.DateFrom = surveyModel.DateFrom;
                page.DateTo = surveyModel.DateTo;
            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }
        public void Delete(int? id)
        {
            var page = _surveyDbContext.surveys.Find(id);
            //var page = _surveyDbContext.surveys.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                HeaderDelete(id);
                ContainerDelete(id);
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }
        private void HeaderDelete(int? surveyId)
        {
            var headers = _surveyDbContext
                .headers.ToList();
            var a = headers.Where(s => s.SurveyId == surveyId);
            foreach (var header in a)
            {
                if (header != null)
                {
                    _surveyDbContext.Remove(header);
                }
            }
        }
        private void ContainerDelete(int? surveyId)
        {
            var containers = _surveyDbContext
                .containers.ToList();
            var containersListSurveyId = containers.Where(s => s.SurveyId == surveyId);
            foreach (var container in containersListSurveyId)
            {
                if (container != null)
                {
                    QuestionDelete(container.Id);
                    _surveyDbContext.Remove(container);
                }
            }
        }
        private void QuestionDelete(int? containerId)
        {
            var questions = _surveyDbContext
                .questions.ToList();
            var questionsListContainerId = questions.Where(s => s.ContainerId == containerId);
            foreach (var question in questionsListContainerId)
            {
                if (question != null)
                {
                    AnswerDelete(question.Id);
                    _surveyDbContext.Remove(question);
                }
            }
        }
        private void AnswerDelete(int? questionId)
        {
            var answers = _surveyDbContext
                .answers.ToList();
            var answersListQuestionId = answers.Where(s => s.QuestionId == questionId);
            foreach (var answer in answersListQuestionId)
            {
                if (answer != null)
                {
                    _surveyDbContext.Remove(answer);
                }
            }
        }
    }
}
