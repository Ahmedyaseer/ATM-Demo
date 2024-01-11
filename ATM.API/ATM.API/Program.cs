using ATM.BLL;
using ATM.BLL.Manager.AccountsManager;
using ATM.BLL.Manager.TransactionsManager;
using ATM.DAL;
using ATM.DAL.DatabaseContext;
using ATM.DAL.Repos.Accounts;
using ATM.DAL.Repos.Transactions;
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


builder.Services.AddScoped<IAccountRepo,AccountRepo>();   
builder.Services.AddScoped<ITransactionRepo,TransactionRepo>();
builder.Services.AddScoped<IAccountManager, AccountManager>();
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
