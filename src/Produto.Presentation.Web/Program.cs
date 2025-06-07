using Microsoft.EntityFrameworkCore;
using Produto.Application.AppServices;
using Produto.Application.Interface;
using Produto.Infrastructure.Data;
using Produto.Infrastructure.Data.Repository;
using Produto.Infrastructure.Data.Repository.Interface;
using Produto.Infrastructure.Data.Repository.Interface.Uow;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProdutoContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Host=localhost;Port=5432;Database=SuplyChain;Username=postgres;Password=1234")));




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProdutoAppService, ProdutoAppService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoContext>();
    dbContext.Database.Migrate(); // Aplica migrações pendentes
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
