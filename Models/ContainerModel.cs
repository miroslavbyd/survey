namespace ankiety.Models
{
    public class ContainerModel
    {
        public int Id;

        public string? Description;

        public int SurveyId;

        public Task<QuestionModel>? questionModel;

        public ContainerModel()
        {

        }
        public ContainerModel(int id, string description, int surveyId)
        {
            Id = id;
            Description = description;
            SurveyId = surveyId;
        }
    }
}
