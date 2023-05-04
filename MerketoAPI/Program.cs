using MerketoAPI.Contexts;
using MerketoAPI.Helpers.Repositories;
using MerketoAPI.Helpers.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Lägger till Contexts/Repos/Services/Managers för dependency injection

//Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ApiDB")));

//Repos
builder.Services.AddScoped<ProductCategoryRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<ProductTagRepo>();


//Services
builder.Services.AddScoped<TagService>();


var app = builder.Build();
//All addresses may access the API, regardless of domain or portnr.
app.UseCors(x => x.AllowAnyOrigin());

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
