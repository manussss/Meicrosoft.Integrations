var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddMassTransitDependency(builder.Configuration);

var host = builder.Build();
host.Run();
