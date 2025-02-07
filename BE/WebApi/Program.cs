using Application;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CleanArchitecture.ApplicationCore.Common;
using Microsoft.AspNetCore.Hosting;
using Application.DynamicDatagridsCQ.Command;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using Application.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//

builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();
builder.Services.AddTransient<IDapperContext, DapperContext>();


builder.Services.AddDbContext<DbContextClass>(option => option.UseSqlServer
(builder.Configuration.GetConnectionString("connect"),
builder => builder.MigrationsAssembly(typeof(DbContextClass).Assembly.FullName)));






builder.Services.AddAuthentication(x =>
{

    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});





builder.Services
    .AddScoped<IApplicationDBContext>(
    provider => provider.GetService<DbContextClass>()
    );
//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(CreateNewDynamicGridCommand).Assembly);
});

builder.Services.AddCors(optins =>
{
    optins.AddPolicy("Alloworigin",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowedToAllowWildcardSubdomains());
});






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentCourse", Version = "V1" });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        c.CustomSchemaIds(x => x.FullName);

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization(); 
app.UseCors("Alloworigin");

app.MapControllers();

app.Run();
 
