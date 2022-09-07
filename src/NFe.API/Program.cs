using NFe.Infraestrutura.IoC;
using NFeExternas.Core.Modelo;
using NFeInternas.Core.Modelo;

var politicaCors = "politicaCors";
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables()
          .Build();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(politicaCors,
                          policy =>
                          {
                              policy.WithOrigins("*")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});

builder.Services.Configure<ConfiguracaoMongoDB>(builder.Configuration.GetSection("ConfiguracaoMongoDB"));
builder.Services.Configure<ConfiguracaoServicoExterno>(builder.Configuration.GetSection("ConfiguracaoServicoExterno"));
builder.Services.Configure<ConfiguracaoSqlServer>(builder.Configuration.GetSection("ConnectionStrings"));

// Add services to the container.
IoCRegistraServico.Registrar(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(politicaCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
