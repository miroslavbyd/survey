using ankiety.Controllers;
using ankiety.Repositories;
using ankiety.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add context
builder.Services.AddDbContext<SurveyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("surveyManagerDatabase")));
builder.Services.AddTransient<ISurveyRepository, SurveyRepository>();
builder.Services.AddTransient<IAnswerCompletedService, AnswerCompletedService>();
builder.Services.AddTransient<IAnswerService, AnswerService>();
builder.Services.AddTransient<IContainerService, ContainerService>();
builder.Services.AddTransient<IHeaderService, HeaderService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<ISurveyCompletedService, SurveyCompletedService>();
builder.Services.AddTransient<ISurveyService, SurveyService>();
builder.Services.AddTransient<ITypeQuestionService, TypeQuestionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Survey}/{action=Index}/{id?}");

app.Run();
