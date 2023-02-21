using ankiety.Controllers;
using ankiety.Domain;
using ankiety.Models;

namespace ankiety.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly SurveyDbContext _surveyDbContext;
        public HeaderService(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(HeaderModel headerModel)
        {
            Header page = new Header();
            if (page != null)
            {
                //page.Id = headerModel.Id;
                page.Description = headerModel.Description;
                page.Style = headerModel.Style;
                page.SurveyId = headerModel.SurveyId;

            }
            _surveyDbContext.Add(page);
            _surveyDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var page = _surveyDbContext.headers.Find(id);
            //var page = _surveyDbContext.headers.SingleOrDefault(x => x.Id == id);
            if (page != null)
            {
                _surveyDbContext.Remove(page);
                _surveyDbContext.SaveChanges();
            }
        }

        public HeaderModel? Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var page = _surveyDbContext.headers.Find(id);

            if (page == null)
            {
                return null;
            }
            var headerModel = new HeaderModel()
            {
                Id = page.Id,
                Description = page.Description,
                Style = page.Style,
                SurveyId = page.SurveyId
            };
            return headerModel;
        }

        public void Edit(HeaderModel headerModel)
        {
            var page = _surveyDbContext.headers.Find(headerModel.Id);
            if (page != null)
            {
                //page.Id = headerModel.Id;
                page.Description = headerModel.Description;
                page.Style = headerModel.Style;
                page.SurveyId = headerModel.SurveyId;
                
            }
            _surveyDbContext.SaveChanges();
        }

        public IEnumerable<HeaderModel> GetAll()
        {
            var headers = _surveyDbContext
                .headers.ToList();
            IEnumerable<HeaderModel> headersModel = headers.Select(s => new HeaderModel()
            {
                Id = s.Id,
                Description = s.Description,
                Style = s.Style,
                SurveyId = s.SurveyId
            });
            var result = headersModel;
            return result;
        }

        public IEnumerable<HeaderModel>? GetAllId(int? id)
        {
            var headers = _surveyDbContext
                .headers.ToList();
            IEnumerable<HeaderModel> headersModel = headers.Select(s => new HeaderModel()
            {
                Id = s.Id,
                Description = s.Description,
                Style = s.Style,
                SurveyId = s.SurveyId
            }).Where(s => s.SurveyId == id);
            var result = headersModel;
            return result;
        }
        public HeaderModel? GetId(int? headerId)
        {
            var headers = _surveyDbContext
                .headers.ToList();
            HeaderModel? headerModel = headers.Select(s => new HeaderModel()
            {
                Id = s.Id,
                Description = s.Description,
                Style = s.Style,
                SurveyId = s.SurveyId
            }).Where(s => s.Id == headerId).FirstOrDefault();
            var result = headerModel;
            return result;
        }

        public int? HeaderIdToSurveyId(int? headerId)
        {
            int? surveyId = null;
            var headers = _surveyDbContext
                .headers.ToList();
            HeaderModel? headerModel = headers.Select(s => new HeaderModel()
            {
                Id = s.Id,
                Description = s.Description,
                Style = s.Style,
                SurveyId = s.SurveyId
            }).Where(s => s.Id == headerId).FirstOrDefault();
            if(headerModel != null)
            {
                surveyId = headerModel.SurveyId;
            }
            return surveyId;
        }
    }
}
