using Shopping.Classes;

public static class PRODUCTS
{
    public static readonly Product Lights = new("Lights", PRODUCT_CATEGORY.christmas, 5.99m);
    public static readonly Product Apple = new("Apple", PRODUCT_CATEGORY.food, 3.27m);
    public static readonly Product Scallop = new("Scallop", PRODUCT_CATEGORY.food, 18m);
    public static readonly Product Salad = new("Salad", PRODUCT_CATEGORY.food, 6.99m);
    public static readonly Product GroundBeef = new("Ground Beef", PRODUCT_CATEGORY.food, 7.99m);
    public static readonly Product RedWine = new("Red Wine", PRODUCT_CATEGORY.food, 25.99m);
    public static readonly Product Tree = new("Tree", PRODUCT_CATEGORY.christmas, 169m);
    public static readonly Product Ornaments = new("Ornaments", PRODUCT_CATEGORY.christmas, 8m);
}

public static class DISCOUNTS
{
    public static readonly Discount ChristmasEarly = new(DISCOUNT_TYPE.sale, 0.8m, item => item.Product.Category == PRODUCT_CATEGORY.christmas, new DateOnly(2020, 12, 1), new DateOnly(2020, 12, 14));
    public static readonly Discount ChristmasMid = new(DISCOUNT_TYPE.sale, 0.4m, item => item.Product.Category == PRODUCT_CATEGORY.christmas, new DateOnly(2020, 12, 15), new DateOnly(2020, 12, 25));
    public static readonly Discount ChristmasLate = new(DISCOUNT_TYPE.sale, 0.1m, item => item.Product.Category == PRODUCT_CATEGORY.christmas, new DateOnly(2020, 12, 26), new DateOnly(2020, 12, 31));
    public static readonly Discount SeniorFood = new(DISCOUNT_TYPE.sale, 0.9m, item => item.Product.Category == PRODUCT_CATEGORY.food, null, null, new TimeOnly(6, 1), new TimeOnly(8, 59));
}