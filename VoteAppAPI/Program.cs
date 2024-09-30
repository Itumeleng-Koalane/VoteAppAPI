using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Data.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Extensions;
using VoteAppAPI.Repositories.Implementations;
using VoteAppAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VoteAppDBContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VoteAppConnectionString"));
});

builder.Services.AddDbContext<RegisterAuthDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VoteAppConnectionString"));
});

builder.Services.AddIdentityApiEndpoints<Register>()
    .AddEntityFrameworkStores<RegisterAuthDBContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.User.RequireUniqueEmail = true;
//});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
    //.AddCookie(IdentityConstants.ApplicationScheme)
    //.AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddScoped<INationalRepository, NationalRepository>();
builder.Services.AddScoped<IProvincialRepository, ProvincialRepository>();
//builder.Services.AddScoped<IRegistrationRepository, RegisterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Add CORS in the Middleware pipeline
app.UseCors(options =>
{
    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
});

app.UseAuthentication();

app.MapControllers();

app.MapGroup("/api")
    .MapIdentityApi<Register>();

app.MapPost("/api/signup", async (UserManager<Register> UserManager,[FromBody] UserRegistrationModel userRegistrationModel)
    =>
    {
        Register registerUser = new Register()
        {
            UserName = userRegistrationModel.Email,
            Email = userRegistrationModel.Email,
            IdentificationNumber = userRegistrationModel.IdentificationNumber,
            Name = userRegistrationModel.Name,
            Surname = userRegistrationModel.Surname,
        };

        var result = await UserManager.CreateAsync(registerUser, userRegistrationModel.Password);

        if(result.Succeeded)
        {
            return Results.Ok(result);
        }
        else
        {
            return Results.BadRequest(result);
        }
    });

app.Run();

public class UserRegistrationModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string IdentificationNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
