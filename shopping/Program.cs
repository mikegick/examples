using Shopping.Classes;
using Shopping.Service;

namespace CodingChallenge.Shopping;

class Program
{
    private readonly Register _register = new Register();

    static void Main(string[] args)
    {
        var program = new Program();
        
        Console.WriteLine("Scenario 1: Christmas Shopping on November 30th");
        program.ChristmasShoppingAtTheGroceryStore(new DateTime(2020, 11, 30, 0, 0, 0));
        Console.WriteLine("-----------------------------");

        Console.WriteLine("Scenario 2: Christmas Shopping on December 30th");
        program.ChristmasShoppingAtTheGroceryStore(new DateTime(2020, 12, 30, 0, 0, 0));
        Console.WriteLine("-----------------------------");

        Console.WriteLine("Scenario 3: Buying Food during normal hours");
        program.BuyingFood(new DateTime(2020, 11, 30, 12, 0, 0));
        Console.WriteLine("-----------------------------");

        Console.WriteLine("Scenario 4: Buying Food during senior discount hours");
        program.BuyingFood(new DateTime(2020, 11, 30, 7, 11, 0));
        Console.WriteLine("-----------------------------");

        Console.WriteLine("End of Scenarios");
    }

    private void ChristmasShoppingAtTheGroceryStore(DateTime checkoutDate)
    {
        var cart = new ShoppingCart();

        cart.Products.Add(new CartItem(PRODUCTS.Lights, 10));
        cart.Products.Add(new CartItem(PRODUCTS.Tree, 1));
        cart.Products.Add(new CartItem(PRODUCTS.Ornaments, 15));

        var total = _register.CalculateTotal(cart);
        Console.WriteLine($"Total before discounts: ${total}");
        
        _register.ApplyDiscounts(cart, checkoutDate);
        var totalAfterChristmas = _register.CalculateTotal(cart);
        Console.WriteLine($"Total after discounts: ${totalAfterChristmas}");
    }

    private void BuyingFood(DateTime checkoutDate)
    {
        var cart = new ShoppingCart();

        cart.Products.Add(new CartItem(PRODUCTS.Apple, -1, 0.79m));
        cart.Products.Add(new CartItem(PRODUCTS.Scallop, -1, 1.5m));
        cart.Products.Add(new CartItem(PRODUCTS.Salad, 1));
        cart.Products.Add(new CartItem(PRODUCTS.GroundBeef, -1, 1.5m));
        cart.Products.Add(new CartItem(PRODUCTS.RedWine, 1));

        var total = _register.CalculateTotal(cart);
        Console.WriteLine($"Total before discounts: ${total}");
        
        _register.ApplyDiscounts(cart, checkoutDate);
        var totalAfterDiscounts = _register.CalculateTotal(cart);
        Console.WriteLine($"Total after discounts: ${totalAfterDiscounts}");
    }
}