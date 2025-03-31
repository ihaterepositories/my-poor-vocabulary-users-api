using BLL.Services;
using BLL.Services.Interfaces;
using BLL.Validators;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Core;
using DAL.Repositories.Core.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Database connection
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// services
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

// repositories
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentActivityRepository, StudentActivityRepository>();
builder.Services.AddScoped<IStudentVocabularyAnalyticRepository, StudentVocabularyAnalyticRepository>();
builder.Services.AddScoped<IStudentGameProgressAnalyticRepository, StudentGameProgressAnalyticRepository>();

// infrastructure
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// mapping
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTeacherDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateSchoolDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateStudentProgressDtoValidator>();

// off auto generating error responses
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();