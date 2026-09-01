using System.Collections.Generic;

namespace Shopping.Classes;

public class ShoppingCart
{
    public List<CartItem> Products { get; } = new List<CartItem>();

    public string CustomerId { get; set; } = string.Empty;
}
