using ankiety.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ankiety.Models
{
    public class SurveyModel
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string? Name { get; set; }
        [DisplayName("Data utworzenia")]
        public DateTime? DateCreation { get; set; }
        [DisplayName("Wazne od")]
        public DateTime? DateFrom { get; set; }
        [DisplayName("Wazne do")]
        public DateTime? DateTo { get; set; }

        //public Task<ContainerModel>? containerModel { get; set; }
        //public Task<HeaderModel>? HeadersModel { get; set; }
        
        public virtual ICollection<Header>? Headers { get; set; }
        public SurveyModel()
        {

        }
        public SurveyModel(int id, string name, DateTime dateCreation, DateTime dateFrom, DateTime dateTo)
        {
            Id = id;
            Name = name;
            DateCreation = dateCreation;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
        //public SurveyModel(int id, string name, DateTime dateCreation, DateTime dateFrom, DateTime dateTo, Task<HeaderModel>? headersModel)
        //{
        //    Id = id;
        //    Name = name;
        //    DateCreation = dateCreation;
        //    DateFrom = dateFrom;
        //    DateTo = dateTo;
        //    HeadersModel = headersModel;
        //}
    }
}
