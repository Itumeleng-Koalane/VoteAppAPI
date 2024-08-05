using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.DBContext;
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<RegisterAuthDBContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<INationalRepository, NationalRepository>();
builder.Services.AddScoped<IProvincialRepository, ProvincialRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegisterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
