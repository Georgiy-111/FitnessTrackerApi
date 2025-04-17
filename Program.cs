using System.Reflection;
using FitnessTrackerApi.Extensions;
using FitnessTrackerApi.Data.Interfaces;
using FitnessTrackerApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services
    .AddCoreServices()
    .AddRepositories()
    .AddDatabase(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    option.IncludeXmlComments(filePath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

