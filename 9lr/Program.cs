using integtest.Classes;
using integtest.Interfaces;

var builder = WebApplication.CreateBuilder(args);

_9lr.Startup.ConfigureServices(builder.Services);

var app = builder.Build();

_9lr.Startup.Configure(app, app.Environment);

app.Run();



