using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TradingJournal.Data;
using TradingJournal.Models;
using TradingJournal.Repoistories;
using TradingJournal.Repoistories.Interfaces;
using TradingJournal.Services;
using TradingJournal.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IUserRegistrationRepoistories,UserRegistrationRepoistories>();
builder.Services.AddTransient<IJournalRepoistories, JournalRepoistories>();
builder.Services.AddTransient(typeof(IUserRegistrationService), typeof(UserRegistrationServices));
builder.Services.AddTransient(typeof(IJournalServices), typeof(JournalServices));
builder.Services.AddScoped<IUnitofWork,UnitofWork>();
builder.Services.AddCors((corsOptions) =>
{
    corsOptions.AddPolicy("Mypolicy", (policyoptions) =>
    {
        policyoptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Mypolicy");
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
