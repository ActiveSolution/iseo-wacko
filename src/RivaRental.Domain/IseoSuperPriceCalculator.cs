namespace RivaRental.Domain;

public class IseoSuperPriceCalculator : IPriceCalculator
{
    public double Calculate(Return returnInstance, double baseHourlyRate, double baseEngineHourRate, double skipperFee)
    {
        return (baseHourlyRate * returnInstance.GetElapsedHours()) +
               (baseEngineHourRate * returnInstance.GetEngineHoursUsed());
    }
}
