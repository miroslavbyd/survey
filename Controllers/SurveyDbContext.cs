using ankiety.Domain;
using Microsoft.EntityFrameworkCore;
using ankiety.Models;



namespace ankiety.Controllers
{
    public class SurveyDbContext : DbContext
    {
        //private string _connectionString =
        //    "Server=(localdb)\\DESKTOP-12PS3PP;Database=survey;Trusted_Connection=True;";

        public SurveyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Survey> surveys { get; set; }

        public DbSet<ankiety.Models.SurveyModel>? SurveyModel { get; set; }
        public DbSet<Header> headers { get; set; }
        public DbSet<Container> containers { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<TypeQuestion> typeQuestions { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<AnswerCompleted> answerCompleteds { get; set; }
        public DbSet<SurveyCompleted> surveyCompleteds { get; set; }
        
    }
}
