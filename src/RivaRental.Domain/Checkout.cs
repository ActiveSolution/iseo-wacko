namespace RivaRental.Domain;

public record Checkout
{
    public required Vin Vin { get; init; }
    public required CustomerReference CustomerReference { get; init; }
    public required string BookingNumber { get; init; }

    public DateTime CheckoutTime { get; private set; }
    public double CheckoutEngineHours { get; private set; }

}
