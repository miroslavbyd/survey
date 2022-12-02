using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public AnswerService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(AnswerModel answerModel)
        {
            Answer page = new Answer();
            if (page != null)
            {
                //page.Id = answerModel.Id;
                page.Signature = answerModel.Signature;
                page.ValueINT = answerModel.ValueINT;
                page.ValueDATETIME = answerModel.ValueDATETIME;
                page.ValueTEXT = answerModel.ValueTEXT;
                page.ValueBIT = answerModel.ValueBIT;
                page.QuestionId = answerModel.QuestionId;

            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var page = _surveyDbContext.answers.Find(id);
            //var page = _surveyDbContext.answers.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }

        public AnswerModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.answers.Find(id);

            if (page == null)
            {
                return null;
            }
            var answerModel = new AnswerModel()
            {
                Id = page.Id,
                Signature = page.Signature,
                ValueINT = page.ValueINT,
                ValueDATETIME = page.ValueDATETIME,
                ValueTEXT = page.ValueTEXT,
                ValueBIT = page.ValueBIT,
                QuestionId = page.QuestionId
            };
            return answerModel;
        }

        public void Edit(AnswerModel answerModel)
        {
            var page = _surveyDbContext.answers.Find(answerModel.Id);
            if (page != null)
            {
                //page.Id = answerModel.Id;
                page.Signature = answerModel.Signature;
                page.ValueINT = answerModel.ValueINT;
                page.ValueDATETIME = answerModel.ValueDATETIME;
                page.ValueTEXT = answerModel.ValueTEXT;
                page.ValueBIT = answerModel.ValueBIT;
                page.QuestionId = answerModel.QuestionId;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<AnswerModel> GetAll()
        {
            var answers = _surveyDbContext
                .answers;
            IEnumerable<AnswerModel> answersModel = answers.Select(s => new AnswerModel()
            {
                Id = s.Id,
                Signature = s.Signature,
                ValueINT = s.ValueINT,
                ValueDATETIME = s.ValueDATETIME,
                ValueTEXT = s.ValueTEXT,
                ValueBIT = s.ValueBIT,
                QuestionId = s.QuestionId
            });
            var result = answersModel;
            return result;
        }

        public IEnumerable<AnswerModel> GetAllId(int id)
        {
            var answers = _surveyDbContext
                .answers;
            IEnumerable<AnswerModel> answersModel = answers.Select(s => new AnswerModel()
            {
                Id = s.Id,
                Signature = s.Signature,
                ValueINT = s.ValueINT,
                ValueDATETIME = s.ValueDATETIME,
                ValueTEXT = s.ValueTEXT,
                ValueBIT = s.ValueBIT,
                QuestionId = s.QuestionId
            }).Where(s => s.QuestionId == id);
            var result = answersModel;
            return result;
        }
    }
}
