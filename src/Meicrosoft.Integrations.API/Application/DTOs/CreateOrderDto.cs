namespace Meicrosoft.Integrations.API.Application.DTOs;

public record CreateOrderDto(List<CreateOrderItemDto> OrderItems);