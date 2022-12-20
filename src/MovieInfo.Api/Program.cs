using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieInfo.Api;
using MovieInfo.Api.Extensions;
using MovieInfo.Api.Middlewares;
using MovieInfo.Infrastructure.Queries;

var builder = WebApplication.CreateBuilder(args);

string dbConnectionString = builder.Configuration.GetConnectionString("MovieInfo");

builder.Services.AddNpgsqlDbContext<MovieInfo.Api.MovieDbContext>(dbConnectionString);

#region Queries

builder.Services.AddNpgsqlDbContext<MovieInfo.Infrastructure.Queries.MovieDbContext>(dbConnectionString);

builder.Services.AddQueryProcessor(options => 
{
    options.Register<GetMoviesListQueryHandler>();
});

#endregion

//builder.Services.AddScoped<CameraRepository>();
//builder.Services.AddCustomHttpClient<TransformInternalApi>(builder.Configuration["TransformInternalApi:Url"]);
//builder.Services.AddScoped<TransformService>();

//builder.Services.AddHttpClient<ArchiveApi>();

//builder.Services.Configure<StorageOptions>(
//    builder.Configuration.GetSection(nameof(StorageOptions)));
//builder.Services.Configure<CameraRecoveryOnTransformOptions>(
//    builder.Configuration.GetSection(nameof(CameraRecoveryOnTransformOptions)));

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

app.UseMiddleware<AspNetCoreHeaderPathBaseMiddleware>();
app.UseMiddleware<DbUpdateConcurrencyExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("../v1/swagger.json", "MovieInfo API v1"));

app.UseAuthorization();

app.MapControllers();
app.MapSwagger("{documentName}/swagger.json");

app.UseRewriter(new RewriteOptions().AddRedirect(@"^$", "swagger", (int)HttpStatusCode.Redirect));

app.RunDatabaseMigrations();
app.Run();

