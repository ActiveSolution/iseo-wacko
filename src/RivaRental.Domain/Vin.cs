namespace RivaRental.Domain;

public readonly record struct Vin(string vincode)
{
    public static implicit operator string(Vin vin) => vin.vincode;
}
