namespace Dating.Aplication.Interfaces
{
    public interface ICityApi
    {
        Task<string> GetCityName(double latitude, double longitude);
    }
}
