using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ankiety.Models
{
    public class HeaderModel
    {
        [Key]
        public int Id;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Description;

        public int? Style;

        public int SurveyId;
        public HeaderModel()
        {

        }
        public HeaderModel(int id, string description, int style, int surveyId)
        {
            Id = id;
            Description = description;
            Style = style;
            SurveyId = surveyId;
        }
    }
}
