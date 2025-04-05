
public class Return
{
    public required Checkout Checkout { get; init; }
    public required DateTime ReturnTime { get; init; }
    public required double ReturnEngineHours { get; init; }

    public void RegisterReturn(DateTime returnTime, double engineHours)
    {
        ReturnTime = returnTime;
        ReturnEngineHours = engineHours;
    }
    public double GetElapsedHours()
    {
        if (!ReturnTime.HasValue)
            throw new InvalidOperationException("Return not registered.");
        return (ReturnTime.Value - CheckoutTime).TotalHours;
    }
    public double GetEngineHoursUsed()
    {
        if (!ReturnEngineHours.HasValue)
            throw new InvalidOperationException("Return not registered.");
        return ReturnEngineHours.Value - CheckoutEngineHours;
    }
}

public interface IRentalPriceCalculator
{
    double CalculatePrice(Rental rental, double baseHourlyRate, double baseEngineHourRate, double skipperFee);
}

public static class RentalPriceCalculatorFactory
{
    public static IRentalPriceCalculator GetCalculator(BoatModel model)
    {
        return model switch
        {
            BoatModel.IseoSuper => new IseoSuperPriceCalculator(),
            BoatModel.Dolceriva => new DolcerivaPriceCalculator(),
            BoatModel.Diable => new DiablePriceCalculator(),
            _ => throw new NotSupportedException($"Model not supported: {model}")
        };
    }
}

public class IseoSuperPriceCalculator : IRentalPriceCalculator
{
    public double CalculatePrice(Rental rental, double baseHourlyRate, double baseEngineHourRate, double skipperFee)
    {
        return (baseHourlyRate * rental.GetElapsedHours()) +
               (baseEngineHourRate * rental.GetEngineHoursUsed());
    }
}
public class DolcerivaPriceCalculator : IRentalPriceCalculator
{
    public double CalculatePrice(Checkout rental, double baseHourlyRate, double baseEngineHourRate, double skipperFee)
    {
        return (baseHourlyRate * rental.GetElapsedHours() * 1.3) +
               (baseEngineHourRate * rental.GetEngineHoursUsed() * 1.5);
    }
}
public class DiablePriceCalculator : IRentalPriceCalculator
{
    public double CalculatePrice(Rental rental, double baseHourlyRate, double baseEngineHourRate, double skipperFee)
    {
        return (baseHourlyRate * rental.GetElapsedHours() * 2.1) +
               (baseEngineHourRate * rental.GetEngineHoursUsed() * 4.0) +
               skipperFee;
    }
}


public record Checkout
{
    public required Vin Vin {get;init; }
    public required CustomerReference CustomerReference { get; init; }
    public required string BookingNumber { get; init; }

    public DateTime CheckoutTime { get; private set; }
    public double CheckoutEngineHours { get; private set; }
   
}

public readonly record struct Vin(string vincode)
{
    public static implicit operator string(Vin vin) => vin.vincode;
}

public enum BoatModel
{
    IseoSuper,
    Dolceriva,
    Diable
}


public record CustomerReference
{

}

public record TheShiznitToPay { }