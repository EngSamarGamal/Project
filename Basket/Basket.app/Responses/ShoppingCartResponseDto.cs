namespace Basket.Application.Responses
{
    public class ShoppingCartResponseDto
    {
        public string Username { get; set; }
        public List<ShoppingCartItemResponseDto> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
    }
}
