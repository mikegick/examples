namespace Shopping.Classes;

/// <summary>
/// Represents a product that can be added to a shopping cart.
/// This class includes properties for the product's quantity and weight.
/// The weight is a decimal value representing the weight of the product in pounds.
/// The quantity is an integer representing how many units of the product are being purchased.
/// The DiscountMultiplier is a decimal value that represents the discount applied to the product, where 1.0 means no discount, 0.5 means a 50% discount, etc.
/// </summary>
public class CartItem
{
    public CartItem(Product product, int quantity, decimal weight = 0)
    {
        this.Product = product;
        this.Quantity = quantity;
        this.Weight = weight;
    }

#region Properties
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Weight { get; set; }
    public decimal DiscountMultiplier { get; set; } = 1.0m;
#endregion

#region Functions
    /// <summary>
    /// Calculates the total price for the cart item based on the product's price, quantity, weight, and any applicable discounts.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public decimal GetItemPrice()
    {
        if (!Enum.IsDefined(this.Product.Category))
            throw new ArgumentException($"Invalid product category: {this.Product.Category}");

        decimal itemPrice;

        switch (this.Product.Category)
        {
            case PRODUCT_CATEGORY.food:
                itemPrice = this.Weight != 0
                  ? this.Product.Price * this.Weight
                  : this.Product.Price * this.Quantity;
                break;
            case PRODUCT_CATEGORY.christmas:
                itemPrice = this.Product.Price * this.Quantity;
                break;
            default:
                itemPrice = this.Product.Price * this.Quantity;
                break;
        }

        return itemPrice * this.DiscountMultiplier;
    }
#endregion
}