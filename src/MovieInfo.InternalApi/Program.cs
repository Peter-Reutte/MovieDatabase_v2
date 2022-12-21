using System.Net;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Rewrite;
using MovieInfo.InternalApi;
using MovieInfo.InternalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

string dbConnectionString = builder.Configuration.GetConnectionString("MovieInfo");

builder.Services.AddNpgsqlDbContext<MovieInfo.InternalApi.MigrationDbContext>(dbConnectionString);

#region Queries

builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Queries.Movies.MovieDbContext>(dbConnectionString);
builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Queries.Actors.ActorDbContext>(dbConnectionString);

builder.Services.AddScoped<MovieInfo.Infrastructure.Queries.Movies.GetMoviesListQueryHandler>();
builder.Services.AddScoped<MovieInfo.Infrastructure.Queries.Movies.GetMovieQueryHandler>();
builder.Services.AddScoped<MovieInfo.Infrastructure.Queries.Actors.GetActorQueryHandler>();
builder.Services.AddScoped<MovieInfo.Infrastructure.Queries.Actors.GetActorsListQueryHandler>();

#endregion

builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Movies.MovieDbContext>(dbConnectionString);
builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Actors.ActorDbContext>(dbConnectionString);

builder.Services.AddScoped<MovieInfo.Domain.Movies.IMovieRepository, MovieInfo.Infrastructure.Movies.MovieRepository>();
builder.Services.AddScoped<MovieInfo.Domain.Actors.IActorRepository, MovieInfo.Infrastructure.Actors.ActorRepository>();

builder.Services.AddControllers()
     .AddFluentValidation(fv =>
     {
         fv.RegisterValidatorsFromAssemblyContaining<Program>();
         fv.ImplicitlyValidateChildProperties = true;
     })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("../v1/swagger.json", "MovieInfo API v1"));

app.UseAuthorization();

app.MapControllers();
app.MapSwagger("{documentName}/swagger.json");

app.UseRewriter(new RewriteOptions().AddRedirect(@"^$", "swagger", (int)HttpStatusCode.Redirect));

app.RunDatabaseMigrations();
app.Run();

