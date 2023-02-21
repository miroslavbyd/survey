using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public QuestionService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(QuestionModel questionModel)
        {
            Question page = new Question();
            if (page != null)
            {
                //page.Id = questionModel.Id;
                page.Description = questionModel.Description;
                page.ContainerId = questionModel.ContainerId;
                page.TypeQuestionId = questionModel.TypeQuestionId;

            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var page = _surveyDbContext.questions.Find(id);
            //var page = _surveyDbContext.questions.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                AnswerDelete(id);
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }
        private void AnswerDelete(int? questionId)
        {
            var answers = _surveyDbContext
                .answers.ToList();
            var answersListQuestionId = answers.Where(s => s.QuestionId == questionId);
            foreach(var answer in answersListQuestionId)
            {
                if (answer != null)
                {
                    _surveyDbContext.Remove(answer);
                }
            }
        }
        public QuestionModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.questions.Find(id);

            if (page == null)
            {
                return null;
            }
            var questionModel = new QuestionModel()
            {
                Id = page.Id,
                Description = page.Description,
                ContainerId = page.ContainerId,
                TypeQuestionId = page.TypeQuestionId
            };
            return questionModel;
        }

        public void Edit(QuestionModel questionModel)
        {
            var page = _surveyDbContext.questions.Find(questionModel.Id);
            if (page != null)
            {
                //page.Id = questionModel.Id;
                page.Description = questionModel.Description;
                page.ContainerId = questionModel.ContainerId;
                page.TypeQuestionId = questionModel.TypeQuestionId;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<QuestionModel> GetAll()
        {
            var questions = _surveyDbContext
                .questions.ToList();
            IEnumerable<QuestionModel> questionsModel = questions.Select(s => new QuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                ContainerId = s.ContainerId,
                TypeQuestionId = s.TypeQuestionId
            });
            var result = questionsModel;
            return result;
        }

        public IEnumerable<QuestionModel>? GetAllId(int? id)
        {
            var questions = _surveyDbContext
                .questions.ToList();
            IEnumerable<QuestionModel> questionsModel = questions.Select(s => new QuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                ContainerId = s.ContainerId,
                TypeQuestionId = s.TypeQuestionId
            }).Where(s => s.ContainerId == id);
            var result = questionsModel;
            return result;
        }
        public QuestionModel? GetId(int? questionId)
        {
            var questions = _surveyDbContext
                .questions.ToList();
            QuestionModel? questionModel = questions.Select(s => new QuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                ContainerId = s.ContainerId,
                TypeQuestionId = s.TypeQuestionId
            }).Where(s => s.Id == questionId).FirstOrDefault();
            var result = questionModel;
            return result;
        }
        public int? QuestionIdToContainerId(int? questionId)
        {
            int? containerId = null;
            var questions = _surveyDbContext
                .questions.ToList();
            QuestionModel? questionModel = questions.Select(s => new QuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                ContainerId = s.ContainerId,
                TypeQuestionId = s.TypeQuestionId
            }).Where(s => s.Id == questionId).FirstOrDefault();
            if (questionModel != null)
            {
                containerId = questionModel.ContainerId;
            }
            return containerId;
        }
        public int? ContainerIdToSurveyId(int? containerId)
        {
            int? surveyId = null;
            var containers = _surveyDbContext
                .containers.ToList();
            ContainerModel? containerModel = containers.Select(s => new ContainerModel()
            {
                Id = s.Id,
                Description = s.Description,
                SurveyId = s.SurveyId
            }).Where(s => s.Id == containerId).FirstOrDefault();
            if (containerModel != null)
            {
                surveyId = containerModel.SurveyId;
            }
            return surveyId;
        }
    }
}
