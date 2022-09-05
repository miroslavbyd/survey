namespace ankiety.Models
{
    public class SurveyCompletedModel
    {
        public int Id;

        public DateTime? DataAnswer;

        public int? Status;

        public int surveyId;

        public int? UserId;

        public int surveyCompletedId;

        public Task<AnswerCompletedModel>? answerCompletedModel;

        public SurveyCompletedModel()
        {

        }
        public SurveyCompletedModel(int id, DateTime? dataAnswer, int? status, int surveyId, int? userId)
        {
            Id = id;
            DataAnswer = dataAnswer;
            Status = status;
            this.surveyId = surveyId;
            UserId = userId;
        }
    }
}
