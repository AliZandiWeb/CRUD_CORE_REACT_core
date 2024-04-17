using ASPNetServer.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions=>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET Core React", Version = "v1" });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.Net React Tutorial";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api serving a very simple Post model");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet("/get-all-posts",async ()=>await PostRepository.GetPostsAsync()).WithTags("Post Endpoints");

app.MapGet("/get-post-by-id/{id}", async(int id ) =>
{
    Post postToReturn = await PostRepository.GetByIdAsync(id);
    if(postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Post Endpoints");

app.MapPost("/create-post", async (Post postToCreate) =>
{
    bool createSuccesful = await PostRepository.CreatePostAsync(postToCreate);
    if (createSuccesful )
    {
        return Results.Ok("Create Succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Post Endpoints");

app.MapPut("/update-post", async (Post postToUpdate) =>
{
    bool updateSuccesful = await PostRepository.UpdatePostAsync(postToUpdate);
    if (updateSuccesful)
    {
        return Results.Ok("Update Succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Post Endpoints");

app.MapDelete("/delete-post-by-id", async (int id) =>
{
    bool deleteSuccesful = await PostRepository.DeletePostAsync(id);
    if (deleteSuccesful)
    {
        return Results.Ok("Delete Succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Post Endpoints");

app.Run();