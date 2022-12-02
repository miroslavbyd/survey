using ankiety.Models;

namespace ankiety.Services
{
    public interface ITypeQuestionService
    {
        IEnumerable<TypeQuestionModel> GetAll();
        TypeQuestionModel? Edit(int? id);
        void Edit(TypeQuestionModel typeQuestionModel);
        void Add(TypeQuestionModel typeQuestion);
        void Delete(int? id);
    }
}
