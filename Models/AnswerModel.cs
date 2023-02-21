namespace ankiety.Models
{
    public class AnswerModel
    {
        public int Id;

        public string? Signature;

        public int? ValueINT;

        public DateTime? ValueDATETIME;

        public string? ValueTEXT;

        public bool? ValueBIT;

        public int QuestionId;

        public AnswerModel()
        {

        }
        public AnswerModel(int id, string? signature, int? valueINT, DateTime? valueDATETIME, string? valueTEXT, bool? valueBIT, int questionId)
        {
            Id = id;
            Signature = signature;
            ValueINT = valueINT;
            ValueDATETIME = valueDATETIME;
            ValueTEXT = valueTEXT;
            ValueBIT = valueBIT;
            QuestionId = questionId;
        }
    }
}
