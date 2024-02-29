using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuestaoUm.API.Mappers;
using QuestaoUm.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("QuestaoUm");

builder.Services.AddDbContext<QuestaoUmDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(QuestaoUmProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "QuestaoUm.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Carlos Veras",
            Email = "carlos.veras@outlook.com",
            Url = new Uri("https://www.linkedin.com/in/carlosaveras/")
        }
    });

    var xmlFile = "QuestaoUm.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
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
