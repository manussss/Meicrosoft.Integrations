namespace Meicrosoft.Integrations.API.Application.DTOs;

public record CreateOrderItemDto(EProduct Product, decimal UnitValue, int Quantity);