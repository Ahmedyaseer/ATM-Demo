using ATM.BLL.Manager.AccountsManager;
using ATM.BLL.Manager.TransactionsManager;
using ATM.DAL.DatabaseContext;
using ATM.DAL.Repos.Accounts;
using ATM.DAL.Repos.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Database

builder.Services.AddDbContext<AtmContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AtmConectionString")
    ));

#endregion

#region Asp Identity 

builder.Services
    .AddIdentity<AddOnIdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 3;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<AtmContext>();

#endregion

#region Authentication

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "XYZ";
        options.DefaultChallengeScheme = "XYZ";
    })
    .AddJwtBearer("XYZ", options =>
    {
        string secretKey = builder.Configuration.GetValue<string>("SecretKey")!;
        var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

#endregion



builder.Services.AddScoped<IAccountRepo,AccountRepo>();   
builder.Services.AddScoped<ITransactionRepo,TransactionRepo>();
builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy",
        p => p.RequireClaim(ClaimTypes.Role, "User"));
});


builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowPolice", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowPolice");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
