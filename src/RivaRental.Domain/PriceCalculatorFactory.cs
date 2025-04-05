namespace RivaRental.Domain;

public static class PriceCalculatorFactory
{
    public static IPriceCalculator GetCalculator(BoatModel model)
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
