using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class AnswerCompletedService : IAnswerCompletedService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public AnswerCompletedService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(AnswerCompletedModel answerModel)
        {
            AnswerCompleted page = new AnswerCompleted();
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
            var page = _surveyDbContext.answerCompleteds.Find(id);
            //var page = _surveyDbContext.answerCompleteds.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }

        public AnswerCompletedModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.answerCompleteds.Find(id);

            if (page == null)
            {
                return null;
            }
            var answerCompletedModel = new AnswerCompletedModel()
            {
                Id = page.Id,
                Signature = page.Signature,
                ValueINT = page.ValueINT,
                ValueDATETIME = page.ValueDATETIME,
                ValueTEXT = page.ValueTEXT,
                ValueBIT = page.ValueBIT,
            };
            return answerCompletedModel;
        }

        public void Edit(AnswerCompletedModel answerCompletedModel)
        {
            var page = _surveyDbContext.answerCompleteds.Find(answerCompletedModel.Id);
            if (page != null)
            {
                //page.Id = answerModel.Id;
                page.Signature = answerCompletedModel.Signature;
                page.ValueINT = answerCompletedModel.ValueINT;
                page.ValueDATETIME = answerCompletedModel.ValueDATETIME;
                page.ValueTEXT = answerCompletedModel.ValueTEXT;
                page.ValueBIT = answerCompletedModel.ValueBIT;

            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<AnswerCompletedModel> GetAll()
        {
            var answerCompleteds = _surveyDbContext
                .answerCompleteds;
            IEnumerable<AnswerCompletedModel> answerCompletedsModel = answerCompleteds.Select(s => new AnswerCompletedModel()
            {
                Id = s.Id,
                Signature = s.Signature,
                ValueINT = s.ValueINT,
                ValueDATETIME = s.ValueDATETIME,
                ValueTEXT = s.ValueTEXT,
                ValueBIT = s.ValueBIT,
            });
            var result = answerCompletedsModel;
            return result;
        }

        public IEnumerable<AnswerCompletedModel> GetAllId(int? id)
        {
            var answerCompleteds = _surveyDbContext
                .answerCompleteds;
            IEnumerable<AnswerCompletedModel> answerCompletedsModel = answerCompleteds.Select(s => new AnswerCompletedModel()
            {
                Id = s.Id,
                Signature = s.Signature,
                ValueINT = s.ValueINT,
                ValueDATETIME = s.ValueDATETIME,
                ValueTEXT = s.ValueTEXT,
                ValueBIT = s.ValueBIT,
            }).Where(s => s.QuestionId == id);
            var result = answerCompletedsModel;
            return result;
        }

    }
}
