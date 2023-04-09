using Order.Repositories;
using Order.Services;
using Order.Services.FaultPolicies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var logger = new LoggerFactory();
var config = builder.Configuration ;

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddCustomPolicyService("PolicyConfig",config);

var app = builder.Build();

app.MapControllers();

app.Run();
