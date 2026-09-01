namespace Shopping.Classes;

/// <summary>
/// Represents a SKU for tracking inventory and providing metadata for CartItems.
/// This class includes properties for the product's name, price, and category. The category is represented by an enum called PRODUCT_CATEGORY.
/// The price is a decimal value representing the cost of the product.
/// The name is a required string property that represents the name of the product.
/// </summary>
public class Product
{
    /// <summary>
    /// Initializes a new instance of the Product class with the specified name, price, and category.
    /// </summary>
    /// <param name="name">The display name of the product.</param>
    /// <param name="category">The category to which the product belongs.</param>
    /// <param name="price">The price per item.</param>
    public Product(string name, PRODUCT_CATEGORY category, decimal price)
    {
        Name = name;
        Price = price;
        Category = category;
    }

#region Properties
    public string Name { get; set; }
    public decimal Price { get; set; }
    public PRODUCT_CATEGORY Category { get; set; }
#endregion
}