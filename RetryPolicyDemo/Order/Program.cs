using Order.Repositories;
using Order.Services;
using Order.Services.FaultPolicies;
using Order.Services.FaultPolicies.Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var logger = new LoggerFactory();
var config = builder.Configuration ;

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddSingleton<IFaultPolicy,FaultPolicy>();
builder.Services.AddPolicyService("PolicyConfig",config);

var app = builder.Build();

app.MapControllers();

app.Run();
