namespace Shopping.Classes;

public class Discount
{
    /// <summary>
    /// Creates a new instance of the Discount class with the specified type, multiplier, affected products, and optional date and time constraints. If any of these parameters are not provided, the discount will be considered valid at all times.
    /// </summary>
    /// <param name="type">The type parameter indicates the type of discount (e.g., coupon, sale)</param>
    /// <param name="multiplier">The multiplier parameter specifies the discount percentage (e.g., 0.5 for 50% off)</param>
    /// <param name="affectedProducts">The affectedProducts parameter is a function that determines which cart items are eligible for the discount</param>
    /// <param name="startDate">The startDate parameter defines the start date for the discount validity period</param>
    /// <param name="endDate">The endDate parameter defines the end date for the discount validity period</param>
    /// <param name="startTime">The startTime parameter defines the start time for the discount validity period</param>
    /// <param name="endTime">The endTime parameter defines the end time for the discount validity period</param>
    public Discount(DISCOUNT_TYPE type, decimal multiplier, Func<CartItem, bool> affectedProducts, DateOnly? startDate = null, DateOnly? endDate = null, TimeOnly? startTime = null, TimeOnly? endTime = null)
    {
        this.Type = type;
        this.Multiplier = multiplier;
        this.AffectedProducts = affectedProducts;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.StartTime = startTime;
        this.EndTime = endTime;
    }

#region Properties
    public DISCOUNT_TYPE Type { get; set; } = DISCOUNT_TYPE.unset;
    public decimal Multiplier { get; set; }
    public Func<CartItem, bool> AffectedProducts { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
#endregion

#region Functions
    /// <summary>
    /// Determines if the discount is valid based on the provided checkout date and time. The discount is considered valid if the checkout date and time fall within the specified start and end dates and times of the discount. If any of the date or time constraints are not met, the discount is deemed invalid.
    /// </summary>
    /// <param name="checkoutDate"></param>
    /// <returns>True/False</returns>
    public bool IsValid(DateTime checkoutDate)
    {
        var checkoutDateOnly = DateOnly.FromDateTime(checkoutDate);
        var checkoutTimeOnly = TimeOnly.FromDateTime(checkoutDate);

        if (
            (StartDate.HasValue && checkoutDateOnly < StartDate.Value)
            || (EndDate.HasValue && checkoutDateOnly > EndDate.Value)
            || (StartTime.HasValue && checkoutTimeOnly < StartTime.Value)
            || (EndTime.HasValue && checkoutTimeOnly > EndTime.Value)
        )
        {
            return false;
        }

        return true;
    }
#endregion
}