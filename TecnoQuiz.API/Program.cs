using TecnoQuiz.Domain.Services;
using TecnoQuiz.Infrastructure.Auth;
using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TecnoQuiz.Infrastructure.Persistence.Context;
using TecnoQuiz.API.Configuration;
using TecnoQuiz.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TecnoQuiz.Domain.Repositories;
using TecnoQuiz.Infrastructure.Persistence.Repositories;
using TecnoQuiz.Application.Queries.Users;
using TecnoQuiz.API.Filters;
using FluentValidation.AspNetCore;
using TecnoQuiz.Application.Validators.Commands.Quizzes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(typeof(IDBConfiguration), typeof(MSSQLConfiguration));
builder.Services.AddTransient(typeof(IDB), typeof(MSSQLContext));

builder.Services.AddDbContext<TecnoQuizContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TecnoQuiz")));

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateQuizCommandValidator>());


builder.Services.AddMediatR(typeof(CreateUserCommand));
builder.Services.AddMediatR(typeof(GetUserByEmailQuery));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TecnoQuiz.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

IConfiguration configuration = builder.Configuration;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TecnoQuiz.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication(); // sempre vem primeiro que o UseAuthorization()/
app.UseAuthorization();
app.MapControllers();

app.Run();
