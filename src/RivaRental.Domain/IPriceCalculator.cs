namespace RivaRental.Domain;

public interface IPriceCalculator
{
    double Calculate(Return returnInstance, double baseHourlyRate, double baseEngineHourRate, double skipperFee);
}
