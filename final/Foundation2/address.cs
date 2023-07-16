public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetStreet()
    {
        return street;
    }

    public string GetCity()
    {
        return city;
    }

    public string GetState()
    {
        return state;
    }

    public string GetCountry()
    {
        return country;
    }

    public bool IsInUSA()
    {
        return string.Equals(country, "USA", StringComparison.OrdinalIgnoreCase);
    }

    public string FormatAddress()
    {
        return $"{street}\n{city}, {state}, {country}";
    }
}
