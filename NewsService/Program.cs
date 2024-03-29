
using Microsoft.EntityFrameworkCore;
using NewsService.Data;
using Microsoft.EntityFrameworkCore.InMemory;
using NewsService.MessageProcessor;
using NewsService.AsyncReciver;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

//builder.Services.AddDbContext<AppDBContext>(
//    option => option.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

builder.Services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMem"));


builder.Services.AddScoped<IRepository, NewsRepository>();
builder.Services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<Subscriper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
