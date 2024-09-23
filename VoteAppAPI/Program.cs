using Microsoft.AspNetCore.Identity;
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

builder.Services.AddIdentityCore<Register>()
    .AddEntityFrameworkStores<RegisterAuthDBContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddScoped<INationalRepository, NationalRepository>();
builder.Services.AddScoped<IProvincialRepository, ProvincialRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegisterRepository>();

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

app.MapIdentityApi<Register>();

app.Run();
