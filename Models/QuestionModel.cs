namespace ankiety.Models
{
    public class QuestionModel
    {
        public int Id;

        public string? Description;

        public int CointainerId;

        public int TypeQuestionId;

        public QuestionModel()
        {

        }
        public QuestionModel(int id, string description, int cointainerId, int typeQuestionId)
        {
            Id = id;
            Description = description;
            CointainerId = cointainerId;
            TypeQuestionId = typeQuestionId;
        }
    }
}
