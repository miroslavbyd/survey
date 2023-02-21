namespace ankiety.Models
{
    public class SurveyCompletedModel
    {
        public int Id;

        public DateTime? DateAnswer;

        public int? Status;

        public int surveyId;

        public int? UserId;

        public Task<AnswerCompletedModel>? answerCompletedModel;

        public SurveyCompletedModel()
        {

        }
        public SurveyCompletedModel(int id, DateTime? dateAnswer, int? status, int surveyId, int? userId)
        {
            Id = id;
            DateAnswer = dateAnswer;
            Status = status;
            this.surveyId = surveyId;
            UserId = userId;
        }
    }
}
