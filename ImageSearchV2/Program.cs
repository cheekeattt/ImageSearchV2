using ImageSearchV2.Interfaces;
using ImageSearchV2.Query;
using ImageSearchV2.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnsplashSourceProvider, UnsplashSourceProvider>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()    
    .AddProjections()
    //.AddQueryType<QueryBase>() // Add the Query class
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;        
    });    
}
app.MapGraphQL("/graphql");
app.MapControllers();
app.Run();
