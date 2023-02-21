using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class ContainerService : IContainerService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public ContainerService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(ContainerModel containerModel)
        {
            Container page = new Container();
            if (page != null)
            {
                //page.Id = containerModel.Id;
                page.Description = containerModel.Description;
                page.SurveyId = containerModel.SurveyId;

            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var page = _surveyDbContext.containers.Find(id);
            //var page = _surveyDbContext.containers.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                QuestionDelete(id);
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
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
        public ContainerModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.containers.Find(id);

            if (page == null)
            {
                return null;
            }
            var containerModel = new ContainerModel()
            {
                Id = page.Id,
                Description = page.Description,
                SurveyId = page.SurveyId
            };
            return containerModel;
        }

        public void Edit(ContainerModel containerModel)
        {
            var page = _surveyDbContext.containers.Find(containerModel.Id);
            if (page != null)
            {
                //page.Id = containerModel.Id;
                page.Description = containerModel.Description;
                page.SurveyId = containerModel.SurveyId;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<ContainerModel> GetAll()
        {
            var containers = _surveyDbContext
                .containers.ToList();
            IEnumerable<ContainerModel> containersModel = containers.Select(s => new ContainerModel()
            {
                Id = s.Id,
                Description = s.Description,
                SurveyId = s.SurveyId
            });
            var result = containersModel;
            return result;
        }

        public IEnumerable<ContainerModel>? GetAllId(int? id)
        {
            var containers = _surveyDbContext
                .containers.ToList();
            IEnumerable<ContainerModel> containersModel = containers.Select(s => new ContainerModel()
            {
                Id = s.Id,
                Description = s.Description,
                SurveyId = s.SurveyId
            }).Where(s => s.SurveyId == id);
            var result = containersModel;
            return result;
        }
        public HeaderModel? GetId(int? headerId)
        {
            var headers = _surveyDbContext
                .containers.ToList();
            HeaderModel? headerModel = headers.Select(s => new HeaderModel()
            {
                Id = s.Id,
                Description = s.Description,
                SurveyId = s.SurveyId
            }).Where(s => s.Id == headerId).FirstOrDefault();
            var result = headerModel;
            return result;
        }
        public int? ContainerIdToSurveyId(int? containerId)
        {
            int? surveyId = null;
            var headers = _surveyDbContext
                .containers.ToList();
            ContainerModel? containerModel = headers.Select(s => new ContainerModel()
            {
                Id = s.Id,
                Description = s.Description,
                SurveyId = s.SurveyId
            }).Where(s => s.Id == containerId).FirstOrDefault();
            if(containerModel != null)
            {
                surveyId = containerModel.SurveyId;
            }
            return surveyId;
        }
    }
}
