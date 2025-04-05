namespace RivaRental.Domain;

public class Return
{
    public required Checkout Checkout { get; set; }
    public required DateTime ReturnTime { get; set; }
    public required double ReturnEngineHours { get; set; }

    public void RegisterReturn(DateTime returnTime, double engineHours)
    {
        ReturnTime = returnTime;
        ReturnEngineHours = engineHours;
    }

    public double GetElapsedHours()
    {
        return (ReturnTime - Checkout.CheckoutTime).TotalHours;
    }

    public double GetEngineHoursUsed()
    {
        return ReturnEngineHours - Checkout.CheckoutEngineHours;
    }
}
