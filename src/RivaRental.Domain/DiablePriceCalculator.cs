namespace RivaRental.Domain;

public class DiablePriceCalculator : IPriceCalculator
{
    public double Calculate(Return returnInstance, double baseHourlyRate, double baseEngineHourRate, double skipperFee)
    {
        return (baseHourlyRate * returnInstance.GetElapsedHours() * 2.1) +
               (baseEngineHourRate * returnInstance.GetEngineHoursUsed() * 4.0) +
               skipperFee;
    }
}
