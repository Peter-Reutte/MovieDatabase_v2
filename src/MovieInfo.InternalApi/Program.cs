using System.Net;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Rewrite;
using MovieInfo.InternalApi;
using MovieInfo.InternalApi.Extensions;
using MovieInfo.Infrastructure.Queries;

var builder = WebApplication.CreateBuilder(args);

string dbConnectionString = builder.Configuration.GetConnectionString("MovieInfo");

builder.Services.AddNpgsqlDbContext<MovieInfo.InternalApi.MigrationDbContext>(dbConnectionString);

#region Queries

builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Queries.MovieDbContext>(dbConnectionString);

builder.Services.AddScoped<GetMoviesListQueryHandler>();
builder.Services.AddScoped<GetMovieQueryHandler>();

#endregion

builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Movies.MovieDbContext>(dbConnectionString);

builder.Services.AddScoped<MovieInfo.Domain.Movies.IMovieRepository, MovieInfo.Infrastructure.Movies.MovieRepository>();

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

