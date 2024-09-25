namespace Dating.Aplication.Interfaces
{
    public interface IAuthService
    {
        Task<long> GetUserId();
    }
}
