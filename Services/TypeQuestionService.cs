using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class TypeQuestionService : ITypeQuestionService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public TypeQuestionService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(TypeQuestionModel typeQuestionModel)
        {
            TypeQuestion page = new TypeQuestion();
            if (page != null)
            {
                //page.Id = answerModel.Id;
                page.Description = typeQuestionModel.Description;
                page.Type = typeQuestionModel.Type;

            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var page = _surveyDbContext.typeQuestions.Find(id);
            //var page = _surveyDbContext.typeQuestions.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }

        public TypeQuestionModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.typeQuestions.Find(id);

            if (page == null)
            {
                return null;
            }
            var typeQuestionModel = new TypeQuestionModel()
            {
                Id = page.Id,
                Description = page.Description,
                Type = page.Type,
            };
            return typeQuestionModel;
        }

        public void Edit(TypeQuestionModel typeQuestionModel)
        {
            var page = _surveyDbContext.typeQuestions.Find(typeQuestionModel.Id);
            if (page != null)
            {
                //page.Id = typeQuestionModel.Id;
                page.Description = typeQuestionModel.Description;
                page.Type = typeQuestionModel.Type;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<TypeQuestionModel> GetAll()
        {
            var typeQuestions = _surveyDbContext
                .typeQuestions.ToList();
            IEnumerable<TypeQuestionModel> typeQuestionsModel = typeQuestions.Select(s => new TypeQuestionModel()
            {
                Id = s.Id,
                Description = s.Description,
                Type = s.Type,
            });
            var result = typeQuestionsModel;
            return result;
        }
    }
}
