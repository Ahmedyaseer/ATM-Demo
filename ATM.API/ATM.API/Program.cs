using ATM.BLL;
using ATM.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AtmContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AtmConectionString")
    ));


builder.Services.AddScoped<IAccountsRepo,AccountsRepo>();   
builder.Services.AddScoped<ITransactionsRepo,TransactionsRepo>();
builder.Services.AddScoped<IAccountManager, AccountsManager>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
