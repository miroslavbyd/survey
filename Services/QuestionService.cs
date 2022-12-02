using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class QuestionService :IQuestionService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public QuestionService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(QuestionModel headerModel)
        {
            Question page = new Question();
            if (page != null)
            {
                //page.Id = headerModel.Id;
                page.Description = headerModel.Description;
                page.CointainerId = headerModel.CointainerId;
                page.TypeQuestionId = headerModel.TypeQuestionId;

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
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
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
                CointainerId = page.CointainerId,
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
                page.CointainerId = questionModel.CointainerId;
                page.TypeQuestionId = questionModel.TypeQuestionId;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<QuestionModel> GetAll()
        {
            var questions = _surveyDbContext
                .questions;
            IEnumerable<QuestionModel> questionsModel = questions.Select(s => new QuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                CointainerId = s.CointainerId,
                TypeQuestionId = s.TypeQuestionId
            });
            var result = questionsModel;
            return result;
        }

        public IEnumerable<QuestionModel>? GetAllId(int? id)
        {
            var questions = _surveyDbContext
                .questions;
            IEnumerable<QuestionModel> questionsModel = questions.Select(s => new QuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                CointainerId = s.CointainerId,
                TypeQuestionId = s.TypeQuestionId
            }).Where(s => s.CointainerId == id);
            var result = questionsModel;
            return result;
        }
    }
}
