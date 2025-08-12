var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransitDependency(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/order", async (
    [FromServices] IOrderService orderService,
    [FromBody] CreateOrderDto dto
) =>
{
    await orderService.CreateAsync(dto);

    return Results.Created();
});

app.MapGet("/health", () =>
{
    return Results.Ok();
})
.WithOpenApi();

await app.RunAsync();
