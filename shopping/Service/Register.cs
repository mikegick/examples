using Shopping.Classes;

namespace Shopping.Service;

public class Register
{
    /// <summary>
    /// Sums the total cost of all items in the shopping cart by multiplying the applyable discount price of each product by its quantity.
    /// </summary>
    /// <param name="cart"></param>
    /// <returns></returns>
    public decimal CalculateTotal(ShoppingCart cart)
    {
        decimal total = 0m;

        foreach (var item in cart.Products)
        {
            total += item.GetItemPrice();
        }
        
        return Math.Round(total, 2);
    }

    /// <summary>
    /// Finds and applies all valid discounts to the products in the shopping cart.
    /// </summary>
    /// <param name="cart">The shopping cart containing the products to which discounts will be applied</param>
    /// <param name="checkoutDate">The date and time of the checkout</param>
    public void ApplyDiscounts(ShoppingCart cart, DateTime checkoutDate)
    {
        var discounts = LoadDiscounts(checkoutDate);

        foreach (var discount in discounts)
        {
            cart.Products.Where(p => discount.AffectedProducts(p))
                .ToList()
                .ForEach(p => p.DiscountMultiplier *= discount.Multiplier);
        }
    }

    /// <summary>
    /// Loads the list of valid discounts
    /// </summary>
    /// <param name="checkoutDate">The date and time of the checkout, used to determine which discounts are valid</param>
    /// <returns>A list of valid discounts</returns>
    private List<Discount> LoadDiscounts(DateTime checkoutDate)
    {
        List<Discount> discounts = new List<Discount>
        {
                DISCOUNTS.ChristmasEarly,
                DISCOUNTS.ChristmasMid,
                DISCOUNTS.ChristmasLate,
                DISCOUNTS.SeniorFood
        };
        
        return discounts.Where(d => d.IsValid(checkoutDate)).ToList();
    }
}