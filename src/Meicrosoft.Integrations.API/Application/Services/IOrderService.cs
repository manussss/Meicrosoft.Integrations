namespace Meicrosoft.Integrations.API.Application.Services;

public interface IOrderService
{
    Task CreateAsync(CreateOrderDto dto);
}