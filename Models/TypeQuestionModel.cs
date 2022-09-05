namespace ankiety.Models
{
    public class TypeQuestionModel
    {
        public int Id;

        public string? Type;

        public string? Description;

        public TypeQuestionModel()
        {

        }
        public TypeQuestionModel(int id, string? type, string? description)
        {
            Id = id;
            Type = type;
            Description = description;
        }
    }
}
