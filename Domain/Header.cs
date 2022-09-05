namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("header")]
    public partial class Header
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Style { get; set; }
        public int SurveyId { get; set; }
        public Header()
        {

        }
        public Header(int id, string description, int style, int surveyId)
        {
            Id = id;
            Description = description;
            Style = style;
            SurveyId = surveyId;
        }
    }
}
