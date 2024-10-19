using VoteAppAPI.Domain_Model;
using VoteAppAPI.Extensions;
using VoteAppAPI.Models;
using VoteAppAPI.Repositories.Implementations;
using VoteAppAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerExtensions()
                .InjectDBContext(builder.Configuration)
                .AddAppConfig(builder.Configuration)
                .AddIdentityHandlersAndStores()
                .ConfigureIdentityOptions()
                .AddIdentityAuth(builder.Configuration);

builder.Services.AddScoped<INationalRepository, NationalRepository>();
builder.Services.AddScoped<IProvincialRepository, ProvincialRepository>();

var app = builder.Build();

app.ConfigureSwaggerExtensions()
    .ConfigureCORS(builder.Configuration)
    .AddIdentityMiddlewares();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGroup("/api")
   .MapIdentityApi<Register>();

app.MapGroup("/api")
   .ConfigureMapPost(builder.Configuration);

app.Run();
