namespace Basket.Core.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new();

        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

        public ShoppingCart() { }

        public ShoppingCart(string username)
        {
            Username = username;
        }
    }
}
