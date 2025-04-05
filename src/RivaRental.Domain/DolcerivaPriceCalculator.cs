namespace RivaRental.Domain;

public class DolcerivaPriceCalculator : IPriceCalculator
{
    public double Calculate(Return returnInstance, double baseHourlyRate, double baseEngineHourRate, double skipperFee)
    {
        return (baseHourlyRate * returnInstance.GetElapsedHours() * 1.3) +
               (baseEngineHourRate * returnInstance.GetEngineHoursUsed() * 1.5);
    }
}
