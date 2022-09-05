namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("surveyCompleted")]
    public partial class SurveyCompleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? DataAnswer { get; set; }
        public int? Status { get; set; }
        public int surveyId { get; set; }
        public int? UserId { get; set; }
        public int surveyCompletedId { get; set; }
        public SurveyCompleted()
        {

        }
        public SurveyCompleted(int id, DateTime? dataAnswer, int? status, int surveyId, int? userId)
        {
            Id = id;
            DataAnswer = dataAnswer;
            Status = status;
            this.surveyId = surveyId;
            UserId = userId;
        }
    }
}
