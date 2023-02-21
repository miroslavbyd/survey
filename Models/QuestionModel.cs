namespace ankiety.Models
{
    public class QuestionModel
    {
        public int Id;

        public string? Description;

        public int ContainerId;

        public int TypeQuestionId;

        public QuestionModel()
        {

        }
        public QuestionModel(int id, string description, int containerId, int typeQuestionId)
        {
            Id = id;
            Description = description;
            ContainerId = containerId;
            TypeQuestionId = typeQuestionId;
        }
    }
}
